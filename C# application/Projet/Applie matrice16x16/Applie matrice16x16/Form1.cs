using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using Button = System.Windows.Forms.Button;

namespace Applie_matrice16x16
{
    public partial class Form1 : Form
    {
        //variable global
        static string couleur_led1, couleur_led2, couleur_led3, couleur_led4, couleur_led5, couleur_led6, couleur_led7, couleur_led8;
        static Button[,] Matrice_Bouton = new Button[16,16];

        public Form1()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * Lors de la génération du form
             * l'on crée les 256 boutons
             * 
             * Jérémy Clémente 11/03/2023
             */

            //Variable
            int i, j;
            Point LePoint=new Point();

            //Début

            //Génération des 256 boutons
            for ( i = 0; i < Matrice_Bouton.GetLength(0); i++)
            {
                for (j = 0; j < Matrice_Bouton.GetLength(1); j++)
                {
                    LePoint.X = 10+((44+2)*j);
                    LePoint.Y = 100+((44+2)*i);
                    Matrice_Bouton[i, j] = GenerateButton(i+";"+j, 44, LePoint);
                    Matrice_Bouton[i, j].Click += button_couleur__Click;
                    Controls.Add(Matrice_Bouton[i, j]);
                }
            }

            //Fin
            // location 10, 160
            //size 44, 44

        }

        static Button GenerateButton(string NumBouton, int Taille, Point Position)
        {
            /*
             * fonction de création de
             * boutons
             * 
             * Jérémy Clémente 11/03/2023
             */

            //Variable
            Button LeButton = new Button();

            //Début
            LeButton.Name = "Button" + NumBouton;
            LeButton.Text = NumBouton;
            LeButton.Enabled = true;
            LeButton.Visible = true;
            LeButton.Width = Taille;
            LeButton.Height = Taille;
            LeButton.Location = Position;
            LeButton.BackColor = Color.LightGreen;
            LeButton.ForeColor = Color.LightGreen;

            return LeButton;
            //Fin
        }

        private void button_couleur__Click(object sender, EventArgs e)
        {
            /*
             * Fonction associé a chaque
             * bouton qui leur fait changé de
             * couleur
             * 
             * Jérémy Clémente 11/03/2023
             */

            //Variable
            Button button;
            int Nbre_Couleur;

            //Début

            try
            {
                Nbre_Couleur = Convert.ToInt16(CB_Nbre.Text); 
            }
            catch 
            {
                Nbre_Couleur = 0;
                
            }

            if (sender is Button)
            {
                button = sender as Button;

                if (button.BackColor == Color.LightGreen && Nbre_Couleur >= 1 )
                { 
                    button.BackColor = Color.Orange;
                    button.ForeColor = Color.Orange;
                }
                else if (button.BackColor == Color.Orange && Nbre_Couleur >= 2 )
                { 
                    button.BackColor = Color.LightBlue;
                    button.ForeColor = Color.LightBlue;
                }
                else if (button.BackColor == Color.LightBlue && Nbre_Couleur >= 3 )
                {
                    button.BackColor = Color.DarkBlue;
                    button.ForeColor = Color.DarkBlue;
                }
                else if (button.BackColor == Color.DarkBlue && Nbre_Couleur >= 4 )
                {
                    button.BackColor = Color.Red;
                    button.ForeColor = Color.Red;
                }
                else if (button.BackColor == Color.Red && Nbre_Couleur >= 5 )
                {
                    button.BackColor = Color.Gold;
                    button.ForeColor = Color.Gold;
                }
                else if (button.BackColor == Color.Gold && Nbre_Couleur >= 6 )
                {
                    button.BackColor = Color.Purple;
                    button.ForeColor = Color.Purple;
                }
                else if (button.BackColor == Color.Purple && Nbre_Couleur >= 7 )
                {
                    button.BackColor = Color.Cyan;
                    button.ForeColor = Color.Cyan;
                }
                else if (button.BackColor == Color.Cyan && Nbre_Couleur >= 8 )
                {
                    button.BackColor = Color.DarkCyan;
                    button.ForeColor = Color.DarkCyan;
                }
                else
                {
                    button.BackColor = Color.LightGreen;
                    button.ForeColor = Color.LightGreen;
                }

                //Fin
            }
        }

        private void Start_Click(object sender, EventArgs e)
        {
            /*
             * Fonction associé au bouton
             * start lors du click crée
             * crée le code dans les textebox
             * 
             * Jérémy Clémente 11/03/2023
             */

            //Variable
            int i, k;

            //initialisation
            couleur_led1 = Couleur_1.Text;
            couleur_led2 = Couleur_2.Text;
            couleur_led3 = Couleur_3.Text;
            couleur_led4 = Couleur_4.Text;
            couleur_led5 = Couleur_5.Text;
            couleur_led6 = Couleur_6.Text;
            couleur_led7 = Couleur_7.Text;
            couleur_led8 = Couleur_8.Text;

            //Début

            //reset des TexteBox avant ecriture
            Texte_code.Clear();
            Image_code.Clear();

            //Code
            Texte_code.Text += "//===========Code===========" + Environment.NewLine;

            Texte_code.Text += Environment.NewLine;

            Texte_code.Text += "//-----------Noir-----------" + Environment.NewLine;

            Texte_code.Text += Environment.NewLine;

            for (k = 0; k < 16; k = k + 1)
            {
                for (i = 0; i < 16; i = i + 1)
                {
                    if (Matrice_Bouton[k, i].BackColor == Color.LightGreen)
                    {
                        Texte_code.Text +=  " leds_16x16[" + k + "][" + i + "] = CRGB::Black;"+ Environment.NewLine;
                    }
                }
            }

            Texte_code.Text += Environment.NewLine;

            Texte_code.Text += "//---------Couleur1---------" + Environment.NewLine;

            Texte_code.Text += Environment.NewLine;

            for (k = 0; k < 16; k = k + 1)
            {
                for (i = 0; i < 16; i = i + 1)
                {
                    if (Matrice_Bouton[k, i].BackColor == Color.Orange)
                    {
                        Texte_code.Text += " leds_16x16[" + k + "][" + i + "] = " + couleur_led1 + Environment.NewLine;
                    }
                }
            }

            Texte_code.Text += Environment.NewLine;

            Texte_code.Text += "//---------Couleur2---------" + Environment.NewLine;

            Texte_code.Text += Environment.NewLine;

            for (k = 0; k < 16; k = k + 1)
            {
                for (i = 0; i < 16; i = i + 1)
                {
                    if (Matrice_Bouton[k, i].BackColor == Color.LightBlue)
                    {
                        Texte_code.Text += " leds_16x16[" + k + "][" + i + "] = " + couleur_led2 + Environment.NewLine;
                    }
                }
            }

            Texte_code.Text += Environment.NewLine;

            Texte_code.Text += "//---------Couleur3---------" + Environment.NewLine;

            Texte_code.Text += Environment.NewLine;

            for (k = 0; k < 16; k = k + 1)
            {
                for (i = 0; i < 16; i = i + 1)
                {
                    if (Matrice_Bouton[k, i].BackColor == Color.DarkBlue)
                    {
                        Texte_code.Text += " leds_16x16[" + k + "][" + i + "] = " + couleur_led3 + Environment.NewLine;
                    }
                }
            }

            Texte_code.Text += Environment.NewLine;

            Texte_code.Text += "//---------Couleur4---------" + Environment.NewLine;

            Texte_code.Text += Environment.NewLine;

            for (k = 0; k < 16; k = k + 1)
            {
                for (i = 0; i < 16; i = i + 1)
                {
                    if (Matrice_Bouton[k, i].BackColor == Color.Red)
                    {
                        Texte_code.Text += " leds_16x16[" + k + "][" + i + "] = " + couleur_led4 + Environment.NewLine;
                    }
                }
            }

            Texte_code.Text += Environment.NewLine;

            Texte_code.Text += "//---------Couleur5---------" + Environment.NewLine;

            Texte_code.Text += Environment.NewLine;

            for (k = 0; k < 16; k = k + 1)
            {
                for (i = 0; i < 16; i = i + 1)
                {
                    if (Matrice_Bouton[k, i].BackColor == Color.Gold)
                    {
                        Texte_code.Text += " leds_16x16[" + k + "][" + i + "] = " + couleur_led5 + Environment.NewLine;
                    }
                }
            }

            Texte_code.Text += Environment.NewLine;

            Texte_code.Text += "//---------Couleur6---------" + Environment.NewLine;

            Texte_code.Text += Environment.NewLine;

            for (k = 0; k < 16; k = k + 1)
            {
                for (i = 0; i < 16; i = i + 1)
                {
                    if (Matrice_Bouton[k, i].BackColor == Color.Purple)
                    {
                        Texte_code.Text += " leds_16x16[" + k + "][" + i + "] = " + couleur_led6 + Environment.NewLine;
                    }
                }
            }

            Texte_code.Text += Environment.NewLine;

            Texte_code.Text += "//---------Couleur7---------" + Environment.NewLine;

            Texte_code.Text += Environment.NewLine;

            for (k = 0; k < 16; k = k + 1)
            {
                for (i = 0; i < 16; i = i + 1)
                {
                    if (Matrice_Bouton[k, i].BackColor == Color.Cyan)
                    {
                        Texte_code.Text += " leds_16x16[" + k + "][" + i + "] = " + couleur_led7 + Environment.NewLine;
                    }
                }
            }

            Texte_code.Text += Environment.NewLine;

            Texte_code.Text += "//---------Couleur8---------" + Environment.NewLine;

            Texte_code.Text += Environment.NewLine;

            for (k = 0; k < 16; k = k + 1)
            {
                for (i = 0; i < 16; i = i + 1)
                {
                    if (Matrice_Bouton[k, i].BackColor == Color.DarkCyan)
                    {
                        Texte_code.Text += " leds_16x16[" + k + "][" + i + "] = " + couleur_led8 + Environment.NewLine;
                    }
                }
            }

            Texte_code.Text += Environment.NewLine;

            Texte_code.Text += "//==========================" + Environment.NewLine;

            //Image

            Image_code.Text += "===========Image===========" + Environment.NewLine;

            for (k = 0; k < 16; k = k + 1)
            {
                for (i = 0; i < 16; i = i + 1)
                {

                    //affichage en fonction de la couleurs
                    if (Matrice_Bouton[k, i].BackColor == Color.LightGreen)
                    {
                        Image_code.Text += "◻";
                    }
                    else if (Matrice_Bouton[k, i].BackColor == Color.Orange)
                    {
                        Image_code.Text += "■";
                    }
                    else if (Matrice_Bouton[k, i].BackColor == Color.LightBlue)
                    {
                        Image_code.Text += "⬟";
                    }
                    else if (Matrice_Bouton[k, i].BackColor == Color.DarkBlue)
                    {
                        Image_code.Text += "▥";
                    }
                    else if (Matrice_Bouton[k, i].BackColor == Color.Red)
                    {
                        Image_code.Text += "▤";
                    }
                    else if (Matrice_Bouton[k, i].BackColor == Color.Gold)
                    {
                        Image_code.Text += "▨";
                    }
                    else if (Matrice_Bouton[k, i].BackColor == Color.Purple)
                    {
                        Image_code.Text += "▣";
                    }
                    else if (Matrice_Bouton[k, i].BackColor == Color.Cyan)
                    {
                        Image_code.Text += "▩";
                    }
                    else if (Matrice_Bouton[k, i].BackColor == Color.DarkCyan)
                    {
                        Image_code.Text += "▧";
                    }

                }
                Image_code.Text += "" + Environment.NewLine;
            }

            Image_code.Text += "===========================" + Environment.NewLine;

            //Fin
        }

        private void Bouton_reset_Click(object sender, EventArgs e)
        {
            /*
             * Fonction qui redonne la
             * couleur d'origine au 256
             * Boutons et reset les textes
             * 
             * Jérémy Clémente
             */

            //Variable
            Control[] controls = this.Controls.OfType<Button>().ToArray();

            //Début

            //reset chaque bouton
            foreach (Control control in controls)
            {
                Button button = control as Button;
                if (control is Button && button.Name != "Bouton_reset" && button.Name != "Start" && button.Name != "BP_import" && button.Name != "BP_sauvegarde")
                {
                    button.BackColor = Color.LightGreen;
                    button.ForeColor = Color.LightGreen; 
                }
            }

            Couleur_1.Text = "";
            Couleur_2.Text = "";
            Couleur_3.Text = "";
            Couleur_4.Text = "";
            Couleur_5.Text = "";
            Couleur_6.Text = "";
            Couleur_7.Text = "";
            Couleur_8.Text = "";


            //Fin
        }

        private void BP_sauvegarde_Click(object sender, EventArgs e)
        {
            /*
             * Cette fonction sert a sauvegarder
             * le fichier pour peut être s'en servir plus tard
             * 
             * Jérémy Clémente 19/03/2023
             */

            //Variable
            StreamWriter fichier_svg;
            string Nom;
            int i, j;

            //Début
            couleur_led1 = Couleur_1.Text;
            couleur_led2 = Couleur_2.Text;
            couleur_led3 = Couleur_3.Text;
            couleur_led4 = Couleur_4.Text;
            couleur_led5 = Couleur_5.Text;
            couleur_led6 = Couleur_6.Text;
            couleur_led7 = Couleur_7.Text;
            couleur_led8 = Couleur_8.Text;

            Nom = "defaut";
            Nom = T_Nom_svg.Text;

            using (fichier_svg = new StreamWriter(Nom + ".Matrice_16x16"))
            {
                fichier_svg.WriteLine(couleur_led1);
                fichier_svg.WriteLine(couleur_led2);
                fichier_svg.WriteLine(couleur_led3);
                fichier_svg.WriteLine(couleur_led4);
                fichier_svg.WriteLine(couleur_led5);
                fichier_svg.WriteLine(couleur_led6);
                fichier_svg.WriteLine(couleur_led7);
                fichier_svg.WriteLine(couleur_led8);
                for (i = 0; i < 16; i++)
                {
                    for (j = 0; j < 16; j++)
                    {
                        fichier_svg.WriteLine(Matrice_Bouton[i,j].BackColor);
                    }
                }
            }

            //Fin
        }

        private void BP_import_Click(object sender, EventArgs e)
        {
            /*
             * Cette fonction sert a sauvegarder
             * le fichier pour peut être s'en servir plus tard
             * 
             * Jérémy Clémente 19/03/2023
             */

            //Variable
            StreamReader fichier_import;
            string Nom, couleur;
            int i, j;

            //Début

            Nom = "sans_nom";

            try
            {
                Nom = T_import.Text;

                using (fichier_import = new StreamReader(Nom + ".Matrice_16x16", true))
                {
                    Couleur_1.Text = fichier_import.ReadLine();
                    Couleur_2.Text = fichier_import.ReadLine();
                    Couleur_3.Text = fichier_import.ReadLine();
                    Couleur_4.Text = fichier_import.ReadLine();
                    Couleur_5.Text = fichier_import.ReadLine();
                    Couleur_6.Text = fichier_import.ReadLine();
                    Couleur_7.Text = fichier_import.ReadLine();
                    Couleur_8.Text = fichier_import.ReadLine();

                    for (i = 0; i < 16; i++)
                    {
                        for (j = 0; j < 16; j++)
                        {
                            couleur = fichier_import.ReadLine();
                            switch (couleur)
                            {
                                case "Color [LightGreen]":
                                    Matrice_Bouton[i, j].BackColor = Color.LightGreen;
                                    Matrice_Bouton[i, j].ForeColor = Color.LightGreen;
                                    break;
                                case "Color [Orange]":
                                    Matrice_Bouton[i, j].BackColor = Color.Orange;
                                    Matrice_Bouton[i, j].ForeColor = Color.Orange;
                                    break;
                                case "Color [LightBlue]":
                                    Matrice_Bouton[i, j].BackColor = Color.LightBlue;
                                    Matrice_Bouton[i, j].ForeColor = Color.LightBlue;
                                    break;
                                case "Color [DarkBlue]":
                                    Matrice_Bouton[i, j].BackColor = Color.DarkBlue;
                                    Matrice_Bouton[i, j].ForeColor = Color.DarkBlue;
                                    break;
                                case "Color [Red]":
                                    Matrice_Bouton[i, j].BackColor = Color.Red;
                                    Matrice_Bouton[i, j].ForeColor = Color.Red;
                                    break;
                                case "Color [Gold]":
                                    Matrice_Bouton[i, j].BackColor = Color.Gold;
                                    Matrice_Bouton[i, j].ForeColor = Color.Gold;
                                    break;
                                case "Color [Purple]":
                                    Matrice_Bouton[i, j].BackColor = Color.Purple;
                                    Matrice_Bouton[i, j].ForeColor = Color.Purple;
                                    break;
                                case "Color [Cyan]":
                                    Matrice_Bouton[i, j].BackColor = Color.Cyan;
                                    Matrice_Bouton[i, j].ForeColor = Color.Cyan;
                                    break;
                                case "Color [DarkCyan]":
                                    Matrice_Bouton[i, j].BackColor = Color.DarkCyan;
                                    Matrice_Bouton[i, j].ForeColor = Color.DarkCyan;
                                    break;

                            }
                        }
                    }
                }
            }
            catch
            {

                
            }

            //Fin
        }

    }
}


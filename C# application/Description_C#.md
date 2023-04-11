## C# Application

### Introduction

Cette __**partie**__ est destinée à __l'application__ **C#** qui sert a crée du code facilement pour la carte arduino **C++**.
Cette partie va detaillé et expliqué les différentes partie du code.

#### Application utilisé :

* [Visual Studio](https://visualstudio.microsoft.com/fr/)
* [Application Window Form](https://learn.microsoft.com/fr-fr/dotnet/desktop/winforms/overview/?view=netdesktop-7.0)

Pour crée l'application on se sert de visual studio et plus précisément, on crée un projet Window Form.

### Explication :

Dans les explications il y aura deux parties une partie sera dédié au Form et une autre au code du Form.

#### Partie Form :

Photo de l'application :
![Photo](https://github.com/R5ELS/Arduino_application_Matrice_led_16x16/blob/main/Datasheet/application_photo.PNG)

On peut voir que l'application est composée de plusieurs partie :
* Une partie principale composé de 256 Boutons Vert en bas a gauche
* Une partie suppérieur pour le choix de couleurs
* Une partie Composé de deux TextBox en noir une sert a affiché le code l'autre donne une image
* Une partie pour sauvegarder une image a crée et une autre pour en importé une
* Une partie de deux bouton l'un pour lancer la génération du code et l'autre pour la reinitialisation
* Une dernier textbox qui permet de choisir le nombre de couleur


#### Comment Utilisé l'application 

Pour utilisé l'application Voici les différente information a savoir :

Les boutons vert a gauche en bas des couleurs sont les pixels de la matrice 1 bouton représente 1 led de la matrice pour faire changé un pixel de couleur il faut deja choisir le nombre de couleurs de __1__ à __8__.

Une fois les couleurs choisis on peut changer les couleurs des boutons. Les cases couleurs de __1__ à __8__ serve au code c'est ici que l'on dit si les case doivent etre rouge vert ou autre en respectant la syntaxe il y a trois possibilité pour afficher une **couleur** :

+ Utilisé les couleurs par defaut avec la syntaxe **CRGB::Red;** (exemple pour la couleur rouge).
+ On peut aussi dire la couleur précise avec la syntaxe **CRGB(R, G, B);** (**R,G,B** est une associé a rouge vert bleu et chaque couleur est compris de **0** à **255**).
+ Il reste aussi la possibilité d'utilise un code en Hexadécimal comme par exemple **0xFF0000;** (ici il ni a pas de CRGB juste la syntax Hexadecimal)

Apres avoir choisis les couleurs et les cases a colorer on peut generer le code via le bouton **start** le code sera dans la grande textebox a droite et la petite sera une image du resultat sans les couleurs.

En dessous du bouton **start** il y a un bouton **Reset** qui remet tous les boutons de la matrice en vert et supprime le texte dans les textbox de couleurs.

Il y as aussi une fonction de sauvegarde il faut mettre un nom dans la textbox puis appuyer sur le bouton de sauvegarde (dans le cas ou il n'y pas de nom le nom sera __"sans_nom"__). IL y a aussi donc une fonction d'importation pour cela il faut juste mettre le nom du fichier de sauvegarde et les textBox et les boutons prendront leur couleurs et leurs texte.

En cas de tentative d'ouverture d'un **fichier inexistant** il ne se passera rien, Les fichiers on pour extension **.Matrice_16x16**.
 
#### Code

Une fois que le **form** a été montrer et explique on va maintenant parler du **code** en lui même.


##### Using

Dans un premier on as les différent using qui sont utilisé dans le code.

~~~C#

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

~~~

Après avoir déclarer les differents différent using nous avons le main space et le form en lui meme.

##### Variable Global

Dans le __début__ du programme dans le namespace et le form on déclare les variables globales qui seront utilisés dans tous 
le **programme**.

~~~C#

        //variable global
        static string couleur_led1, couleur_led2, couleur_led3, couleur_led4, couleur_led5, couleur_led6, couleur_led7, couleur_led8;
        static Button[,] Matrice_Bouton = new Button[16,16];

~~~

Donc il y a plusieurs variables globales :
L'une gère les différentes couleurs 8 variables pour les 8 couleurs il serait possible d'utilisé un tableau monodimension avec 8 case a la place des 8 variables.
L'autre est la variables des 256 boutons (un tableau 2D), les 256 boutons ne sont placer a la main mais crée via le code, placé les boutons a la main serai long et fastidieux.

##### Form 

Après les variables globale on as le form ou l'on initialisation les composants.

~~~C#

        public Form1()
        {

            InitializeComponent();
            
        }
        
~~~        

##### Génération du Form

L'une des première fonction importante est le Form Load c'est fonction va créer les 256 boutons et donner les caractéristique a chaque bouton.

~~~C#

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

~~~

**Les Variables** de la fonction i,j servent au boucles quand a la variable LePoint sert a déterminer les différente coordonnée des boutons.

Les deux boucles imbriqué sert a choisir les boutons dans l'ordre a générer donc on commence par dire la position du bouton chaque bouton seront legerement decaller les un des autres sur l'axe X grace a la variable j quand a la variable i elle sert a choisir la ligne.

Ensuite On utilise une fonction pour générer plus précisement les boutons (fonction développez juste après) puis on assigne la fonction de clique au bouton (la fonction sera aussi détailler plus tard) 
Enfin une fois le bouton générer avec ces différente information on le place.
On répète l'opération 256 fois pour les 256 boutons.

###### Fonction Génération Bouton

La fonction du Form Load appelle la fonction de génération de bouton pour les crée fonction que voici 

~~~C#

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

~~~

Cette fonction recoit plusieurs paramètre : 
* Le Nom du bouton
* ca taille ici un carré
* et sa position

Cette fonction quand a elle renvoie les informations du bouton via le return.

Dans cette fonction on assigne le Nom du boutton avec une base "Button" + les coordonnée du bouton qui va de 0;0 jusqu'à 15;15.

On lui donne sont texte qui est aussi sa postion dans le tableau de bouton.

Ensuite on lui dit qu'il existe et que il doit être visible.

Ca taille est gérée grace a valeur envoyer on assigne la même pour sa longueur et largeur donc se sera forcement un carré.

Ca position est assigné via la variable position qui est aussi envoyer dans la fonction.

On lui donne ca couleur de base Vert clair et enfin on retourne les informations du bouton.

##### Fonction Couleur Boutons

Cette fonction est utilisé quand un bouton parmis les 256 clique dessus et lui dit qu'elle couleur prendre.

~~~C#

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

~~~
Cette fonction est associé a tous les boutons de la matrice.

**Variable :**

Cette fonction Utilise deux variables une variable bouton et une autre un entier qui sert combien de couleur on utilise.

**Fonctionnement :**

La première partie de la fonction essaye de convertir ce qui as dans la TextBox du nombre de couleur en nombre si elle ne peut pas le convertir en nombre il prend 0 comme 
valeur par defaut. Cela évite que l'on rentre **une lettre** et que **lors de l'utilisation** de la fonction l'application crash.

On vérifie que c'est un bouton qui est appuyer. Après l'on rentre dans un grand nombre de else if qui va déterminer la couleur suivante a prendre. Pour passer a la couleur suivante on prend en compte la couleur actuel du bouton. Une autre condition lors du changement de couleur est le nombre contenue dans la textbox du nombre de couleur.

##### Fonction bouton reset 

~~~C#

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

~~~

Cette fonction a pour but de réinitialisée l'état de tous les boutons de la matrice ainsi que les textbox de couleur.

**Variable :**

Cette partie du code utilise une variable qui va passer en revue tous les boutons.

**Fonctionnement :**

Dans un premier temps la fonction va passer tous les boutons en revue et leur redonner leur couleurs d'origine (Vert clair). Des boutons ne sont pas affectés par cette variable se sont les boutons Rest, Start, Sauvegarde et Import.

Dans un second temps cette fonction va reset les textBox de couleur supprimant leur contenus.

##### Fonction Sauvegarde

~~~C#

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

~~~

Cette fonction a pour but de créer un fichier contenant les informations de l'image l'endroit de l'exécutable.

**Variable :**

Les Variables importantes de la fonction sont la variable fichier_svg qui sert a écrire et créer le fichier, Nom qui est le nom du fichier et les différente variable de couleurs qui prennent les couleurs des textBox. Il y a aussi les variable i et j qui sert au boucle.

**Fonctionnement :** 

Cette fonction va créer un fichier .Matrice_16x16 avec les informations de l'image. Le fichier sera créer a l'emplacement de l'application. Dans un premier temps le programme va prendre le nom dans la textBox de sauvegarder pour nommer le fichier. Si la textbox est vide le nom par defaut est "defaut". Après avoir créer le fichier le programme va écrire dedans. Les huit premières lignes servent pour les textes dans les huit TextBox des couleurs. La suite du fichier est pour les 256 boutons ou chaque lignes est la couleurs d'un bouton.

##### Fonction Importation

~~~C#

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

~~~

La fonction d'importation est la reciproque de la fonction sauvegarde elle permet grace a un fichier .Matrice_16x16 de ravoir les boutons colorié ainsie que les couleurs dans les TextBox.

**Variable :**

Cette fonctions utilise plusieurs variables. fichier_import est la variable qui permet de lire le fichier. Nom est le nom du fichier qui est pris dans la textbox par defaut c'est : "sans_nom". Couleur est une variable qui sert à savoir quelle est la bonne couleur du bouton de la ligne du fichier. i et j sont les variable lié au boucle. On utilise aussi les variables couleurs des huit textBox.

**Fonctionnement :**

La fonction a la fonctionnement inverse de la fonction sauvegarde. dans un premier temps elle va prendre le nom dans la textbox et essayer d'ouvrir le fichier. Ensuite elle va recopier les huit première ligne dans les huits textbox des couleurs correspondante. Après elle va passer en revue les 256 boutons en changeant leurs couleurs grace a chaque ligne etant la couleur d'un bouton. On prend ce qui est écrit dans un ligne et on passe dans le switch qui determine la couleur. Dans le cas ou la fonction n'arrive pas a ouvrir le fichier elle ne fait rien.

##### Fonction Bouton Start

~~~C#

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



~~~

Cette Fonction est celle associé au bouton de start. Elle va créer le code C++ en prenant les informations dans les textBox de couleur et les couleurs des boutons.

**Variables :**

Cette fonction utilisent peu de variable. Il y a les huits variable lié au couleurs des textBox. Les deux autres variables i et k servent au boucle.

**Fonctionemment :** 

La fonction va d'abord associé les variables de couleurs au textBox. puis elle clear les textBoxs. Ensuite elle commencent a écrire les couleurs en parcourant le tableau d'abord avec le noir (couleur par défaut). Après elle recommence avec les huit couleurs en les séparant le tous est affichée dans la même textBox. Enfin on repasse une dernière fois pour affiché un image dans une autre TextBox.
On peut noter que il est possible d'optimisé la fonction en ne fesais que 1 passage au lieu de 9 grace a un tableau trié pour obtenir le même résultat.

Ceci est la fin de la parti C# pour plus d'information allé voir le pdf.










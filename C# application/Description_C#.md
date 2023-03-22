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

#### Code

Une fois que le **form** a été montrer et explique on va maintenant parler du **code** en lui meme


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










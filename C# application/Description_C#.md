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
L'autre est la variables des 256 boutons, les 256 boutons ne sont placer a la main mais crée via le code, placé les boutons a la main serai long et fastidieux.









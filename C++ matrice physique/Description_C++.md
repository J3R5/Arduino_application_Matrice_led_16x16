## C++ Code Arduino

### Introduction

Cette partie est consacrée au code dans la **carte Arduino** avec un exemple de dessins possible crée via l'application __C#__.
Le code __C++__ utilise la bibliothèque [FastLed](https://fastled.io/).

##### Compostants :

* [Arduino Nano](https://docs.arduino.cc/hardware/nano)
* [Matrice Led 16x16](https://www.btf-lighting.com/products/ws2812b-panel-screen-8-8-16-16-8-32-pixel-256-pixels-digital-flexible-led-programmed-individually-addressable-full-color-dc5v?_pos=1&_sid=3fc4f91ac&_ss=r&variant=20203594547300)

#### Code :

Dans un premier temps il faut installer la bibliothèque [FastLed](https://fastled.io/) (si vous ne savez pas installé une bibliothèque voici un [tutoriel](https://fablabutc.fr/wp-content/uploads/2021/01/Tutoriel_Installer-une-bibliotheque-pour-Arduino.pdf)).

Il faut savoir que la matrice de leds est est considérée comme un ruban de __256 leds__ et non comme une vraie matrice 
donc sois on code directement comme un ruban les 256 sois on code comme une matrice **2D** puis on crée une fonction 
de conversion **2D** en **1D**. Une variable en **2D** permet de crée des animation de mouvement facilement (exemple : deplacement
gauche, droite)

#### Initialisation :

Une fois la bibliothèque installer on doit l'importer (via un #include) dans le code :
~~~C++

//----------bibliothèque----------//
#include <FastLED.h>
//-------------------------------//

~~~


après on Définie Le nombre de led du ruban ou de la matrice et le pin qui sert pour la data

~~~C++

//------------Define------------//
#define NUM_LEDS 256 //Nombre de Led
#define DATA_PIN 4 //Pin de la data
//-----------------------------//

~~~

Ensuite on déclare à Les variables :

~~~C++

//-----------Variable-----------//
CRGB leds[NUM_LEDS]; //tableau Led réelle
CRGB leds_16x16[16][16]; //tableau led application
int i,k,t; //variable boucle
int carreaux; //variable position led matrice réel
//-----------------------------//

~~~

#### Void Setup :

Après on passe a L'initialisation la boucle setup ou l'on initialise la matrice puis
on regle la luminosité

~~~C++

void setup() {
  
  //-----------Initialisation-----------//
  FastLED.addLeds<NEOPIXEL, DATA_PIN>(leds, NUM_LEDS); //initialisation Bandeau et pin
  FastLED.setBrightness(12); //reglage luminosité global
  //-----------------------------------//

}

~~~

#### Void loop :

après L'initialisation on as la boucle loop qui contient une fonction de ce que doit afficher
la matrice.

~~~C++

void loop() {
  
  papillon();

}

~~~

On utilise une fonction au lieu de mettre directement le code car il y a beaucoup de ligne de code et si on souhaite montré plusieurs image successivement il est plus simple d'utilisé des fonctions.

#### Fonction :

Il a deux fonctions dans se programme l'une est la fonction de conversion 2D en 1D et une autre est un qui est l'affichage du papillons

Fonction Convertion 2D --> 1D :


~~~C++
void Matrice_16x16()
{
  /*
  * Fonction convertion tableau 2D
  * en 1D représentation réel
  * Ruban du tableau
  *
  * Jérémy Clémente 11/03/2022
  */

  //variable
  carreaux = 0;

  //Début
  for (k = 0; k<16; k = k + 1) 
  {
    if (k % 2 == 0) {
      for (i=15; i>=0; i = i - 1) 
      {
        leds[carreaux] = leds_16x16[k][i];
        carreaux = carreaux + 1 ;
      }
    }
    else 
    {
      for (i=0; i<16; i = i + 1) 
      {
        leds[carreaux] = leds_16x16[k][i];
        carreaux = carreaux + 1 ;
      }
    }
  }
  //Fin
}

~~~

La matrice de led est un ruban mais aussi un ruban en Zig Zag comme un serpent
exemple :
[Photo](https://github.com/R5ELS/Arduino_application_Matrice_led_16x16/blob/main/Datasheet/photo_tableau.PNG)




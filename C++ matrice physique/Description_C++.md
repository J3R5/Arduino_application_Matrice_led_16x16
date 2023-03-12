## C++ Code Arduino

### Introduction

Cette partie est consacrée au code dans la **carte Arduino** avec un exemple de dessins possible crée via l'application __C#__.
Le code __C++__ utilise la bibliothèque [FastLed](https://fastled.io/).

##### Compostants :

* [Arduino Nano](https://docs.arduino.cc/hardware/nano)
* [Matrice Led 16x16](https://www.btf-lighting.com/products/ws2812b-panel-screen-8-8-16-16-8-32-pixel-256-pixels-digital-flexible-led-programmed-individually-addressable-full-color-dc5v?_pos=1&_sid=3fc4f91ac&_ss=r&variant=20203594547300)

#### Code :

Dans un premier temps il faut installer la bibliothèque [FastLed](https://fastled.io/) (si vous ne savez pas installé une bibliothèque voici un [tutoriel](https://fablabutc.fr/wp-content/uploads/2021/01/Tutoriel_Installer-une-bibliotheque-pour-Arduino.pdf)).

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









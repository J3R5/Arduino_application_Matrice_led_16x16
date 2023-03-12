## Matrice Led 16x16 RGB code arduino C++ et code application C#

### Introduction

Ce projet a pour but de coder une matrice de Led RGB 16x16 via une carte arduino. 
La matrice de led RGB utilisé est basé sur les led RGB adressable [WS2812B](https://pdf1.alldatasheet.com/datasheet-pdf/view/1179113/WORLDSEMI/WS2812B.html)

Ce projet Comportera deux grandes partie différente :

* Une partie **C++** code controle de la matrice via __carte arduino__
* Une partie **C#** code d'une __application__ pour aider a coder la matrice

#### Partie C++ et électronique

Les composants utilisé pour se projet est une matrice led
de chez BTF-Lighting la WS2812E LED Panel ainsi que une carte
[Arduino Nano](https://docs.arduino.cc/static/11f0c2880b9a2f2add7890e0de0ff192/A000005-full-pinout.pdf).
il ni as pas d'autre composant hormis des cable qui relie la carte 
eletronique a la matrice.

Le **code** a été réalisée via [l'IDE Arduino](https://www.arduino.cc/en/software)
et on utilise aussi la bibliothèque [FastLed](https://fastled.io/).

[Partie Complète](https://github.com/R5ELS/Arduino_application_Matrice_led_16x16/blob/main/C++%20matrice%20physique/Description_C++.md)

#### Partie C# Application

Cette partie est l'application qui permet de générer le code C++ pour la matrice de led
le projet a été coder en [Window Form](https://learn.microsoft.com/fr-fr/dotnet/desktop/winforms/overview/?view=netdesktop-7.0) via le logiciel [Visual Studio](https://visualstudio.microsoft.com/fr/).

[Partie Complète]()

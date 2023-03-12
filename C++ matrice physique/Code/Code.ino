
//----------bibliothèque----------//
#include <FastLED.h>
//-------------------------------//

//------------Define------------//
#define NUM_LEDS 256 //Nombre de Led
#define DATA_PIN 4 //Pin de la date
//-----------------------------//

//-----------Variable-----------//
CRGB leds[NUM_LEDS]; //tableau Led réelle
CRGB leds_16x16[16][16]; //tableau led application
int i,k,t; //variable boucle
int carreaux; //variable position led matrice réel
//-----------------------------//

void setup() {
  
  //-----------Initialisation-----------//
  FastLED.addLeds<NEOPIXEL, DATA_PIN>(leds, NUM_LEDS); //initialisation tableau et pin
  FastLED.setBrightness(12); //reglage luminosité global
  //-----------------------------------//

}

void loop() {
  
  papillon();

}

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

void papillon()
{
  /*
   *  Code générer via l'application
   *  dans ce cas c'est le dessin d'un
   *  papillon
   *
   *  Jérémy Clémente 11/03/2023
   */

  //Début

 //------------Noir------------// 
 leds_16x16[0][0] = CRGB::Black;
 leds_16x16[0][1] = CRGB::Black;
 leds_16x16[0][2] = CRGB::Black;
 leds_16x16[0][3] = CRGB::Black;
 leds_16x16[0][4] = CRGB::Black;
 leds_16x16[0][5] = CRGB::Black;
 leds_16x16[0][6] = CRGB::Black;
 leds_16x16[0][7] = CRGB::Black;
 leds_16x16[0][8] = CRGB::Black;
 leds_16x16[0][9] = CRGB::Black;
 leds_16x16[0][10] = CRGB::Black;
 leds_16x16[0][11] = CRGB::Black;
 leds_16x16[0][12] = CRGB::Black;
 leds_16x16[0][13] = CRGB::Black;
 leds_16x16[0][14] = CRGB::Black;
 leds_16x16[0][15] = CRGB::Black;
 leds_16x16[1][0] = CRGB::Black;
 leds_16x16[1][1] = CRGB::Black;
 leds_16x16[1][2] = CRGB::Black;
 leds_16x16[1][3] = CRGB::Black;
 leds_16x16[1][4] = CRGB::Black;
 leds_16x16[1][5] = CRGB::Black;
 leds_16x16[1][6] = CRGB::Black;
 leds_16x16[1][7] = CRGB::Black;
 leds_16x16[1][8] = CRGB::Black;
 leds_16x16[1][9] = CRGB::Black;
 leds_16x16[1][10] = CRGB::Black;
 leds_16x16[1][11] = CRGB::Black;
 leds_16x16[1][12] = CRGB::Black;
 leds_16x16[1][13] = CRGB::Black;
 leds_16x16[1][14] = CRGB::Black;
 leds_16x16[1][15] = CRGB::Black;
 leds_16x16[2][0] = CRGB::Black;
 leds_16x16[2][1] = CRGB::Black;
 leds_16x16[2][5] = CRGB::Black;
 leds_16x16[2][6] = CRGB::Black;
 leds_16x16[2][7] = CRGB::Black;
 leds_16x16[2][8] = CRGB::Black;
 leds_16x16[2][9] = CRGB::Black;
 leds_16x16[2][13] = CRGB::Black;
 leds_16x16[2][14] = CRGB::Black;
 leds_16x16[2][15] = CRGB::Black;
 leds_16x16[3][0] = CRGB::Black;
 leds_16x16[3][6] = CRGB::Black;
 leds_16x16[3][7] = CRGB::Black;
 leds_16x16[3][8] = CRGB::Black;
 leds_16x16[3][14] = CRGB::Black;
 leds_16x16[3][15] = CRGB::Black;
 leds_16x16[4][0] = CRGB::Black;
 leds_16x16[4][7] = CRGB::Black;
 leds_16x16[4][14] = CRGB::Black;
 leds_16x16[4][15] = CRGB::Black;
 leds_16x16[5][0] = CRGB::Black;
 leds_16x16[5][14] = CRGB::Black;
 leds_16x16[5][15] = CRGB::Black;
 leds_16x16[6][0] = CRGB::Black;
 leds_16x16[6][14] = CRGB::Black;
 leds_16x16[6][15] = CRGB::Black;
 leds_16x16[7][0] = CRGB::Black;
 leds_16x16[7][14] = CRGB::Black;
 leds_16x16[7][15] = CRGB::Black;
 leds_16x16[8][0] = CRGB::Black;
 leds_16x16[8][1] = CRGB::Black;
 leds_16x16[8][13] = CRGB::Black;
 leds_16x16[8][14] = CRGB::Black;
 leds_16x16[8][15] = CRGB::Black;
 leds_16x16[9][0] = CRGB::Black;
 leds_16x16[9][1] = CRGB::Black;
 leds_16x16[9][2] = CRGB::Black;
 leds_16x16[9][12] = CRGB::Black;
 leds_16x16[9][13] = CRGB::Black;
 leds_16x16[9][14] = CRGB::Black;
 leds_16x16[9][15] = CRGB::Black;
 leds_16x16[10][0] = CRGB::Black;
 leds_16x16[10][1] = CRGB::Black;
 leds_16x16[10][13] = CRGB::Black;
 leds_16x16[10][14] = CRGB::Black;
 leds_16x16[10][15] = CRGB::Black;
 leds_16x16[11][0] = CRGB::Black;
 leds_16x16[11][1] = CRGB::Black;
 leds_16x16[11][13] = CRGB::Black;
 leds_16x16[11][14] = CRGB::Black;
 leds_16x16[11][15] = CRGB::Black;
 leds_16x16[12][0] = CRGB::Black;
 leds_16x16[12][1] = CRGB::Black;
 leds_16x16[12][7] = CRGB::Black;
 leds_16x16[12][13] = CRGB::Black;
 leds_16x16[12][14] = CRGB::Black;
 leds_16x16[12][15] = CRGB::Black;
 leds_16x16[13][0] = CRGB::Black;
 leds_16x16[13][1] = CRGB::Black;
 leds_16x16[13][2] = CRGB::Black;
 leds_16x16[13][6] = CRGB::Black;
 leds_16x16[13][7] = CRGB::Black;
 leds_16x16[13][8] = CRGB::Black;
 leds_16x16[13][12] = CRGB::Black;
 leds_16x16[13][13] = CRGB::Black;
 leds_16x16[13][14] = CRGB::Black;
 leds_16x16[13][15] = CRGB::Black;
 leds_16x16[14][0] = CRGB::Black;
 leds_16x16[14][1] = CRGB::Black;
 leds_16x16[14][2] = CRGB::Black;
 leds_16x16[14][3] = CRGB::Black;
 leds_16x16[14][4] = CRGB::Black;
 leds_16x16[14][5] = CRGB::Black;
 leds_16x16[14][6] = CRGB::Black;
 leds_16x16[14][7] = CRGB::Black;
 leds_16x16[14][8] = CRGB::Black;
 leds_16x16[14][9] = CRGB::Black;
 leds_16x16[14][10] = CRGB::Black;
 leds_16x16[14][11] = CRGB::Black;
 leds_16x16[14][12] = CRGB::Black;
 leds_16x16[14][13] = CRGB::Black;
 leds_16x16[14][14] = CRGB::Black;
 leds_16x16[14][15] = CRGB::Black;
 leds_16x16[15][0] = CRGB::Black;
 leds_16x16[15][1] = CRGB::Black;
 leds_16x16[15][2] = CRGB::Black;
 leds_16x16[15][3] = CRGB::Black;
 leds_16x16[15][4] = CRGB::Black;
 leds_16x16[15][5] = CRGB::Black;
 leds_16x16[15][6] = CRGB::Black;
 leds_16x16[15][7] = CRGB::Black;
 leds_16x16[15][8] = CRGB::Black;
 leds_16x16[15][9] = CRGB::Black;
 leds_16x16[15][10] = CRGB::Black;
 leds_16x16[15][11] = CRGB::Black;
 leds_16x16[15][12] = CRGB::Black;
 leds_16x16[15][13] = CRGB::Black;
 leds_16x16[15][14] = CRGB::Black;
 leds_16x16[15][15] = CRGB::Black;
 //------------Cyan------------// 
 leds_16x16[2][2] = CRGB::Cyan;
 leds_16x16[2][3] = CRGB::Cyan;
 leds_16x16[2][4] = CRGB::Cyan;
 leds_16x16[2][10] = CRGB::Cyan;
 leds_16x16[2][11] = CRGB::Cyan;
 leds_16x16[2][12] = CRGB::Cyan;
 leds_16x16[3][1] = CRGB::Cyan;
 leds_16x16[3][2] = CRGB::Cyan;
 leds_16x16[3][5] = CRGB::Cyan;
 leds_16x16[3][9] = CRGB::Cyan;
 leds_16x16[3][12] = CRGB::Cyan;
 leds_16x16[3][13] = CRGB::Cyan;
 leds_16x16[4][1] = CRGB::Cyan;
 leds_16x16[4][6] = CRGB::Cyan;
 leds_16x16[4][8] = CRGB::Cyan;
 leds_16x16[4][13] = CRGB::Cyan;
 leds_16x16[5][1] = CRGB::Cyan;
 leds_16x16[5][6] = CRGB::Cyan;
 leds_16x16[5][7] = CRGB::Cyan;
 leds_16x16[5][8] = CRGB::Cyan;
 leds_16x16[5][13] = CRGB::Cyan;
 leds_16x16[6][1] = CRGB::Cyan;
 leds_16x16[6][7] = CRGB::Cyan;
 leds_16x16[6][13] = CRGB::Cyan;
 leds_16x16[7][1] = CRGB::Cyan;
 leds_16x16[7][7] = CRGB::Cyan;
 leds_16x16[7][13] = CRGB::Cyan;
 leds_16x16[8][2] = CRGB::Cyan;
 leds_16x16[8][6] = CRGB::Cyan;
 leds_16x16[8][7] = CRGB::Cyan;
 leds_16x16[8][8] = CRGB::Cyan;
 leds_16x16[8][12] = CRGB::Cyan;
 leds_16x16[9][3] = CRGB::Cyan;
 leds_16x16[9][4] = CRGB::Cyan;
 leds_16x16[9][5] = CRGB::Cyan;
 leds_16x16[9][6] = CRGB::Cyan;
 leds_16x16[9][7] = CRGB::Cyan;
 leds_16x16[9][8] = CRGB::Cyan;
 leds_16x16[9][9] = CRGB::Cyan;
 leds_16x16[9][10] = CRGB::Cyan;
 leds_16x16[9][11] = CRGB::Cyan;
 leds_16x16[10][2] = CRGB::Cyan;
 leds_16x16[10][6] = CRGB::Cyan;
 leds_16x16[10][7] = CRGB::Cyan;
 leds_16x16[10][8] = CRGB::Cyan;
 leds_16x16[10][12] = CRGB::Cyan;
 leds_16x16[11][2] = CRGB::Cyan;
 leds_16x16[11][6] = CRGB::Cyan;
 leds_16x16[11][7] = CRGB::Cyan;
 leds_16x16[11][8] = CRGB::Cyan;
 leds_16x16[11][12] = CRGB::Cyan;
 leds_16x16[12][2] = CRGB::Cyan;
 leds_16x16[12][5] = CRGB::Cyan;
 leds_16x16[12][6] = CRGB::Cyan;
 leds_16x16[12][8] = CRGB::Cyan;
 leds_16x16[12][9] = CRGB::Cyan;
 leds_16x16[12][12] = CRGB::Cyan;
 leds_16x16[13][3] = CRGB::Cyan;
 leds_16x16[13][4] = CRGB::Cyan;
 leds_16x16[13][5] = CRGB::Cyan;
 leds_16x16[13][9] = CRGB::Cyan;
 leds_16x16[13][10] = CRGB::Cyan;
 leds_16x16[13][11] = CRGB::Cyan;
 //------------Rose------------// 
 leds_16x16[6][4] = CRGB::HotPink;
 leds_16x16[6][10] = CRGB::HotPink;
 leds_16x16[10][3] = CRGB::HotPink;
 leds_16x16[10][4] = CRGB::HotPink;
 leds_16x16[10][5] = CRGB::HotPink;
 leds_16x16[10][9] = CRGB::HotPink;
 leds_16x16[10][10] = CRGB::HotPink;
 leds_16x16[10][11] = CRGB::HotPink;
 leds_16x16[11][3] = CRGB::HotPink;
 leds_16x16[11][5] = CRGB::HotPink;
 leds_16x16[11][9] = CRGB::HotPink;
 leds_16x16[11][11] = CRGB::HotPink;
 leds_16x16[12][3] = CRGB::HotPink;
 leds_16x16[12][4] = CRGB::HotPink;
 leds_16x16[12][10] = CRGB::HotPink;
 leds_16x16[12][11] = CRGB::HotPink;
 //------------Violet------------// 
 leds_16x16[5][3] = CRGB::Purple;
 leds_16x16[5][4] = CRGB::Purple;
 leds_16x16[5][10] = CRGB::Purple;
 leds_16x16[5][11] = CRGB::Purple;
 leds_16x16[6][3] = CRGB::Purple;
 leds_16x16[6][5] = CRGB::Purple;
 leds_16x16[6][9] = CRGB::Purple;
 leds_16x16[6][11] = CRGB::Purple;
 leds_16x16[7][4] = CRGB::Purple;
 leds_16x16[7][5] = CRGB::Purple;
 leds_16x16[7][9] = CRGB::Purple;
 leds_16x16[7][10] = CRGB::Purple;
 leds_16x16[11][4] = CRGB::Purple;
 leds_16x16[11][10] = CRGB::Purple;
 //------------Jaune------------// 
 leds_16x16[3][3] = CRGB::Yellow;
 leds_16x16[3][4] = CRGB::Yellow;
 leds_16x16[3][10] = CRGB::Yellow;
 leds_16x16[3][11] = CRGB::Yellow;
 leds_16x16[4][2] = CRGB::Yellow;
 leds_16x16[4][3] = CRGB::Yellow;
 leds_16x16[4][4] = CRGB::Yellow;
 leds_16x16[4][5] = CRGB::Yellow;
 leds_16x16[4][9] = CRGB::Yellow;
 leds_16x16[4][10] = CRGB::Yellow;
 leds_16x16[4][11] = CRGB::Yellow;
 leds_16x16[4][12] = CRGB::Yellow;
 leds_16x16[5][2] = CRGB::Yellow;
 leds_16x16[5][5] = CRGB::Yellow;
 leds_16x16[5][9] = CRGB::Yellow;
 leds_16x16[5][12] = CRGB::Yellow;
 leds_16x16[6][2] = CRGB::Yellow;
 leds_16x16[6][6] = CRGB::Yellow;
 leds_16x16[6][8] = CRGB::Yellow;
 leds_16x16[6][12] = CRGB::Yellow;
 leds_16x16[7][2] = CRGB::Yellow;
 leds_16x16[7][3] = CRGB::Yellow;
 leds_16x16[7][6] = CRGB::Yellow;
 leds_16x16[7][8] = CRGB::Yellow;
 leds_16x16[7][11] = CRGB::Yellow;
 leds_16x16[7][12] = CRGB::Yellow;
 leds_16x16[8][3] = CRGB::Yellow;
 leds_16x16[8][4] = CRGB::Yellow;
 leds_16x16[8][5] = CRGB::Yellow;
 leds_16x16[8][9] = CRGB::Yellow;
 leds_16x16[8][10] = CRGB::Yellow;
 leds_16x16[8][11] = CRGB::Yellow;
 //-----------------------------// 

 Matrice_16x16();//Convertion tableau 2d théorique en matrice réel
 FastLED.show();//après convertion affichage des leds selon leurs couleurs

 //Fin
}





#include <Time.h> // see http://playground.arduino.cc/Code/time 
#include <Servo.h>
#define WISHY 3 // Offset of the Y coordinats of the plate-wisher
#define SERVOFAKTORLEFT 600
#define SERVOFAKTORRIGHT 600
#define SERVOLEFTNULL 1950
#define SERVORIGHTNULL 815
#define SERVOPINLIFT  A2
#define SERVOPINLEFT  A3
#define SERVOPINRIGHT A1
#define ZOFF 90
// lift positions of lifting servo
#define LIFT0 1110+ZOFF // on drawing surface
#define LIFT1 995+ZOFF  // between numbers
#define LIFT2 735+ZOFF  // going towards sweeper
// speed of liftimg arm, higher is slower
#define LIFTSPEED 2000
// length of arms
#define L1 35
#define L2 55.1
#define L3 13.2
#define L4 45
// origin points of left and right servo 
#define O1X 24//22
#define O1Y -25
#define O2X 49//47
#define O2Y -25
#include <Wire.h>
#include <DS1307RTC.h> // see http://playground.arduino.cc/Code/time    
int servoLift = 1500;
Servo servo1;  // 
Servo servo2;  // 
Servo servo3;  // 
volatile double lastX = 75;
volatile double lastY = 47.5;
char peekChar;
int melody[2][156] = {{},{}};
int timeDelay = 20;
int E=0;
int i = 0;
int draw_num1;
int draw_num2;
char finishArm =' ';

void setup() 
{   
  //pinMode(7, INPUT_PULLUP);
  Serial.begin(9600); 
  for(int i = 9; i >= 2 ; i--)
  {
    pinMode(i, OUTPUT);
  }
  digitalWrite(9,LOW);//turn off comunication with altera  
  sendNote(1); // reset old melody
  delay(10);
  drawTo(75.2, 47);
  lift(2);  
  servo1.attach(SERVOPINLIFT);  //  lifting servo
  servo2.attach(SERVOPINLEFT);  //  left servo
  servo3.attach(SERVOPINRIGHT);  //  right servo
  delay(1000); 
} 

void loop() 
{ 
  if (Serial.available() > 0)
  {
    if(Serial.peek()=='#')
    {
       Serial.read();
       peekChar = Serial.peek();
       Serial.read();
       switch(peekChar)
       {
          case '8': writeArm();break; 
          case '1':sendNote(1);storage();saveArmData();displayMelody();writeArm();break;
          case '2': storage();break;////////////////////////////////////
          case '9':pingRequest();break;         
       }
    }
    Serial.read();
  }
  delay(200);
} 

void cleanPort()
{
  for(int i=0; i<64;i++)
    Serial.read();
  
}

void blinkLed()
{
  char finish = Serial.peek();
  Serial.read();
  if(finish == '$')
  {
    pinMode(13,OUTPUT);
    digitalWrite(13, HIGH);
    for(long k=0; k<8000000; k++)
    {
      if(Serial.peek() == '%')
        break;
    }
    digitalWrite(13, LOW);
  }
  
}


void pingRequest()
{
  char finish = Serial.peek();
  Serial.read();
  if(finish == '$')
  {
    Serial.print("&");
  }
}


void sendNote(int outWord)
{
  for(int i=6; i>=0; i--)
  {
    //Serial.print("i=");///////////////////
    //Serial.print(i);///////////////////
    //Serial.print("     ");///////////////////
     float power = pow(2,i);
     //Serial.print("power=");///////////////////
    //Serial.print(power);///////////////////
     //Serial.print("          ");///////////////////
     if(outWord>=power)
     {
       digitalWrite(i+2,HIGH);
       
       outWord= outWord - power;
       //Serial.print(outWord);////////////////////////////
       //Serial.print(" 1");///////////////////

     }
     else
     {
       digitalWrite(i+2,LOW); 
       //Serial.print(outWord);///////////////////////     
       //Serial.print(" 0");///////////////////
     }
     //Serial.print("\n");///////////////////
  }  
  
  digitalWrite(9,HIGH);//anable gpio data reading
  //Serial.print("read");///////////////////
  //Serial.print("\n");///////////////////
  delay(50);///////////////
  //delayMicroseconds(10);
  digitalWrite(9,LOW);//anable gpio data reading
  //Serial.print("dont");///////////////////
  //Serial.print("\n");///////////////////
}


int convNote(int noteNumber, int noteType)
{
  int outWord=80;
  switch(noteNumber)
  {
     case 1: outWord=8; break;
     case 2: outWord=16; break;
     case 3: outWord=24; break;
     case 4: outWord=32; break;
     case 5: outWord=40; break;
     case 6: outWord=48; break;
     case 7: outWord=56; break;
     case 8: outWord=64; break;
     case 9: outWord=8; break;
     case 10: outWord=16; break;
     case 11: outWord=24; break;
     case 12: outWord=32; break;
     case 13: outWord=40; break;
     case 14: outWord=80; break;//bigger than 70 so is lines
  }
  if(noteNumber <= 8)
  {
    switch(noteType)
    {
      case 1:outWord+=5;break;
      case 2:outWord+=2;break;
      case 4:outWord+=1;break;
      case 8:outWord+=1;break;
    }
  }
  else
  {
    switch(noteType)
    {
      case 1:outWord+=0;break;
      case 2:outWord+=7;break;
      case 4:outWord+=6;break;
      case 8:outWord+=6;break;
    }
  }
  if(outWord>=80)
    outWord=127;//lines
  
  return outWord;
}


////goot////
void storage()
{
  //Serial.print("enter case 1");
  char finish;
  ////reset melody///////
  for(int i=0;i<2;i++)
  {
    for(int j=0;j<156;j++)//lengh of melody[1]
    {
      melody[i][j]=0;
    }
  }
  
  for(i=0 ; i<300 ; i++)
  {
    //Serial.print(" i = " );///////////////////////////
    //Serial.print(i);/////////////////////////////
    //Serial.print(" - ");////////////////////////////
    finish = Serial.peek();
    if(finish == '$')
    {
      Serial.read();
      break; 
    }
    else
    {
      if (finish == '%')
      {
        Serial.read();
        for(long k=0; k<10000000; k++)
        {
          if(Serial.peek() == '%')
          {
            Serial.read();
            delay(timeDelay);
            k = 10000000;            
          }
            
        }
      }
      if(i < 156)
      {
        melody[0][i] = Serial.read();
        //Serial.print(melody[0][i]);/////////////////////////////////////
        //Serial.print("  ");/////////////////////////////////////
        delay(timeDelay);
      }
      else
        Serial.read();
      
      finish = Serial.peek();
      if(finish == '$')
      {        
        melody[0][i] = 0;
        Serial.read();
        break; 
      }      
      else
      { 
        if(finish == '%')
        {
          Serial.read();
          for(long k=0; k<10000000; k++)
          {
            if(Serial.peek() == '%')
            {
              Serial.read();
              delay(timeDelay);
              k = 10000000;            
            }             
          }
        }      
        if(i < 156)
        {
          melody[1][i] = Serial.read();
          //Serial.print(melody[1][i]);////////////////////////////
          //Serial.print("\n");/////////////////////////////////////
          delay(timeDelay);
        }      
        else
          Serial.read(); 
      }
    }
  }
  if (finish!= '$') //reset
  {
    for(int i=0;i<2;i++)
    {
      for(int j=0;j<156;j++)//lengh of melody[1]
      {
        melody[i][j]=0;
      }
    }
  }
}




/*
////////old storage/////////////
void storage()
{
  char finish;
  ////reset melody///////
  for(int i=0;i<2;i++)
  {
    for(int j=0;j<156;j++)//lengh of melody[1]
    {
      melody[i][j]=0;
    }
  }
  for(int i=0;i<300;i++)
  {
   finish = Serial.peek();
   if(finish == '$')
   {
     Serial.read();
     break; 
   }
   if(i < 156)
    melody[0][i] = Serial.read()-48;
   else
    Serial.read();
   finish = Serial.peek();
   if(finish == '$')
   {
     melody[0][i] = 0;
     Serial.read();
     break; 
   }     
   if(i < 156)
    melody[1][i] = Serial.read()-48;
   else
    Serial.read();
  }
  if (finish!= '$') //reset
  {
    for(int i=0;i<2;i++)
    {
      for(int j=0;j<156;j++)//lengh of melody[1]
      {
        melody[i][j]=0;
      }
    }
  }
}
*/

void displayMelody()
{
  sendNote(1); // reset old melody
  delay(2);
 // Serial.print("1");
//  Serial.print("\n");



/////////////////////////////
 // sendNote(convNote(1,2));  
 // Serial.print(convNote(1,2));
//  Serial.print("\n");
///////////////////////////////////////



  
  for(int j=0;j<156;j++)//lengh of melody[1]
  {
    if(melody[0][j] != 0 && melody[1][j] != 0)
    {
      sendNote(convNote(melody[0][j],melody[1][j]));       
    }
    else
      break;
  }
}


void writeArm()
{
  
  //char draw = Serial.peek();///////////////////////
  //Serial.read();/////////////////////////  
  if(finishArm == '$')
  {
    /////erase//////////
    //number(25, 20, 111, 0.9);
    ////number to draw///////
    lift(2);
    delay(200);
    number(35,35, draw_num1, -0.9);//number(25, 20, draw_num, 1.5);
    lift(2);
    delay(200);
    number(48,35, draw_num2, -0.9);//number(25, 20, draw_num, 1.5);
    lift(2);
    delay(200);
    ////base position////////
    drawTo(71.0, 47.2);
    //lift(1);
    delay(50);
  }
}

void saveArmData()
{
  finishArm =' ';
  draw_num1 = Serial.read()-48;
  draw_num2 = Serial.read()-48;
  //Serial.println(draw_num1);
  //Serial.println(draw_num2);
  finishArm = Serial.peek();
  Serial.read();
  if(draw_num2 == -12)
    {
      draw_num2 = 0;
      finishArm = '$';
    }
  
  
}
// Writing numeral with bx by being the bottom left originpoint. Scale 1 equals a 20 mm high font.
// The structure follows this principle: move to first startpoint of the numeral, lift down, draw numeral, lift up
void number(float bx, float by, int num, float scale) {
  switch (num) {
  case 0:
    drawTo(bx + 12 * scale, by + 6 * scale);
    lift(0);
    bogenGZS(bx + 7 * scale, by + 10 * scale, 10 * scale, -0.8, 6.7, 0.5);
    lift(2);
    break;
  case 1:

    drawTo(bx + 3 * scale, by + 15 * scale);
    lift(0);
    drawTo(bx + 10 * scale, by + 20 * scale);
    drawTo(bx + 10 * scale, by + 0 * scale);
    lift(1);
    break;
  case 2:
    drawTo(bx + 2 * scale, by + 12 * scale);
    lift(0);
    bogenUZS(bx + 11 * scale, by + 14 * scale, 6 * scale, 3, -0.8, 1);//bx + 8 * scale, by + 14 * scale, 6 * scale, 3, -0.8, 1
    drawTo(bx + 1 * scale, by + 0 * scale);
    drawTo(bx + 12 * scale, by + 0 * scale);
    lift(1);
    break;
  case 3:
    drawTo(bx + 2 * scale, by + 17 * scale);
    lift(0);
    bogenUZS(bx + 5 * scale, by + 15 * scale, 5 * scale, 3, -2, 1);
    bogenUZS(bx + 5 * scale, by + 5 * scale, 5 * scale, 1.57, -3, 1);
    lift(1);
    break;
  case 4:
    drawTo(bx + 10 * scale, by + 0 * scale);
    lift(0);
    drawTo(bx + 10 * scale, by + 20 * scale);
    drawTo(bx + 2 * scale, by + 6 * scale);
    drawTo(bx + 14 * scale, by + 6 * scale);
    lift(1);
    break;
  case 5:
    drawTo(bx + 2 * scale, by + 5 * scale);
    lift(0);
    bogenGZS(bx + 5 * scale, by + 6 * scale, 6 * scale, -2.5, 2, 1);
    drawTo(bx + 1 * scale, by + 20 * scale);
    drawTo(bx + 12 * scale, by + 18 * scale);
    lift(1);
    break;
  case 6:
    drawTo(bx + 2 * scale, by + 10 * scale);
    lift(0);
    bogenUZS(bx + 7 * scale, by + 6 * scale, 6 * scale,2, -4.4, 1);//2, -4.4, 1
    drawTo(bx + 11 * scale, by + 20 * scale);
    lift(1);
    break;
  case 7:
    drawTo(bx + 2 * scale, by + 20 * scale);
    lift(0);
    drawTo(bx + 12 * scale, by + 20 * scale);
    drawTo(bx + 2 * scale, by + 0);
    lift(1);
    break;
  case 8:
    drawTo(bx + 5 * scale, by + 10 * scale);
    lift(0);
    bogenUZS(bx + 5 * scale, by + 15 * scale, 5 * scale, 4.7, -1.6, 1);
    bogenGZS(bx + 5 * scale, by + 5 * scale, 5 * scale, -4.7, 2, 1);
    lift(1);
    break;

  case 9:
    drawTo(bx + 9 * scale, by + 11 * scale);
    lift(0);
    bogenUZS(bx + 7 * scale, by + 15 * scale, 5 * scale, 4, -0.5, 1);
    drawTo(bx + 5 * scale, by + 0);
    lift(1);
    break;
    /////full erase/////
  case 111:
    lift(0);
    drawTo(70, 45);
    drawTo(65-WISHY, 43);
    drawTo(65-WISHY, 46);
    drawTo(5, 49);
    drawTo(5, 46);
    drawTo(63-WISHY, 46);
    drawTo(63-WISHY, 42);
    drawTo(5, 42);
    drawTo(5, 38);
    drawTo(63-WISHY, 38);
    drawTo(63-WISHY, 34);
    drawTo(5, 34);
    drawTo(5, 29);
    drawTo(6, 29);
    drawTo(65-WISHY, 26);
    drawTo(5, 26);
    drawTo(60-WISHY, 40);
    drawTo(73.2, 44.0);
    lift(2);
    break;
  }
}
void lift(char lift) {
  switch (lift) {
    // room to optimize  !
  case 0: //850
      if (servoLift >= LIFT0) {
      while (servoLift >= LIFT0) 
      {
        servoLift--;
        servo1.writeMicroseconds(servoLift);        
        delayMicroseconds(LIFTSPEED);
      }
    } 
    else {
      while (servoLift <= LIFT0) {
        servoLift++;
        servo1.writeMicroseconds(servoLift);
        delayMicroseconds(LIFTSPEED);
      }
    }
    break;
  case 1: //150
    if (servoLift >= LIFT1) {
      while (servoLift >= LIFT1) {
        servoLift--;
        servo1.writeMicroseconds(servoLift);
        delayMicroseconds(LIFTSPEED);
      }
    } 
    else {
      while (servoLift <= LIFT1) {
        servoLift++;
        servo1.writeMicroseconds(servoLift);
        delayMicroseconds(LIFTSPEED);
      }
    }
    break;
  case 2:
    if (servoLift >= LIFT2) {
      while (servoLift >= LIFT2) {
        servoLift--;
        servo1.writeMicroseconds(servoLift);
        delayMicroseconds(LIFTSPEED);
      }
    } 
    else {
      while (servoLift <= LIFT2) {
        servoLift++;
        servo1.writeMicroseconds(servoLift);        
        delayMicroseconds(LIFTSPEED);
      }
    }
    break;
  }
}
void bogenUZS(float bx, float by, float radius, int start, int ende, float sqee) {
  float inkr = -0.05;
  float count = 0;
  do {
    drawTo(sqee * radius * cos(start + count) + bx,
    radius * sin(start + count) + by);
    count += inkr;
  } 
  while ((start + count) > ende);
}
void bogenGZS(float bx, float by, float radius, int start, int ende, float sqee) {
  float inkr = 0.05;
  float count = 0;
  do {
    drawTo(sqee * radius * cos(start + count) + bx,
    radius * sin(start + count) + by);
    count += inkr;
  } 
  while ((start + count) <= ende);
}
void drawTo(double pX, double pY) {
  double dx, dy, c;
  int i;
  // dx dy of new point
  dx = pX - lastX;
  dy = pY - lastY;
  //path lenght in mm, times 4 equals 4 steps per mm
  c = floor(7 * sqrt(dx * dx + dy * dy));
  if (c < 1) c = 1;
  for (i = 0; i <= c; i++) {
    // draw line point by point
    set_XY(lastX + (i * dx / c), lastY + (i * dy / c));
  }
  lastX = pX;
  lastY = pY;
}
double return_angle(double a, double b, double c) {
  // cosine rule for angle between c and a
  return acos((a * a + c * c - b * b) / (2 * a * c));
}
void set_XY(double Tx, double Ty) 
{
  delay(1);
  double dx, dy, c, a1, a2, Hx, Hy;
  // calculate triangle between pen, servoLeft and arm joint
  // cartesian dx/dy
  dx = Tx - O1X;
  dy = Ty - O1Y;
  // polar lemgth (c) and angle (a1)
  c = sqrt(dx * dx + dy * dy); // 
  a1 = atan2(dy, dx); //
  a2 = return_angle(L1, L2, c);
  servo2.writeMicroseconds(floor(((a2 + a1 - M_PI) * SERVOFAKTORLEFT) + SERVOLEFTNULL));
  // calculate joinr arm point for triangle of the right servo arm
  a2 = return_angle(L2, L1, c);
  Hx = Tx + L3 * cos((a1 - a2 + 0.621) + M_PI); //36,5°
  Hy = Ty + L3 * sin((a1 - a2 + 0.621) + M_PI);
  // calculate triangle between pen joint, servoRight and arm joint
  dx = Hx - O2X;
  dy = Hy - O2Y;
  c = sqrt(dx * dx + dy * dy);
  a1 = atan2(dy, dx);
  a2 = return_angle(L1, L4, c);
  servo3.writeMicroseconds(floor(((a1 - a2) * SERVOFAKTORRIGHT) + SERVORIGHTNULL));
}

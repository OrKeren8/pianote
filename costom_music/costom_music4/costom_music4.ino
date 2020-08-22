#define buzzer A0 
//*****************************************
#define DO  262   //Defining note frequency
#define DO_SH  277
#define RE  294
#define RE_SH  311
#define MI  330
#define FA  349
#define FA_SH  370
#define SOL  392
#define SOL_SH  415
#define LA 440 
#define LA_SH  466
#define SI 494
#define DO_2 523
//*****************************************
int debug = 0;
int timeDelay = 20;
int inNote=0,inType=0;
char peekChar;
int header;
String data;
int i = 0, wait = 150, noteLen = 0, recP = 0;
int tempo = 140;
int eighthTime = (30000 / tempo);
bool isRec = false;
int arr[2][13] = {
                 {13,11 , 9 , 8 , 6   , 4 , 2 , A5  ,  12  ,  10  ,   7   ,  5    , 3  },
                 {DO, RE, MI, FA, SOL, LA, SI, DO_2, DO_SH, RE_SH, FA_SH, SOL_SH, LA_SH}};
int recSize = 156;
int melody[2][156] = {{1,3,5,8},{8,8,8,4}};


/////////////////////////setup/////////////////////////
void setup() {
 Serial.begin(9600);
  for(int pin = 0; pin < 13; pin++)
  {    
    pinMode(arr[0][pin],INPUT);
  }
  soundMelody();
}


/////////////////////////loop/////////////////////////
void loop() {
  if (Serial.available() > 0)
  {
    if(Serial.peek()=='#')
    {
      Serial.read();
      peekChar = Serial.peek();
      Serial.read();
      switch(peekChar)
      {
        case '1':storage();soundMelody();break;//storage
        case '2':soundMelody();break;
        case '3':PCrequestsData();break;//request data        
        case '4':setTempo();break;
        case '9':pingRequest();break; 
      }
    }
    Serial.read();
  } 
  else
  {
    for(i = 0; i < 13; i++)
    {    
      if(isPressed(arr[0][i]))
      {
        //noteLen = 0;      
        do
        {
         // noteLen += wait;          
          tone(buzzer,arr[1][i],wait);
        }
        while(isPressed(arr[0][i]));  
        /*    
        if(recP < (recSize))
        {
          melody[0][recP] = i;      
          melody[1][recP] =  findLen(noteLen);
          recP ++;
        }
        */
        delay(150);
      }    
    }  
  }
}


////good////
int findLen(int len)
{
  float ratio = len/eighthTime;
  if(ratio < 1.5)
    len = 8;
  else if(ratio >= 1.5 && ratio < 3)
    len = 4;
  else if(ratio >= 3 && ratio < 6)
    len = 2;
  else if(ratio >= 6)
    len = 1; 
  return len;  
}


////good////
bool isPressed(int pin)
{
  int sum = 0;
  bool isLow = false;
  for(int t = 0; t < 100; t++)
  {
    if(digitalRead(arr[0][i]) == LOW)
    {
      sum ++;
      if(sum > 50)
      {        
        break;
      }
    }
  }
  if(sum > 50)
  {
    isLow = true;
  }
  
  if(i==0)
  {
    if(sum<51)
    {
      Serial.print(sum);
      Serial.println("*****************");
    }
    else
      Serial.println(sum);
  }
  if(pin == A5)
    isLow = false;
  return isLow;
}


////to be continued////
void PCrequestsData()
{
  
}


////good////
void pingRequest()
{
  char finish = Serial.peek();
  Serial.read();
  if(finish == '$')
  {
    Serial.print("|");
  }
}



////good////
void soundMelody()
{
  for(int i=0;i<156;i++)//lengh of melody[1]
  {
    //serial.println(Serial.peek());
    if(Serial.peek() == 42)
    {
      Serial.read();
      break;
    }
    if(melody[0][i]<=0 || melody[1][i]<=0)
      break;
    int thisWait = (eighthTime*8/melody[1][i]);
    if(melody[0][i] != 14)
      tone(buzzer,arr[1][melody[0][i]-1],thisWait);    
    delay(thisWait+50);
  }  
  
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
    //Serial.print(" integer is =" );///////////////////////////
    //Serial.print(i);/////////////////////////////
    //Serial.print("\n");////////////////////////////
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
        melody[0][i] = Serial.read()-48*debug;/////////////////////
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
          melody[1][i] = Serial.read()-48*debug;/////////////////////
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

void setTempo()
{
  //serial.println(tempo);
  int meot = Serial.read()-48; 
  delay(5);
  int asarot = Serial.read()-48;
  delay(5);
  char currentFinish = Serial.peek();
  delay(5);
  int yehidot = Serial.read()-48;
  delay(5);
  char finish = Serial.peek();
  Serial.read();
  if(finish == '$')
  {    
    int requestedTempo = yehidot + (asarot*10) + (meot*100);
    if(requestedTempo>20 && requestedTempo < 450)
    {
     tempo = requestedTempo;
     eighthTime = (30000 / tempo); 
     //serial.println(tempo);
    }   
  }
  else if (currentFinish == '$')
  {
    int requestedTempo = (asarot) + (meot*10);
    if(requestedTempo>20 && requestedTempo < 450)
    {
      tempo = requestedTempo;
      eighthTime = (30000 / tempo); 
      //serial.println(tempo);
    }   
  }  
}

/*
void playNote()
{
  inNote = Serial.read();
  inType = Serial.read();
  
  char finish = Serial.peek();
  Serial.read();
  if(finish == '$')
  {
    int thisWait = (eighthTime*8/inType);
    tone(buzzer,arr[1][inNote],50);//thisWait
    Serial.print(inNote);
    Serial.print(inType);
    
  }
}
*/

/*
-> HMI - R-5v,Blk-GND,Blu-10,Y-9 
-> Caudalimetro - R-5v,Blk-GND,Y-3
-> Sensores temp - R-5v,Blk-GND,Y-2,resistencia 4.7K ohm entre R e Y
-> CPU e RAM - Programa em C#
*/

//Librarias
#include <Nextion.h>
#include <OneWire.h>
#include <DallasTemperature.h>
// Data wire is plugged into port 2 on the Arduino for temp sensors
#define ONE_WIRE_BUS 2
OneWire oneWire(ONE_WIRE_BUS);// Setup a oneWire instance to communicate with any OneWire devices
DallasTemperature sensors(&oneWire);// Pass our oneWire reference to Dallas Temperature.


//Enderecos dos sendores de temperatura
uint8_t sensor_intake[8] = { 0x28, 0xCB, 0x6C, 0x07, 0xD6, 0x01, 0x3C, 0xDE };
uint8_t sensor_inside[8] = { 0x28, 0xA8, 0x8A, 0x07, 0xD6, 0x01, 0x3C, 0x02 };
uint8_t sensor_rear[8] = { 0x28, 0x37, 0x0F, 0x07, 0xD6, 0x01, 0x3C, 0x8E };
uint8_t sensor_radiator[8] = { 0x28, 0x2C, 0x30, 0x07, 0xD6, 0x01, 0x3C, 0xC6 };
uint8_t sensor_reservatory[8] = { 0x28, 0x6A, 0x61, 0xC5, 0x26, 0x20, 0x01, 0xAC };


//portas do arduino ligadas ao lcd hmi nextion
SoftwareSerial HMISerial(9, 10);

/*
SINTAXE DAS VARIAVEIS DO HMI
tipo_de_componente_hmi nome_amigavel_dado_ao_campo_no_programa = tipo_de_componente_hmi(pagina_hmi, id_componente_editor_hmi, "nome_dado_ao_componente_no_editor_hmi");
*/
/*PAGINA LOADING*/
NexText p0_firmware = NexText(0, 9, "t3p0"); //mostra a versao do firmware atual
NexProgressBar p0_loading = NexProgressBar(0, 3, "j0p0"); //barra de loading
/*PAGINA 1*/
NexText p1_campo1 = NexText(1, 7, "t4p1"); //define o campo do HMI da temperatura de entrada
NexText p1_campo2 = NexText(1, 8, "t5p1"); //define o campo do HMI da temperatura inerior
NexText p1_campo3 = NexText(1, 9, "t6p1"); //define o campo do HMI da temperatura traseira
NexText p1_campo4 = NexText(1, 10, "t7p1"); //define o campo do HMI da temperatura do radiador
NexText p1_campo5 = NexText(1, 31, "t24p1"); //define o campo do HMI do caudal
NexText p1_campo6 = NexText(1, 28, "t25p1"); //define o campo do HMI da temperatura da  agua no reservatorio
NexText p1_campo7 = NexText(1, 20, "t16p1"); //define o campo do HMI da CPU
NexText p1_campo8 = NexText(1, 21, "t17p1"); //define o campo do HMI da RAM em USO
NexText p1_campo9 = NexText(1, 22, "t18p1"); //define o campo do HMI da RAM LIVRE
//NexText p1_campo10 = NexText(1, 16, "t12p1"); //define o campo do HMI das horas
//NexText p1_campo11 = NexText(1, 18, "t14p1"); //define o campo do HMI dos minutos
/*PAGINA 2*/
NexText p2_campo1 = NexText(2, 7, "t0p2"); //define o campo do HMI da temperatura de entrada
NexText p2_campo2 = NexText(2, 5, "t1p2"); //define o campo do HMI da temperatura inerior
NexText p2_campo3 = NexText(2, 6, "t2p2"); //define o campo do HMI da temperatura traseira
NexText p2_campo4 = NexText(2, 10, "t5p2"); //define o campo do HMI da temperatura do radiador
/*PAGINA 3*/
NexText p3_campo1 = NexText(3, 8, "t4p3"); //define o campo do HMI da temperatura de entrada
NexText p3_campo2 = NexText(3, 9, "t5p3"); //define o campo do HMI da temperatura inerior
NexText p3_campo3 = NexText(3, 10, "t6p3"); //define o campo do HMI da temperatura traseira
NexText p3_campo4 = NexText(3, 11, "t7p3"); //define o campo do HMI da temperatura do radiador
NexWaveform p3_onda = NexWaveform (3, 16, "s0p3");
/*PAGINA 4*/
NexText p4_campo1 = NexText(4, 8, "t3p4"); //define o campo do HMI da temperatura da  agua no reservatorio
NexText p4_campo2 = NexText(4, 4, "t4p4"); //define o campo do HMI do caudal
NexGauge p4_manometro1 = NexGauge(4, 10, "z0p4"); //define o campo do HMI do manometro
NexWaveform p4_onda = NexWaveform (4, 11, "s0p4");
/*PAGINA DEFINICOES (7)*/
NexText p5_campo1 = NexText(5, 12, "t3p7"); //mostra o fluxo de leitura do caudalimetro em valores brutos


//Variaveis
int RXLED = 17;            // The RX LED has a defined Arduino pro micro pin
float loading=0;           //loading
/*TEMPERATURAS*/
float temp_intake=0;       //
float temp_inside=0;       //
float temp_rear=0;         //Guarda os valores da temperatura
float temp_radiator=0;     //
float temp_reservatory=0;  //
/*CAUDALIMETRO*/
byte sensorInterrupt= 0;// 0 = digital pin 3
byte flowSensor= 3;
float calibrationFactor= 4.5;// The hall-effect flow sensor outputs approximately 4.5 pulses per second per litre/minute of flow.
volatile byte pulseCount=0;  
float flowRate=0;
unsigned long oldTime=0;
int flow_manometro=0;           //variavel para os valores do manometro
/*RECEBE OS VALORES DA STRING DO PROGRAMA EM C#*/
String strArr[3]; //Set the size of the array to equal the number of values you will be receiveing.
//String horasString= "0";
//String minutosString = "0";
String cpuValueString = "0";
String memUsedString = "0";
String memFreeString = "0";
/*VALORES CONVERTIDOS PARA O HMI*/
char hmi_temp_intake[3]="";        //
char hmi_temp_inside[3]="";        //
char hmi_temp_rear[3]="";          //
char hmi_temp_radiator[3]="";      //
char hmi_temp_reservatory[3]="";   //
char hmi_flow[3]="";               //Guarda os valores convertidos para o HMI
char hmi_flow_manometro[3]="";     //
//char hmi_horas[10]="";           //
//char hmi_minutos[10]="";         //
char hmi_cpu[3]="";                //
char hmi_ram_used[3]="";           //
char hmi_ram_free[3]="";           //


void setup(void){
  Serial.begin(9600);
  pinMode(RXLED, OUTPUT);  // Set RX LED as an output
  pinMode(flowSensor, INPUT);
  digitalWrite(flowSensor, HIGH);
  attachInterrupt(sensorInterrupt, pulseCounter, FALLING);// The Hall-effect sensor is connected to pin 3 which uses interrupt 0. Configured to trigger on a FALLING state change (transition from HIGHstate to LOW state)
  sensors.begin();
  nexInit();
}






























void loop(void){
//pagina de loading para carregar sensores
  if(loading<=100){

    digitalWrite(RXLED, LOW);   // set the LED off
    TXLED1;
    loading=loading+33;
    if(loading>100){
      loading=100;
    }
    p0_loading.setValue(loading);
    p0_firmware.setText(".V3_ProMicro");//Moastra a versão do firmware no HMI(Alterar sempre que for feito um update ao codigo)
    Serial.println(loading);
    TXLED0;
    digitalWrite(RXLED, HIGH);   // set the LED on
  }


//CAUDALIMETRO
  if((millis() - oldTime) > 1000)    // Only process counters once per second
  { 
    // Disable the interrupt while calculating flow rate and sending the value to the host
    detachInterrupt(sensorInterrupt);
        
    // Because this loop may not complete in exactly 1 second intervals we calculate
    // the number of milliseconds that have passed since the last execution and use
    // that to scale the output. We also apply the calibrationFactor to scale the output
    // based on the number of pulses per second per units of measure (litres/minute in
    // this case) coming from the sensor.
    flowRate = ((1000.0 / (millis() - oldTime)) * pulseCount) / calibrationFactor;

    // Note the time this processing pass was executed. Note that because we've
    // disabled interrupts the millis() function won't actually be incrementing right
    // at this point, but it will still return the value it was set to just before
    // interrupts went away.
    oldTime = millis();
    
    // Print the flow rate for this second in litres / minute
    Serial.println("> Flow rate: ");
    Serial.print(int(flowRate));  // Print the integer part of the variable
    Serial.println("L/min");
    
    //converte os valores para o maometro
    if(int(flowRate)==1){
      flow_manometro=90;
    }else if(int(flowRate)==2){
      flow_manometro=135;
    }else if(int(flowRate)==3){
      flow_manometro=160;
    }else if(int(flowRate)==4){
      flow_manometro=195;
    }else if(int(flowRate)>=5){
      flow_manometro=220;
    }else{
      flow_manometro=320;
    }
    
    // Reset the pulse counter so we can start incrementing again
    pulseCount = 0;

    // Enable the interrupt again now that we've finished sending output
    attachInterrupt(sensorInterrupt, pulseCounter, FALLING);
  }


//SENSORES TEMP
  sensors.requestTemperatures();
  
  if (sensors.getTempC(sensor_intake) > 0) {
  temp_intake = sensors.getTempC(sensor_intake);
  }else{temp_intake = 0;}
  if (sensors.getTempC(sensor_inside) > 0) {
  temp_inside = sensors.getTempC(sensor_inside);
  }else{temp_inside = 0;}
  if (sensors.getTempC(sensor_rear) > 0) {
  temp_rear = sensors.getTempC(sensor_rear);
  }else{temp_rear = 0;}
  if (sensors.getTempC(sensor_radiator) > 0) {
  temp_radiator = sensors.getTempC(sensor_radiator);
  }else{temp_radiator = 0;}
  if (sensors.getTempC(sensor_reservatory) > 0) {
  temp_reservatory = sensors.getTempC(sensor_reservatory);
  }else{temp_reservatory = 0;}

  /*Serial.print("> Temp - intake: ");
  Serial.print(temp_intake);
  Serial.print(" | inside: ");
  Serial.print(temp_inside);
  Serial.print(" | rear: ");
  Serial.print(temp_rear);
  Serial.print(" | temp radiator: ");
  Serial.print(temp_radiator);
  Serial.print(" | temp amb magiobd: ");
  Serial.print("> Temp water - magiobd: ");
  Serial.print(temp_magiobd_water);
  Serial.print(" | radiator in: ");
  //Serial.print(temp_radiator_in);
  Serial.print(" | radiator out: ");
  Serial.println(temp_radiator_out);*/


//RECEBE OS VALORES DO PROGRAMA EM C#
  String rxString = "";
  cpuValueString = "";
  //Keep looping until there is something in the buffer.
  while (Serial.available()) {
    //Delay to allow byte to arrive in input buffer.
    delay(1);
    //Read a single character from the buffer.
    char ch = Serial.read();
    //Append that single character to a string.
    rxString += ch;
  }
  int stringStart = 0;
  int arrayIndex = 0;
  for (int i = 0; i  < rxString.length(); i++) {
    //Get character and check if it's our "special" character.
    if (rxString.charAt(i) == ',') {
      //Clear previous values from array.
      strArr[arrayIndex] = "";
      //Save substring into array.
      strArr[arrayIndex] = rxString.substring(stringStart, i);
      //Set new string starting point.
      stringStart = (i + 1);
      arrayIndex++;
    }
  }
  //Put values from the array into the variables.
  cpuValueString = strArr[0];
  memUsedString = strArr[1];
  memFreeString = strArr[2];
//  horasString = strArr[3];
//  minutosString = strArr[4];

  /*Serial.print("CPU ");
  Serial.println(cpuValueString.toInt());
  Serial.print("RAM USED ");
  Serial.println(memUsedString.toInt());
  Serial.print("RAM FREE ");
  Serial.println(memFreeString.toInt());*/


// IMPRIMIR OS VALORES NO HMI NEXTION
  /*converte os valores para CHAR*/
  utoa(temp_intake, hmi_temp_intake, 10);
  utoa(temp_inside, hmi_temp_inside, 10);
  utoa(temp_rear, hmi_temp_rear, 10);
  utoa(temp_radiator, hmi_temp_radiator, 10);
  utoa(temp_reservatory, hmi_temp_reservatory, 10);  
  utoa(flowRate, hmi_flow, 10);
//  utoa(horasString.toInt(), hmi_horas, 10);
//  utoa(minutosString.toInt(), hmi_minutos, 10);
  utoa(cpuValueString.toInt(), hmi_cpu, 10);
  utoa(memUsedString.toInt(), hmi_ram_used, 10);
  utoa(memFreeString.toInt(), hmi_ram_free, 10);
  /*imprime no HMI*/
  p1_campo1.setText(hmi_temp_intake);
  p1_campo2.setText(hmi_temp_inside);
  p1_campo3.setText(hmi_temp_rear);
  p1_campo4.setText(hmi_temp_radiator);
  p1_campo5.setText(hmi_flow);
  p1_campo6.setText(hmi_temp_reservatory);
  p1_campo7.setText(hmi_cpu);
  p1_campo8.setText(hmi_ram_used);
  p1_campo9.setText(hmi_ram_free);
//  p1_campo10.setText(hmi_horas);
//  p1_campo11.setText(hmi_minutos);
  p2_campo1.setText(hmi_temp_intake);
  p2_campo2.setText(hmi_temp_inside);
  p2_campo3.setText(hmi_temp_rear);
  p2_campo4.setText(hmi_temp_radiator);
  p3_campo1.setText(hmi_temp_intake);
  p3_campo2.setText(hmi_temp_inside);
  p3_campo3.setText(hmi_temp_rear);
  p3_campo4.setText(hmi_temp_radiator);
  p3_onda.addValue(0,temp_intake);
  p3_onda.addValue(1,temp_inside);
  p3_onda.addValue(2,temp_rear);
  p3_onda.addValue(3,temp_radiator);
  p4_campo1.setText(hmi_temp_reservatory);
  p4_campo2.setText(hmi_flow);
  p4_manometro1.setValue(flow_manometro);
  p4_onda.addValue(0,temp_reservatory);
  
  delay(1); //Delay 1 sec.
}


void pulseCounter()
{
  // Increment the pulse counter
  pulseCount++;
}

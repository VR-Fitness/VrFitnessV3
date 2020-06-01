#include <BluetoothSerial.h>

#include <Wire.h>

// Code to retrieve heartrate information from the Polar Heart Rate Monitor Interface via I2C

#include "Wire.h"
#include <Arduino.h>
#include "BluetoothSerial.h"

#if !defined(CONFIG_BT_ENABLED) || !defined(CONFIG_BLUEDROID_ENABLED)
#error Bluetooth is not enabled! Please run `make menuconfig` to and enable it
#endif

#define HRMI_I2C_ADDR      127
#define HRMI_HR_ALG        1   // 1= average sample, 0 = raw sample
int lowHeartRate = 50; //BPM - change as needed
int highHeartRate = 200; //BPM - change as needed
int vibemotor = 13;    // motor is connected to digital pin 13

BluetoothSerial SerialBT;

void setup(){
     SerialBT.begin("ESP32Puls"); //Bluetooth device name
  Serial.println("The device started, now you can pair it with bluetooth!");    
  setupHeartMonitor(HRMI_HR_ALG);
  Serial.begin(9600);
  
  pinMode(vibemotor, HIGH); 
//  esp_bt.begin("heartbeat");
}

void loop(){

rdelay(3000); 

  int heartRate = getHeartRate();
  SerialBT.println(heartRate);
  if (SerialBT.available()) {

  delay(3000); //just here to slow down the checking to once a second
  
   int vibe = map(heartRate, lowHeartRate, highHeartRate, 0, 1024);
 
 if (heartRate > 125) {
   digitalWrite(vibemotor, HIGH);
 }
  else{
    digitalWrite(vibemotor, LOW);
  }
 
  }
}

void setupHeartMonitor(int type){
  //setup the heartrate monitor
  Wire.begin();
  writeRegister(HRMI_I2C_ADDR, 0x53, type); // Configure the HRMI with the requested algorithm mode
}

int getHeartRate(){
  //get and return heart rate
  //returns 0 if we couldnt get the heart rate
  byte i2cRspArray[3]; // I2C response array laver en array på 3 lang 
  i2cRspArray[2] = 0; // posin i arrayet er 2 lang 

  writeRegister(HRMI_I2C_ADDR,  0x47, 0x1); // Request a set of heart rate values 

  if (hrmiGetData(127, 3, i2cRspArray)) { // kald på get data sender adreese som er 127 som er HRMI og det array som sendes med ne 
    return i2cRspArray[2];
  }
  else{
    return 0;
  }
  
}

void writeRegister(int deviceAddress, byte address, byte val) {
  //I2C command to send data to a specific address on the device
  Wire.beginTransmission(deviceAddress); // start transmission to device 
  Wire.write(address);       // send register address
  Wire.write(val);         // send value to write
  Wire.endTransmission();     // end transmission
}

boolean hrmiGetData(byte addr, byte numBytes, byte* dataArray){
  //Get data from heart rate monitor and fill dataArray byte with responce
  //Returns true if it was able to get it, false if not
  Wire.requestFrom(addr, numBytes);
  if (Wire.available()) {

    for (int i=0; i<numBytes; i++){
      dataArray[i] = Wire.read();
    }

    return true;
  }
  else{
    return false;
  }
  
}

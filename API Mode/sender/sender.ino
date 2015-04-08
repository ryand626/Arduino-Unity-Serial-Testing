/*
 * Written by: Ryan Dougherty
 * Adapted From: http://cpham.perso.univ-pau.fr/ENSEIGNEMENT/PAU-UPPA/RESA-M2/intro-arduino-xbee.pdf
 * What it does:
 * creates an XBee Transmission 64 request at a specified Address (note the 16-bit MY address was used)
 * Hardware: Arduino Uno, XBee Wireless shield, XBee series 1 chip
 * Radio Chip Settings:
 *  DH: 0
 *  DL: FFFF
 *  MY: (ID OF TRANSMITTER)
*/
#include <XBee.h>

XBee xbee = XBee();
uint8_t* payload;
String data;

void setup(){
  data = "";
  Serial.begin(9600);
  xbee.begin(Serial);
}

void loop(){
  // Manipulate data (TODO: read arduino pins instead of hard coding)
  // DEVICE NUMBER
  data += "1,";
  // Button 1
  data += "0,";
  // Button 2
  data += "0,";
  // LED 1
  data += "0,";
  // LED 2
  data += "0,";
  // Potentiometer
  data += "000";
  
  // Make a new payload from the data
  delete [] payload;
  payload = new uint8_t[data.length()];
  for(int i = 0; i < data.length();i++){
    payload[i] = (uint8_t)data[i];
  }
  // Address of intended reciever using 16 bit MY as the lower bits
  XBeeAddress64 addr64 = XBeeAddress64(0x00000000, 0x00000000);
  // Create the packet with the payload
  Tx64Request tx64 = Tx64Request(addr64, payload, data.length());
  // Send the packet
  xbee.send(tx64);
  // Clear the Data
  data = "";
  
  delay(50);
}

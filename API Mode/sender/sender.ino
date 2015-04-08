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
// Unique Message of Sender
uint8_t payload[] = { 'y', 'o',' ','t','h','i','s',' ','c','r','e','y' };

void setup(){
    Serial.begin(9600);
    xbee.begin(Serial);
}

void loop(){
  // Address of intended reciever using 16 bit MY as the lower bits
  XBeeAddress64 addr64 = XBeeAddress64(0x00000000, 0x00000000);
  Tx64Request tx64 = Tx64Request(addr64, payload, sizeof(payload));

  xbee.send(tx64);
  //delay(50);
}

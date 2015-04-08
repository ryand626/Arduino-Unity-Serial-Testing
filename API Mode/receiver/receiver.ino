/* Written By: Ryan Dougherty
 * Adapted From: http://cpham.perso.univ-pau.fr/ENSEIGNEMENT/PAU-UPPA/RESA-M2/intro-arduino-xbee.pdf
 * What it does:
 * Recieves an XBee 64 bit response packet, and prints its data out to Serial
 * Hardware: Arduino Uno, XBee Wireless shield, XBee series 1 chip
 * Radio Chip Settings:
 *  DH: 0
 *  DL: FFFF
 *  MY: (ID OF RECIEVER)
 */
#include <XBee.h>
#include <SoftwareSerial.h>

XBee xbee = XBee();

uint8_t* payload;
uint8_t payload_len;

Rx16Response rx16 = Rx16Response();

void setup() {
  xbee.begin(Serial);
  Serial.begin(9600);
}

void loop() {
  // read incoming packet
  xbee.readPacket();
  if (xbee.getResponse().isAvailable()) {
    if (xbee.getResponse().getApiId() == RX_16_RESPONSE) {
      xbee.getResponse().getRx16Response(rx16);
      payload = rx16.getData();
      payload_len = rx16.getDataLength();
      
      // Print out the message
      for (int i = 0; i < payload_len; i++){
        Serial.print((char)payload[i]);
      }
      // Print a newline
      Serial.println(" ");
    }
  }
}

// This is just me testing out code.....you can ignore it

#include <SoftwareSerial.h>

SoftwareSerial XBee(0, 1); // RX, TX
void setup()
{
  // Set up both ports at 9600 baud. This value is most important
  // for the XBee. Make sure the baud rate matches the config
  // setting of your XBee.
  XBee.begin(9600);
  Serial.begin(9600);
}

void loop()
{
  
  if (Serial.available())
  { // If data comes in from serial monitor, send it out to XBee
    XBee.write(Serial.read());
    XBee.write("Hello friend!");
    //Serial.println("SENDING SERIAL");
  }
  if (XBee.available())
  { // If data comes in from XBee, send it out to serial monitor
    Serial.write(XBee.read());
   // XBee.write("SENDING XBEE");
  }
  
}

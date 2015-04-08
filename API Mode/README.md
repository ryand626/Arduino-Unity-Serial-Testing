# API MODE

The XBee API mode library for Arduino 

## Software
- [Arduino IDE] (http://arduino.cc/en/Main/Software)
- [API mode for Arduino] (https://code.google.com/p/xbee-arduino/)
- [XCTU] (http://www.digi.com/support/productdetail?pid=3352&type=utilities)

## Hardware
- [Arduino UNO] (http://arduino.cc/en/main/arduinoBoardUno)
- [Wireless Shield] (http://arduino.cc/en/Main/ArduinoXbeeShield)
- [XBee Series 1 Chip] (http://www.digi.com/products/wireless-wired-embedded-solutions/zigbee-rf-modules/point-multipoint-rfmodules/xbee-series1-module#overview)

## Hardware Configuration
Each Xbee is set to API mode with a DH of 0, and DL of FFFF.  The MY of the receiver is set to 0.  The other MY's are set arbitrarily (1-4 in my case).

XCTU was used to program the XBee radio modules.

## Sender
Sends packets to the address of the receiver

## Receiver 
Listens for packets, and then prints them to serial

## References:
[Useful PDF from Université de Pau](http://cpham.perso.univ-pau.fr/ENSEIGNEMENT/PAU-UPPA/RESA-M2/intro-arduino-xbee.pdf)
[David Beath Blog](https://davidbeath.com/posts/reading-xbee-rssi-with-arduino.html)
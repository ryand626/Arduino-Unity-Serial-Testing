// This program writes random x, y, and z coordinates out to the
// Serial port in a CSV format
// Written by Ryan Dougherty
// Last updated 3/4/15

#define RANDOM_SPREAD 255 // The +/- spread of the coordinates
// packet number could help identify lost packets in a later version
int packetsIn = 0;
int packetsOut = 0;
// The message to be sent
String message;
// The coordinates
int x;
int y;
int z;

void setup() {
  message = "";              // make the message blank
  Serial.begin(9600);        // initialize the serial port
  randomSeed(analogRead(0)); // seed the random number generator
}
void loop() {
  // ===Send Data===
  
  // randomize coordinates
  x = random(-1*RANDOM_SPREAD, RANDOM_SPREAD);
  y = random(-1*RANDOM_SPREAD, RANDOM_SPREAD);
  z = random(-1*RANDOM_SPREAD, RANDOM_SPREAD);
  
  // print out the coordinates to the serial port in CSV format
  Serial.print(x);
  Serial.print(",");
  Serial.print(y);
  Serial.print(",");
  Serial.println(z);

  // packetsOut++; // unused for now but might be used later
  // delay(1000); // NO BRAKES!
  
  // ===Receive Data===
  //if (Serial.available()) {
  //    message = Serial.readStringUntil('\n');
  //    Serial.println(message);
  //    Serial.flush();
  //}
}


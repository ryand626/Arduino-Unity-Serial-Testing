# AT Mode

It should be noted that this only works for Windows machines

## Purpose
To visualize the speed of data transfer from **Arduino** to **XBee** to **Unity 3D** via the serial port

## Arduino Side
- The Arduino generates 3 random numbers in the range -RANDOM_SPREAD to RANDOM_SPREAD.
- The random numbers are then written to the **serial port**, separated by commas.
- The serial information is written to **XBee** and sent wirelessly

## XBee Side
- In **AT** mode, information is received from the Arduino and displayed *transparently* on the **serial port**.

## Unity Side
- The program opens a connection to the **serial port**.
- The program reads in a line from the serial port.
- The line is parsed into x, y and z coordinates.
- The position of the cube is updated.

**For fun**

I added a spinning camera, a container for the cube, and the ability to change the way the camera rotates by pressing spacebar.

## Driver Notes
[Download drivers for XBee here: ](http://www.digi.com/support/productdetail?pid=3257)

**To Program**
Make sure the jumpers are set to 'USB'

**To use XBee Communication**
Make sure the jumpers are set to 'XBee'

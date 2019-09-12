# Navigation-System

Design description
 Version Control    : Github
 project language   : C#
 User Inputs/OutPut : Console
 
 Input formart : zX zY rX rY rD MOVEMENTS(MRL)
               description: zX and zY ->  x and y coordinates of the Zone's bounds 
                          : rX,rY and xD -> x and y are start coordinate and rD is the direction the Rover is facing( only N,E,S and W can                             be used)
                          :	MRL -> movement list without spaces (only M,R and L can be used)
               Note: all inputs must be separated by single space except for movement list. eg: 12 20 2 2 E MMMMMMRMLLMMM	
               
 Output Format : rX rY rE
                (Command status)
                
 Functional Description
  -first run of the Program will require input from user through console
  -validate user inputs(return failed command status if not valid)
  -create 2D world and rover start coordinate
  -execute movements list(if The Rover's next move is out of bounds,terminate and return the current coordinate and failed command status)
  -all commands were successfully executed  there return new coordinatesof the rover  



Tesing Strategy

After reading and analying the project requirments and uses cases
i have decided to use the To-Down Intergration Testing.
the main reason for this is that the main program will be writen/executed first
before the sub components/Modules such as the zone(2D world) , movements of the rover
and update will be built/rely on the inputs from the main program.

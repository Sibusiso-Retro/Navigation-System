using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation
{
    public class Command
    {
        //constructors
        public Command() { }
        public Command(string input)
        {
            string[] parameters = input.Split(' ');
            ZoneX = Int32.Parse(parameters[0]);
            ZoneY = Int32.Parse(parameters[1]);
            RoverX = Int32.Parse(parameters[2]);
            RoverY = Int32.Parse(parameters[3]);
            RoverD = char.Parse(parameters[4]);
            Moves = new List<char>(0);
            for (int i = 0; i < parameters[5].Length; i++)//add each char of the string into Moves List
            {
                Moves.Add(parameters[5][i]);
            }
        }
        public Command(int zoneX, int zoneY, int roverX, int roverY, char roverD, List<char> moves)
        {
            ZoneX = zoneX;
            ZoneY = zoneY;
            RoverX = roverX;
            RoverY = roverY;
            RoverD = roverD;
            Moves = moves;
        }

        //getters and setters
        public int ZoneX { get; set; }
        public int ZoneY { get; set; }
        public int RoverX { get; set; }
        public int RoverY { get; set; }
        public char RoverD { get; set; }
        public List<char> Moves { get; set; }
        public string GetRoverCoordinates()
        {
            return RoverX + " " + RoverY + " " + RoverD;
        }
        //operations
        public string ExecuteNavigationMovements()
        {
            string output = "";
            for(int i = 0; i < Moves.Count; i++)//execute all rover moves
            {
                if (isDirection(Moves.ElementAt(i)))
                {
                    updateRoverDirection(Moves.ElementAt(i));//update rover's direction
                }
                else
                {
                    output = updateRoverCoordinate(Moves.ElementAt(i));
                    if (!output.Equals("pass"))//if movement did not pass then termination, else continue executing movements
                    {
                        return output;
                    }
                }
            }
            return "pass";//all movements executed successfully
        }
        public string updateRoverCoordinate(char m)
        {
            if(RoverD == 'N' && RoverY < ZoneY)
            {
                RoverY++;
            }else if (RoverD == 'E' && RoverX < ZoneX)
            {
                RoverX++;
            }
            else if (RoverD == 'S' && RoverY >= 1)
            {
                RoverY--;
            }
            else if (RoverD == 'W' && RoverX >= 1)
            {
                RoverX--;
            }
            else
            {
                return "Rover cannot move outside safe zone";
            }

            return "pass";
        }
        public char updateRoverDirection(char m)
        {
            //N =1(also 5), E = 2. S = 3, W = 4(also 0)
            //R -> +
            //L => -
            int currentD = DirectionToNumber(RoverD);
            if(m == 'R')//Add
            {
                currentD++; //might go to 5
            }
            else//subtract
            {
                currentD--; //might go to 0
            }
            //convert back from Number to character(direction)
            if (currentD == 1 || currentD == 5) RoverD = 'N';
            if (currentD == 2) RoverD = 'E'; 
            if (currentD == 3) RoverD = 'S';
            if (currentD == 4 || currentD == 0) RoverD = 'W';
            return RoverD;

        }
        private int DirectionToNumber(char c)
        {
            int num = 0;
            switch (c)
            {
                case 'N':
                    num = 1;
                    break;
                case 'E':
                    num = 2;
                    break;
                case 'S':
                    num = 3;
                    break;
                default:
                    num = 4;
                    break;
            }
            return num;
        }
        private bool isDirection(char m)//check if current character is move(M) or Direction(R or L)
        {
            if(m == 'R' || m == 'L')
            {
                return true;
            }
            return false;
        }
    }
}
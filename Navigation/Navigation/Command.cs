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
    }
}
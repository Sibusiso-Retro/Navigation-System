using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationSystem
{
    public static class Validator
    {
        //User Inputs Validation
        public static string InputParameterCount(string input)
        {
            int count = input.Split(' ').Length;
            if (count != 6)
            {
                return "number of parameters must be 6, eg: zX(1) zY(2) rX(3) rY(4) rD(5) MOVEMENTS(6)";
            }
            else
            {
                return "pass";
            }
        }
        public static string NumberCheck(string value)
        {
            try
            {
                int num = int.Parse(value);
                if (num <= 0)
                {
                    throw new Exception("");
                }
                return "pass";
            }
            catch (Exception e)
            {
                return "zX,zY,rX,rY and rD must be a positive number";
            }
        }
        public static string RoverStartCoordinateCheck(int zX, int zY, int rX, int rY)
        {
            //ensure that rY <= zY and rX <= zX (Safe zone)
            if (zX < rX)
            {
                return "Rover start position must be within the safe Zone: rY <= zY and rX <= zX";
            }
            else if (zY < rY)
            {
                return "Rover start position must be within the safe Zone: rY <= zY and rX <= zX";
            }
            else
            {
                return "pass";
            }
        }
        public static string RoverDirectionCheck(string RD)
        {
            if ((RD.Length == 1 && NumberCheck(RD) != "pass") && RD == "N" || RD == "E" || RD == "S" || RD == "W")
            {
                return "pass";
            }
            else
            {
                return "RD(Rover Direction) can only be N,E,S or W";
            }
        }
        public static string RoverMovementsCheck(string Moves)
        {
            for (int i = 0; i < Moves.Length; i++)
            {
                if (Moves[i] != 'M' && Moves[i] != 'R' && Moves[i] != 'L')
                {
                    return "Movements can only contain M,R or L";
                }
            }
            return "pass";
        }
        //Main program and User Input Intergration Validation
        public static string UserInputComand(string strInputComand)
        {
            string output = InputParameterCount(strInputComand);
            if (!output.Equals("pass"))
            {
                return output;
            }

            //separate all paramenters into a string array
            string[] parameters = strInputComand.Split(' ');
            for (int i = 0; i < 4; i++)
            {
                output = NumberCheck(parameters[i]);
                if (!output.Equals("pass"))// check if the first for inputs are valid positive numbers
                {
                    return output;
                }
            }
            //validate rover start location
            output = RoverStartCoordinateCheck(int.Parse(parameters[0]), int.Parse(parameters[1]), int.Parse(parameters[2]), int.Parse(parameters[3]));
            if (!output.Equals("pass"))
            {
                return output;
            }
            //validate rover initial direction
            output = RoverDirectionCheck(parameters[4]);
            if (!output.Equals("pass"))
            {
                return output;
            }
            output = RoverMovementsCheck(parameters[5]);
            if (!output.Equals("pass"))
            {
                return output;
            }
            //final success output
            return output;
        }
    }
}
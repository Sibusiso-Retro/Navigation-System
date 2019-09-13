using System;

namespace Navigation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter navigation comands[ zX zY rX rY rD MOVEMENTS]:");
            string navInstructions = Console.ReadLine().ToUpper();

            //Validate User Input, if all parameters are valid continue ,else terminate.
            String status = Validator.UserInputComand(navInstructions);
            if (status != "pass")
            {
                Console.WriteLine(status);
                Console.ReadKey();
                return;
            }

            //create Navigation Command Object,this stage all user input parameters are valid
            Command navigationCommand = new Command(navInstructions);

            //Navigate Rover to new Coordinate
            status = navigationCommand.ExecuteNavigationMovements();
            string output = navigationCommand.GetRoverCoordinates();
            if (!status.Equals("pass"))//if not all the Movement commands were executed diplay updated rover coordinates and a failed status 
            {
                output += '\n' + status;
            }
            else
            {
                output += "\n Rover Navigation successful";
            }
            
            //display results on console
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
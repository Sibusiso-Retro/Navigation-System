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

            Console.WriteLine("User input valid");
            Console.ReadKey();
        }
    }
}
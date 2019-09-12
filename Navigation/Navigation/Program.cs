using System;

namespace NavigationSystem
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
            Console.WriteLine("User input valid");
            Console.ReadKey();
        }
    }
}
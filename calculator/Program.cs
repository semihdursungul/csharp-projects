using System;

namespace SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Calculator");

            while (true)
            {
                Console.WriteLine("Enter the first number:");
                double num1 = GetNumberFromUser();

                Console.WriteLine("Enter the operator (+, -, *, /):");
                char op = GetOperatorFromUser();

                Console.WriteLine("Enter the second number:");
                double num2 = GetNumberFromUser();

                double result = 0;

                switch (op)
                {
                    case '+':
                        result = num1 + num2;
                        break;
                    case '-':
                        result = num1 - num2;
                        break;
                    case '*':
                        result = num1 * num2;
                        break;
                    case '/':
                        result = num2 != 0 ? num1 / num2 : double.NaN;
                        break;
                    default:
                        Console.WriteLine("Invalid operator.");
                        continue;
                }

                Console.WriteLine("Result: " + result);
                Console.WriteLine("Press 'Q' to quit or any other key to continue.");
                if (Console.ReadKey().Key == ConsoleKey.Q)
                    break;

                Console.Clear();
            }
        }

        static double GetNumberFromUser()
        {
            double number;
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Invalid input. Please enter a valid number:");
            }
            return number;
        }

        static char GetOperatorFromUser()
        {
            char op;
            while (!char.TryParse(Console.ReadLine(), out op) || !IsOperatorValid(op))
            {
                Console.WriteLine("Invalid operator. Please enter a valid operator (+, -, *, /):");
            }
            return op;
        }

        static bool IsOperatorValid(char op)
        {
            return op == '+' || op == '-' || op == '*' || op == '/';
        }
    }
}

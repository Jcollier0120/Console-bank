using System;

namespace ConsoleBank
{
    class Program
    {
        static int accountNumber = 0;

        static string accountNumberInput = string.Empty;
        static string accountNumberLast4 = string.Empty;

        static decimal totalFunds = new decimal(150.00);

        static void Main(string[] args)
        {
            if (validateAccount())
            {
                displayOptions();
            }

            promptForMenu();
        }

        private static void promptForMenu()
        {
            Console.WriteLine("Press 'y' to return to the menu or any other key to exit");

            var input = Console.ReadLine();
            if (input.ToLower() == "y")
            {
                displayOptions();
                promptForMenu();
            }

        }

        private static void displayOptions()
        {
            Console.WriteLine("Available options:");
            Console.WriteLine("1. Deposit funds");
            Console.WriteLine("2. Withdraw funds");
            Console.WriteLine("3. View funds");

            var input = int.Parse(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.WriteLine("Please enter amount to deposit in USD.");
                    decimal depositDecimal;
                    decimal.TryParse(Console.ReadLine(), out depositDecimal);
                    if (depositDecimal > 0)
                    {
                        depositFunds(depositDecimal);
                    }
                    break;
                case 2:
                    Console.WriteLine("Please enter amount to withdraw in USD.");
                    decimal withdrawalDecimal;
                    decimal.TryParse(Console.ReadLine(), out withdrawalDecimal);
                    if (withdrawalDecimal > 0)
                    {
                        withdrawFunds(withdrawalDecimal);
                    }
                    break;
                case 3:
                    viewFunds();
                    break;
                default:
                    Console.WriteLine("That is not a valid option");
                    displayOptions();
                    break;
            }
        }

        private static void depositFunds(decimal depositAmount)
        {
            totalFunds += depositAmount;
            Console.WriteLine($"Succesfully deposited ${depositAmount} into account ending in {accountNumberLast4}");
            Console.WriteLine($"Available funds: ${totalFunds}");
        }

        private static void withdrawFunds(decimal withdrawalAmount)
        {
            if (withdrawalAmount <= totalFunds)
            {
                totalFunds -= withdrawalAmount;
                Console.WriteLine($"Succesfully withdrew ${withdrawalAmount} from account ending in {accountNumberLast4}");
                Console.WriteLine($"Available funds left: ${totalFunds}");
            }
            else
            {
                Console.WriteLine("Insufficient funds");
            }
        }

        private static void viewFunds()
        {
            Console.WriteLine($"Funds available in account ending in {accountNumberLast4}: ${totalFunds}");
        }

        /// <summary>
        /// Superficial validation on account number
        /// Ensure it is 10-digits and numerical
        /// </summary>
        /// <returns></returns>
        private static bool validateAccount()
        {
            Console.WriteLine("Please enter your account number");
            accountNumberInput = Console.ReadLine();

            if (accountNumberInput.Length != 10)
            {
                Console.WriteLine("Account number must be 10 digits long");
                validateAccount();
            }
            else if (!int.TryParse(accountNumberInput, out accountNumber))
            {
                Console.WriteLine("Account number must be comprised of numbers only.");
                validateAccount();
            }
            accountNumberLast4 = accountNumberInput.Substring(accountNumberInput.Length - 4, 4);

            return true;
        }
    }
}

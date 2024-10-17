namespace Home_Sales_PT_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] salesNames = { "Danielle", "Edward", "Francis" };
            char[] salesInitials = { 'D', 'E', 'F' };
            double[] salesTotals = new double[salesNames.Length];

            // User input variables
            char salesRep;
            double saleAmount;

            // Prompting for salesRep initials until the user enters 'Z'
            do
            {
                Console.Write("Enter a salesRep initial of D, E, or F, then select Z to end input: ");
                salesRep = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                // Checking if user input is for a valid salesRep
                int index = Array.IndexOf(salesInitials, salesRep);
                if (index != -1) // Valid salesRep
                {
                    Console.Write("Enter a sale amount: ");
                    if (double.TryParse(Console.ReadLine(), out saleAmount) && saleAmount > 0)
                    {
                        // Adding the sales to the correct salesRep's total
                        salesTotals[index] += saleAmount; // Update the total using the index
                    }
                    else
                    {
                        Console.WriteLine("Invalid number, please enter a valid number and try again");
                    }
                }
                else if (salesRep != 'Z')
                {
                    Console.WriteLine("Error, invalid salesperson selected, please try again");
                }

            } while (salesRep != 'Z');

            // Totals printed
            for (int i = 0; i < salesNames.Length; i++)
            {
                Console.WriteLine($"{salesNames[i]}'s total: {salesTotals[i]:C}");
            }

            double grandTotal = 0;
            for (int i = 0; i < salesTotals.Length; i++)
            {
                grandTotal += salesTotals[i];
            }
            Console.WriteLine($"Grand total: {grandTotal:C}");

            // If statement showing the sales rep with the highest sales total
            int highestIndex = 0; // Index of the salesperson with the highest sales total
            for (int i = 1; i < salesTotals.Length; i++)
            {
                if (salesTotals[i] > salesTotals[highestIndex])
                {
                    highestIndex = i; // Update the highestIndex if current total is greater
                }
            }

            Console.WriteLine($"Highest sale: {salesInitials[highestIndex]}");
        }
    }
    }


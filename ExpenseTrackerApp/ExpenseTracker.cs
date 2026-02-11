using System;
namespace ExpenseTrackerApp
{
    class ExpenseTracker
    {
        public class Expense
        {
            // Vars for the expense class
            public string Description { get; set; }
            public decimal Amount { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }

            // Constructor for the expense class (could also use a primary constructor)
            public Expense(string description, decimal amount, string category) 
            {
                Description = description;
                Amount = amount;
                Category = category;
                Date = DateTime.Now;
            }

            // TODO: Override ToString() method to display expense details in a readable format

        }


        static void Main(string[] args)
        {
            List<Expense> expensesList = new List<Expense>(); // List to store expenses
            while (true)
            {
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View All Expenses");
                Console.WriteLine("3. View Expenses by Category");
                Console.WriteLine("4. View Total Spending");
                Console.WriteLine("5. Exit");
                Console.WriteLine("");

                Console.WriteLine("Select an option: ");

                int userInput = Convert.ToInt32(Console.ReadLine()); // Gets the user input and converts it to an integer
                Console.WriteLine("");

                switch (userInput)
                {
                    // Add expense
                    case 1:
                        Expense newExpense = new Expense("", 0, "");

                        Console.WriteLine("Please input the expense description");
                        newExpense.Description = Console.ReadLine() ?? "No description provided";

                        Console.WriteLine("Please input expense amount");
                        newExpense.Amount = Convert.ToDecimal(Console.ReadLine()); // Gets the expense amount from the user and converts it to a decimal

                        Console.WriteLine("Please input expense category");
                        newExpense.Category = Console.ReadLine() ?? "No category provided";

                        expensesList.Add(newExpense); // Add the new expense created to the list of expenses
                        Console.WriteLine("");

                        // Print out the new expense
                        Console.WriteLine("New Expense Added...");
                        Console.WriteLine($"{expensesList.Last().Description}");
                        Console.WriteLine($"Amount: {expensesList.Last().Amount:C}");
                        Console.WriteLine($"Category: {expensesList.Last().Category}");
                        Console.WriteLine("");

                        break;

                    // View all expenses
                    case 2:
                        if(expensesList.Count > 0)
                        {
                            for (int i = 0; i < expensesList.Count; i++)
                            {
                                Console.WriteLine($"{expensesList[i].Description}");
                                Console.WriteLine($"Amount: {expensesList[i].Amount:C}");
                                Console.WriteLine($"Category: {expensesList[i].Category}");
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No expenses have been added yet");
                        }
                        Console.WriteLine("");
                        break;

                    // View expense by category
                    case 3:



                        break;
                    case 4:
                        break;
                    case 5:
                        Console.WriteLine("Exiting the program...");
                        return; // Exits the program
                }
            }
        }
    }
}
using System;
namespace ExpenseTrackerApp
{
    class ExpenseTracker
    {
        public static void PrintExpensesInList(List<Expense> expensesList) 
        {
            if (expensesList.Count > 0)
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
        }

        public static int GetIntInput(string input)
        {
            int resultInt;
            while (true)
            {
                if (int.TryParse(input, out resultInt))
                {
                    Console.WriteLine($"Good Input. You entered: {resultInt}");
                    break;
                }
                else
                {
                    // If the user typed "abc", this code runs instead of crashing
                    Console.WriteLine("Invalid input. Please enter a whole number.");
                }
            }
            return resultInt;
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


                int userInput;
                while (true)
                {
                    Console.WriteLine("Select an option: ");
                    string input = Console.ReadLine() ?? "";

                    if (int.TryParse(input, out userInput))
                    {
                        break; // Exit the loop because we have a valid number
                    }

                    Console.WriteLine($"\"{input}\" is not a number. Please reinput selection");
                    Console.WriteLine("");
                }
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
                        PrintExpensesInList(expensesList);
                        break;

                    // View expense by category
                    case 3:
                        Console.WriteLine("What category would you like to view?");
                        string categoryInput = Console.ReadLine() ?? "";

                        List<Expense> categoryList = expensesList.Where(e => e.Category == categoryInput).ToList(); // Make a new list to hold the returned expenses

                        PrintExpensesInList(categoryList); // Prints the expenses that were returned based on the category

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
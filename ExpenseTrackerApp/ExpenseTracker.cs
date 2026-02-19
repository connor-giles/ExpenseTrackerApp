using System;
namespace ExpenseTrackerApp
{
    class ExpenseTracker
    {
        public static void ViewAllExpenses(List<Expense> expensesList) 
        {
            if (expensesList.Count > 0)
            {
                for (int i = 0; i < expensesList.Count; i++)
                {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine($"Name: {expensesList[i].Description}");
                    Console.WriteLine($"Amount: {expensesList[i].Amount:C}");
                    Console.WriteLine($"Category: {expensesList[i].Category}");
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("");
                }
                decimal maxExpense = expensesList.Max(e => e.Amount);
                decimal minExpense = expensesList.Min(e => e.Amount);
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Largest Expense: {maxExpense:C}");
                Console.WriteLine($"Smallest Expense: {minExpense:C}");
                Console.WriteLine("-------------------------------");
            }
            else
            {
                Console.WriteLine("No expenses have been added yet");
            }
            Console.WriteLine("");
        }

        // TODO: Make AddExpense() method
        // TODO: Make GetTotalSpending() method
        // TODO: Improve deletion method
        // TODO: Create average expense amount menu option
        // TODO: Find the highest/lowest expense using LINQ .Max() / .Min()
        // TODO: Group expenses by category and show subtotals
        static void Main(string[] args)
        {
            List<Expense> expensesList = []; // List to store expenses
            while (true)
            {
                Console.WriteLine("1. Add Expense");
                Console.WriteLine("2. View All Expenses");
                Console.WriteLine("3. View Expenses by Category");
                Console.WriteLine("4. View Total Spending");
                Console.WriteLine("5. Delete Expense");
                Console.WriteLine("0. Exit");
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

                        // New expense description
                        Console.WriteLine("Please input the expense description");
                        newExpense.Description = Console.ReadLine() ?? "No description provided";

                        // Get the expense amount and check for validity, must be positive, and a number
                        Console.WriteLine("Please input expense amount");
                        decimal validatedExpense;
                        while(!decimal.TryParse(Console.ReadLine(), out validatedExpense) || validatedExpense <= 0) // Continues to ask for user input until the value is satisfactory
                        {
                            Console.WriteLine("Invalid expense input. Please enter a positive numerical amount (e.g. 12.50)");
                        }
                        newExpense.Amount = validatedExpense;


                        // New expense category
                        // TODO: Add function that allows user to input category from a list
                        Console.WriteLine("Please input expense category");
                        newExpense.Category = Console.ReadLine() ?? "No category provided";

                        expensesList.Add(newExpense); // Add the new expense created to the list of expenses
                        Console.WriteLine("");

                        // Print out the new expense
                        Console.WriteLine("New Expense Added");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine($"Name: {expensesList.Last().Description}");
                        Console.WriteLine($"Amount: {expensesList.Last().Amount:C}");
                        Console.WriteLine($"Category: {expensesList.Last().Category}");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("");

                        break;

                    // View all expenses
                    case 2:
                        Console.WriteLine("All Recorded Expenses");
                        ViewAllExpenses(expensesList);
                        break;

                    // View expense by category
                    case 3:
                        Console.WriteLine("What category would you like to view?");
                        string categoryInput = Console.ReadLine() ?? "";

                        List<Expense> categoryList = expensesList.Where(e => e.Category == categoryInput).ToList(); // Make a new list to hold the returned expenses

                        Console.WriteLine("");
                        //PrintExpensesInList(categoryList); // Prints the expenses that were returned based on the LINQ
                        break;

                    // View total spending
                    case 4:
                        decimal totalSpending = expensesList.Sum(e => e.Amount); // Sum up all the expenses

                        // Print the total expenses
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine($"Total Expenses: {expensesList.Count}");
                        Console.WriteLine($"Total Amount:   {totalSpending:C}");
                        Console.WriteLine("-------------------------------");
                        Console.WriteLine("");

                        break;

                    // Delete Expense
                    case 5:
                        if(expensesList.Count > 0) 
                        {
                            // Prompt user for which expense to delete
                            Console.WriteLine("Which expense would you like to delete? (must match description)"); // TODO: improve this ability to delete expenses
                            string expenseToDelete = Console.ReadLine() ?? string.Empty;
                            
                            // Find that expense in the expensesList (using LINQ)
                            Expense? toDelete = expensesList.FirstOrDefault(e => e.Description == expenseToDelete);

                            // Delete that entry from the list of expenses
                            if (toDelete != null)
                            {
                                expensesList.Remove(toDelete);
                                Console.WriteLine($"{toDelete.Description} has been deleted");
                                Console.WriteLine("");
                            }
                            else
                            {
                                Console.WriteLine("Could not find an expense with that description");
                            }
                        }
                        else
                        {   
                            Console.WriteLine("No expenses have been added yet");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Exiting the program...");
                        return; // Exits the program

                    default:
                        Console.WriteLine("Invalid Menu Input, Try Again");
                        break;
                }
            }
        }
    }
}
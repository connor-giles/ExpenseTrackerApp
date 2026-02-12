using System;
using System.Collections.Generic;
using System.Text;

namespace ExpenseTrackerApp
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
}

﻿using SplitSage.Bot.Telegram.Features.Users;

namespace SplitSage.Bot.Telegram.Features.Expenses;

public class ExpenseShare
{
    public Guid Id { get; set; }
    
    public Guid ExpenseId { get; set; }
    public Expense Expense { get; set; }
    
    public Guid UserId { get; set; }  // The user who owes money
    public User User { get; set; }

    public decimal Amount { get; set; }
}
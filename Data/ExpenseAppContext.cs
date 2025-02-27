using ExpenseApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApp.Data;

public class ExpenseAppContext : DbContext
{
    public ExpenseAppContext(DbContextOptions<ExpenseAppContext> options) : base(options) {}

    public DbSet<Expense> Expenses { get; set; }
}
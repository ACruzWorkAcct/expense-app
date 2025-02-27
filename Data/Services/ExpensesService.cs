using ExpenseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApp.Data.Services;

public class ExpensesService : IExpensesService
{
    private readonly ExpenseAppContext _context;

    public ExpensesService(ExpenseAppContext context) => _context = context;

    public async Task<IEnumerable<Expense>> GetAll()
    {
        var expenses = await _context.Expenses.ToListAsync();

        return expenses;
    }

    public async Task Add(Expense expense)
    {
        _context.Expenses.Add(expense);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(int? id)
    {
        var expense = await _context.Expenses
            .FirstOrDefaultAsync(x => x.Id == id);

        if (expense != null)
        {
            _context.Expenses.Remove(expense);
        }

        await _context.SaveChangesAsync();
    }

    public IQueryable GetChartData()
    {
        var data = _context.Expenses
            .GroupBy(g => g.Category)
            .Select(e => new {
                Category = e.Key,
                Total = e.Sum(e => e.Amount)
            });

        return data;
    }
}
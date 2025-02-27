using ExpenseApp.Models;

namespace ExpenseApp.Data.Services;

public interface IExpensesService
{
    Task<IEnumerable<Expense>> GetAll();
    Task Add(Expense expense);
    Task Delete(int? id);
    IQueryable GetChartData();
}

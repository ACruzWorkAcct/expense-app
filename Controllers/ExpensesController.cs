using ExpenseApp.Data;
using ExpenseApp.Data.Services;
using ExpenseApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseApp.Controllers;

public class ExpensesController : Controller
{
    private readonly IExpensesService _expensesService;

    public ExpensesController(IExpensesService expensesService) => _expensesService = expensesService;

    public async Task<IActionResult> Index()
    {
        var expenses = await _expensesService.GetAll();
        return View(expenses);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Expense expense)
    {
        if (ModelState.IsValid)
        {
            await _expensesService.Add(expense);

            return RedirectToAction("Index");
        }

        return View(expense);
    }

    public async Task<IActionResult> Delete(int id)
    {
        await _expensesService.Delete(id);

        return RedirectToAction("Index");
    }

    public IActionResult GetChart()
    {
        var data = _expensesService.GetChartData();

        return Json(data);
    }
}

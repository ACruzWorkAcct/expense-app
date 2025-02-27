using System.ComponentModel.DataAnnotations;

namespace ExpenseApp.Models;

public class Expense
{
    public int Id { get; set; }
    public string? Description { get; set; }
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Higher than 0 required.")]
    public double Amount { get; set; }
    [Required]
    public string? Category { get; set; }
    public DateTime Date { get; set; } = DateTime.Now;
}

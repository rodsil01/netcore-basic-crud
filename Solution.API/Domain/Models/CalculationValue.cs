using System.ComponentModel.DataAnnotations;

namespace Calculator.API.Domain.Models;


public class CalculatorValue {
    [Key]
    public Guid Id { get; set; }
    public Guid GroupId { get; set; }
    public double Value { get; set; }
    public DateTime CreatedDate { get; set; }
}

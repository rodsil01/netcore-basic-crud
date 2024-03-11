using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Calculator.API.Domain.Models;


public class Position {
    [Key]
    public Guid Id { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int GenId { get; set; }
    public string? Description { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.DataAccess.Entities;

[Table("Klines")]
public class KlineEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    public string Interval { get; set; } = string.Empty;

    public long StartTime { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }
    public decimal Volume { get; set; }
    public decimal Turnover { get; set; }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyProject.Domain.BybitModels.Prices;

namespace ByBit.DataAccess.Entities;

[Table("Klines")]
public class KlineEntity : Kline
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Symbol { get; set; } = string.Empty;

    [Required]
    public Interval Interval { get; set; }
}

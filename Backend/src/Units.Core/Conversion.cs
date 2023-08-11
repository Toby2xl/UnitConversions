namespace Units.Core;

public class Conversion : EntityBase<int>
{
    public string Units { get; set; } = string.Empty;
    public string Dimension { get; set; } = string.Empty;
    public decimal Factor { get; set; }
}

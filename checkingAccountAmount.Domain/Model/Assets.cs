namespace checkingAccountAmount.Domain.Model;

public class Assets
{
    public string? Symbol { get; set; }
    public int Amount { get; set; }
    public decimal CurrentPrice { get; set; }
}
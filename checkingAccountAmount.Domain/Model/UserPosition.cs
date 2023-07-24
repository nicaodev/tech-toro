namespace checkingAccountAmount.Domain.Model;

public class UserPosition
{
    public string cpf { get; set; } = "32711582078";
    public decimal CheckingAccountAmount { get; set; }
    public List<Assets> Positions { get; set; }
    public decimal Consolidated => CheckingAccountAmount + Positions.Sum(p => p.Amount * p.CurrentPrice);
}
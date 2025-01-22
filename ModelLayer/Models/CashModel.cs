
namespace ModelLayer.Models
{
    public class CashModel
    {
        public int CashId { get; set; }
        public string CashDescription { get; set; } = string.Empty;
        public char active { get; set; }
        public TurnModel? Turn { get; set; }
    }
}

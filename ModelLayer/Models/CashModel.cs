
namespace ModelLayer.Models
{
    public class CashModel
    {
        public int CashId { get; set; }
        public string CashDescription { get; set; } = string.Empty;
        public char active { get; set; }
        public ICollection<TurnModel> Turns { get; set; } = new List<TurnModel>();  
        public List<UserCashModel> UsersCashes { get; } = [];
    }
}

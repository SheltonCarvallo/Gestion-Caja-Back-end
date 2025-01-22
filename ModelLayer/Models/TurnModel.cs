using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class TurnModel
    {
        public int TurnId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int CashId { get; set; }
        public int UserGestorId { get; set; }

        public CashModel Cash { get; set; } = null!;
        public AttentionModel? Attention { get; set; }
    }
}

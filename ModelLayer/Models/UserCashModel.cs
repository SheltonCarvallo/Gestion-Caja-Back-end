using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class UserCashModel
    {
        public int UserId { get; set; }
        
        public int CashId { get; set; }

        public UserModel User { get; set; } = null!;
        public CashModel Cash { get; set; } = null!;
    }
}

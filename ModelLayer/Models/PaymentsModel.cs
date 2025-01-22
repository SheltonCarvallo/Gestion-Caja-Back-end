using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class PaymentsModel
    {
        public int PaymentId { get; set; }
        public DateTime PaymentDate { get; set; }
        public int ClientId { get; set; }
        public ClientModel Client { get; set; } = null!;


    }
}

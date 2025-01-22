using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class MethodPaymentModel
    {
        public int MethodPaymentId { get; set; }
        public string Description { get; set; } = string.Empty;
        public ContractModel? Contract { get; set; }
    }
}

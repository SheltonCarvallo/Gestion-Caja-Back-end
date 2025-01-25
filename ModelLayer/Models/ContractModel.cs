using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class ContractModel
    {
        public int ContractId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int ServiceId { get; set; }
        public string StatusContractId { get; set; } = string.Empty;
        public int ClientId { get; set; } // Required FK 
        public int MethodPaymentId { get; set; }
        public ServiceModel Service { get; set; } = null!;
        public StatusContractModel StatusContract { get; set; } = null!;
        public ClientModel Client { get; set; } = null!;
        public MethodPaymentModel MethodPayment { get; set; } = null!;
    }
}

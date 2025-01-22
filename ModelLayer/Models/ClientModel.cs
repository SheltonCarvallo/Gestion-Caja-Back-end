using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class ClientModel
    {
        public int ClientId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string identification { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string ReferenceAddress { get; set; } = string.Empty;

        public ContractModel? Contract { get; set; } // Reference navigation to dependent
        public AttentionModel? Attention { get; set; }
        public PaymentsModel? Payments { get; set; }
    }
}

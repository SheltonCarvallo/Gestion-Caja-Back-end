using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class StatusContractModel
    {
        public string StatusContractId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ContractModel? Contract { get; set; }
    }
}

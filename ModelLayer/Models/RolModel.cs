using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class RolModel
    {
        public int RolId { get; set; }
        public string RolDescription { get; set; } = string.Empty;

        public UserModel? User { get; set; }
    }
}

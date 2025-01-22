using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class AttentionTypeModel
    {
        public string AttentionTypeId { get; set; } = string.Empty;
        public string AttentionDescription { get; set; } = string.Empty;
        public AttentionModel? Attention { get; set; }
    }
}

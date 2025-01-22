using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class DeviceModel
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; } = string.Empty;
        public int ServiceId { get; set; }
        public ServiceModel Service { get; set; } = null!;
    }
}

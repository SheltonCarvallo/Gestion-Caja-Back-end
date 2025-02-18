﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class ServiceModel
    {
        public int ServiceId { get; set; }
        public string ServiceName { get; set; } = string.Empty;
        public string ServiceDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ICollection<ContractModel> Contracts { get; set; } = new List<ContractModel>();
        public ICollection<DeviceModel> Devices { get; set; } = new List<DeviceModel>();

    }
}

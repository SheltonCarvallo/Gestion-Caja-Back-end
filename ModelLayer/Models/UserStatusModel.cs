using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class UserStatusModel
    {
        public string StatusId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<UserModel> Users { get; set; } = new List<UserModel>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int RolId { get; set; }
        public DateTime CreationDate { get; set; }
        public int UserCreateId { get; set; }
        public int UserApprovalId { get; set; }
        public DateTime DateApproval { get; set; }
        public string UserStatusId { get; set; } = string.Empty;
        public UserStatusModel? UserStatus { get; set; }
        public RolModel Rol { get; set; } = null!;
        public List<UserCashModel> UsersCashes { get; } = [];
    }
}

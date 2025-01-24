using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Models
{
    public class ClientModel
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Client name is required"), MinLength(4, ErrorMessage ="Min number of characters 4"), MaxLength(30, ErrorMessage ="Max number of characters 30")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Client name is required"), MinLength(4, ErrorMessage = "Min number of characters 4"), MaxLength(30, ErrorMessage = "Max number of characters 30")]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage ="Identification number is required"),
         RegularExpression(@"^\d{10,13}$", ErrorMessage ="Identification must have a length of 10 to 13 digits, and only consist of numbers")]
        public string identification { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage ="Phone number is required"),
         RegularExpression(@"^09\d{8}$", ErrorMessage = "The phone number must be at least 10 digits long and only numbers and only start with 09")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required"), MinLength(20, ErrorMessage ="Min number of characters 20"), MaxLength(100, ErrorMessage ="Max number of characteres 100")]
        public string Address { get; set; } = string.Empty;
     
        [Required(ErrorMessage = "Reference address is required"), MinLength(20, ErrorMessage = "Min number of characters 20"), MaxLength(100, ErrorMessage = "Max number of characteres 100")]
        public string ReferenceAddress { get; set; } = string.Empty;

        public ContractModel? Contract { get; set; } // Reference navigation to dependent
        public AttentionModel? Attention { get; set; }
        public PaymentsModel? Payments { get; set; }
    }
}

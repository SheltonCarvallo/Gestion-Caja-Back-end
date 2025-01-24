using System.ComponentModel.DataAnnotations;

namespace GestionDeCajas.Authentication.Models
{
    public class RegisterOrUpdateUserModel
    {
        [Required(ErrorMessage = "Username is required"), MinLength(8, ErrorMessage ="Min length is 8 characters"), MaxLength(30, ErrorMessage ="Max lenght is 30 characters"),
         RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]+$", ErrorMessage ="Special characters are not allowed or You haven't included a number in you username")]
        public string UserName { get; set; } = string.Empty;
        
        [Required (ErrorMessage = "Email is required"), EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required (ErrorMessage = "Password is required"), MinLength(8, ErrorMessage = "Min length is 8 characters"), MaxLength(30, ErrorMessage = "Max lenght is 30 characters")]
        public string Password { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace ProjectGoodSamaritan.Models
{
    public class RegisterModel 
        //use data annotations to configure models securely
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; } 
        
        [Required]
        public string UserName { get; set; }
    }


    public class SignInModel 
    {
        [Required]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
 
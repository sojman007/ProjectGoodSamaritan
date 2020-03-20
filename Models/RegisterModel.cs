using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGoodSamaritan.Models
{
    public class RegisterModel : IAuthModel
    {
        [Required]
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        [Required]
        public string UserName { get; set; }
    }


    public class SignInModel : IAuthModel
    {
        [Required]
        public string Email { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        [Required]
        public string Password { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
 
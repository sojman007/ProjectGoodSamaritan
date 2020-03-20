using Microsoft.AspNetCore.Identity;
using ProjectGoodSamaritan.Data;
using ProjectGoodSamaritan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGoodSamaritan.Logic
{
   public interface IValidator
    {
        public  bool ValidateModel(SignInModel model);
    }

    public class Validator : IValidator
    {

        ApplicationDbContext _context;
        PasswordHasher<IdentityUser> _hasher;
        
        public Validator(ApplicationDbContext context , PasswordHasher<IdentityUser> hasher)
        {
            _context = context;
            _hasher = hasher;

        }
        public bool ValidateModel(SignInModel model)
        {
            var validUser = _context.Users.Where(user => user.Email == model.Email).FirstOrDefault();
            
            
            
            if (_hasher.VerifyHashedPassword(validUser, validUser.PasswordHash, model.Password) == PasswordVerificationResult.Success)

            {
                return true;

            }
            
            return false;
            
        
        }
    }
}

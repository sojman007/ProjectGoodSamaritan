using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectGoodSamaritan.Data;
using ProjectGoodSamaritan.Logic;
using ProjectGoodSamaritan.Models;
using System.Threading.Tasks;

namespace ProjectGoodSamaritan.Controllers
{
    //TODO: complete this
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> uM;
        private readonly PasswordHasher<AppUser> _hasher;
        //Inject Dependencies
        public AuthController(UserManager<AppUser> uMan)
        {
            uM = uMan;
            _hasher = new PasswordHasher<AppUser>();

        }

        [HttpPost("signin")]
        public async Task<ActionResult<string>> SignIn(SignInModel SignIn)
        {
            //if user exists, generate a token for the new User
            var existingUser = await uM.FindByEmailAsync(SignIn.Email);
           

            var validPassWord = _hasher.VerifyHashedPassword(existingUser, existingUser.PasswordHash, SignIn.Password);
           
            if(existingUser!= null && validPassWord == PasswordVerificationResult.Success)
            {
                return await TokenGenerator.GenerateToken(SignIn,uM);
            }
            
            return Unauthorized("User does not exist");

        }

        
        [HttpPost("signup")]
        public async Task<ActionResult> Register(RegisterModel register)
        {

            var newUser = await uM.CreateAsync(new AppUser {Email = register.Email , UserName = register.UserName }, register.Password);
            return new CreatedResult("AspNetUsers",newUser);
        
        
        }


    
    }



}

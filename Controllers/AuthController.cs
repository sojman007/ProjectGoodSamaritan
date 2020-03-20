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
        private readonly SignInManager<AppUser> sM;
        private readonly ApplicationDbContext con;
        private readonly Validator _val;
        //Inject Dependencies
        public AuthController(
            UserManager<AppUser> uMan,
            ApplicationDbContext cont,
            Validator val)
        {
            uM = uMan;
            con = cont;
            _val = val;
        }
        [HttpPost]
        public async Task<ActionResult> SignIn(SignInModel SignIn)
        {

            //TODO: check Dto model for valid details ,  return Token
            if (_val.ValidateModel(SignIn) == true)
            {
                await Task.Delay(0); 
                    
                return Ok();//generate token here and return it 
            }
            
            return Unauthorized();

        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel Register)
        {
            var newUser = await uM.CreateAsync(new AppUser {Email = Register.Email , UserName = Register.UserName }, Register.Password);
            return new CreatedResult("AspNetUsers",newUser);
        }


        [HttpGet]
        public async Task<ActionResult> SignOut()
        {
            await sM.SignOutAsync();
            return Ok("signed out");
        }




    }



}

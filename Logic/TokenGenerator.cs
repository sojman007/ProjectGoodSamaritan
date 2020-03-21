using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using ProjectGoodSamaritan.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGoodSamaritan.Logic
{
    public class TokenGenerator
    {
        public async static Task<string> GenerateToken(SignInModel model, UserManager<AppUser> userManager)
        {

            var existingUser = await userManager.FindByEmailAsync(model.Email);
            var userClaims = await userManager.GetClaimsAsync(existingUser);

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("thisismysecretkey"));
            var signingCredentials =  new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer:"DefaultIssuer" , 
                audience:"Audience", 
                userClaims,
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials:signingCredentials);

            
            return new  JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

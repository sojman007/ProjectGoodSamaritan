using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGoodSamaritan.Models
{
    public class AppUser:IdentityUser
    {
        //relationships to many: a user can have many LostItems and Many FoundItems
        public List<LostItem> LostItems { get; set; } = new List<LostItem>();
        public List<FoundItem> FoundItems { get; set; } = new List<FoundItem>();
    }
}

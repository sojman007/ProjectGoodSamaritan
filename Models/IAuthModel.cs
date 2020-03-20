using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGoodSamaritan.Models
{
    public interface IAuthModel
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
}

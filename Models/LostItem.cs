using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGoodSamaritan.Models
{
    public class LostItem
    {
     
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        [MaxLength(20)]
        public string ItemName { get; set; }
               
        [MaxLength(256)]
        public string Description{ get; set; }
        [Required]
        public DateTime LostDateTime { get; set; }

        //configure relationship  to Application User
        public string AppUserId { get; set; }
        public AppUser User { get; set; }

    }
}

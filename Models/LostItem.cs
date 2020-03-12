using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectGoodSamaritan.Models
{
    public class LostItem
    {
     //   [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
        [Required]
        [MaxLength(20)]
        public string ItemName { get; set; }
       // public int Index { get; set; }
        
        [MaxLength(256)]
        public string Description{ get; set; }
        [Required]
        public DateTime LostDateTime { get; set; }
    }
}

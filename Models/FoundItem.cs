using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectGoodSamaritan.Models
{
    public class FoundItem
    {

       // [Key]
        public string Id { get; set; } =  Guid.NewGuid().ToString();

        
        [Required]
        [MaxLength(20)]
        public string ItemName { get; set; }
        
        [MaxLength(256)]
        public string Description { get; set; }
       
        [Required]
        public DateTime FoundDateTime { get; set; } = DateTime.Now;
        public string ItemRecoveryInstructions { get; set; }
        
        //relationship stuff to User 
        
        public string AppUserId { get; set; }
        public AppUser User { get; set; }


    }
}

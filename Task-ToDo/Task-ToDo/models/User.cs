
using System.ComponentModel.DataAnnotations;

namespace Task_ToDo.models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserPassword { get; set; }
            
    }
}

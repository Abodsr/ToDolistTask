using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task_ToDo.models
{
    public class ToDoTask
    {
        [Key]
        public int IdTask { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public bool IsCompleted { get; set; } = false;

        // Foreign Key to User
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string TagName;
        [ForeignKey("TagName")]
        public Tag Tag { get; set; }
        
       

        
    }
}
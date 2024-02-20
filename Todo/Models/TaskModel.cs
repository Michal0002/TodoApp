using System.ComponentModel.DataAnnotations;

namespace Todo.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        [StringLength(16, MinimumLength = 3)]
        public string Title { get; set; }
        [StringLength(32, MinimumLength = 6)]
        public  string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now; 
        public DateTime DueDate { get; set; } = DateTime.Now;
        public  string Status { get; set; }
        public  string Priority { get; set; }
    }
}

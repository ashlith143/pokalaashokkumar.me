using System.ComponentModel.DataAnnotations;

namespace EnterpriseApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
    }
}

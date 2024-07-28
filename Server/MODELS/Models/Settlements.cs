using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Settlements
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}

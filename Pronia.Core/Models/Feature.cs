using System.ComponentModel.DataAnnotations;

namespace Pronia.Core.Models
{
    public class Feature : BaseEntity
    {
        [Required]
        public string Icon { get; set; } = null!;
        [StringLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

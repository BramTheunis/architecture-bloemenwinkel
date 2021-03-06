using System.ComponentModel.DataAnnotations;

namespace BasicRestAPI.Model.Web
{
    public class FlowerUpsertInput
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = null!;
        
        [Required]
        public int Price { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; } = null!;
    }
}
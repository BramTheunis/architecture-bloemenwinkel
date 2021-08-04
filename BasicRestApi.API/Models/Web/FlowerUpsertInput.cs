using System.ComponentModel.DataAnnotations;
using BasicRestAPI.Model.Domain;

namespace BasicRestAPI.Model.Web
{
    public class FlowerUpsertInput
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        [Required]
        public int Price { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }
    }
}
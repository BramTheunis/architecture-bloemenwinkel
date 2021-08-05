using System.ComponentModel.DataAnnotations;

namespace BasicRestAPI.Model.Web
{
    public class StoreUpsertInput
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string Region { get; set; } = null!;

        [Required]
        [StringLength(255)]
        public string StreetName { get; set; } = null!;

        [Required]
        public int Number { get; set; }
    }
}
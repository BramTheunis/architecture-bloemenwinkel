using System.ComponentModel.DataAnnotations;

namespace BasicRestAPI.Model.Web
{
    public class SaleUpsertInput
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public int Quantity { get; set; }
        
        [Required]
        public int FlowerId { get; set; }

        [Required]
        [StringLength(255)]
        public int StoreId { get; set; }
    }
}
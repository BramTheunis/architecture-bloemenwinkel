namespace BasicRestAPI.Model.Domain
{
    public class Sale : BaseDatabaseClass
    {
        public int Quantity { get; set; }
        public int FlowerId { get; set; }
        public int StoreId { get; set; }
    }
}
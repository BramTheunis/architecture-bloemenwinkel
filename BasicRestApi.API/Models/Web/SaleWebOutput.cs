namespace BasicRestAPI.Model.Web
{
    public class SaleWebOutput
    {
        public SaleWebOutput(int id, string quantity, int flowerid, int storeid)
        {
            Id = id;
            Quantity = quantity;
            FlowerId = flowerid;
            StoreId = storeid;
        }

        public int Id { get; set; }
        public string Quantity { get; set; }
        public int FlowerId { get; set; }
        public int StoreId { get; set; }
    }
}
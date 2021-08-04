namespace BasicRestAPI.Model.Web
{
    public class StoreWebOutput
    {
        public StoreWebOutput(int id, string name, string region)
        {
            Id = id;
            Name = name;
            Region = region;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
    }
}
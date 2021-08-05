namespace BasicRestAPI.Model.Web
{
    public class StoreWebOutput
    {
        public StoreWebOutput(int id, string name, string region, string streetname, int number)
        {
            Id = id;
            Name = name;
            Region = region;
            StreetName = streetname;
            Number = number;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string StreetName { get; set; }
        public int Number { get; set; }
    }
}
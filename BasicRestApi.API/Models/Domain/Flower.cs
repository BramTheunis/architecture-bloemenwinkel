namespace BasicRestAPI.Model.Domain
{
    public class Flower : BaseDatabaseClass
    {
        public string Name { get; set; } = null!;
        public int Price { get; set; }
        public string Description { get; set; } = null!;
    }
}
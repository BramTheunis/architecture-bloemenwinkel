using System.Collections.Generic;

namespace BasicRestAPI.Model.Domain
{
    public class Store : BaseDatabaseClass
    {
        public string Name { get; set; } = null!;
        // public IEnumerable<Flower> Flowers { get; set; }
        public string Region { get; set; } = null!;
    }
}
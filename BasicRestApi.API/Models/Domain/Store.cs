using System.Collections.Generic;

namespace BasicRestAPI.Model.Domain
{
    public class Store : BaseDatabaseClass
    {
        public string Name { get; set; } = null!;
        public string Region { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public int Number { get; set; }
    }
}
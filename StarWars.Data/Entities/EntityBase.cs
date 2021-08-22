using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public byte[] PhotoBytes { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}

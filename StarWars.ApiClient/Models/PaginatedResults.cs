using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.ApiClient.Models
{
    public class PaginatedResults<T>
    {
        public int Count { get; set; }

        public IEnumerable<T> Results { get; set; }
    }
}

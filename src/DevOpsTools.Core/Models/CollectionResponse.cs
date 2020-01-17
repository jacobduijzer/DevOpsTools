using System.Collections.Generic;

namespace DevOpsTools.Core.Models
{
    public class CollectionResponse<T>
    {
        public int Count { get; set; }

        public IEnumerable<T> Value { get; set; }
    }
}
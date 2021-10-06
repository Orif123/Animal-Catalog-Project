using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectAnimalCatalog.Models
{
    public partial class Category
    {
        public Category()
        {
            Animals = new HashSet<Animal>();
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}

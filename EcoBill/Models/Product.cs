using System;
using System.Collections.Generic;

namespace EcoBill.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Price { get; set; }
    }
}

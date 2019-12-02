using System;
using System.Collections.Generic;

namespace EcoBill.Models
{
    public partial class ProductCard
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public int? ShoppingCardId { get; set; }
    }
}

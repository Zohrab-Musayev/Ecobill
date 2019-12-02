using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoBill.Models
{
   
    public partial class ShoppingCard
    {
        Random r = new Random();

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UserId { get; set; }

        public string TotalPrice { get; set; }
        [NotMapped]
        public int TotalPricee {
            get {
                return r.Next(100, 200);
            } set { } }
    }
}

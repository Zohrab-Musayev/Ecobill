using System;
using System.Collections.Generic;

namespace EcoBill.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string QrCode { get; set; }
        public string UniqueCode { get; set; }
    }
}

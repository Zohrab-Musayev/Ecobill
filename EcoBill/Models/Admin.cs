﻿using System;
using System.Collections.Generic;

namespace EcoBill.Models
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}

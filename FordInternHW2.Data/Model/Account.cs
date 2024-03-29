﻿using FordInternHW2.Base.Model;

namespace FordInternHW2.Data.Model
{
    public class Account : BaseModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        //public DateTime LastActivity { get; set; } // Comes from BaseModel
    }
}

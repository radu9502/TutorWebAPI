﻿using static TestAPIAuth.Utils.Enums;
namespace TestAPIAuth.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Deleted { get; set; }
        public Role Role { get; set; }
    }
}

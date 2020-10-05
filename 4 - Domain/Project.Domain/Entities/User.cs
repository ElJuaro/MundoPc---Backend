using System;
using System.Collections.Generic;

namespace Project.Domain.Entities

{
    public class User : EntityBase
    {

        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public RoleType Role { get; set; }
        public string Telephone { get; set; }
        public bool IsActive { get; set; }

     
    }
}
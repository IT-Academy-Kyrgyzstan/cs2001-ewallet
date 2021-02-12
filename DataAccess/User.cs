﻿using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess
{
    public class User
    {
        [Key]        
        public int Id { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [StringLength(50, MinimumLength = 6)]        
        public string Password { get; set; }

        [StringLength(20, MinimumLength = 3)]
        public string Login { get; set; }
        
        public DateTime Created { get; set; }
    }
}
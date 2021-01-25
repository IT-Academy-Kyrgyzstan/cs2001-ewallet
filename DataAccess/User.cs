using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class User
    {
        [Key]        
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [StringLength(20, MinimumLength = 6)]        
        public string Password { get; set; }
        public string Login { get; set; }
        public DateTime Created { get; set; }
    }
}
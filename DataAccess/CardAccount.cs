using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class CardAccount
    {
        [Key]
        [Column(TypeName = "int")]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(6)")]
        [StringLength(6, MinimumLength = 6)]
        public string CardNumber { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        [StringLength(20, MinimumLength = 4)]
        public string CardName { get; set; }

        //[Column(TypeName = "int")]
        //public int UserId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CardBalance { get; set; }

        [Column(TypeName = "DateTime")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "DateTime.Now")]
        public DateTime EndDate { get; set; }

        
        public Statuses Status { get; set; }
        public enum Statuses
        {
            worked = 0,
            blocked = 1,
            frozen = 2           
        }
        //public User User { get; set; }
    }
}
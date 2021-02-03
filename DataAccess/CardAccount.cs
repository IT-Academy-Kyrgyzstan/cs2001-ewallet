using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class CardAccount
    {
        [Key]
        public int Id { get; set; }

        [StringLength(6, MinimumLength = 6)]
        public string CardNumber { get; set; }

        [StringLength(20, MinimumLength = 4)]
        public string CardName { get; set; }
      
        public int UserId { get; set; }

        public decimal CardBalance { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime EndDate { get; set; }

        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public Statuses Status { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
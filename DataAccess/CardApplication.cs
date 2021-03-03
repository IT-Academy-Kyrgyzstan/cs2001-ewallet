using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataAccess
{
    public class CardApplication
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }      

        public int OperatorId { get; set; }

        [MaxLength(30)]
        public string NameCard { get; set; }

        public int CurruncyEnum { get; set; }

        public int CardView { get; set; }

        public int Status { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime DecisionDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}

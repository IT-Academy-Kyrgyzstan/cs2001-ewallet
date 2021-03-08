using DataAccess.Enum;
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

        public string NameCard { get; set; }
        public Currency Сurrency { get; set; }
        public CardType CardType { get; set; }
        public CardStatus Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime DecisionDate { get; set; }       

    }
}

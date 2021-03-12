using DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CardAppViewOperator
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string OperatorId { get; set; }

        public string NameCard { get; set; }
        public string Сurrency { get; set; }
        public string CardType { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime DecisionDate { get; set; }

    }
}


using DataAccess;
using DataAccess.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CardApplicationSM
    {       
        [Display(Name = "Currency")]
        public Currency Currency { get; set; }
        [Display(Name = "Card type")]
        public CardType CardType { get; set; }
    }
}

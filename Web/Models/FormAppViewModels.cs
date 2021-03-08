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
    public class FormAppViewModels
    {       
        [Display(Name = "Currency")]
        public Currency Curruncy { get; set; }
        [Display(Name = "Card view")]
        public CardType CardView { get; set; }
    }
}

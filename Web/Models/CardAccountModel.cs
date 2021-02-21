using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CardAccountModel
    {

        [StringLength(6, MinimumLength = 6)]
        public string SelectCardNumber { get; set; }
        [StringLength(6, MinimumLength = 6)]
        public string TransferCardNumber { get; set; }

        public decimal TransferBalance { get; set; }


    }
}

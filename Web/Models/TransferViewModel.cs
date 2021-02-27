using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class TransferViewModel
    {
        private IEnumerable<CardAccount> cardAccounts;
        public IEnumerable<CardAccount> CardAccounts { 
            get 
            {
                return cardAccounts;
            }
            set
            {
                cardAccounts = value;
            }
        }

        public string SelectCardNumber { get; set; }
        public string TransferCardNumber { get; set; }
        public decimal TransferBalance { get; set; }
    }
}

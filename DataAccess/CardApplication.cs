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
        
        [Required]
        public int UserId { get; set; }      

        public int OperatorId { get; set; }

        [Required]
        [MaxLength(30)]
        public string NameCard { get; set; }
        
        [Required]
        public CurruncyEnum Сurruncy{ get; set; }
        
        [Required]
        public CardViewsEnum CardView { get; set; }
        
        [Required]
        public StatusesEnum Status { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        
        [Required]
        public DateTime CreatedDate { get; set; }

        public DateTime DecisionDate { get; set; }       

    }
}

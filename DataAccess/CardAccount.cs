using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class CardAccount
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Номер Карты")]
        [StringLength(6, MinimumLength = 6)]
        public string CardNumber { get; set; }

        [Display(Name = "Название карты")]
        [StringLength(20, MinimumLength = 4)]
        public string CardName { get; set; }
        
        [Display(Name = "Id пользователя")]
        public int UserId { get; set; }

        [Display(Name = "Баланс карты")]
        public decimal CardBalance { get; set; }

        [Display(Name = "Дата создания")]
        public string CreatedDate { get; set; }

        [Display(Name = "Дата окончания")]
        public string EndDate { get; set; }

        [Display(Name = "Статус")]
        public int StatusId { get; set; }

        [ForeignKey("StatusId")]
        public Statuses Status { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class User
    {
        [Key]        
        public int Id { get; set; }

        [Display(Name = "Имя")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Display(Name = "Пароль")]
        [StringLength(50, MinimumLength = 6)]        
        public string Password { get; set; }

        [Display(Name = "Логин")]
        [StringLength(20, MinimumLength = 3)]
        public string Login { get; set; }

        [Display(Name = "Дата создания")]
        public string Created { get; set; }
    }
}
using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "Не указан Name")]
        [StringLength(30, MinimumLength = 10)]
        [Display(Name = "Имя пользователя")]
        public string name { get; set; }

        [Required(ErrorMessage = "Не указан Ник")]
        [StringLength(30, MinimumLength = 10)]
        [Display(Name = "Ник пользователя")]
        public string nick_name { get; set; }

        [Required(ErrorMessage = "Не указан номер")]
        [StringLength(11, MinimumLength = 11)]
        [Display(Name = "Имя пользователя")]
        public long phone { get; set; }

        [Required(ErrorMessage = "Не указан О себе")]
        [StringLength(30, MinimumLength = 10)]
        [Display(Name = "О себе")]
        public string about_me { get; set; }

        [Required(ErrorMessage = "Не указана Фамилия")]
        [StringLength(30, MinimumLength = 10)]
        [Display(Name = "Фамилия пользователя")]
        public string surname { get; set; }
    }
}

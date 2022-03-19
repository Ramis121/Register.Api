using Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domains.DTO
{
    public class RegisterDTO 
    {
        [Key]
        public int id { get; set; }
        [StringLength(15, MinimumLength = 4)]
        [Display(Name = "Имя")]
        public string name_r { get; set; }

        [Required(ErrorMessage = "Ник занят")]
        [Display(Name = "Ник")]
        public string nick_name_r { get; set; }

        [Required(ErrorMessage = "Номер уже существует")]
        [StringLength(11, MinimumLength = 11)]
        [Display(Name = "Номер")]
        public string phone_r { get; set; }
        [Display(Name = "О себе")]
        public string about_me_r { get; set; }

        [Required(ErrorMessage = "Не указан Surname")]
        [StringLength(10, MinimumLength = 2)]
        [Display(Name = "Фамилия")]
        public string surname_r { get; set; }
    }
}

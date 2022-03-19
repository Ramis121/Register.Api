using Domain.Base;
using Domain.Model;
using Domains.DTO;
using Microsoft.Extensions.Logging;
using Register.Api.Data;
using Register.Api.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Api.Services
{
    public class RegisterService : RegisterDTO, IRegister 
    {
        private readonly ILogger<RegisterService> logger;
        public RegisterService(ILogger<RegisterService> logger)
        {
            this.logger = logger
                ?? throw new ArgumentException(nameof(logger));
        }
        /// <summary>
        /// Проверка на наличие номера телефона в БД
        /// </summary>
        /// <param name="aplicationDb"></param>
        /// <returns></returns>
        public bool Accessing_DataBase()
        {
            using (AplicationDbContext db = new AplicationDbContext())
            {
                try
                {
                    var convert = Convert.ToInt64(phone_r);
                    IQueryable<User> result = db.users.Where(a => a.phone == convert);
                    return result.Count() <= 0 ? true : throw new Exception("Ошибка при обработке данных");

                }
                catch (Exception)
                {
                    return false;
                }
            }
        } 

        /// <summary>
        /// Добавление пользователя в БД 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public bool Add_User()
        {
            using (AplicationDbContext db = new AplicationDbContext())
            {
                if (Accessing_DataBase() && Field_Validation() && Check_for_Nickname())
                {
                    var convert = Convert.ToInt64(phone_r);
                    if (about_me_r is null)
                    {
                        List<User> list_user = new List<User>
                        {
                           new User { name = name_r, phone = convert, about_me = "В спортзале", nick_name = nick_name_r, surname = surname_r }
                        };
                        db.users.AddRange(list_user);
                        db.SaveChanges();
                        return true;
                    }

                    List<User> list_user2 = new List<User>
                    {
                       new User { name = name_r, phone = convert, about_me = about_me_r, nick_name = nick_name_r, surname = surname_r }
                    };
                    db.users.AddRange(list_user2);
                    db.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Проверка на наличие ника 
        /// </summary>
        /// <param name="aplicationDb"></param>
        /// <returns></returns>
        public bool Check_for_Nickname()
        {
            using (AplicationDbContext db = new AplicationDbContext())
            {
                try
                {
                    IQueryable<User> result = db.users.Where(a => a.nick_name == nick_name_r);
                    return result.Count() <= 0 ? true : throw new Exception("Ошибка при обработке данных");

                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Проверка на количество цифр в номере
        /// </summary>
        /// <returns></returns>
        public bool Field_Validation()
        {
            return name_r.Length >= 3 && phone_r.Length == 11;
        }
    }
}

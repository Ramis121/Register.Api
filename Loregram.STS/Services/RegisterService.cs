using Domain.Base;
using Domain.Model;
using Domains.DTO;
using Loregram.STS.Data;
using Microsoft.Extensions.Logging;
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
        private readonly ApplicationDbContext db;
        public RegisterService() { }
       
        public RegisterService(ILogger<RegisterService> logger, ApplicationDbContext dbContext)
        {
            this.logger = logger
                ?? throw new ArgumentException(nameof(logger));
            this.db = dbContext
                ?? throw new ArgumentException(nameof(dbContext));
        }
        /// <summary>
        /// Проверка на наличие номера телефона в БД
        /// </summary>
        /// <param name="aplicationDb"></param>
        /// <returns></returns>
        public bool Accessing_DataBase(ApplicationDbContext dbContext)
        {
           try
           {
               var convert = Convert.ToInt64(phone_r);
               IQueryable<User> result = dbContext.users.Where(a => a.phone == convert);
               return result.Count() <= 0 ? true : throw new Exception("Ошибка при обработке данных");
           }
           catch (Exception)
           {
              return false;
           }
        } 

        /// <summary>
        /// Добавление пользователя в БД 
        /// </summary>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public bool Add_User(ApplicationDbContext dbContext)
        {
           if (Accessing_DataBase(dbContext) && Field_Validation() && Check_for_Nickname(dbContext))
           {
               var convert = Convert.ToInt64(phone_r);
               if (about_me_r is null)
               {
                    List<User> list_user = new List<User>
                    {
                      new User { name = name_r, phone = convert, about_me = "В спортзале", nick_name = nick_name_r, surname = surname_r }
                    };
                    dbContext.users.AddRange(list_user);
                    dbContext.SaveChanges();
                    return true;
               }

                List<User> list_user2 = new List<User>
                {
                    new User { name = name_r, phone = convert, about_me = about_me_r, nick_name = nick_name_r, surname = surname_r }
                };
                dbContext.users.AddRange(list_user2);
                dbContext.SaveChanges();
               return true;
           }
           return false;
        }

        /// <summary>
        /// Проверка на наличие ника 
        /// </summary>
        /// <param name="aplicationDb"></param>
        /// <returns></returns>
        public bool Check_for_Nickname(ApplicationDbContext dbContext)
        {
           try
           {
               IQueryable<User> result = dbContext.users.Where(a => a.nick_name == nick_name_r);
               return result.Count() <= 0 ? true : throw new Exception("Ошибка при обработке данных");
           }
           catch (Exception)
           {
              return false;
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

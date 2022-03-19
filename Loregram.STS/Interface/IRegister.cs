using Loregram.STS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Api.Interface
{
    public interface IRegister
    {
        bool Field_Validation();
        bool Accessing_DataBase(ApplicationDbContext dbContext);
        bool Add_User(ApplicationDbContext dbContext);
        bool Check_for_Nickname(ApplicationDbContext dbContext);
    }
}

using Register.Api.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Register.Api.Interface
{
    public interface IRegister
    {
        bool Field_Validation();
        bool Accessing_DataBase();
        bool Add_User();
        bool Check_for_Nickname();
    }
}

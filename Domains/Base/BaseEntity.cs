using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Base
{
    public abstract class BaseEntity
    {
        [Key]
        public int id { get; set; }
    }
    public abstract class BaseDateEntity : BaseEntity 
    {
        public DateTime Create { get; set; }
    }
}

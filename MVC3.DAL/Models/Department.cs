using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC3.DAL.Models
{
    public class Department:ModelBase
    {
       

        [Required]
        public string Code { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime DateOfCreation { get; set; }

    }
}

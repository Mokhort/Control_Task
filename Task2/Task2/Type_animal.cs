using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Type_animal
    {
        [Key]
        public int id { get; set; }
        public string type_name { get; set; }
    }
}

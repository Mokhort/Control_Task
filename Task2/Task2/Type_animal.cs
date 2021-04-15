using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

       // [InverseProperty("Type_animal")]
       // public virtual List<Info> info { get; set; }


    }
}

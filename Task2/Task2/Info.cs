using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Info
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public DateTime date_of_birth { get; set; }
        public string gender { get; set; }
        public int parent_1 { get; set; }

        // Внешний ключ
        [ForeignKey("Type_animal")]
        public int typeid { get; set; }

         // Навигационные свойства
        //public Type_animal Type_animal { get; set; }
        //public List<OrderLines> Lines { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int type { get; set; }
    }
}

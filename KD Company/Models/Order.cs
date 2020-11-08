using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace KD_Company.Models
{
    public class Order
    {[Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public string Carname { get; set; }
        [ForeignKey("Carid")]
        public int Carid { get; set; }
        
        public int NoOfDays { get; set; }
        public int Total { get; set; }
    }
}

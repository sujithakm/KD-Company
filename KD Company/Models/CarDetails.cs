﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KD_Company.Models
{
    public class CarDetails
    {[Key]
        public int Id { get; set; }
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public string Type { get; set; }
        public string  Color { get; set; }
        public string Price { get; set; }



    }
}
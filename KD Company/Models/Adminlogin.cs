﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KD_Company.Models
{
    public class Adminlogin
    {
       [Key]
        public int Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }

    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KD_Company.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string FeedBack { get; set; }
    }
}
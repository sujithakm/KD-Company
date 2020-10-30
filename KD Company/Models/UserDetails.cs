using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KD_Company.Models
{
    public class UserDetails
    {[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string City { get; set; }

        public int Pincode { get; set; }

        public string Phonenumber { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}

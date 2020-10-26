using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KD_Company.Models
{
    public class Register
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public string City { get; set; }

        public int Pincode { get; set; }

        public int Phonenumber { get; set; }

        public string Email { get; set; }
        public int Password { get; set; }


    }
}

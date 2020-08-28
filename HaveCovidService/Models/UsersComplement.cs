using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HaveCovidService.Models
{
    public class UsersComplement
    {
        [Key]
        public long ID { get; set; }
        public long UsersID { get; set; }
        public string Name { get;set;}
        public string LastName { get; set; }
        public string Phone { get; set;}
        public string Street { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }

    }
}

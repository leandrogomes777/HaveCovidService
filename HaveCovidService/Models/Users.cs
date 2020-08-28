using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HaveCovidService.Models
{
    public class Users
    {
        [Key]
        public long ID { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [ForeignKey("UsersComplementID")]
        public UsersComplement UsersComplement { get;set;}
    }
}

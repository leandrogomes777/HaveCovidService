using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaveCovidService.Models
{
    public class WithCovidReport
    {
        public long ID { get; set; }

        public long UsersID { get; set; }
        public DateTime DateSymptoms { get; set; } 
        public DateTime DateTest { get; set; }
        public bool PositiveTest { get; set; }
        public bool Asymptomatic { get; set; }
        public List<Symptoms> Symptoms { get; set; }
        public List<Medicines> Medicines { get; set; }
    }
}

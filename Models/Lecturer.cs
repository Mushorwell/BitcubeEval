using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitcubeEval.Models
{
    public class Lecturer : Person
    {
        [Display(Name = "Degree Name")]
        public ICollection<Degree> Degrees { get; set; }
    }
}

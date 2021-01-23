using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BitcubeEval.Models
{
    public class Student : Person
    {
        public int DegreeID { get; set; }
        [ForeignKey("DegreeID")]
        [Display(Name = "Degree Programme")]
        public Degree Degree { get; set; }
    }
}

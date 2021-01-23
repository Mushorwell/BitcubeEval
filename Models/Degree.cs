using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BitcubeEval.Models
{
    public class Degree
    {
        /*[DatabaseGenerated(DatabaseGeneratedOption.None)]*/
        public int DegreeID { get; set; }
        [Display(Name = "Degree Name")]
        public string DegreeName { get; set; }
        [Display(Name = "Degree Duration")]
        public int DegreeDuration { get; set; }
        public int LecturerID { get; set; }
        [ForeignKey("LecturerID")]
        [Display(Name = "Lecture Contact")]
        public Lecturer Lecturer { get; set; }
        [Display(Name = "Courses")]
        public ICollection<Course> Courses {get; set; }
    }
}

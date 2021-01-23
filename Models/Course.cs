using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BitcubeEval.Models
{
    public class Course
    {
        /*[DatabaseGenerated(DatabaseGeneratedOption.None)]*/
        public int CourseID { get; set; }
        public int DegreeID { get; set; }
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }
        [Display(Name = "Course Length (Months)")]
        public int CourseDuration { get; set; }
        [ForeignKey("DegreeID")]
        [Display(Name = "Degree")]
        public Degree Degree { get; set; } 
    }
}

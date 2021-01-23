using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BitcubeEval.Models
{
    public abstract class Person : IPerson
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Forenames")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z]*$+[ ]")]
        public string Forenames { get; set; }
        [Required]
        [StringLength(50, MinimumLength =2)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "First Name")]
        public string Firstname
        {
            get
            {
                return GetFirstName();
            }
        }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return Firstname + " " + Surname;
            }
        }
        public virtual string GetFirstName()
        {
            return Forenames.Split(" ")[0];
        }
    }
}

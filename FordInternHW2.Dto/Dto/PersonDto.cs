using FordInternHW2.Base;
using FordInternHW2.Base.Attribute;
using FordInternHW2.Base.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FordInternHW2.Dto.Dto
{
    public class PersonDto : BaseDto
    {
        [Required]
        [MaxLength(25)]
        [Display(Name = "Account Id")]
        public string AccountId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [Phone]
        [MaxLength(50)]
        public string Phone { get; set; }

        [Required]
        [DateOfBirth]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }


        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

    }

}

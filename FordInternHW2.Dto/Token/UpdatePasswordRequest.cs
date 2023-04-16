using FordInternHW2.Base.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW2.Dto.Token
{
    public class UpdatePasswordRequest
    {
        [Required]
        [PasswordAttribute]
        public string OldPassword { get; set; }

        [Required]
        [Password]
        public string NewPassword { get; set; }
    }
}

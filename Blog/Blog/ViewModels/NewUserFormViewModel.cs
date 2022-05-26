using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class NewUserFormViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password is not confirm")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class NewRoleFormViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}

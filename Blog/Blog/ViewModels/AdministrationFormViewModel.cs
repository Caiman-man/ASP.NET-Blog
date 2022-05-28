using Blog.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Blog.ViewModels
{
    public class AdministrationFormViewModel
    {
        public List<IdentityRole> Roles { get; set; }

        public List<ApplicationUser> Users { get; set; }

    }
}

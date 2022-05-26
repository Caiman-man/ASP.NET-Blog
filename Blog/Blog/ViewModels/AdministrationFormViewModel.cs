﻿using Blog.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class AdministrationFormViewModel
    {
        public List<IdentityRole> Roles { get; set; }

        public List<ApplicationUser> Users { get; set; }

    }
}

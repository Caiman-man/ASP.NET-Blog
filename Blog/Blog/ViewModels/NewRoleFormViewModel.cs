﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels
{
    public class NewRoleFormViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}

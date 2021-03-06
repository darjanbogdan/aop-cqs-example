﻿using AopExample.DAL.Identity.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopExample.DAL.Identity.Manager
{
    public class ApplicationUserManager : UserManager<ApplicationUser, Guid>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser, Guid> store)
            : base(store)
        {
            this.UserValidator = new UserValidator<ApplicationUser, Guid>(this)
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true
            };

            this.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6
            };

            this.PasswordHasher = new PlainPasswordHasher();
        }
    }
}
﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopExample.DAL.Identity.Models
{
    public class ApplicationUserLogin : IdentityUserLogin<Guid>
    {
    }
}
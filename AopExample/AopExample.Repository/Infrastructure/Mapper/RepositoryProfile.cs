using AopExample.DAL.Identity.Models;
using AopExample.Model.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AopExample.Repository.Infrastructure.Mapper
{
    public class RepositoryProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "RepositoryProfile";
            }
        }

        protected override void Configure()
        {
            this.CreateMap<User, ApplicationUser>();
        }
    }
}
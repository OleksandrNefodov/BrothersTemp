using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Brothers.Common.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Brothers.Common.Models.Context
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext() 
        : base("name=IdentityDb")
        {
        }

        static IdentityContext()
        {
            System.Data.Entity.Database.SetInitializer<IdentityContext>(new IdentityDbInit());
        }

        public static IdentityContext Create()
        {
            return new IdentityContext();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Brothers.Common.Models.Context;
using Brothers.Common.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Brothers.Repository.IdentityInfrastructure
{
    public class UserManagement : UserManager<AppUser>
    {
        public UserManagement(IUserStore<AppUser> store)
        :base(store)
        {
        }

        public static UserManagement Create(IdentityFactoryOptions<UserManagement> options, IOwinContext context)
        {
            IdentityContext db = context.Get<IdentityContext>();
            UserManagement manager = new UserManagement(new UserStore<AppUser>(db));

            manager.UserValidator = new UserValidator<AppUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            manager.PasswordValidator = new PasswordValidator()
            {
                RequiredLength = 6                
            };

            return manager;
        }
    }
}
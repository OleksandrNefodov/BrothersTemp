using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Brothers.Common.Models.Context
{
    public class IdentityDbInit : DropCreateDatabaseIfModelChanges<IdentityContext>
    {
        protected override void Seed(IdentityContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(IdentityContext context)
        {
        }
    }
}
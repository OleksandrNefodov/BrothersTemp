using System.Collections.Generic;
using System.Data.Entity;

namespace Brothers.Common.Models.Context
{
    public class BrothersContextInitializer : DropCreateDatabaseAlways<BrothersContext>
    {
        protected override void Seed(BrothersContext db)
        {
           
        }
    }
}
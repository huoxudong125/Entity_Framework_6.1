using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQF.Tutorial.EntityFramework.Commons.Entities;

namespace HQF.Tutorial.EntityFramework.Commons.DbContexts
{
    public class PartialUpdateDbContextInitializer:DropCreateDatabaseAlways<PartialUpdateDbContext>
    {
        public override void InitializeDatabase(PartialUpdateDbContext context)
        {
            base.InitializeDatabase(context);
            context.Users.Add(new User() {UserId = 1, LastName = "Last Name", FirstName = "First Name"});
            context.SaveChanges();
        }
    }
}

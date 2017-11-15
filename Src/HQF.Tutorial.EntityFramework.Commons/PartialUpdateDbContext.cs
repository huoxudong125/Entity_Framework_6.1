using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQF.Tutorial.EntityFramework.Commons.DbContexts.Mappings;
using HQF.Tutorial.EntityFramework.Commons.Entities;

namespace HQF.Tutorial.EntityFramework.Commons.DbContexts
{
    public class PartialUpdateDbContext:DbContext
    {
        public PartialUpdateDbContext()
        {
            Database.SetInitializer(new PartialUpdateDbContextInitializer());
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new UserMap());
        }

        public DbSet<User> Users { get; set; }

    }
}

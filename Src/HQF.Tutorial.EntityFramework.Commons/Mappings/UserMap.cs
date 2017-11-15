using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HQF.Tutorial.EntityFramework.Commons.Entities;

namespace HQF.Tutorial.EntityFramework.Commons.DbContexts.Mappings
{
    public class UserMap:EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            Property(t => t.FirstName).IsRequired();
            Property(t => t.LastName).IsRequired();

            Ignore(t => t.BillingDetailId);
        }
    }
}

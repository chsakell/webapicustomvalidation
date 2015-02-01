using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(u => u.ID);

            Property(u => u.ID).HasColumnName("UserID");
            Property(u => u.FirstName).IsRequired().HasMaxLength(50);
            Property(u => u.LastName).IsRequired().HasMaxLength(50);
            Property(u => u.Username).IsRequired().HasMaxLength(100);
            Property(u => u.BirthDate).IsRequired().HasMaxLength(20);
            Property(u => u.EmailAddress).IsRequired().HasMaxLength(100);

            HasRequired(u => u.Sex).WithMany(s => s.Users).HasForeignKey(u => u.SexID);
        }
    }
}

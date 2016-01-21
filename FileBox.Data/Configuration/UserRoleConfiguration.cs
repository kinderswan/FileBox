using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Model.Models;

namespace FileBox.Data.Configuration
{
    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            ToTable("UserRole");
            HasKey(r => r.UserRoleID);
            Property(r => r.UserRoleID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(r => r.Role).IsRequired();
            HasMany(r => r.Users).WithRequired(r => r.UserRole).HasForeignKey(r => r.UserRoleID);

        }
        
    }
}

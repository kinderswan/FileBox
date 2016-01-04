using System;
using System.Collections.Generic;
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
            HasRequired(u => u.UserInfo).WithMany(u => u.Roles).HasForeignKey(f => f.UserInfoID);
        }
        
    }
}

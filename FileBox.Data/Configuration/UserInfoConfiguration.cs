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
    public class UserInfoConfiguration : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration()
        {
            ToTable("UserInfo");
            HasKey(u => u.UserInfoID);
            Property(u => u.UserInfoID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(u => u.Login).IsRequired();
            Property(u => u.Password).IsRequired();
            Property(u => u.Email).IsRequired();
            HasMany(u => u.Files).WithRequired(u => u.UserInfo).HasForeignKey(u => u.UserInfoID);
            HasMany(u => u.Roles).WithRequired(u => u.UserInfo).HasForeignKey(u => u.UserInfoID);
        }
    }
}

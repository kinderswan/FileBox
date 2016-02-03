using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Data.Configuration;
using FileBox.Model.Models;

namespace FileBox.Data
{
    public class FileBoxEntities : DbContext
    {
        static FileBoxEntities()//for lazy context seeding
        {
            System.Data.Entity.Database.SetInitializer(new FileBoxSeedData());
        }

        public FileBoxEntities() : base("FileBoxEntities") { }
        public FileBoxEntities(string connectionString) : base(connectionString) { }

        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<FilesInfo> FilesInfos { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserInfoConfiguration());
            modelBuilder.Configurations.Add(new FilesInfoConfiguration());
            modelBuilder.Configurations.Add(new UserRoleConfiguration());
        }
    }
}

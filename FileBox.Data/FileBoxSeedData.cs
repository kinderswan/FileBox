using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Model.Models;

namespace FileBox.Data
{
    public class FileBoxSeedData : CreateDatabaseIfNotExists<FileBoxEntities>
    {
        protected override void Seed(FileBoxEntities context)
        {
            foreach (var item in GetUserRoles())
            {
                context.UserRoles.Add(item);
            }
            context.Commit();
            foreach (var item in GetUserInfos())
            {
                context.UserInfos.Add(item);
            }
            context.Commit();
            
            
        }

        private static List<UserInfo> GetUserInfos()
        {
            return new List<UserInfo>
            {
                new UserInfo()
                {
                    FirstName = "Pavel",
                    Login = "kinderswan",
                    Password = "8cb2237d0679ca88db6464eac60da96345513964",
                    Email = "gamanovichpavel@gmail.com",
                    UserRoleID = 1
                },
                new UserInfo()
                {
                    FirstName = "Alexey",
                    Login = "alex_1992",
                    Password = "0be17ae32bce5731dd1b4a8e2b1ad310a3653899",
                    Email = "alexsuponev@mail.com",
                    UserRoleID = 2
                },
                new UserInfo()
                {
                    FirstName = "Mikhail",
                    Login = "stopman3000",
                    Password = "5baa61e4c9b93f3f0682250b6cf8331b7ee68fd8",
                    Email = "mikhail.ivanov@gmail.com",
                    UserRoleID = 2
                }
            };
        }
        private static List<UserRole> GetUserRoles()
        {
            return new List<UserRole>
            {
               new UserRole()
               {
                   Role = "Admin"
               },
               new UserRole()
               {
                   Role = "User"
               }
            };
        }
    }
}

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
            foreach (var item in GetUserInfos())
            {
                context.UserInfos.Add(item);
            }
            context.Commit();
            foreach (var item in GetUserRoles())
            {
                context.UserRoles.Add(item);
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
                    Password = "12345",
                    Email = "gamanovichpavel@gmail.com"
                },
                new UserInfo()
                {
                    FirstName = "Alexey",
                    Login = "alex_1992",
                    Password = "alexcrazy",
                    Email = "alexsuponev@mail.com"
                },
                new UserInfo()
                {
                    FirstName = "Mikhail",
                    Login = "stopman3000",
                    Password = "password",
                    Email = "mikhail.ivanov@gmail.com"
                }
            };
        }
        private static List<UserRole> GetUserRoles()
        {
            return new List<UserRole>
            {
               new UserRole()
               {
                   Role = "Admin",
                   UserInfoID = 1
               },
               new UserRole()
               {
                   Role = "User",
                   UserInfoID = 1
               }
            };
        }
    }
}

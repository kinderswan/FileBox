using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Model.Models;

namespace FileBox.Data
{
    public class FileBoxSeedData : DropCreateDatabaseIfModelChanges<FileBoxEntities>
    {
        protected override void Seed(FileBoxEntities context)
        {
            foreach (var item in GetUserInfos())
            {
                context.UserInfos.Add(item);
            }
            context.Commit();
            foreach (var item in GetFilesInfos())
            {
                context.FilesInfos.Add(item);
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
                    FirstName = "A",
                    Login = "b",
                    Password = "c"
                },
                new UserInfo()
                {
                    FirstName = "B",
                    Login = "b",
                    Password = "c"
                },
                new UserInfo()
                {
                    FirstName = "C",
                    Login = "b",
                    Password = "c"
                }
            };
        }
        private static List<UserRole> GetUserRoles()
        {
            return new List<UserRole>
            {
               new UserRole()
               {
                   UserInfoID = 1,
                   Role = "Admin"
               },
               new UserRole()
               {
                   UserInfoID = 2,
                   Role = "User"
               },
               new UserRole()
               {
                   UserInfoID = 3,
                   Role = "Anonym"
               }
            };
        }
        private static List<FilesInfo> GetFilesInfos()
        {
            return new List<FilesInfo>
            {
                new FilesInfo()
                {
                    UserInfoID = 1,
                    Extension = "A",
                    FileAccess = false,
                    FileName = "B",
                    ShortUrl = "C"
                },
                 new FilesInfo()
                {
                    UserInfoID = 2,
                    Extension = "A",
                    FileAccess = false,
                    FileName = "B",
                    ShortUrl = "C"
                }
            };
        }
    }
}

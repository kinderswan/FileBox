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
            GetUserInfos().ForEach(c => context.UserInfos.Add(c));
            GetFilesInfos().ForEach(f => context.FilesInfos.Add(f));
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
        private static List<FilesInfo> GetFilesInfos()
        {
            return new List<FilesInfo>
            {
                new FilesInfo()
                {
                    //UsrID = 1,
                    Extension = "A",
                    FileAccess = false,
                    FileName = "B",
                    IsDirectory = false,
                    ShortUrl = "C"
                },
                 new FilesInfo()
                {
                    //UsrID = 2,
                    Extension = "A",
                    FileAccess = false,
                    FileName = "B",
                    IsDirectory = false,
                    ShortUrl = "C"
                }
            };
        }
    }
}

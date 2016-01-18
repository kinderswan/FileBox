using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Data.Infrastructure;
using FileBox.Model.Models;

namespace FileBox.Data.Repository
{
   public class UserInfoRepository : RepositoryBase<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}

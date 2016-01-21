using FileBox.Data.Infrastructure;
using FileBox.Data.Infrastructure.Concrete;
using FileBox.Data.Infrastructure.Interfaces;
using FileBox.Data.Repository.Interfaces;
using FileBox.Model.Models;

namespace FileBox.Data.Repository.Concrete
{
   public class UserInfoRepository : RepositoryBase<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}

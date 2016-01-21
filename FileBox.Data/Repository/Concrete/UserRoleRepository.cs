using FileBox.Data.Infrastructure;
using FileBox.Data.Infrastructure.Concrete;
using FileBox.Data.Infrastructure.Interfaces;
using FileBox.Data.Repository.Interfaces;
using FileBox.Model.Models;

namespace FileBox.Data.Repository.Concrete
{
    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}

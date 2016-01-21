using FileBox.Data.Infrastructure.Interfaces;

namespace FileBox.Data.Infrastructure.Concrete
{
    public class DbFactory : Disposable, IDbFactory
    {
        FileBoxEntities _dbContext;

        public FileBoxEntities Init()
        {
            return _dbContext ?? (_dbContext = new FileBoxEntities());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}

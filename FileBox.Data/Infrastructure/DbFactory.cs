using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBox.Data.Infrastructure
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

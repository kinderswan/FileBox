using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileBox.Data.Infrastructure;
using FileBox.Model.Models;

namespace FileBox.Data.Repository
{
    public class FilesInfoRepository : RepositoryBase<FilesInfo>, IFilesInfoRepository
    {
        public FilesInfoRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}

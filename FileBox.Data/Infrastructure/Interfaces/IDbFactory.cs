using System;

namespace FileBox.Data.Infrastructure.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        FileBoxEntities Init();
    }
}

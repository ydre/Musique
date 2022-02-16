using Musique.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Musique.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IArtistRepository Artists { get; }
        IMusicRepository Musics { get; }
        Task<int> CommitAsync();
    }
}

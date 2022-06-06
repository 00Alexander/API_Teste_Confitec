using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApiUsuario.Domain.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        bool HasActiveTransaction { get; }
        Guid GetTransactionId { get; }
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
        Task<Guid> BeginTransactionAsync();
        Task CommitTransactionAsync();
        void RollbackTransaction();
    }
}

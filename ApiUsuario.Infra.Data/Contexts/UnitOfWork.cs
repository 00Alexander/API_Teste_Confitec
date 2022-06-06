using ApiUsuario.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApiUsuario.Infra.Data.Contexts
{
    class UnitOfWork : IUnitOfWork, IDisposable, IScoped
    {
        private readonly DataContext _context;
        private IDbContextTransaction _currentTransaction;
        private bool _disposed;
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;
        public bool HasActiveTransaction => _currentTransaction != null;
        public Guid GetTransactionId => _currentTransaction.TransactionId;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        private void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    if (HasActiveTransaction)
                        this._currentTransaction.Dispose();
                    this._context.Dispose();
                }
            }

            this._disposed = true;
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var result = await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Guid> BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                return Guid.Empty;
            }

            try
            {
                _currentTransaction = await this._context.Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return _currentTransaction.TransactionId;
        }

        public async Task CommitTransactionAsync()
        {
            if (_currentTransaction == null) throw new ArgumentNullException(nameof(_currentTransaction));

            try
            {
                await this._context.SaveChangesAsync();
                _currentTransaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}

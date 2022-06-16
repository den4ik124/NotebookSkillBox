﻿using Notebook.Core;
using Notebook.Core.Interfaces.Repositories;
using System;
using System.Threading.Tasks;

namespace Notebook.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NotesDbContext context;

        public IRepository<Note> NotesRepository { get; private set; }

        public UnitOfWork(NotesDbContext context)
        {
            this.context = context;
            NotesRepository = new Repository<Note>(this.context);
        }

        public async Task BeginTransactionAsync()
        {
            await this.context.Database.BeginTransactionAsync();
        }

        public void TransactionCommit()
        {
            this.context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            this.context.Database.RollbackTransaction();
        }

        public async Task<bool> CompleteAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
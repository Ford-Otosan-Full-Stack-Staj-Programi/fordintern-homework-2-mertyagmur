using FordInternHW2.Data.Context;
using FordInternHW2.Data.Model;
using FordInternHW2.Data.Repository.Abstract;
using FordInternHW2.Data.Repository.Concrete;
using FordInternHW2.Data.UnitOfWork.Abstract;
using Microsoft.EntityFrameworkCore;

namespace FordInternHW2.Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;
        private bool disposed;

        public IGenericRepository<Account> AccountRepository { get; private set; }

        public IGenericRepository<Person> PersonRepository { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;

            AccountRepository = new GenericRepository<Account>(context);
            PersonRepository = new GenericRepository<Person>(context);
        }

        public void Complete()
        {
            context.SaveChanges();
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void CompleteWithTransaction()
        {
            using (var dbContextTransaction = context.Database.BeginTransaction())
            {
                try
                {
                    context.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                }
            }
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}

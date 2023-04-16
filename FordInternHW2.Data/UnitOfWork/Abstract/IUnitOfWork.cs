using FordInternHW2.Data.Model;
using FordInternHW2.Data.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FordInternHW2.Data.UnitOfWork.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Account> AccountRepository { get; }
        IGenericRepository<Person> PersonRepository { get; }
        void CompleteWithTransaction();
        void Complete();
        Task CompleteAsync();
    }
}

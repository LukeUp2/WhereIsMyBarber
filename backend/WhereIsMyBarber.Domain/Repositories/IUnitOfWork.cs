using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhereIsMyBarber.Domain.Repositories
{
    public interface IUnitOfWork
    {
        public Task Commit();
    }
}
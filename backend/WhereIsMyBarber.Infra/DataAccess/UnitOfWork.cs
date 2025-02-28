using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyBarber.Domain.Repositories;

namespace WhereIsMyBarber.Infra.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WhereIsMyBarberDbContext _db;

        public UnitOfWork(WhereIsMyBarberDbContext db)
        {
            _db = db;
        }

        public async Task Commit()
        {
            await _db.SaveChangesAsync();
        }
    }
}
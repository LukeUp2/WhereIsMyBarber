using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyBarber.Domain.Entities;
using WhereIsMyBarber.Domain.Repositories;

namespace WhereIsMyBarber.Infra.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WhereIsMyBarberDbContext _context;

        public UserRepository(WhereIsMyBarberDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<bool> UserWithEmailAlreadyExists(string email)
        {
            return await _context.Users.AsNoTracking().AnyAsync(u => u.Email == email);
        }

        public async Task<User?> GetUserWithEmailAndHashedPassword(string email, string hashedPassword)
        {
            return await _context.Users.Where(u => u.Email == email && u.HashedPassword == hashedPassword).FirstOrDefaultAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhereIsMyBarber.Domain.Entities;

namespace WhereIsMyBarber.Domain.Repositories
{
    public interface IUserRepository
    {
        Task Add(User user);

        Task<bool> UserWithEmailAlreadyExists(string email);

        Task<User?> GetUserWithEmailAndHashedPassword(string email, string hashedPassword);
    }
}
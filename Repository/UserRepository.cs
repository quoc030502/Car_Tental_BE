using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basic_api.Constants;
using basic_api.Data;
using basic_api.Dtos.User;
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Repository
{
    public class UserRepository : IUserInterface
    {
        private readonly ApplicationDBContext _context;

        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User> Create(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync((u) => u.Email == email);

            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.Where(u => u.Role == Roles.User).ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> ActiveUser(int id, ActiveUserRequest req)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null) return null;

            user.IsActive = req.IsActive;

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null) return null;

            _context.Users.Remove(user);

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User?> Update(User user)
        {
            await _context.SaveChangesAsync();

            return user;
        }
    }
}

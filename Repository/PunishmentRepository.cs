using System.Linq.Expressions;
using basic_api.Data;
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Repository
{
    public class PunishmentRepository(ApplicationDBContext context) : IPunishmentInterface
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Punishment> Create(ApplicationDBContext? context, Punishment punishment)
        {
            if (context != null)
            {
                await context.AddAsync(punishment);
                await context.SaveChangesAsync();
            }
            else
            {
                await _context.AddAsync(punishment);
                await _context.SaveChangesAsync();
            }

            return punishment;
        }

        public async Task<List<Punishment>> GetAll()
        {
            return await _context.Punishments.Include(p => p.Order).ToListAsync();
        }

        public async Task<Punishment?> TakePunishment(Expression<Func<Punishment, bool>> predicate)
        {
            var punishment = await _context.Punishments.Include(p => p.Order).FirstOrDefaultAsync(predicate);
            return punishment;
        }


        public async Task<Punishment?> Delete(int id)
        {
            var punishment = await _context.Punishments.FindAsync(id);

            if (punishment == null) return null;

            _context.Punishments.Remove(punishment);

            await _context.SaveChangesAsync();

            return punishment;
        }

        public async Task<Punishment?> Update(Punishment punishment)
        {
            await _context.SaveChangesAsync();

            return punishment;
        }
    }
}

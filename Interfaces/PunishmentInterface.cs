using System.Linq.Expressions;
using basic_api.Data;
using basic_api.Models;

namespace basic_api.Interfaces
{
    public interface IPunishmentInterface
    {
        Task<Punishment> Create(ApplicationDBContext? context, Punishment punishment);
        Task<List<Punishment>> GetAll();
        Task<Punishment?> TakePunishment(Expression<Func<Punishment, bool>> predicate);
        Task<Punishment?> Delete(int id);
        Task<Punishment?> Update(Punishment punishment);
    }
}
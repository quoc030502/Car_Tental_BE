using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basic_api.Models;

namespace basic_api.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetByIdAsync(int id);
    }
}

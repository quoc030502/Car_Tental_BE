using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basic_api.Dtos.Stock;
using basic_api.Models;

namespace basic_api.Interfaces
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync();
        Task<Stock?> GetByIdAsync(int id);
        Task<Stock> CreateAsync(Stock stockModel);
        Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Task<Stock?> DeleteAsync(int id);
    }
}

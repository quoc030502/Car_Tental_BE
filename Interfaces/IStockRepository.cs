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
        Task<List<Car>> GetAllAsync();
        Task<Car?> GetByIdAsync(int id);
        Task<Car> CreateAsync(Car stockModel);
        Task<Car?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Task<Car?> DeleteAsync(int id);
    }
}

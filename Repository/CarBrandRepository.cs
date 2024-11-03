using basic_api.Data;
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Repository
{
    public class CarBrandRepository(ApplicationDBContext context) : ICarBrandInterface
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<CarBrand> Create(CarBrand carBrand)
        {
            await _context.AddAsync(carBrand);
            await _context.SaveChangesAsync();

            return carBrand;
        }

        public async Task<List<CarBrand>> GetAll()
        {
            return await _context.CarBrands.Include(ct => ct.Cars).ToListAsync();
        }


        public async Task<CarBrand?> Delete(int id)
        {
            var carBrand = await _context.CarBrands.FindAsync(id);

            if (carBrand == null) return null;

            _context.CarBrands.Remove(carBrand);

            await _context.SaveChangesAsync();

            return carBrand;
        }
    }
}

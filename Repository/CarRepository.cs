using basic_api.Data;
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Repository
{
    public class CarRepository : ICarInterface
    {
        private readonly ApplicationDBContext _context;

        public CarRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Car> Create(Car car)
        {
            await _context.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<List<Car>> GetAll()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car?> GetCarById(int id)
        {
            return await _context.Cars.FindAsync(id);
        }


        public async Task<Car?> Delete(int id)
        {
            var Car = await _context.Cars.FindAsync(id);

            if (Car == null) return null;

            _context.Cars.Remove(Car);

            await _context.SaveChangesAsync();

            return Car;
        }

        public async Task<Car?> Update(Car car)
        {
            await _context.SaveChangesAsync();

            return car;
        }
    }
}

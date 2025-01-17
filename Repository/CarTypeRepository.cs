﻿using basic_api.Data;
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Repository
{
    public class CarTypeRepository(ApplicationDBContext context) : ICarTypeInterface
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<CarType> Create(CarType carType)
        {
            await _context.AddAsync(carType);
            await _context.SaveChangesAsync();

            return carType;
        }

        public async Task<List<CarType>> GetAll()
        {
            return await _context.CarTypes.Where(ct => ct.DeletedAt == null).Include(ct => ct.Cars).ToListAsync();
        }

        public async Task<CarType?> GetCarTypeById(int id)
        {
            return await _context.CarTypes.Where(ct => ct.DeletedAt == null).Include(ct => ct.Cars)
              .FirstOrDefaultAsync(ct => ct.Id == id);
        }



        public async Task<CarType?> Delete(int id)
        {
            var carType = await _context.CarTypes.FindAsync(id);

            if (carType == null) return null;

            carType.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return carType;
        }

        public async Task<CarType?> Update(CarType carType)
        {
            await _context.SaveChangesAsync();

            return carType;
        }

        public async Task<List<CarType>> GuessGetAll()
        {
            return await _context.CarTypes.Where(ct => ct.DeletedAt == null).ToListAsync();
        }

    }
}

using basic_api.Data;
using basic_api.Dtos;
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Repository
{
    public class CarRepository(ApplicationDBContext context) : ICarInterface
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Car> Create(Car car)
        {
            await _context.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<List<GetListCarResponse>> GetAll()
        {
            var carsWithType = await _context.Cars
              .Where(c => c.DeletedAt == null)
              .Select(c => new GetListCarResponse
              {
                  Id = c.Id,
                  Name = c.Name,
                  CarTypeID = c.CarTypeID,
                  CarBrandID = c.CarBrandID,
                  LicensePlate = c.LicensePlate,
                  IsInUse = c.IsInUse,
                  Seats = c.Seats,
                  PricePerDay = c.PricePerDay,
                  PricePerHour = c.PricePerHour,
                  ImageURL = c.ImageURL,
                  Fuel = c.Fuel,
                  CarType = new CarTypeInCarList
                  {
                      Type = c.CarType.Type
                  },
                  CarBrand = new CarBrandInCarList
                  {
                      Brand = c.CarBrand.Brand
                  }
              })
              .ToListAsync();

            return carsWithType;
        }

        public async Task<Car?> GetCarById(int? id)
        {
            return await _context.Cars.Where(c => c.DeletedAt == null).Include(car => car.CarType)
              .Include(car => car.CarBrand).FirstOrDefaultAsync(car => car.Id == id);
        }


        public async Task<Car?> Delete(int id)
        {
            var car = await _context.Cars.FindAsync(id);

            if (car == null) return null;

            car.DeletedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car?> Update(Car car)
        {
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<List<UserGetListCarResponse>> UserGetAll(UserGetListCarRequest req)
        {
            var db = _context.Cars.Where(c => c.DeletedAt == null).AsQueryable();

            if (req.CarType != null)
                db = db.Where(c => c.CarType.Type == req.CarType);

            if (req.IsInUse != null)
                db = db.Where(c => c.IsInUse == req.IsInUse);

            // if (req.Sort != null){
            //   db = db.OrderByDescending(c => 
            // }

            var cars = await db
              .Select(c => new UserGetListCarResponse
              {
                  Id = c.Id,
                  Name = c.Name,
                  CarTypeID = c.CarTypeID,
                  CarBrandID = c.CarBrandID,
                  LicensePlate = c.LicensePlate,
                  IsInUse = c.IsInUse,
                  PricePerDay = c.PricePerDay,
                  PricePerHour = c.PricePerHour,
                  ImageURL = c.ImageURL,
                  Seats = c.Seats,
                  Fuel = c.Fuel,
                  CarType = new CarTypeInCarList
                  {
                      Type = c.CarType.Type
                  },
                  CarBrand = new CarBrandInCarList
                  {
                      Brand = c.CarBrand.Brand
                  }
              })
              .ToListAsync();

            return cars;
            // return await _context.Cars.ToListAsync();
        }

        public async Task<List<GuessGetListCarResponse>> GuessGetAll(GuessGetListCarRequest req)
        {
            var db = _context.Cars.Where(c => c.DeletedAt == null).AsQueryable();

            if (req.CarType != null)
                db = db.Where(c => c.CarType.Type == req.CarType);


            // if (req.Sort != null){
            //   db = db.OrderByDescending(c => 
            // }

            var cars = await db
              .Select(c => new GuessGetListCarResponse
              {
                  Id = c.Id,
                  Name = c.Name,
                  CarTypeID = c.CarTypeID,
                  LicensePlate = c.LicensePlate,
                  PricePerDay = c.PricePerDay,
                  PricePerHour = c.PricePerHour,
                  ImageURL = c.ImageURL,
              })
              .ToListAsync();

            return cars;
            // return await _context.Cars.ToListAsync();
        }
    }
}

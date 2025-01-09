using System.Linq.Expressions;
using basic_api.Data;
using basic_api.Dtos;
using basic_api.Interfaces;
using basic_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Repository
{
    public class OrderRepository(ApplicationDBContext context) : IOrderInterface
    {
        private readonly ApplicationDBContext _context = context;

        public async Task<Order> Create(ApplicationDBContext? context, Order Order)
        {
            if (context != null)
            {
                await context.AddAsync(Order);
                await context.SaveChangesAsync();
            }
            else
            {
                await _context.AddAsync(Order);
                await _context.SaveChangesAsync();
            }

            return Order;
        }

        public async Task<List<OrderDto>> GetAll(string? status)
        {
            var db = _context.Orders.AsQueryable();

            if (status != null)
                db = db.Where(o => o.Status == status);

            var orders = await db.Select(o => new OrderDto
            {
                Id = o.Id,
                UserID = o.UserID,
                CouponID = o.CouponID,
                IsPay = o.IsPay,
                IsDeposit = o.IsDeposit,
                WithDriver = o.WithDriver,
                Status = o.Status,
                Message = o.Message,
                Cost = o.Cost,
                Deposit = o.Deposit,
                Contract = o.Contract,
                Evidence = o.Evidence,
                Punishment = o.Punishment.Amount,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt,
                Image = o.Images.Select(i => new ImageDto
                {
                    ImageURL = i.ImageURL,
                    Type = i.Type
                }).ToList(),
                User = new UserDto
                {
                    Id = o.User.Id,
                    Phone = o.User.Phone,
                    Email = o.User.Email,
                    Username = o.User.Username,
                },
                CarOrder = o.CarOrders.Select(co => new CarOrderDto
                {
                    Id = co.Id,
                    CarID = co.CarID,
                    StartDate = co.StartDate,
                    EndDate = co.EndDate,
                    Car = new CarDto
                    {
                        Id = co.Car.Id,
                        Name = co.Car.Name,
                        LicensePlate = co.Car.LicensePlate,
                        PricePerDay = co.Car.PricePerDay,
                        PricePerHour = co.Car.PricePerHour,
                        ImageURL = co.Car.ImageURL,
                        Fuel = co.Car.Fuel,
                        Seats = co.Car.Seats
                    }
                }).ToList()
            }).ToListAsync();

            return orders;
        }

        public async Task<List<OrderDto>> GetMyOrder(string? status, int? userId)
        {
            var db = _context.Orders.AsQueryable();

            if (status != null)
                db = db.Where(o => o.Status == status);

            var orders = await db
            .Where(o => o.UserID == userId)
            .Select(o => new OrderDto
            {
                Id = o.Id,
                UserID = o.UserID,
                CouponID = o.CouponID,
                IsPay = o.IsPay,
                IsDeposit = o.IsDeposit,
                WithDriver = o.WithDriver,
                Status = o.Status,
                Message = o.Message,
                Cost = o.Cost,
                Deposit = o.Deposit,
                Punishment = o.Punishment.Amount,
                Contract = o.Contract,
                Evidence = o.Evidence,
                CreatedAt = o.CreatedAt,
                UpdatedAt = o.UpdatedAt,
                User = new UserDto
                {
                    Id = o.User.Id,
                    Phone = o.User.Phone,
                    Email = o.User.Email,
                    Username = o.User.Username,
                },
                Image = o.Images.Select(i => new ImageDto
                {
                    ImageURL = i.ImageURL,
                    Type = i.Type
                }).ToList(),
                CarOrder = o.CarOrders.Select(co => new CarOrderDto
                {
                    Id = co.Id,
                    CarID = co.CarID,
                    StartDate = co.StartDate,
                    EndDate = co.EndDate,
                    Car = new CarDto
                    {
                        Id = co.Car.Id,
                        Name = co.Car.Name,
                        LicensePlate = co.Car.LicensePlate,
                        PricePerDay = co.Car.PricePerDay,
                        PricePerHour = co.Car.PricePerHour,
                        ImageURL = co.Car.ImageURL,
                        Fuel = co.Car.Fuel,
                        Seats = co.Car.Seats
                    }
                }).ToList()
            }).ToListAsync();


            return orders;
        }

        public async Task<Order?> GetOrderById(int id)
        {
            return await _context.Orders
            .Include(o => o.CarOrders)
            .ThenInclude(co => co.Car)
            .FirstOrDefaultAsync(o => o.Id == id);
        }


        public async Task<Order?> Delete(int id)
        {
            var Order = await _context.Orders.FindAsync(id);

            if (Order == null) return null;

            _context.Orders.Remove(Order);

            await _context.SaveChangesAsync();

            return Order;
        }

        public async Task<Order?> Update(ApplicationDBContext? context, Order Order)
        {
            if (context != null)
            {
                await context.SaveChangesAsync();
            }
            else
            {
                await _context.SaveChangesAsync();
            }

            return Order;
        }

        public async Task<List<Order>> CronGetAll(Expression<Func<Order, bool>> predicate)
        {
            return await _context.Orders.Where(predicate).Include(co => co.CarOrders.Where(co => co.EndDate < DateTime.Now)).ToListAsync();
        }

        public async Task<Order?> GetOrderByUserIDAndCarID(int carID, int userID)
        {
            return await _context.Orders.Where(o => o.UserID == userID).Include(o => o.CarOrders.Where(co => co.CarID == carID)).FirstOrDefaultAsync();
        }
    }
}
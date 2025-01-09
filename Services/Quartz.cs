using basic_api.Constants;
using basic_api.Data;
using basic_api.Interfaces;
using basic_api.Models;
using Quartz;
using System;
using System.Threading.Tasks;
namespace basic_api.Services
{
    public class DailyJob(Service service, IOrderInterface orderRepo, IUserInterface userRepo) : IJob
    {
        private readonly Service _service = service;
        private readonly IOrderInterface _orderRepo = orderRepo;
        private readonly IUserInterface _userRepo = userRepo;
        public async Task Execute(IJobExecutionContext context)

        {
            var orders = await _orderRepo.CronGetAll(o => o.Status != OrderStatus.Success);

            foreach (var order in orders)
            {

                Console.WriteLine("orders.Count---------------------------------------------------------------------");
                Console.WriteLine(order.UserID);

                var user = await _userRepo.GetUserById(order.UserID);
                Console.WriteLine(order.CarOrders.FirstOrDefault().EndDate.ToString("yyyy-MM-dd HH:mm"));
                Console.WriteLine(order.Id);
                if (user == null)
                {
                    Console.WriteLine(ErrorMessages.UserNotFound);
                    continue;
                }
                await _service.SendEmailRemind(user.Email, user.Username, order.CarOrders.FirstOrDefault().EndDate.ToString("yyyy-MM-dd HH:mm"));
            }
            // return Task.CompletedTask;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using basic_api.Models;
using Microsoft.EntityFrameworkCore;

namespace basic_api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options) { }

        public DbSet<Car> Stocks { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}

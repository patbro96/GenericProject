using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication7.Models;

namespace WebApplication7.Persistence
{
    public class CarDbContext: DbContext
    {
        public CarDbContext() : base("Cars")
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
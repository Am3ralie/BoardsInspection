//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BoardsInspection.Infrastructure.Data
//{
//    internal class ApplicationDbContext
//    {
//    }
//}

using BoardsInspection.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace BoardsInspection.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<Event> Events { get; set; }
    }
}

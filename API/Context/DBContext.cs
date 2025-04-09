using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models.User;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        public DbSet<Users> Users { get; set; }
        // public DbSet<Vehicles> Vehicles { get; set; }
        // public DbSet<Orders> Orders { get; set; }
    }
}
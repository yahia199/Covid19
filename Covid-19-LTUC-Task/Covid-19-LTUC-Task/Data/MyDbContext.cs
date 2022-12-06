using Covid_19_LTUC_Task.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid_19_LTUC_Task.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<Countries> Countries { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}

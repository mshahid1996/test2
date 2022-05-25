using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class EmpCoreDBContext : DbContext
    {

        public EmpCoreDBContext(DbContextOptions<EmpCoreDBContext> options) : base(options)
        {
        }

        public DbSet<Emp>  Employees { get; set; }


    }
}

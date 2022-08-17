using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MSSQL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSSQL.Data
{
    public class MssqlDbContext : DbContext
    {
        public DbSet<TelopModel> Telops { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=test;User Id=TestLogin;Password=TestLogin;");
        }
    }
}

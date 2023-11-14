using Microsoft.EntityFrameworkCore;
using SimpleCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCrud.Data
{
    internal class SimpleCrudDataContext : DbContext
    {

        // TODO: Add DbSet properties for each model class
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                "server=localhost;" +                     // Server name
                "port=3306;" +                            // Server port
                "user=c_sharp_dev;" +                     // Username
                "password=abc;" +                 // Password
                "database=csd_iv_PersonApp_v1_0_1;"       // Database name
                , Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql") // Version
                );

        }
    }
}

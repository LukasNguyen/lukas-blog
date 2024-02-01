using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LukasBlog.Data
{
    public class LukasBlogContextFactory : IDesignTimeDbContextFactory<LukasBlogContext>
    {
        public LukasBlogContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<LukasBlogContext>();
            builder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new LukasBlogContext(builder.Options);
        }
    }
}

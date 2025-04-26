using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Context
{
    public class RentACarContextFactory : IDesignTimeDbContextFactory<RentACarContext>
    {
        public RentACarContext CreateDbContext(string[] args)
        {

            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "..\\RentACar.WebAPI"));
            // appsettings.json dosyasını oku
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Connection string'i al
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // DbContextOptions oluştur
            var optionsBuilder = new DbContextOptionsBuilder<RentACarContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new RentACarContext(optionsBuilder.Options);
        }
    }
}

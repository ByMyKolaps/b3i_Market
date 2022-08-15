using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace DAL
{
    public static class Services
    {
        public static ServiceProvider CollectionServices = ServiceProvider();
        private static ServiceProvider ServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IMongoClient>(provider =>
                new MongoClient("mongodb://localhost/myFirstDatabase?retryWrites=true&w=majority"));
            services.AddDbContext<MarketContext>(options =>
                options.UseNpgsql("Host=localhost;Port=5432;Database=b3i;Username=postgres;Password=postgres;"));
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }
    }
}

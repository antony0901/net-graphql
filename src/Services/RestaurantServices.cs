using System.Linq;
using Microsoft.EntityFrameworkCore;
using src.Db;
using src.Models;

namespace src.Services
{
    public class RestaurantServices
    {
        private readonly AppDbContext _dbContext;

        public RestaurantServices(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContext = dbContextFactory.CreateDbContext();
        }

        public IQueryable<Restaurant> GetRestaurants()
        {
            return _dbContext.Set<Restaurant>()
            .Where(x => x.Status == StatusEnum.Active);
        }
    }
}
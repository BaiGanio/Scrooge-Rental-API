using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Query
    {
        [UseDbContext(typeof(AppDbCtx))]
        [UseProjection]
        public IQueryable<User> GetUsers([ScopedService] AppDbCtx ctx)
        {
            var res =  ctx.Users;
            return res;
        }

        [UseDbContext(typeof(AppDbCtx))]
        [UseProjection]
        public IQueryable<Order> GetOrders([ScopedService] AppDbCtx ctx)
        {
            return ctx.Orders;
        }

        [UseDbContext(typeof(AppDbCtx))]
        [UseProjection]
        public IQueryable<Car> GetCars([ScopedService] AppDbCtx ctx)
        {
            return ctx.Cars;
        }
    }
}

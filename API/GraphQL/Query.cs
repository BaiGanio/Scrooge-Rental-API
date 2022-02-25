namespace API
{
    public class Query
    {
        [UseDbContext(typeof(AppDbCtx))]
        public IQueryable<User> GetUsers([ScopedService] AppDbCtx ctx)
        {
            return ctx.Users;
        }

        [UseDbContext(typeof(AppDbCtx))]
        public IQueryable<Order> GetOrders([ScopedService] AppDbCtx ctx)
        {
            return ctx.Orders;
        }

        [UseDbContext(typeof(AppDbCtx))]
        public IQueryable<Car> GetCars([ScopedService] AppDbCtx ctx)
        {
            return ctx.Cars;
        }
    }
}

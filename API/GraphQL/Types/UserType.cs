namespace API
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Represents user and orders");

            descriptor
                .Field(u => u.Orders)
                .ResolveWith<Resolvers>(r => r.GetOrders(default!, default!))
                .UseDbContext<AppDbCtx>()
                .Description("This is an actual orders requested by the issuer");

            //descriptor
            //    .Field(o => o.Car)
            //    .ResolveWith<Resolvers>(o => o.GetCar(default!, default!))
            //    .UseDbContext<AppDbCtx>()
            //    .Description("This is the requested car");
        }

        private class Resolvers
        {
            public IQueryable GetOrders(User user, [ScopedService] AppDbCtx ctx) 
            {
                return ctx.Orders.Where(o => o.UserId == user.Id);
            }

            //public IQueryable GetCar(Order order, [ScopedService] AppDbCtx ctx)
            //{
            //    return ctx.Cars.Where(c => c.Id == order.CarId);
            //}
        }
    }
}

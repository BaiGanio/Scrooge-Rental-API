namespace API
{
    public class OrderType : ObjectType<Order>
    {
        protected override void Configure(IObjectTypeDescriptor<Order> descriptor)
        {
            descriptor.Description("Represents user and orders");

            descriptor
                .Field(o => o.User)
                .ResolveWith<Resolvers>(r => r.GetUser(default!, default!))
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
            public IQueryable GetUser(Order order, [ScopedService] AppDbCtx ctx)
            {
                return ctx.Users.Where(u => u.Id == order.UserId);
            }

            //public IQueryable GetCar(Order order, [ScopedService] AppDbCtx ctx)
            //{
            //    return ctx.Cars.Where(c => c.Id == order.CarId);
            //}
        }
    }
}

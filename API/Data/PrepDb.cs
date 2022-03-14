namespace API
{
    public static class PrepDb
    {
        public static void PopulateDb(IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var ctx = scope.ServiceProvider.GetService<AppDbCtx>();
            SeedData(ctx);
        }

        private static void SeedData(AppDbCtx ctx)
        {
            var bugsy = new User() { Id = Guid.NewGuid(), FirstName = "Bugs", LastName = "Bunny", Email = "busgy@mail.com"};
            var daffy = new User() { Id = Guid.NewGuid(), FirstName = "Daffy", LastName = "Duck", Email = "daffy@mail.com" };
            var johnDoe = new User() { Id = Guid.NewGuid(), FirstName = "John", LastName = "Doe", Email = "john@mail.com" };
            var micki = new User() { Id = Guid.NewGuid(), FirstName = "Micki", LastName = "Mouse", Email = "micki@mail.com" };
            var pinko = new User() { Id = Guid.NewGuid(), FirstName = "Pink", LastName = "Panther", Email = "pinko@mail.com" };
            var taz = new User() { Id = Guid.NewGuid(), FirstName = "Taz", LastName = "Tasmanian Devil", Email = "taz@mail.com" };

            if (!ctx.Users.Any())
            {
                ctx.AddRange(johnDoe, micki, pinko, taz, daffy, bugsy);
                ctx.SaveChanges();
            }

            var r8 = new Car() 
            { 
                Id = Guid.NewGuid(), 
                Maker = Maker.Audi.ToString(), 
                Model = "R8", 
                Year = new DateTime(2022, 4, 1), 
                FuelType = FuelType.Petrol.ToString(),
                ImageUrl = "https://howtokodi.co/wp-content/uploads/2020/12/review-and-release-date-audi-r8-2022-black.jpg" 
            };
            var porsche = new Car() 
            { 
                Id = Guid.NewGuid(), 
                Maker = Maker.Porsche.ToString(), 
                Model = "Taycan", 
                Year = new DateTime(2021, 12, 27), 
                FuelType = FuelType.Petrol.ToString(), 
                ImageUrl = "https://i.redd.it/na61w3fiwnw31.jpg" 
            };
            var etron = new Car() 
            { 
                Id = Guid.NewGuid(), 
                Maker = Maker.Audi.ToString(), 
                Model = "ETron GT", 
                Year = new DateTime(2022, 1, 1), 
                FuelType = FuelType.Electric.ToString(), 
                ImageUrl = "https://static1.hotcarsimages.com/wordpress/wp-content/uploads/2021/01/e-tron-gt.jpg" 
            };

            if (!ctx.Cars.Any())
            {
                ctx.AddRange(r8, porsche, etron);
                ctx.SaveChanges();
            }

            if (!ctx.Orders.Any())
            {
                ctx.AddRange(
                    new Order() { Id = Guid.NewGuid(), Title = "Rent the R8 for the weekend", Car = r8, User = bugsy },
                    new Order() { Id = Guid.NewGuid(), Title = "Getting the electricity outside for a ride", Car = porsche, User = bugsy },
                    new Order() { Id = Guid.NewGuid(), Title = "Driving like lightning over the weekend", Car = etron, User = daffy },
                    new Order() { Id = Guid.NewGuid(), Title = "Doing nothing but showing off to the crowd", Car = etron, User = johnDoe }
                );
                ctx.SaveChanges();
            }

        }
    }
}

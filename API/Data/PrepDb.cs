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
            var bugsId = Guid.NewGuid();
            var daffyId = Guid.NewGuid();
            var johnId = Guid.NewGuid();
            if (!ctx.Users.Any())
            {
                ctx.AddRange(
                        new User() { Id = johnId, FirstName = "John", LastName = "Doe" },
                         new User() { Id = Guid.NewGuid(), FirstName = "Miki", LastName = "Mouse" },
                         new User() { Id = Guid.NewGuid(), FirstName = "Pink", LastName = "Panther" },
                         new User() { Id = daffyId, FirstName = "Daffy", LastName = "Duck" },
                         new User() { Id = bugsId, FirstName = "Bugs", LastName = "Bunny" },
                         new User() { Id = Guid.NewGuid(), FirstName = "Tasmanian", LastName = "Devil" }
                    );

                ctx.SaveChanges();
            }

            var r8Id = Guid.NewGuid();
            var porscheId = Guid.NewGuid();
            var etronId = Guid.NewGuid();
            if (!ctx.Cars.Any())
            {
                ctx.AddRange(
                        new Car() { Id = r8Id, Maker = Maker.Audi.ToString(), Model = "R8", Year = new DateTime(2022, 4, 1), FuelType = FuelType.Petrol.ToString(), ImageUrl = "https://howtokodi.co/wp-content/uploads/2020/12/review-and-release-date-audi-r8-2022-black.jpg" },
                         new Car() { Id = porscheId, Maker = Maker.Porsche.ToString(), Model = "Taycan", Year = new DateTime(2021, 12, 27), FuelType = FuelType.Petrol.ToString(), ImageUrl = "https://i.redd.it/na61w3fiwnw31.jpg" },
                         new Car() { Id = etronId, Maker = Maker.Audi.ToString(), Model = "ETron GT", Year = new DateTime(2022, 1, 1), FuelType = FuelType.Electric.ToString(), ImageUrl = "https://static1.hotcarsimages.com/wordpress/wp-content/uploads/2021/01/e-tron-gt.jpg" }
                    );

                ctx.SaveChanges();
            }

            if (!ctx.Orders.Any())
            {
                ctx.AddRange(
                        new Order() { Id = Guid.NewGuid(), Title="Rent the R8 for the weekend", CarId = r8Id, UserId = bugsId},
                        new Order() { Id = Guid.NewGuid(), Title = "Getting the electricity outside for a ride", CarId = porscheId, UserId = bugsId },
                        new Order() { Id = Guid.NewGuid(), Title = "Driving like lightning over the weekend", CarId = etronId, UserId = daffyId },
                        new Order() { Id = Guid.NewGuid(), Title = "Doing nothing but showing off to the crowd", CarId = etronId, UserId = johnId }
                    );

                ctx.SaveChanges();
            }

        }
    }
}

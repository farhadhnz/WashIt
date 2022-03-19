using WashIt.API.Models;

namespace WashIt.API.Data
{
    public static class DbPrep
    {
        public static void PreparePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Devices.Any())
            {
                Console.WriteLine(" --> Populating Database...");

                context.Devices.AddRange(
                    new Machine() { Name = "Mahchine 01" },
                    new Machine() { Name = "Mahchine 02" },
                    new Machine() { Name = "Mahchine 03" },
                    new Machine() { Name = "Mahchine 04" },
                    new Machine() { Name = "Mahchine 05" },
                    new Machine() { Name = "Mahchine 06" },
                    new Machine() { Name = "Mahchine 07" },
                    new Machine() { Name = "Mahchine 08" },
                    new Machine() { Name = "Mahchine 09" },
                    new Machine() { Name = "Mahchine 10" },
                    new Machine() { Name = "Mahchine 11" },
                    new Machine() { Name = "Mahchine 12" }
                );
                context.SaveChanges();
            }
            else
                Console.WriteLine(" --> We already have data");
        }
    }
}
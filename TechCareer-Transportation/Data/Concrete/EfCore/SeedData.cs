using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<TransportContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Jobs.Any())
                {
                    context.Jobs.AddRange(
                        new Job { JobName = "Driver"},
                        new Job { JobName = "Worker" }
                    );
                    context.SaveChanges();
                }
                if (!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "mertacar", Name = "Mert Acar", Email = "mert@mert.com", Password = "123456", Image = "p1.jpg" },
                        new User { UserName = "yigitacar", Name = "Yigit Acar", Email = "yigit@yigit.com", Password = "123456", Image = "p2.jpg" }
                    );
                    context.SaveChanges();
                }
                if (!context.Companies.Any())
                {
                    context.Companies.AddRange(
                        new Company { CompanyName = "Mert Nakliyat", Vehicles = context.Vehicles.Take(1).Where(x => x.VehicleId == 1).ToList(),Url="mert" ,UserId=1},
                        new Company { CompanyName = "Yigit Nakliyat", Vehicles = context.Vehicles.Take(1).Where(x => x.VehicleId == 2).ToList(),Url="yigit",UserId=1 },
                        new Company { CompanyName = "Mehmet Nakliyat", Vehicles = context.Vehicles.Take(1).Where(x => x.VehicleId == 3).ToList(),Url="mehmet" ,UserId=1},
                        new Company { CompanyName = "Fatih Nakliyat", Vehicles = context.Vehicles.Take(1).Where(x => x.VehicleId == 4).ToList(),Url="fatih" ,UserId=1},
                        new Company { CompanyName = "Eymen Nakliyat", Vehicles = context.Vehicles.Take(1).Where(x => x.VehicleId == 5).ToList() ,Url="eymen",UserId=1}
                    );
                    context.SaveChanges();
                }
                
                if (!context.Vehicles.Any())
                {
                    context.Vehicles.AddRange(
                        new Vehicle { VehicleType = "Kamyon", EnergySource = "Benzin", CountOfWheel = "10", Brand = "Mercedes", Workers = context.Workers.Take(1).Where(x => x.WorkerId == 1).ToList(), CompanyId = 1 },
                        new Vehicle { VehicleType = "Tır", EnergySource = "Benzin", CountOfWheel = "12", Brand = "Fiat", Workers = context.Workers.Take(1).Where(x => x.WorkerId == 2).ToList(), CompanyId = 1 },
                        new Vehicle { VehicleType = "Kamyonet", EnergySource = "Benzin", CountOfWheel = "8", Brand = "Bedford", Workers = context.Workers.Take(1).Where(x => x.WorkerId == 3).ToList(), CompanyId = 3 },
                        new Vehicle { VehicleType = "Kamyon", EnergySource = "Mazot", CountOfWheel = "10", Brand = "Fuso", Workers = context.Workers.Take(1).Where(x => x.WorkerId == 4).ToList(), CompanyId = 4 },
                        new Vehicle { VehicleType = "Tır", EnergySource = "Mazot", CountOfWheel = "12", Brand = "Askam", Workers = context.Workers.Take(1).Where(x => x.WorkerId == 5).ToList(), CompanyId = 5 }
                    );
                    context.SaveChanges();
                }
                if (!context.Workers.Any())
                {
                    context.Workers.AddRange(
                        new Worker { WorkerName = "Ahmet",JobId=1,VehicleId= 1},
                        new Worker { WorkerName = "Mehmet",JobId=1,VehicleId=2},
                        new Worker { WorkerName = "Veli", JobId = 1, VehicleId = 3, },
                        new Worker { WorkerName = "Yunus",JobId=1,VehicleId=4 },
                        new Worker { WorkerName = "Sedat",JobId=1,VehicleId=5}
                    );
                    context.SaveChanges();
                }
                
               
            }
        }
    }
}
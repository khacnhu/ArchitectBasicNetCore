using Restaurant.Domain.Entities;
using Restaurant.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Seeders
{
    internal class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantSeeder
    {

        public async Task Seed()
        {
            if (await dbContext.Database.CanConnectAsync())
            {
                if (!dbContext.restaurants.Any())
                {
                    var restaurantsList = GetRestaurants();
                    dbContext.restaurants.AddRange(restaurantsList);
                    await dbContext.SaveChangesAsync();
                }
            }
        }

        private IEnumerable<ResTauRant> GetRestaurants()
        {
            List<ResTauRant> resTauRants = new List<ResTauRant>()
            {
                new()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC (short for Kentucky Fried Chicken) is an American fast food restaurant",
                    ContactEmail="contact@kfc.com",
                    HasDelivery =true,
                    Dishes=
                    [
                        new() {
                            Name = "NashVille Hot Chicken",
                            Description = "Nashville Hot Chicken Vip pro 10 pcs",
                            Price = 10.30M
                        },
                        new() {
                            Name = "Chicken Nugets",
                            Description = "Chicken Nugets 5 pcs",
                            Price = 5.30M
                        }
                        ],
                    Address = new Address()
                    {
                        City = "London",
                        Street = "Cork St 5",
                        PostalCode = "WC2N 5DU"
                    }
                },
                new ResTauRant ()
                {
                    Name = "MC Donald",
                    Category = "Fast Food",
                    Description = "MC Donald (short for MC Donald MC Donald MC Donald) is an American fast food restaurant",
                    ContactEmail="contact@MCDonald.com",
                    HasDelivery =true,
                    Dishes=
                    [
                        new() {
                            Name = "MC Donald MC Donald MC Donald",
                            Description = "MC Donald Hot MC Donald Vip pro 10 pcs",
                            Price = 13.34M
                        },
                        new() {
                            Name = "MC Donald MC Donald",
                            Description = "MC Donald Chicken Nugets 5 pcs",
                            Price = 15.32M
                        }
                        ],
                       Address = new Address()
                    {
                        City = "New York",
                        Street = "LE THANH PHUONG",
                        PostalCode = "WCN620000"
                    }
                },

            };

            return resTauRants;
        }

    }
}

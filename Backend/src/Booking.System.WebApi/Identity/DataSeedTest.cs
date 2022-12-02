using Booking.System.WebApi.Data;
using Booking.System.WebApi.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Booking.System.WebApi.Identity
{
    public class DataSeedTest
    {
        public static async Task SeedDataAsync(SecurityDbContext context, UserManager<IdentityUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var users = new List<AppUser>
                            {
                                new AppUser
                                    {
                                        DisplayName = "TestUserFirst",
                                        UserName = "TestUserFirst",
                                        Email = "testuserfirst@test.com"
                                    },

                                new AppUser
                                    {
                                        DisplayName = "TestUserSecond",
                                        UserName = "TestUserSecond",
                                        Email = "testusersecond@test.com"
                                    }
                              };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "123qweASD");
                }
            }
        }
    }
}
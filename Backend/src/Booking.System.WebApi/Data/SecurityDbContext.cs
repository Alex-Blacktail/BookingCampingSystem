using Booking.System.WebApi.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Booking.System.WebApi.Data
{
    public class SecurityDbContext : IdentityDbContext<AppUser>
    {
        public SecurityDbContext(DbContextOptions options)
            : base(options) { }
    }
}

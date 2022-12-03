using Booking.System.Domain.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Booking.System.WebApi.Data
{
    public class SecurityDbContext : IdentityDbContext<AppUser>
    {
        public SecurityDbContext(DbContextOptions<SecurityDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}

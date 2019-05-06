using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.RestApi
{
    public class AppDataContext : IdentityDbContext<IdentityUser>
    {

        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
              new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "User", NormalizedName = "USER" }
                );
            builder.Entity<IdentityUser>().HasData(
                    new
                    {
                        Id = "1",
                        UserName = "CrmAdmin",
                        NormalizedUserName = "CRMADMIN",
                        EmailConfirmed = true,
                        PasswordHash = "",
                        PhoneNumberConfirmed = false,
                        TwoFactorEnabled = false,
                        LockoutEnabled = false,
                        AccessFailedCount = 0
                    }
                );
        }
        public DbSet<Assignment> Assignments { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<AssignmentStatus> AssignmentStatuses { get; set; }
    }
}

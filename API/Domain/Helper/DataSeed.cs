using Domain.Entity;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Helper
{
    internal static class DataSeed
    {
        internal static void PopulateAdminAndRoles(this ModelBuilder builder)
        {
            string adminUserId = "662278bb-5893-4b8c-89f0-592edfacef22";
            string adminRoleId = "8a49e3ac-aa54-4b4c-8e7a-b9f99f67e7f7";

            var adminRole = new IdentityRole()
            {
                Id = adminRoleId,
                Name = RoleType.Admin.ToString(),
                ConcurrencyStamp = "1f900332-556d-4f74-8700-91161c4118b4",
                NormalizedName = RoleType.Admin.ToString().ToUpper()
            };

            var userRole = new IdentityRole()
            {
                Id = "e5eb009a-767d-4b5e-b3cd-3513063e46c6",
                Name = RoleType.User.ToString(),
                ConcurrencyStamp = "380bdb8e-6f39-444f-830e-903a0f3b4482",
                NormalizedName = RoleType.User.ToString().ToUpper()
            };

            var adminUser = new ApplicationUser
            {
                Id = adminUserId,
                Name = "Admin User",
                UserName = "admin@gmail.com",
                NormalizedUserName = "ADMIN@GMAIL.COM",
                Email = "admin@gmail.com",
                NormalizedEmail = "ADMIN@GMAIL.COM",
                LockoutEnabled = false,
                ConcurrencyStamp = "5b2f5a62-691c-4188-99f3-068c158d8677",
                SecurityStamp = "0197e84b-fd4e-4622-956b-870fe6102150",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEJ/t6u7aASZG6DMGaFkLr5XlRW3NRRHWbMpZwWG2FzfLR1k+YwiOgiKuuS+UQEtv+w==" //AdminPass123@#
            };

            builder.Entity<ApplicationUser>().HasData(adminUser);
            builder.Entity<IdentityRole>().HasData(adminRole);
            builder.Entity<IdentityRole>().HasData(userRole);
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { UserId = adminUserId, RoleId = adminRoleId }
            );
        }
    }
}

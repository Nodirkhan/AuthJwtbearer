using AuthJwtbearer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AuthJwtbearer.Data
{
    public class DefaultData : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Nodir",
                LastName = "Abdumurotov",
                Email = "abdumurodovnodirxon@gmail.com",
                UserName = "Nodirkhan",
                Password = "12345",
                Role = EnumRole.Admin
            },
            new User
            {
                Id = Guid.NewGuid(),
                FirstName = "Doston",
                LastName = "Yoqubjonov",
                Email = "doston@gmail.com",
                UserName = "Doston",
                Password = "54321",
                Role = EnumRole.Employee
            });
        }
    }
}

using Blog.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Seeds
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
               new User
               {
                   Id = 1,
                   UserName = "Test",
               },
               new User
               {
                   Id = 2,
                   UserName = "Test",
               },

               new User
               {
                   Id = 3,
                   UserName = "Test",
               });
        }
    }
}

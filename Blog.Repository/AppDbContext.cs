using Microsoft.EntityFrameworkCore;
using Blog.Core.Entity;
using System.Reflection;

namespace Blog.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<BlogContent> BlogContexts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
       // public DbSet<User> Users { get; set; }
        public UserCredentials UserCredentials { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }


    }
    
}

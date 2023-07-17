using Microsoft.EntityFrameworkCore;
using Blog.Core.Entity;
using System.Reflection;
using Blog.Repository.Configuration;

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
            //builder.ApplyConfiguration(new UserConfiguration());
            //builder.ApplyConfiguration(new CommentConfiguration());
            //builder.ApplyConfiguration(new BlogContentConfiguration());
            //builder.ApplyConfiguration(new CategoryConfiguration());
            //builder.ApplyConfiguration(new UserCredentialsConfiguration());



            base.OnModelCreating(builder);
        }


    }
    
}

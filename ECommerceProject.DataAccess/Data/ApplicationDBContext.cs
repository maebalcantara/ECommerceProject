
using ECommerceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceProject.DataAccess.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
            
        }
        
        public DbSet<Category> Categories { get; set; } //this creates a database called Categories based off Category

        //seed category table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //this is used to populate some default data
            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Category 1", DisplayOrder = 1 },
                    new Category { Id = 2, Name = "Category 2", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "Category 3", DisplayOrder = 3 }
                );
        } 
    }
}

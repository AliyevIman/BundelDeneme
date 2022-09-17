using BundlerDeneme3.Entites;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BundlerDeneme3.Data_Acces
{
    public class CategoryDb : IdentityDbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder option)
        {
            option.UseSqlServer(@"Server =.\;Database=ParentCatDb;Trusted_Connection=true;MultipleActiveResultSets=True");
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<CategoryWithChild> categoriesWithChild { get; set; }
    }   
}

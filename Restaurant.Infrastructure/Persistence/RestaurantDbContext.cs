using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Entities;


namespace Restaurant.Infrastructure.Persistence
{
    internal class RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : DbContext(options)
    {


        internal DbSet<Dish> dishes { get; set;}
        internal DbSet<ResTauRant> restaurants { get; set;}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=TknData;Integrated Security=True;Trusted_Connection=true;TrustServerCertificate=true;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ResTauRant>()
                .OwnsOne(r => r.Address);


            modelBuilder.Entity<ResTauRant>()
                .HasMany(r => r.Dishes)
                .WithOne()
                .HasForeignKey(d => d.RestaurantId);

        
        }



    }
}

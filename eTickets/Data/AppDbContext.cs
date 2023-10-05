using eTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser> 
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieID
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieID);
            modelBuilder.Entity<Actor_Movie>().HasOne(o => o.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);



            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> cinemas { get; set; }

        public DbSet<Movie> movies { get; set; }
        public DbSet<Producer> producers { get; set; }


        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> orderItems  { get; set; }

        public DbSet<ShoppingCartItem> shoppingCartItems { get; set; }




    }
}

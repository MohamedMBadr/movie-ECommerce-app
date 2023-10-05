using eTickets.Data.Enums;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using eTickets.Data.Static;

namespace eTickets.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var ServiecScop = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = ServiecScop.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.cinemas.Any())
                {
                    context.cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName = "Actor 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.producers.Any())
                {
                    context.producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Producer 1",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            FullName = "Producer 2",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 3",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 4",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName = "Producer 5",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.movies.Any())
                {
                    context.movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            CinemaId = 3,
                            ProducerID = 3,
                            MoiveCategory = MoiveCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Description = "This is the Shawshank Redemption description",
                            Price = 29.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(3),
                            CinemaId = 1,
                            ProducerID = 1,
                            MoiveCategory = MoiveCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Description = "This is the Ghost movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate = DateTime.Now,
                            EndDate = DateTime.Now.AddDays(7),
                            CinemaId = 4,
                            ProducerID = 4,
                            MoiveCategory = MoiveCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            CinemaId = 1,
                            ProducerID = 2,
                            MoiveCategory = MoiveCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            CinemaId = 1,
                            ProducerID = 3,
                            MoiveCategory = MoiveCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            CinemaId = 1,
                            ProducerID = 5,
                            MoiveCategory = MoiveCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieID = 1
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieID = 2
                        },
                         new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieID = 2
                        },

                        new Actor_Movie()
                        {
                            ActorId = 1,
                            MovieID = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieID = 3
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieID = 3
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieID = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieID = 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieID = 4
                        },


                        new Actor_Movie()
                        {
                            ActorId = 2,
                            MovieID = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieID = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieID = 5
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieID = 5
                        },


                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieID = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 4,
                            MovieID = 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 5,
                            MovieID = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

        }

        public static async Task seedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {


            using (var servicesScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var rolManager = servicesScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await rolManager.RoleExistsAsync(UserRoles.Admin))
                    await rolManager.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await rolManager.RoleExistsAsync(UserRoles.User))
                    await rolManager.CreateAsync(new IdentityRole(UserRoles.User));


                var userManager = servicesScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                var adminUser = await userManager.FindByEmailAsync("admin@etickets.com");
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin",
                        Email = "admin@etickets.com",
                        EmailConfirmed = true

                    };
                    await userManager.CreateAsync(newAdminUser, "Coding@1234");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }




                var appUser = await userManager.FindByEmailAsync("user@etickets.com");
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "App-user",
                        Email = "user@etickets.com",
                        EmailConfirmed = true

                    };
                    await userManager.CreateAsync(newAppUser, "Coding@1234");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.Admin);
                }

            }
        }
    }
}

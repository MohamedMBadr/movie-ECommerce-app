using eTickets.Data.Base.BaseClasses;
using eTickets.Data.Services.InterFaces;
using eTickets.Data.ViewModels;
using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services.ServicesClasses
{
    public class MovieServices : EntityBaseRepository<Movie>, IMoviesServices
    {


        public MovieServices(AppDbContext dbContext) : base(dbContext)
        {

        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var  newMovie= new Movie()
            {
                Name= data.Name,
                Description= data.Description,
                Price= data.Price,
                ImageURL = data.ImageURL,
                CinemaId= data.CinemaId,
                StartDate= data.StartDate,
                EndDate = data.EndDate,
                MoiveCategory= data.MoiveCategory,
                ProducerID = data.ProducerID
            };
            await _context.movies.AddAsync(newMovie);

            await _context.SaveChangesAsync();
            foreach (var actorId in data.ActorsIds)
            {
                var NewActorMovie = new Actor_Movie()
                {
                    MovieID = newMovie.Id,
                    ActorId = actorId
                };

                await _context.Actors_Movies.AddAsync(NewActorMovie);

            }
            await _context.SaveChangesAsync();

        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = _context.movies
                .Include(c => c.Cinema)
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return await movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {

            var responce = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await _context.cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await _context.producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return responce;

        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.movies.FirstOrDefaultAsync(n=>n.Id == data.Id);
            if (dbMovie != null) {
     
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MoiveCategory = data.MoiveCategory;
                dbMovie.ProducerID = data.ProducerID;
                await _context.SaveChangesAsync();
            

            }
            var ExistingActors = _context.Actors_Movies.Where(n=>n.MovieID == data.Id).ToList();
             _context.Actors_Movies.RemoveRange(ExistingActors);
            await _context.SaveChangesAsync();


            foreach (var actorId in data.ActorsIds)
            {
                var NewActorMovie = new Actor_Movie()
                {
                    MovieID = data.Id,
                    ActorId = actorId
                };

                await _context.Actors_Movies.AddAsync(NewActorMovie);

            }
            await _context.SaveChangesAsync();

        }
    }
}

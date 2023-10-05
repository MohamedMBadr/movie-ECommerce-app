using eTickets.Data.Base.BaesInterFaces;
using eTickets.Data.Cart;
using eTickets.Data.Services;
using eTickets.Data.Services.InterFaces;
using eTickets.Data.Services.ServicesClasses;
using System.Threading.Tasks;

namespace eTickets.Data.Base.BaseClasses
{
    public class UnitOfWork : IunitOfWork
    {
        private readonly AppDbContext _dbContext;

        public IActorService ActorService { get; set; }
        public ICinemasServices CinemasServices { get; set; }

        public IProducerServices ProducerServices { get; set; }

        public IMoviesServices MoviesServices  { get; set; }

        public UnitOfWork(AppDbContext dbContext)
        {
            ActorService = new ActorsService(dbContext);
            CinemasServices= new CinemasServices(dbContext);
            ProducerServices =new ProducerServices(dbContext);
            MoviesServices= new MovieServices(dbContext);

            _dbContext = dbContext;
        }

        public async Task<int> Complete() => await _dbContext.SaveChangesAsync();
        public void Dispose() => _dbContext.Dispose();
    }
}

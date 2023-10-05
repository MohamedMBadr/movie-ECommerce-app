using eTickets.Data.Cart;
using eTickets.Data.Services;
using eTickets.Data.Services.InterFaces;
using System;
using System.Threading.Tasks;

namespace eTickets.Data.Base.BaesInterFaces
{
    public interface IunitOfWork : IDisposable
    {
        public IActorService ActorService { get; set; }

        public ICinemasServices CinemasServices { get; set; }

        public IProducerServices ProducerServices { get; set; }

        public IMoviesServices MoviesServices { get; set; }


        Task<int> Complete();
    }
}

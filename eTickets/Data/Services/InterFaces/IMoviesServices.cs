using eTickets.Data.Base.BaesInterFaces;
using eTickets.Data.ViewModels;
using eTickets.Models;
using System.Threading.Tasks;

namespace eTickets.Data.Services.InterFaces
{
    public interface IMoviesServices : IEntityBaseRepository<Movie>
    {

        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();

        Task AddNewMovieAsync(NewMovieVM newMovieVM);

        Task UpdateMovieAsync(NewMovieVM data);
    }
}

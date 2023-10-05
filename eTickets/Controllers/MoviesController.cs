using eTickets.Data;
using eTickets.Data.Base.BaesInterFaces;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class MoviesController : Controller
    {
        private readonly IunitOfWork _unitOfWork;

        ///private readonly AppDbContext _context;
        ///public MoviesController(AppDbContext context)
        ///{
        ///    _context = context;
        ///}

        public MoviesController(IunitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var allMovies = await _unitOfWork.MoviesServices.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }
        //Filter
        [AllowAnonymous]

        public async Task<IActionResult> Filter( string searchString)
        {
            var allMovies = await _unitOfWork.MoviesServices.GetAllAsync(n => n.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allMovies.Where(n=> n.Name.ToLower() .Contains(searchString.ToLower())|| n.Description.ToLower().Contains(searchString.ToLower() ))
                    .ToList();
                return View(nameof(Index), filteredResult);
            }
            return View( nameof(Index), allMovies);
        }
        [AllowAnonymous]

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _unitOfWork.MoviesServices.GetMovieByIdAsync(id);

            return View(movieDetails);
        }


        public async Task<IActionResult> Create()
        {

            var movieDropDownsData = await _unitOfWork.MoviesServices.GetNewMovieDropdownsValues();
            ViewBag.Cinmeas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropDownsData = await _unitOfWork.MoviesServices.GetNewMovieDropdownsValues();
                ViewBag.Cinmeas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _unitOfWork.MoviesServices.AddNewMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {

            var movieDetails = await _unitOfWork.MoviesServices.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("NotFound");
             var responce = new NewMovieVM()
            {
                Id = id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                ImageURL = movieDetails.ImageURL,
                MoiveCategory = movieDetails.MoiveCategory,
                CinemaId = movieDetails.CinemaId,
                ProducerID = movieDetails.ProducerID,
                ActorsIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList()
            };
            var movieDropDownsData = await _unitOfWork.MoviesServices.GetNewMovieDropdownsValues();
            ViewBag.Cinmeas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
            return View(responce);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id ,  NewMovieVM movie)
        {
            if(id != movie.Id) return View(nameof(NotFound));
            if (!ModelState.IsValid)
            {
                var movieDropDownsData = await _unitOfWork.MoviesServices.GetNewMovieDropdownsValues();
                ViewBag.Cinmeas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            await _unitOfWork.MoviesServices.UpdateMovieAsync(movie);

            return RedirectToAction(nameof(Index));
        }

    }
}

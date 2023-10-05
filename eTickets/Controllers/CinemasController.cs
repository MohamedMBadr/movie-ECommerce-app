using eTickets.Data;
using eTickets.Data.Base.BaesInterFaces;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly IunitOfWork _unitOfWork;

        ///private readonly AppDbContext _context;
        ///public CinemasController(AppDbContext context)
        ///{
        ///    _context = context;
        ///}

        public CinemasController(IunitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _unitOfWork.CinemasServices.GetAllAsync();
            return View(allCinemas);
        }


        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);

            }
            await _unitOfWork.CinemasServices.AddAsync(cinema);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]

        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _unitOfWork.CinemasServices.GetByIdAsync(id);
            if (producerDetails is null)
                return View("NotFound");
            return View(producerDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var atorDetails = await _unitOfWork.CinemasServices.GetByIdAsync(id);
            if (atorDetails is null)
                return View("NotFound");
            return View(atorDetails);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int id, Cinema cinema)
        {
            if (!ModelState.IsValid)
            {
                return View(cinema);

            }
            await _unitOfWork.CinemasServices.UpdateAsync(id, cinema);
            await _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var atorDetails = await _unitOfWork.CinemasServices.GetByIdAsync(id);
            if (atorDetails is null)
                return View("NotFound");
            return View(atorDetails);
        }
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atorDetails = await _unitOfWork.CinemasServices.GetByIdAsync(id);
            if (atorDetails is null)
                return View("NotFound");
            await _unitOfWork.CinemasServices.DeleteAsync(id);
            await _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }

    }
}

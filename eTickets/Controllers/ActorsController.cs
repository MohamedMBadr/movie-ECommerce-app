using eTickets.Data;
using eTickets.Data.Base.BaesInterFaces;
using eTickets.Data.Services;
using eTickets.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IunitOfWork _unitOfWork;
        public ActorsController(IunitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _unitOfWork.ActorService.GetAllAsync();
            return View(data);
        }

        //Actors/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);

            }
            await _unitOfWork.ActorService.AddAsync(actor);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]

        public async Task<IActionResult> Details(int id)
        {
            var atorDetails = await _unitOfWork.ActorService.GetByIdAsync(id);
            if (atorDetails is null)
                return View("NotFound");
            return View(atorDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var atorDetails = await _unitOfWork.ActorService.GetByIdAsync(id);
            if (atorDetails is null)
                return View("NotFound");
            return View(atorDetails);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int id, Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);

            }
            await _unitOfWork.ActorService.UpdateAsync(id, actor);
            await _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var atorDetails = await _unitOfWork.ActorService.GetByIdAsync(id);
            if (atorDetails is null)
                return View("NotFound");
            return View(atorDetails);
        }
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var atorDetails = await _unitOfWork.ActorService.GetByIdAsync(id);
            if (atorDetails is null)
                return View("NotFound");
            await _unitOfWork.ActorService.DeleteAsync(id);
            await _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }




    }
}

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
    [Authorize(Roles =UserRoles.Admin)]
    public class ProducersController : Controller
    {
        private readonly IunitOfWork _unitOfWork;

        public ProducersController(IunitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var AllProducers = await _unitOfWork.ProducerServices.GetAllAsync();
            return View(AllProducers);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);

            }
            await _unitOfWork.ProducerServices.AddAsync(producer);
            await _unitOfWork.Complete();
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]

        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await _unitOfWork.ProducerServices.GetByIdAsync(id);
            if (producerDetails is null)
                return View("NotFound");
            return View(producerDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var producerDetails = await _unitOfWork.ProducerServices.GetByIdAsync(id);
            if (producerDetails is null)
                return View("NotFound");
            return View(producerDetails);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int id, Producer producer)
        {
            if (!ModelState.IsValid)
            {
                return View(producer);

            }
            await _unitOfWork.ProducerServices.UpdateAsync(id, producer);
            await _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var producerDetails = await _unitOfWork.ProducerServices.GetByIdAsync(id);
            if (producerDetails is null)
                return View("NotFound");
            return View(producerDetails);
        }
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producerDetails = await _unitOfWork.ProducerServices.GetByIdAsync(id);
            if (producerDetails is null)
                return View("NotFound");
            await _unitOfWork.ProducerServices.DeleteAsync(id);
            await _unitOfWork.Complete();

            return RedirectToAction(nameof(Index));
        }

    }
}

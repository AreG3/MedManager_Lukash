using MedManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MedManager.Repositories;

namespace MedManager.Controllers
{
    public class MedTakeController : Controller
    {
        private readonly IMedRepository _medRepository;

        public MedTakeController(IMedRepository medRepository)
        {
            _medRepository = medRepository;
        }



        // GET: MedTake
        public ActionResult Index()
        {
            return View(_medRepository.GetAllActive());
        }

        // GET: MedTake/Details/5
        public ActionResult Details(int id)
        {
            return View(_medRepository.Get(id));
        }

        // GET: MedTake/Create
        public ActionResult Create()
        {
            return View(new MedTakeModel());
        }

        // POST: MedTake/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedTakeModel medTakeModel)
        {
            _medRepository.Add(medTakeModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: MedTake/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_medRepository.Get(id));
        }

        // POST: MedTake/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedTakeModel medTakeModel)
        {
            _medRepository.update(id, medTakeModel);

            return RedirectToAction(nameof(Index));
        }

        // GET: MedTake/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_medRepository.Get(id));
        }

        // POST: MedTake/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, MedTakeModel medTakeModel)
        {
            _medRepository.delete(id);

            return RedirectToAction(nameof(Index));
        }

        // GET: Medtake/Done/
        public ActionResult Done(int id)
        {
            MedTakeModel medtake = _medRepository.Get(id);
            medtake.Done = true;
            _medRepository.update(id, medtake);

            return RedirectToAction(nameof(Index));
        }
    }
}

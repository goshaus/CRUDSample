using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Repository;
using Domain.Entities;
using Domain.Context;
using System.Data.Entity;

namespace WebUI.Controllers
{
    public class PatientController : Controller
    {
        private readonly DataRepository<Person> _repository;

        public PatientController()
        {
            this._repository = new DataRepository<Person>(new PersonContext());
        }


        public ActionResult List()
        {
            var patients = this._repository.GetAll();
            return View(patients);
        }


        public ActionResult Details(int id)
        {
            var patient = this._repository.FindById(id);
            return View(patient);
        }


        public ActionResult Delete(int id)
        {
            var patient = this._repository.FindById(id);
            return View(patient);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var patient = this._repository.FindById(id);
            this._repository.Remove(patient);

            return RedirectToAction("List");
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConfirmed([Bind(Include = "Name, Surname, BirthDay, Diagnosis, Description")] Person patient)
        {
            if (ModelState.IsValid)
            {
                this._repository.Create(patient);
                return RedirectToAction("List");
            }

            return View();
        }


        public ActionResult Edit(int id)
        {
            var patient = this._repository.FindById(id);
            return View(patient);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirmed([Bind(Include = "PersonId, Name, Surname, BirthDay, Diagnosis, Description")] Person patient)
        {
            if (ModelState.IsValid)
            {
                this._repository.Update(patient);
                return RedirectToAction("List");
            }

            return RedirectToAction("Details", new { id = patient.PersonId}) ;
        }
    }
}
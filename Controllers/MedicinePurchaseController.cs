using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.SQL_Query;
using Hospital_Management.Models;
namespace Hospital_Management.Controllers
{
    public class MedicinePurchaseController : Controller
    {
        PatientPortal patientPortal = new PatientPortal();
        MedicinePortal medicinetPortal = new MedicinePortal();
        public ActionResult Index()
        {
            Medicine_Purchase medicine_Purchase = new Medicine_Purchase();
            medicine_Purchase.getAllPatientsName = patientPortal.getAllPatientsName();
            medicine_Purchase.getAllMedicinesName = medicinetPortal.getAllMedicinesName();
            return View(medicine_Purchase);
        }

        // GET: MedicinePurchase/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedicinePurchase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicinePurchase/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicinePurchase/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MedicinePurchase/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MedicinePurchase/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedicinePurchase/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

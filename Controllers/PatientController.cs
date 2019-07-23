using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.SQL_Query;
using Hospital_Management.Models;
namespace Hospital_Management.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patients
        PatientPortal patientPortal = new PatientPortal();
        public ActionResult Index()
        {
            return View(patientPortal.selectAll());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int id)
        {
            return View(patientPortal.select(id));
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            Patient patient = new Patient
            {
                getGender = patientPortal.getGender(),
                getBloodGroup = patientPortal.getBloodGroup()
            };
            return View(patient);
        }

        // POST: Patients/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Patient patient = new Patient
                {
                    name = collection["name"],
                    gender = collection["gender"],
                    age = Convert.ToInt32(collection["age"]),
                    blood = collection["blood"],
                    address =collection["address"],
                    phone_no=collection["phone_no"]
                };
                patientPortal.insert(patient);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int id)
        {
            Patient tempPatient = patientPortal.select(id);
            Patient patient = new Patient
            {
                name = tempPatient.name,
                gender = tempPatient.gender,
                age=tempPatient.age,
                blood = tempPatient.blood,
                address =tempPatient.address,
                phone_no=tempPatient.phone_no,
                getGender = patientPortal.getGender(),
                getBloodGroup = patientPortal.getBloodGroup()
            };
            return View(patient);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Patient patient = new Patient
                {
                    //all the form values coming as a string...
                    id = Convert.ToInt32(collection["id"]),
                    name = collection["name"],
                    gender = collection["gender"],
                    age=Convert.ToInt32(collection["age"]),
                    blood=collection["blood"],
                    address=collection["address"],
                    phone_no=collection["phone_no"]
                };
                patientPortal.update(patient);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int id)
        {
            return View(patientPortal.select(id));
        }

        // POST: Patients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                patientPortal.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

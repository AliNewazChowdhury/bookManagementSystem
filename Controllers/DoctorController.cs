﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital_Management.SQL_Query;
using Hospital_Management.Models;
namespace Hospital_Management.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        DoctorPortal doctorPortal = new DoctorPortal();
        public ActionResult Index()
        {
            Doctor doctor = new Doctor();
            doctor.AllDoctorList = doctorPortal.selectAll();
            doctor.getAllDepartmentsName = doctorPortal.getAllDepartmentsName();
            return View(doctor);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            return View(doctorPortal.select(id));
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            PatientPortal patientPortal = new PatientPortal();
            Doctor doctor = new Doctor
            {
                getGender = patientPortal.getGender()
            };
            return View(doctor);
        }

        // POST: Doctor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                Doctor doctor = new Doctor
                {
                    name = collection["name"],
                    qualification = collection["qualification"],
                    dept = collection["dept"],
                    designation = collection["designation"],
                    gender = collection["gender"],
                    phone_no = collection["phone_no"]
                };
                doctorPortal.insert(doctor);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            Doctor tempDoctor = doctorPortal.select(id);
            PatientPortal patientPortal = new PatientPortal();
            Doctor doctor = new Doctor
            {
                name=tempDoctor.name,
                qualification = tempDoctor.qualification,
                dept =tempDoctor.dept,
                designation=tempDoctor.designation,
                gender=tempDoctor.gender,
                phone_no=tempDoctor.phone_no,
                getGender=patientPortal.getGender()
            };
            return View(doctor);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                Doctor doctor = new Doctor
                {
                    id = Convert.ToInt32(collection["id"]),
                    name = collection["name"],
                    qualification = collection["qualification"],
                    dept = collection["dept"],
                    designation = collection["designation"],
                    gender = collection["gender"],
                    phone_no = collection["phone_no"]
                };

                doctorPortal.update(doctor);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Delete/5
        public ActionResult Delete(int id)
        {
            return View(doctorPortal.select(id));
        }

        // POST: Doctor/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                doctorPortal.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

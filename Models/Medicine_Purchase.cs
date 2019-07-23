using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Hospital_Management.Models
{
    public class Medicine_Purchase
    {
        [Required]
        [Display(Name = "Patients Name: ")]
        public string patient_name { get; set; }
        [Required]
        [Display(Name = "Medicines Name: ")]
        public string medicine_name { get; set; }

        public List<SelectListItem> getAllPatientsName { get; set; }
        public List<SelectListItem> getAllMedicinesName { get; set; }
        [DataType(DataType.Date)]
        //[Range(typeof(DateTime), "01/01/20017", "01/12/2038")]
        [Display(Name = "Date: ")]
        [Required]
        public DateTime dateTime { get; set; }
        [Display(Name ="Quantity")]
        [Required]
        [Range(1,1000)]
        public int quantitly { get; set; }

    }
}
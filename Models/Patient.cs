using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Hospital_Management.Models;
namespace Hospital_Management.Models
{
    public class Patient
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        [Required]
        [Display(Name ="Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Required]
        [Display(Name = "Age")]
        public int age { get; set; }
        [Required]
        [Display(Name = "Blood Group")]
        public string blood { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string address { get; set; }
        [RegularExpression(@"^([0-9]{11})$", ErrorMessage = "Mobile number should be 11 digits long")]
        [Display(Name = "Phone Number")]
        public string phone_no { get; set; }
        public List<SelectListItem> getGender { get; set; }
        public List<SelectListItem> getBloodGroup { get; set; }
        
    }
   
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using System.Data;

namespace Hospital_Management.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult validateuser(string username,string password)
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from Login where username=@Username and password=@Password";
                SqlCommand sqlCmd = new SqlCommand(query, conn);
                sqlCmd.Parameters.AddWithValue("@Username", username);
                sqlCmd.Parameters.AddWithValue("@Password", password);
                SqlDataAdapter adapter = new SqlDataAdapter(sqlCmd);
                conn.Open();
                adapter.Fill(dataTable);
                if(dataTable.Rows.Count==1)
                {
                    return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, JsonRequestBehavior.AllowGet });
                }
            }
        }
    }
}
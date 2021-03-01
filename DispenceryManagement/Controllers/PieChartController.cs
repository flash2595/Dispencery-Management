using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DispenceryManagement.Controllers
{
    public class PieChartController : Controller
    {
        // GET: PieChart
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod()
        {
            string query = "SELECT MedicineType,COUNT(DISTINCT(PurchaseCourses.BillNo)) TotalOrders FROM MembershipTypes ";
            query += "INNER JOIN Patients ON MembershipTypes.Id=Patients.MembershipTypeId INNER JOIN PurchaseCourses ON Patients.Id = PurchaseCourses.PatientId GROUP BY MedicineType";
            string constr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=aspnet-Vidly-20160330105730;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            List<object> chartData = new List<object>();
            chartData.Add(new object[]
            {
                "MedicineType", "TotalOrders"
            });


            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            chartData.Add(new object[]
                            {
                            sdr["MedicineType"], sdr["TotalOrders"]
                            });
                        }
                    }

                    con.Close();
                }
            }

            return Json(chartData);
        }
    }
}
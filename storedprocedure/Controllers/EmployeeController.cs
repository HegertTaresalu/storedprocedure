using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storedprocedure.Data;
using storedprocedure.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace storedprocedure.Controllers
{
    public class Employee : Controller
    {
        public IConfiguration _config { get; }
        public StoredProcedureDBcontext _context;
        public IActionResult Index()
        


        {
            return View();
        }


        public IEnumerable<Employee> SearchResult()
        {
            var result = _context.Employee.FromSqlRaw<Employee>("spSearchEmployees").ToList();
                



            return result;
        }



       [HttpGet]
        public IActionResult DynamicSQL()
        {
            string connectionSTR = _config.GetConnectionString("DefaultConnection");
            using (SqlConnection con = new SqlConnection(connectionSTR))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "dbo.spSearchEmployees";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                List<Employee> model = new List<Employee>();
                while(sdr.Read())
                {
                    var Details = new Employee();
                    Details.FirstName = sdr["FirstName"].ToString();
                    Details.LastName = sdr["LastName"].ToString();
                    


                }

            }
                
        }



    }
}

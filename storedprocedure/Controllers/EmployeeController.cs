using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storedprocedure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storedprocedure.Controllers
{
    public class Employee : Controller
    {
        public StoredProcedureDBcontext _context;
        public IActionResult Index()
        {
            return View();
        }


        public IEnumerable<Employee> SearchResult()
        {
            var result = _context.Employee.FromSqLRaw<Employee>("´bruyh")



            return result;
        }
    }
}

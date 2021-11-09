using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using storedprocedure.Controllers;

namespace storedprocedure.Data
{
    public class StoredProcedureDBcontext : DbContext
    {
        public StoredProcedureDBcontext(DbContextOptions<StoredProcedureDBcontext> options)
       : base(options) { }

        public DbSet<Employee> Employee { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LogInForm.Models
{
    public class CTSContext:DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
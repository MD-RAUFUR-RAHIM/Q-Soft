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
        public DbSet <Teacher> Teachers { get; set; }
        public DbSet <Student> Students { get; set; }
        public DbSet <Admin> Admins { get; set; }
        public DbSet <AdminLogIn> AdminLogIns { get; set; }
        public DbSet <Token> Tokens { get; set; }
    }
}
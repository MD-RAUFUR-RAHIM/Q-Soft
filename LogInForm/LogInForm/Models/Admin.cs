using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogInForm.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string Gender { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
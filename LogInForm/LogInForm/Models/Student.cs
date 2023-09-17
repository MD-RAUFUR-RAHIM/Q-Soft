using LogInForm.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogInForm.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string phone { get; set; }
        public string  Gender { get; set; }
        public string username { get; set; }
        public string password { get; set; }
       
        [ForeignKey("Teacher")]
        public int T_Id { get; set; }
        public virtual Teacher Teacher { get; set; }
        [ForeignKey("Admin")]
        public int A_Id { get; set; }
        public virtual Admin Admin { get; set; }

    }
}
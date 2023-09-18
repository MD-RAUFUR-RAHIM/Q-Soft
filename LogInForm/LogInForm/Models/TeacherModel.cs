using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogInForm.Models
{
    public class TeacherModel
    {
        
        public string SelectedTeacherName { get; set; }
        public List<string> TeacherNames { get; set; }
    }
}
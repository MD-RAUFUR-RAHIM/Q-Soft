using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogInForm.Models
{
    public class TeacherModel
    {
        
        public int SelectedTeacherId { get; set; }
        public List<int> TeacherId { get; set; }
    }
}
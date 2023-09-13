using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogInForm.Perams_Model
{
    public class LoginPerams
    {
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
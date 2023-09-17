using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LogInForm.Perams_Model
{
    public class LoginPerams
    {
        [Required]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password can not be null")]
        public string Password { get; set; }
    }
}
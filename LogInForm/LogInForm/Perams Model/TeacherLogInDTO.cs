using LogInForm.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogInForm.Perams_Model
{
    public class TeacherLogInDTO

    {
        public int Id { get; set; }
        [GmailAddress]
        public string Email { get; set; }
        [PasswordValidation]
        public string Password { get; set; }
    }
}
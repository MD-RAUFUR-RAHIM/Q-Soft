using LogInForm.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogInForm.Perams_Model
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [GmailAddress]
        public string Email { get; set; }
        [PhoneValidation]
        public string phone { get; set; }
        public string Gender { get; set; }
        public int Admin_Id { get; set; }
        [username]
        public string username { get; set; }
        [PasswordValidation]
        public string password { get; set; }
    }
}
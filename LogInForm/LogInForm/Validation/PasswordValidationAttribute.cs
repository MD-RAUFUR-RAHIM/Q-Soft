using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LogInForm.Validation
{
    public class PasswordValidationAttribute: ValidationAttribute
    {
        public PasswordValidationAttribute()
        {
            ErrorMessage = "The password must contain one special character, one digit, one lowercase and one uppercase and length should be at most 8";
        }
        public override bool IsValid(object value)
        {
            if (value is string password)
            {
                
                string pattern = @"^(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\\/\-])(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{1,8}$";

                return Regex.IsMatch(password, pattern);
            }

            return false;
        }
    }
}
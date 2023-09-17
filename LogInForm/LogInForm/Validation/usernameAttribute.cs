using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LogInForm.Validation
{
    public class usernameAttribute: ValidationAttribute
    {
        public usernameAttribute()
        {
            ErrorMessage = "The name should contain one lowercase";
        }
        public override bool IsValid(object value)
        {
            if (value is string username)
            {
                return Regex.IsMatch(username, "^[a-z]+$");
            }

            return false;
        }
    }
}
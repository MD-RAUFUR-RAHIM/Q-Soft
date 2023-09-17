using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LogInForm.Validation
{
    public class PhoneValidationAttribute: ValidationAttribute
    {
        private const string PhonePattern = @"^\+880\d{10}$";
        public PhoneValidationAttribute()
        {
            ErrorMessage = "The phone number must be in the format +880XXXXXXXXXX.";
        }
        public override bool IsValid(object value)
        {
            if (value is string phone)
            {
               
                return Regex.IsMatch(phone, PhonePattern, RegexOptions.IgnoreCase);
            }

            return false;
        }
       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace LogInForm.Validation
{
    public class GmailAddressAttribute: ValidationAttribute
    {
        public GmailAddressAttribute()
        {
            ErrorMessage = "Only Gmail accounts are accepted";
        }
        public override bool IsValid(object value)
        {
            if (value is string email)
            {
                return Regex.IsMatch(email, @"@gmail\.com$", RegexOptions.IgnoreCase);
            }

            return false; 
        }
    }
}
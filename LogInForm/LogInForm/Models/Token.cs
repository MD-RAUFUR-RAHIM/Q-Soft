using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LogInForm.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string tokenKey { get; set; }
        
        [ForeignKey("Users")]
        public int User_Id { get; set; }
        public virtual User Users { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
        

    }
}
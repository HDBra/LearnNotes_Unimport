using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnWebAPI.Removable.Models
{
    public class User
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnWebApi2.Removable.Models
{
    public class Task
    {
        public long? TaskId { get; set; }
        public string Subject { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public Status Status { get; set; }
        public List<Link> Links { get; set; }
        public List<User> Assignees { get; set; } 
    }

    public class Status
    {
        public long StatusId { get; set; }
        public string Name { get; set; }
        public int Ordinal { get; set; }
    }

    public class User
    {
        public long UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public List<Link> Links { get; set; } 
    }


}
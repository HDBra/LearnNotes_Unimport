using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnWebAPI.Removable.Models
{
    public class Task
    {
        private readonly IList<User> _users = new List<User>();
        public string TaskId { get; set; }
        public string Subject { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Status Status { get; set; }
        public virtual User CreatedBy { get; set; }
        public virtual IList<User> Users
        {
            get { return _users; }
        }
    }
}
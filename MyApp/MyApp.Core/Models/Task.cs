using System;

namespace MyApp.Core.Models
{
    public class Task
    {
        public int ID { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        public int StatusID { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}

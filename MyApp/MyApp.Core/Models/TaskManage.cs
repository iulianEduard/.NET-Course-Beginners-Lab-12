using System;

namespace MyApp.Core.Models
{
    public class TaskManage
    {
        public int ID { get; set; }

        public int TaskID { get; set; }

        public int FrequencyID { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

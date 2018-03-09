using Dapper.Contrib.Extensions;
using System;

namespace MyApp.Repository.Entity
{
    [Table("dbo.Task")]
    public class TaskEntity
    {
        [Key]
        public int ID { get; set; }

        public string TaskName { get; set; }

        public string Description { get; set; }

        public int StatusID { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}

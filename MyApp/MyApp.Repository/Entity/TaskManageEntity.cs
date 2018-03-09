using Dapper.Contrib.Extensions;
using System;

namespace MyApp.Repository.Entity
{
    [Table("dbo.TaskManage")]
    public class TaskManageEntity
    {
        [Key]
        public int ID { get; set; }

        public int TaskID { get; set; }

        public int FrequencyID { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

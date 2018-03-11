using Dapper.Contrib.Extensions;

namespace MyApp.Repository.Entity
{
    [Table("dbo.Status")]
    public class StatusEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

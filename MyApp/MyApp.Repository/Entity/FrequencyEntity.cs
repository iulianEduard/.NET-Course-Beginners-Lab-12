using Dapper.Contrib.Extensions;

namespace MyApp.Repository.Entity
{
    [Table("dbo.Frequency")]
    public class FrequencyEntity
    {
        [Key]
        public int Id { get; set; }

        public string Frequency { get; set; }
    }
}

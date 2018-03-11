using MyApp.Repository.Entity;
using System.Collections.Generic;

namespace MyApp.Repository.Ports
{
    public interface IStatusRepository
    {
        List<StatusEntity> GetAll();
    }
}

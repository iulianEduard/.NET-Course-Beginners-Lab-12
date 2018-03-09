using MyApp.Repository.Entity;
using System.Collections.Generic;

namespace MyApp.Repository.Ports
{
    public interface ITaskManageRepository
    {
        TaskManageEntity GetById(int id);

        IEnumerable<TaskManageEntity> GetAll();

        int Insert(TaskManageEntity taskEntity);

        void Update(TaskManageEntity taskEntity);

        bool Delete(TaskManageEntity taskEntity);
    }
}

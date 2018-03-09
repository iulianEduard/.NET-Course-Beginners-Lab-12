using MyApp.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repository.Ports
{
    public interface ITaskRepository
    {
        TaskEntity GetById(int id);

        IEnumerable<TaskEntity> GetAll();

        int Insert(TaskEntity taskEntity);

        void Update(TaskEntity taskEntity);

        bool Delete(TaskEntity taskEntity);
    }
}

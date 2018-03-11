using MyApp.Core.Models;
using MyApp.Repository.Entity;
using System.Collections.Generic;

namespace MyApp.Repository.Ports
{
    public interface ITaskRepository
    {
        TaskEntity GetById(int id);

        IEnumerable<TaskEntity> GetAll();

        int Insert(TaskEntity taskEntity);

        void Update(TaskEntity taskEntity);

        bool Delete(TaskEntity taskEntity);

        List<TaskUnassigned> GetUnassignedTasks();

        List<TaskUnassigned> GetAssignedTasks(int statusId);
    }
}

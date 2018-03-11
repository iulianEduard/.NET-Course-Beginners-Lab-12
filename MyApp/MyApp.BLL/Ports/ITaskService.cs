using MyApp.Core.Models;
using System.Collections.Generic;

namespace MyApp.BLL.Ports
{
    public interface ITaskService
    {
        Task GetTaskById(int id);

        List<Task> GetAll();

        void Save(Task task);

        void Delete(int taskId);

        List<TaskUnassigned> GetUnassignedTask();

        List<TaskUnassigned> GetAssignedTasks();

        void ResetStatus(int id, int statusId);
    }
}

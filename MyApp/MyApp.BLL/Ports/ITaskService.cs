using MyApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyApp.BLL.Ports
{
    public interface ITaskService
    {
        Task GetTaskById(int id);

        List<Task> GetAll();

        void Save(Task task);

        void Delete(int taskId);
    }
}

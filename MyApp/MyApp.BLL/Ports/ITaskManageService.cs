using MyApp.Core.Models;
using System.Collections.Generic;

namespace MyApp.BLL.Ports
{
    public interface ITaskManageService
    {
        TaskManage GetById(int id);

        List<TaskManage> GetTaskManageList();

        void SaveTaskManage(TaskManage taskManage);

        void Delete(int id);
    }
}

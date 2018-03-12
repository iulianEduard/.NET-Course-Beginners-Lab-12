using AutoMapper;
using MyApp.Core.Models;
using Synkron.UI.Models.Task;
using Synkron.UI.Models.TaskManage;

namespace MyApp.UI.App_Start
{
    public static class MapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TaskViewModel, Task>();
                cfg.CreateMap<Task, TaskViewModel>();

                cfg.CreateMap<TaskUnassigned, TaskManageUIModel>();
                cfg.CreateMap<TaskManageUIModel, TaskUnassigned>();

                cfg.CreateMap<TaskManage, TaskUIModel>();
                cfg.CreateMap<TaskUIModel, TaskManage>();
            });
        }
    }
}
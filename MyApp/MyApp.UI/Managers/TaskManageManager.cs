using MyApp.BLL.Ports;
using Synkron.UI.Models.TaskManage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.UI.Managers
{
    public class TaskManageManager
    {
        #region Attributes

        private readonly ITaskManageService _taskManageService;
        private readonly ITaskService _taskService;
        private readonly IFrequencyService _frequencyService;

        #endregion Attributes

        #region Contructor

        public TaskManageManager(ITaskManageService taskManageService, ITaskService taskService, IFrequencyService frequencyService)
        {
            _taskManageService = taskManageService;
            _taskService = taskService;
            _frequencyService = frequencyService;
        }

        #endregion Constructor

        #region Public Methods

        public TaskManageWorker ViewAll()
        {
            var model = new TaskManageWorker()
            {
                FrequencyList = new List<FrequencyUIModel>(),
                TaskManageList = new List<TaskManageUIModel>()
            };

            return model;
        }

        public void SetupTaskManageView(TaskManageWorker model)
        {
            var frequnecyList = new List<FrequencyUIModel>();

            var frequencyData = _frequencyService.GetFrequencyList().OrderBy(f => f.Id).ToList();
            frequencyData.ForEach(f => frequnecyList.Add(new FrequencyUIModel { Id = f.Id, Frequency = f.Frequency }));
            frequnecyList.Insert(0, new FrequencyUIModel { Id = 0, Frequency = "Unassigned Tasks" });

            // Add frequencies
            model.FrequencyList = frequnecyList;

            // Add unassigned tasks
            var unassignedTasks = _taskService.GetUnassignedTask();
            unassignedTasks.ForEach(ut => model.TaskManageList.Add(ConvertToUI(ut)));

            // Add assigned tasks
            var assignedTasks = _taskManageService.GetTaskManageList();
            assignedTasks.ForEach(at => model.TaskManageList.Add(ConvertToUI(at)));
        }

        #endregion Public Methods

    }
}
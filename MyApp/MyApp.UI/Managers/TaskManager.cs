using AutoMapper;
using MyApp.BLL.Ports;
using MyApp.Core.Models;
using Synkron.UI.Models.Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyApp.UI.Managers
{
    public class TaskManager
    {
        #region Attributes

        private readonly ITaskService _taskService;
        private readonly IStatusService _statusService;

        #endregion Attributes

        #region Constructor

        public TaskManager(ITaskService taskService, IStatusService statusService)
        {
            _taskService = taskService;
            _statusService = statusService;
        }

        #endregion Constructor

        #region Public Methods

        public List<TaskViewModel> ViewAllTasks()
        {
            var taskList = new List<TaskViewModel>();
            var taskListService = _taskService.GetAll();

            taskList = Mapper.Map<List<TaskViewModel>>(taskListService);

            return taskList;
        }

        public TaskUIModel CreateTask()
        {
            var model = new TaskUIModel();

            SetupTask(model);

            return model;
        }

        public void SaveTask(TaskUIModel taskModel)
        {
            var task = Mapper.Map<Task>(taskModel);

            _taskService.Save(task);
        }

        public void SetupTask(TaskUIModel model)
        {
            var statusList = _statusService.GetStatusList();
            model.StatusList = ConvertToSelectList(statusList);
        }

        #endregion Public Methods

        #region Private Methods

        private static List<SelectListItem> ConvertToSelectList(List<Status> statusListModel)
        {
            var selectList = new List<SelectListItem>();

            statusListModel.ForEach(sl => selectList.Add(new SelectListItem { Text = sl.Name, Value = sl.Id.ToString() }));

            return selectList;
        }

        #endregion Private Methods
    }
}
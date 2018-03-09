using AutoMapper;
using MyApp.BLL.Ports;
using MyApp.Core.Models;
using MyApp.Repository.Entity;
using MyApp.Repository.Ports;
using System;
using System.Collections.Generic;

namespace MyApp.BLL
{
    public class TaskService : ITaskService
    {
        #region Attributes

        private readonly ITaskRepository _taskRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        #region Public Methods

        public void Delete(int taskId)
        {
            var taskEntity = _taskRepository.GetById(taskId);

            if(taskEntity != null)
            {
                _taskRepository.Delete(taskEntity);
            }
        }

        public List<Task> GetAll()
        {
            var taskList = new List<Task>();
            var taskEnumerable = _taskRepository.GetAll();

            return taskList;
        }

        public Task GetTaskById(int id)
        {
            var task = new Task();

            var taskEntity = _taskRepository.GetById(id);

            return task;
        }

        public void Save(Task task)
        {
            if(task.ID == 0)
            {

            }
            else
            {

            }
        }

        #endregion Public Methods

        #region Private Methods

        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Task, TaskEntity>();
                cfg.CreateMap<TaskEntity, Task>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private Methods
    }
}

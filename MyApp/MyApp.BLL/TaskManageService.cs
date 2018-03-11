using AutoMapper;
using MyApp.BLL.Ports;
using MyApp.Core.Models;
using MyApp.Repository.Entity;
using MyApp.Repository.Ports;
using System;
using System.Collections.Generic;

namespace MyApp.BLL
{
    public class TaskManageService : ITaskManageService
    {
        #region Attrbiutes

        private readonly ITaskManageRepository _taskManageRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        public TaskManageService(ITaskManageRepository taskManageRepository)
        {
            _taskManageRepository = taskManageRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        #region Public Methods

        public void Delete(int id)
        {
            if (id == 0)
            {
                throw new Exception("Select a task manage to delete");
            }

            var taskManageModel = _taskManageRepository.GetById(id);
            var taskId = taskManageModel.TaskID;

            _taskManageRepository.Delete(taskManageModel);
        }

        public TaskManage GetById(int id)
        {
            var model = new TaskManage();
            var taskManageEntity = _taskManageRepository.GetById(id);

            model = Mapper.Map<TaskManage>(taskManageEntity);

            return model;
        }

        public List<TaskManage> GetTaskManageList()
        {
            var taskManageList = new List<TaskManage>();
            var taskManageEntityList = _taskManageRepository.GetAll();

            taskManageList = Mapper.Map<List<TaskManage>>(taskManageEntityList);

            return taskManageList;
        }

        public void SaveTaskManage(TaskManage taskManage)
        {
            var entity = Mapper.Map<TaskManageEntity>(taskManage);
            
            if (entity.ID == 0)
            {
                _taskManageRepository.Insert(entity);
            }
            else
            {
                _taskManageRepository.Update(entity);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TaskManage, TaskManageEntity>();
                cfg.CreateMap<TaskManageEntity, TaskManage>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private Methods
    }
}

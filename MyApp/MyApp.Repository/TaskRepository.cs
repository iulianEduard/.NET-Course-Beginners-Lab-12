using Dapper;
using MyApp.Core.Models;
using MyApp.Repository.Entity;
using MyApp.Repository.Ports;
using MyApp.Repository.Repo;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Repository
{
    public class TaskRepository : ITaskRepository
    {
        #region Attributes

        private readonly IRepository<TaskEntity> _taskRepository;

        #endregion Attributes

        #region Constructor

        public TaskRepository(IRepository<TaskEntity> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        #endregion Constructor

        #region Public Methods

        public bool Delete(TaskEntity taskEntity)
        {
            _taskRepository.Delete(taskEntity);

            return true;
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return _taskRepository.GetAll();
        }

        public TaskEntity GetById(int id)
        {
            return _taskRepository.Get(id);
        }

        public int Insert(TaskEntity taskEntity)
        {
            return _taskRepository.Add(taskEntity);
        }

        public void Update(TaskEntity taskEntity)
        {
            _taskRepository.Update(taskEntity);
        }

        public List<TaskUnassigned> GetUnassignedTasks()
        {
            var spResult = _taskRepository.SingleSetStoredProcedure<TaskUnassigned>("dbo.usp_GetUnassignedTasks");

            return spResult.ToList();
        }

        public List<TaskUnassigned> GetAssignedTasks(int statusId)
        {
            var spParams = new DynamicParameters(new {
                @StatusId = statusId
            });

            var spResult = _taskRepository.SingleSetStoredProcedure<TaskUnassigned>("dbo.usp_GetTaskByStatus", spParams);

            return spResult.ToList();
        }

        #endregion Public Methods
    }
}

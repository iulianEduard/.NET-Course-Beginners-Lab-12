using MyApp.Repository.Entity;
using MyApp.Repository.Ports;
using MyApp.Repository.Repo;
using System.Collections.Generic;

namespace MyApp.Repository
{
    public class TaskManageRepository : ITaskManageRepository
    {
        #region Attributes

        private readonly IRepository<TaskManageEntity> _taskManageRepository;

        #endregion Attributes

        #region Constructor

        public TaskManageRepository(IRepository<TaskManageEntity> taskManageRepository)
        {
            _taskManageRepository = taskManageRepository;
        }

        #endregion Constructor

        #region Public Methods

        public bool Delete(TaskManageEntity taskEntity)
        {
            _taskManageRepository.Delete(taskEntity);

            return true;
        }

        public IEnumerable<TaskManageEntity> GetAll()
        {
            return _taskManageRepository.GetAll();
        }

        public TaskManageEntity GetById(int id)
        {
            return _taskManageRepository.Get(id);
        }

        public int Insert(TaskManageEntity taskEntity)
        {
            return _taskManageRepository.Add(taskEntity);
        }

        public void Update(TaskManageEntity taskEntity)
        {
            _taskManageRepository.Update(taskEntity);
        }

        #endregion Public Methods
    }
}

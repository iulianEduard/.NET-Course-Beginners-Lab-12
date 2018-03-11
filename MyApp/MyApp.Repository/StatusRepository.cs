using MyApp.Repository.Entity;
using MyApp.Repository.Ports;
using MyApp.Repository.Repo;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Repository
{
    public class StatusRepository : IStatusRepository
    {
        #region Attributes

        private readonly IRepository<StatusEntity> _statusRepository;

        #endregion Attributes

        #region Constructor

        public StatusRepository(IRepository<StatusEntity> statusRepository)
        {
            _statusRepository = statusRepository;
        }

        #endregion Constructor

        #region Public Methods

        public List<StatusEntity> GetAll()
        {
            return _statusRepository.GetAll().ToList();
        }

        #endregion Public Methods
    }
}

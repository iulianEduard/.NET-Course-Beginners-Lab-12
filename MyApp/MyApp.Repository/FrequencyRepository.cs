using MyApp.Repository.Entity;
using MyApp.Repository.Ports;
using MyApp.Repository.Repo;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Repository
{
    public class FrequencyRepository : IFrequencyRepository
    {
        #region Attributes

        private readonly IRepository<FrequencyEntity> _frequencyRepository;

        #endregion Attributes

        #region Constructor

        public FrequencyRepository(IRepository<FrequencyEntity> frequencyRepository)
        {
            _frequencyRepository = frequencyRepository;
        }

        #endregion Constructor

        #region Public Methods

        public List<FrequencyEntity> GetAll()
        {
            return _frequencyRepository.GetAll().ToList();
        }

        #endregion Public Methods
    }
}

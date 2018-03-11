using MyApp.BLL.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyApp.Core.Models;
using MyApp.Repository.Ports;
using AutoMapper;
using MyApp.Repository.Entity;

namespace MyApp.BLL
{
    public class FrequencyService : IFrequencyService
    {
        #region Attributes

        private readonly IFrequencyRepository _frequencyRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        public FrequencyService(IFrequencyRepository frequencyRepository)
        {
            _frequencyRepository = frequencyRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        #region Public Methods

        public List<FrequencyDto> GetFrequencyList()
        {
            var frequencyEntityList = _frequencyRepository.GetAll();
            var frequencyList = Mapper.Map<List<FrequencyDto>>(frequencyEntityList);

            return frequencyList;
        }

        #endregion Public Methods

        #region Private Methods

        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FrequencyDto, FrequencyEntity>();
                cfg.CreateMap<FrequencyEntity, FrequencyDto>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private Methods
    }
}

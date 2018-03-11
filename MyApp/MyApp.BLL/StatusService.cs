using AutoMapper;
using MyApp.BLL.Ports;
using MyApp.Core.Models;
using MyApp.Repository.Entity;
using MyApp.Repository.Ports;
using System.Collections.Generic;

namespace MyApp.BLL
{
    public class StatusService : IStatusService
    {
        #region Attributes

        private readonly IStatusRepository _statusRepository;

        private IMapper Mapper { get; set; }

        #endregion Attributes

        #region Constructor

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;

            Mapper = SetMapperConfigs();
        }

        #endregion Constructor

        #region Public Methods

        public List<Status> GetStatusList()
        {
            var statusEntityList = _statusRepository.GetAll();
            var statusList = Mapper.Map<List<Status>>(statusEntityList);

            return statusList;
        }

        #endregion Public Methods

        #region Private Methods

        private IMapper SetMapperConfigs()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StatusEntity, Status>();
                cfg.CreateMap<Status, StatusEntity>();
            });

            IMapper mapper = config.CreateMapper();

            return mapper;
        }

        #endregion Private Methods
    }
}

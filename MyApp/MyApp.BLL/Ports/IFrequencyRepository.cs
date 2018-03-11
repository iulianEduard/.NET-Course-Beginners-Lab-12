using MyApp.Core.Models;
using System.Collections.Generic;

namespace MyApp.BLL.Ports
{
    public interface IFrequencyService
    {
        List<FrequencyDto> GetFrequencyList();
    }
}

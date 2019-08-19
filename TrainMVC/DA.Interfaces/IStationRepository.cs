using System.Collections.Generic;
using TrainMVC.FilterParameter;
using TrainMVC.Models;

namespace TrainMVC.DA.Interfaces
{
    public interface IStationRepository
    {
        List<StationModel> GetAll();
    }
}
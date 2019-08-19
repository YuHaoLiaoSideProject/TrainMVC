using System.Collections.Generic;
using TrainMVC.Models;
using TrainMVC.ViewModel;

namespace TrainMVC.BL.Interfaces
{
    public interface ITrainService
    {
        List<TrainQueryViewModel> GetTimetable(int startStation, int endStation);
        List<StationModel> GetStations();
        Dictionary<int, string> GetStationDic();
    }
}
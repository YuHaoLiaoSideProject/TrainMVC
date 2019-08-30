using System.Collections.Generic;
using System.Linq;
using TrainMVC.BL.Interfaces;
using TrainMVC.DA.Interfaces;
using TrainMVC.DA.Repositories;
using TrainMVC.FilterParameter;
using TrainMVC.Models;
using TrainMVC.Utility.Extensions;
using TrainMVC.ViewModel;

namespace TrainMVC.BL.Services
{
    public class TrainService : ITrainService
    {
        ICountyStationMappingRepository TrainRepository = new TrainRepository();

        IStationRepository StationRepository = new StationRepository();
        private List<StationModel> _Stations { get; set; }
        private Dictionary<int, string> _StationsDic { get; set; }
        public TrainService()
        {
            _Stations = StationRepository.GetAll();
            _StationsDic = _Stations.ToLookup(e => e.Station, e => e.StationCTName).ToDictionary(e => e.Key, e => e.First());
        }

        public List<StationModel> GetStations()
        {
            return _Stations;
        }
        public Dictionary<int, string> GetStationDic()
        {
            return _StationsDic;
        }
        public List<TrainQueryViewModel> GetTimetable(int startStation,int endStation)
        { 
            return TrainRepository.GetByFilter(new TrainFilterParameter
            {
                StartStation = startStation,
                EndStation = endStation
            }).Select(e => new TrainQueryViewModel
            {
                EndARRTime = e.EndARRTime,
                StartARRTime = e.StartARRTime,
                EndStationName = _StationsDic.GetValue(e.EndStation),
                StartStationName = _StationsDic.GetValue(e.StartStation),
                Train = e.Train
            }).ToList();
        }
    }
}
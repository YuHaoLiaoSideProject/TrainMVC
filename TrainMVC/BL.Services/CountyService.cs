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
    public class CountyService : ICountyService
    {
        ICountyRepository CountyRepository = new CountyRepository();

        IStationRepository StationRepository = new StationRepository();
        private List<CountyModel> _County { get; set; }
        private Dictionary<int, string> _CountyDic { get; set; }
        public CountyService()
        {
            _County = CountyRepository.GetAll();
            _CountyDic = _County.ToLookup(e => e.CountyNo, e => e.County).ToDictionary(e => e.Key, e => e.First());
        }

        public List<CountyModel> GetCounty()
        {
            return _County;
        }
        public Dictionary<int, string> GetCountyDic()
        {
            return _CountyDic;
        }
    }
}
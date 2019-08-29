using System.Collections.Generic;
using TrainMVC.Models;
using TrainMVC.ViewModel;

namespace TrainMVC.BL.Interfaces
{
    public interface ICountyService
    {

        List<CountyModel> GetCounty();
        Dictionary<int, string> GetCountyDic();
    }
}
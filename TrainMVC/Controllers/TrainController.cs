using System.Web.Mvc;
using TrainMVC.BL.Interfaces;
using TrainMVC.BL.Services;
using TrainMVC.Utility.Extensions;

namespace TrainMVC.Controllers
{
    public class TrainController : Controller
    {
        ITrainService TrainService = new TrainService();
        ICountyService CountyService = new CountyService();
        public ActionResult Index()
        {
            
            ViewBag.County = CountyService.GetCounty();
                                          
            ViewBag.Stations = TrainService.GetStations();
            
            return View();
        }
        [HttpPost]
        public ActionResult Index(int startStation , int endStation , int StartStationCounty , int EndStationCounty)
        {
            var result = TrainService.GetTimetable(startStation, endStation);

             var stations = TrainService.GetStations();

            var stationDic = TrainService.GetStationDic();

            var county = CountyService.GetCounty();

            var countyDic = CountyService.GetCountyDic();

            ViewBag.StartStationCounty = StartStationCounty;

            ViewBag.EndStationCounty = EndStationCounty;

            ViewBag.County = CountyService.GetCounty();

            ViewBag.StartStationCountyName = countyDic.GetValue(StartStationCounty);

            ViewBag.EndStationCountyName = countyDic.GetValue(EndStationCounty);

            
            ViewBag.Stations = TrainService.GetStations();

            ViewBag.StartStation = startStation;

            ViewBag.EndStation = endStation;

            ViewBag.StartStationName = stationDic.GetValue(startStation);

            ViewBag.EndStationName = stationDic.GetValue(endStation);



            return View(result);
        }
    }
}
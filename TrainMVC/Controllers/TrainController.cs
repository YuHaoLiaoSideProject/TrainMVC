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
        public ActionResult Index(int startStationId , int endStationId , int startStationCountyId , int endStationCountyId)
        {
            var result = TrainService.GetTimetable(startStationId, endStationId);

             var stations = TrainService.GetStations();

            var stationDic = TrainService.GetStationDic();

            var county = CountyService.GetCounty();

            var countyDic = CountyService.GetCountyDic();

            ViewBag.StartStationCounty = startStationCountyId;

            ViewBag.EndStationCounty = endStationCountyId;

            ViewBag.County = CountyService.GetCounty();

            ViewBag.StartStationCountyName = countyDic.GetValue(startStationCountyId);

            ViewBag.EndStationCountyName = countyDic.GetValue(endStationCountyId);

            
            ViewBag.Stations = TrainService.GetStations();

            ViewBag.StartStation = startStationId;

            ViewBag.EndStation = endStationId;

            ViewBag.StartStationName = stationDic.GetValue(startStationId);

            ViewBag.EndStationName = stationDic.GetValue(endStationId);



            return View(result);
        }
    }
}
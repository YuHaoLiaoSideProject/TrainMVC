using System.Web.Mvc;
using TrainMVC.BL.Interfaces;
using TrainMVC.BL.Services;
using TrainMVC.Utility.Extensions;

namespace TrainMVC.Controllers
{
    public class TrainController : Controller
    {
        ITrainService TrainService = new TrainService();
        public ActionResult Index(int startStation = 1001, int endStation = 1008)
        {
            var result = TrainService.GetTimetable(startStation, endStation);

            var stations = TrainService.GetStations();

            var stationDic = TrainService.GetStationDic();

            ViewBag.Stations = TrainService.GetStations();

            ViewBag.StartStation = startStation;

            ViewBag.EndStation = endStation;

            ViewBag.StartStationName = stationDic.GetValue(startStation);

            ViewBag.EndStationName = stationDic.GetValue(endStation);

            //測試
            return View(result);
        }
    }
}
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
    public class GetTrainIFOService : IGetTrainIFOService
    {
        IGetTrainIFORepository GetTrainIFORepository = new GetTrainIFORepository();

        //private List<GetTrainIFOModel> _GetTrainIFO { get; set; }

        public List<GetTrainIFOViewModel> GetTrainIFO(int train)
        {
            return GetTrainIFORepository.GetByFilter(new GetTrainIFOFilterParameter
            {
                Train = train,
            }).Select(e => new GetTrainIFOViewModel
            {
                StationCTName = e.StationCTName,
                ARRTime = e.ARRTime,

            }).ToList();
        }
    }
}
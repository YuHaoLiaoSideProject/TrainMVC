using System.Collections.Generic;
using TrainMVC.Models;
using TrainMVC.ViewModel;

namespace TrainMVC.BL.Interfaces
{
    public interface IGetTrainIFOService
    {
        List<GetTrainIFOViewModel> GetTrainIFO(int train);

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainMVC.ViewModel
{
    public class TrainQueryViewModel
    {
        public int Train { get; set; }
        public string StartStationName { get; set; }
        public string StartARRTime { get; set; }
        public string EndStationName { get; set; }
        public string EndARRTime { get; set; }

    }
}
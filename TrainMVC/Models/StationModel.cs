namespace TrainMVC.Models
{
    public class StationModel
    {
        public int Station { get; set; }
        public string StationCTName { get; set; }
    }

    public class StationCountyModel
    {
        public int Station { get; set; }
        public string StationCTName { get; set; }
        public int CountyNo { get; set; }
    }
}
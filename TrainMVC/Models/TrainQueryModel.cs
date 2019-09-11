namespace TrainMVC.Models
{
    public class TrainQueryModel
    {
        public int Train{get;set;}
        public int StartStation { get; set; }
        public string StartARRTime { get; set; }
        public int EndStation { get; set; }
        public string EndARRTime { get; set; }
        public string TrainLevel { get; set; }
    }
}
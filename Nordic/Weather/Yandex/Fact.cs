namespace Weather.Yandex
{
    public class Fact
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_water { get; set; }
        public string condition { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double humidity { get; set; }
        public string season { get; set; }   
    }
}
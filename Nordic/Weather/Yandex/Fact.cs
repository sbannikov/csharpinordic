namespace Weather.Yandex
{
    public class Fact
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_water { get; set; }
        public string condition { get; set; }
        /// <summary>
        /// Скорость ветра в м/с
        /// </summary>
        public double wind_speed { get; set; }
        /// <summary>
        /// Скорость повывов ветра в м/с
        /// </summary>
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        /// <summary>
        /// Давление в мм.рт.ст.
        /// </summary>
        public double pressure_mm { get; set; }
        public double humidity { get; set; }
        public string season { get; set; }   
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Weather
{
    public class Worker
    {
        private System.Timers.Timer timer;

        private IWeather weather;

        public Worker()
        {
            var config = JsonFile.Load<Configuration>();
            timer = new System.Timers.Timer(config.IntervalInSeconds * 1000);
            timer.Elapsed += Timer_Elapsed;
            weather = new Yandex.YandexWeather();
        }

        /// <summary>
        /// Основное событие запроса данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timer.Stop();
                var meteo = weather.GetData();
                if (meteo != null)
                {
                    string json = JsonSerializer.Serialize(meteo);
                    string name = $@"C:\FOLDER\{meteo.TimeStamp.Ticks}.json";
                    System.IO.File.WriteAllText(name, json);
                }
            }
            catch (Exception ex)
            {
                // [!] дописать на досуге
            }
            finally
            {
                timer.Start();
            }
        }

        public void StartService()
        {
            timer.Start();
        }

        public void StopService()
        {
            timer.Stop();
        }

        public void PauseService()
        {
            timer.Stop();
        }

        public void ContinueService()
        {
            timer.Start();
        }
    }
}
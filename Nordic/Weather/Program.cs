using Topshelf;

namespace Weather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rc = HostFactory.Run(x =>
            {
                x.Service<Worker>(s => {
                    s.ConstructUsing(w => new Worker(1));
                    s.WhenStarted(w => w.Start());
                    s.WhenStopped(w => w.Stop());
                });
                x.RunAsLocalSystem();
                x.SetServiceName("YandexWeather");
                x.SetDisplayName("Получение погоды Yandex");
                x.SetDescription("Получение погоды Yandex");
            });        
        }
    }
}
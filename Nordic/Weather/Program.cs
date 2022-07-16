using Topshelf;

namespace Weather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var run = HostFactory.Run(x =>
            {
                x.Service<Worker>(s => 
                {
                    s.ConstructUsing(w => new Worker());
                    s.WhenStarted(w => w.StartService());
                    s.WhenStopped(w => w.StopService());
                    s.WhenPaused(w => w.PauseService());
                    s.WhenContinued(w => w.ContinueService());
                });
                x.RunAsLocalSystem();
                x.SetServiceName("weathersvc");
                x.SetDisplayName("Служба сбора метеорологических данных");
                x.SetDescription("Служба сбора метеорологических данных от Яндекса");
            });
        }
    }
}
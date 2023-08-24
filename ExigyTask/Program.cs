using Autofac;
using ExigyTask.Services;

namespace ExigyTask
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ConfigureContainer();

            var application = container.Resolve<ApplicationService>();

            application.PlayGame();
        }

        private static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApplicationService>();

            return builder.Build();
        }
    }
}

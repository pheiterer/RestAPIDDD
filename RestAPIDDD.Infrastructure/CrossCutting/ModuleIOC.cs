using Autofac;
using RestAPIDDD.Infrastructure.CrossCutting.IOC;

namespace RestAPIDDD.Infrastructure.CrossCutting
{
    public class ModuleIOC : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            ConfigurationIOC.Load(builder);
        }
    }
}

using Autofac;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Reflection;

namespace Vehicle.Presentation.API.bootstrapping
{
    public class CoreModule : Autofac.Module
    {
        private readonly IConfiguration configuration;

        public CoreModule(IConfiguration configuration)
        {
            this.configuration = configuration ?? throw new System.ArgumentNullException(nameof(configuration));
        }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterValidators(builder, Assembly.Load("Vehicle.Core"));
        }

        private void RegisterValidators(ContainerBuilder builder, Assembly assembly)
        {
            builder
                .RegisterAssemblyTypes(assembly)
                .Where(t => t.IsClass && t.Name.EndsWith("Validator"))
                .AsSelf()
                .InstancePerLifetimeScope();
        }

    }
}

using HelpDesk_BLL.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HelpDesk_BLL
{
    internal struct InterfaceToImplementation
    {
        public Type Implementation;
        public Type Interface;
    }

    public static class HelpDesk_BLL_ModuleHead
	{
        public static void RegisterModule(IServiceCollection services)
        {
            var currentAssembly = Assembly.GetAssembly(typeof(HelpDesk_BLL_ModuleHead));

            var allTypesInThisAssembly = currentAssembly.GetTypes();

            var serviceTypes = allTypesInThisAssembly
                .Where(type =>
                    type.IsAssignableTo(typeof(IService))
                    && !type.IsInterface
                );

            var interfaceToImplementationMap = serviceTypes.Select(serviceType => {
                var implementation = serviceType;
                var @interface = serviceType.GetInterfaces()
                    .First(serviceInterface => serviceInterface != typeof(IService));

                return new InterfaceToImplementation
                {
                    Interface = @interface,
                    Implementation = implementation,
                };
            });

            foreach (var serviceToInterface in interfaceToImplementationMap)
            {
                services.AddTransient(serviceToInterface.Interface, serviceToInterface.Implementation);
            }
        }
    }
}

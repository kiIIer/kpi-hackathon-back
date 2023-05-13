using System.Reflection;
using Idk.Application.Dependencies;

namespace Idk.Web.Dependencies;

public static class DependenciesRegistrator
{
    public static void Register(this IServiceCollection serviceCollection)
    {
        var attributeType = typeof(DefaultTransientImplementation);
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p =>  p.IsDefined(attributeType, true) && !p.IsInterface).Select(s => new
            {
                Service = s.GetInterface($"I{s.Name}"),
                Implementation = s 
            }).Where(x => x.Service != null);

        foreach (var type in types)
        {
            if (type.Implementation.IsDefined(attributeType, false))
            {
                serviceCollection.AddTransient(type.Service, type.Implementation);
            }
        }
    }
}
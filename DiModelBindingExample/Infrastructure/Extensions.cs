using System;
using System.Linq;
using DiModelBindingExample.Models.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace DiModelBindingExample.Infrastructure
{
    public static class Extensions
    {
        /// <summary>
        /// Add the Command, Notification and Query requests to the service collection.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <returns></returns>
        public static IServiceCollection AddRequests(this IServiceCollection serviceCollection)
        {
            var requestTypes = (from domainAssembly in AppDomain.CurrentDomain.GetAssemblies()
                                from assemblyType in domainAssembly.GetTypes()
                                where assemblyType.IsSubclassOfRawGeneric(typeof(Command<>)) && !assemblyType.IsAbstract
                                select assemblyType).ToArray();
            foreach (var requestType in requestTypes)
            {
                serviceCollection.AddScoped(requestType);
            }

            return serviceCollection;
        }

        /// <summary>
        /// Alternative version of <see cref="Type.IsSubclassOf"/> that supports raw generic types (generic types without
        /// any type parameters).
        /// </summary>
        /// <param name="generic">The base type class for which the check is made.</param>
        /// <param name="toCheck">To type to determine for whether it derives from <paramref name="generic"/>.</param>
        public static bool IsSubclassOfRawGeneric(this Type toCheck, Type generic)
        {
            while (toCheck != null && toCheck != typeof(object))
            {
                var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
                if (generic == cur)
                {
                    return true;
                }
                toCheck = toCheck.BaseType;
            }
            return false;
        }
    }
}

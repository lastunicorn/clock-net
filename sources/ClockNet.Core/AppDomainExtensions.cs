using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DustInTheWind.ClockNet.Core
{
    public static class AppDomainExtensions
    {
        public static IEnumerable<Type> GetTypesImplementing<T>(this AppDomain appDomain)
        {
            Type baseType = typeof(T);

            if (baseType is null) throw new ArgumentNullException(nameof(baseType));

            return appDomain.GetAssemblies()
                .SelectMany(x => GetTypesSafely(x))
                .Where(x => baseType.IsAssignableFrom(x) && x.IsClass && !x.IsAbstract);
        }

        private static IEnumerable<Type> GetTypesSafely(Assembly assembly)
        {
            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(x => x != null);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace Common.Core.Infrastructure.Helpers
{

    public class HarnessOneSerializationBinder : ISerializationBinder
    {
        private Dictionary<string, Dictionary<string, Type>> KnownTypes { get; } = new Dictionary<string, Dictionary<string, Type>>();

        public HarnessOneSerializationBinder()
        {
            if (File.Exists(@".\Common.Core.dll"))
            {
                var commonCore = Assembly.Load(AssemblyName.GetAssemblyName(@".\Common.Core.dll"));
                ReadAssemblyForTypes(commonCore);
            }

            if (File.Exists(@".\Common.Core.SF.dll"))
            {
                var commonSf = Assembly.Load(AssemblyName.GetAssemblyName(@".\Common.Core.SF.dll"));
                ReadAssemblyForTypes(commonSf);
            }
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            return KnownTypes[assemblyName][typeName];
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = serializedType.Assembly.GetName().Name;
            typeName = serializedType.Name;
        }

        private void ReadAssemblyForTypes(Assembly assembly)
        {
            IEnumerable<Type> loadableTypes;

            try
            {
                loadableTypes = assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                loadableTypes = ex.Types.Where(t => t != null && t.IsPublic);
            }

            var knownTypeForAssembly = new Dictionary<string, Type>();
            foreach (var type in loadableTypes)
                knownTypeForAssembly[type.FullName ?? throw new InvalidOperationException()] = type;

            KnownTypes[assembly.FullName] = knownTypeForAssembly;
        }
    }
}

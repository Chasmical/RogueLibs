using System;
using System.IO;
using Mono.Cecil;

namespace RogueLibsPatcher.Console
{
	public static class Program
	{
		public static void Main()
		{
			string path = System.Console.ReadLine();
			path = path.Trim('"');
			string newPath = path + "2";
			AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(path, new ReaderParameters()
            {
				AssemblyResolver = new CustomResolver(),
            });
			RogueLibsPatcher.Patch(assembly);
            assembly.Write(newPath);
			assembly.Dispose();
			File.Copy(newPath, path, true);
			File.Delete(newPath);
		}
        private class CustomResolver : BaseAssemblyResolver
        {
            private readonly DefaultAssemblyResolver _defaultResolver;

            public CustomResolver()
            {
                _defaultResolver = new DefaultAssemblyResolver();
            }

            public override AssemblyDefinition Resolve(AssemblyNameReference name)
            {
                AssemblyDefinition assembly;
                try
                {
                    assembly = _defaultResolver.Resolve(name);
                }
                catch (AssemblyResolutionException ex)
                {
                    assembly = AssemblyDefinition.ReadAssembly(@"D:\Steam\steamapps\common\Streets of Rogue\StreetsOfRogue_Data\Managed\XGamingRuntime.dll");
                }
                return assembly;
            }
        }
	}
}

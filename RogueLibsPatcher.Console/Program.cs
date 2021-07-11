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
			AssemblyDefinition assembly = AssemblyDefinition.ReadAssembly(path);
			RogueLibsPatcher.Patch(assembly);
			assembly.Write(newPath);
			assembly.Dispose();
			File.Copy(newPath, path, true);
			File.Delete(newPath);
		}
	}
}

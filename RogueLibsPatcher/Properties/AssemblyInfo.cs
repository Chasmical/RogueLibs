using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("RogueLibsPatcher")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyCompany("Abbysssal")]
[assembly: AssemblyProduct("RogueLibsPatcher")]
[assembly: AssemblyCopyright("Copyright © 2021")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

#if DEBUG
[assembly: AssemblyConfiguration("Debug")]
#elif RELEASE
[assembly: AssemblyConfiguration("Release")]
#else
[assembly: AssemblyConfiguration("")]
#endif

[assembly: ComVisible(false)]
[assembly: Guid("31ae3c3a-2227-4df9-a3e1-8173a4df70c0")]

[assembly: AssemblyVersion(RogueLibsCore.RogueLibs.AssemblyVersion)]
[assembly: AssemblyFileVersion(RogueLibsCore.RogueLibs.AssemblyVersion)]

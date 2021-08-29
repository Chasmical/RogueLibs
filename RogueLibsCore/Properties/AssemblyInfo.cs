using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: AssemblyTitle("RogueLibsCore")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyCompany("Abbysssal")]
[assembly: AssemblyProduct("RogueLibsCore")]
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
[assembly: Guid("43a221f2-a56c-4f59-8c3c-828de75259c4")]

[assembly: AssemblyVersion(RogueLibsCore.RogueLibs.AssemblyVersion)]
[assembly: AssemblyFileVersion(RogueLibsCore.RogueLibs.AssemblyVersion)]

[assembly: InternalsVisibleTo("RogueLibsCore.Test")]
[assembly: InternalsVisibleTo("RogueLibsPatcher")]

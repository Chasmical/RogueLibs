using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
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

[assembly: InternalsVisibleTo("RogueLibsCore.Test")]

[assembly: Guid("43a221f2-a56c-4f59-8c3c-828de75259c4")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion(RogueLibsCore.RogueLibs.AssemblyVersion)]
[assembly: AssemblyFileVersion(RogueLibsCore.RogueLibs.AssemblyVersion)]

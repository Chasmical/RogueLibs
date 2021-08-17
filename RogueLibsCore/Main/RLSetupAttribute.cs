using System;
using JetBrains.Annotations;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Indicates that this method should be executed when <see cref="RogueLibs.LoadFromAssembly()"/> is called.</para>
	/// </summary>
	[MeansImplicitUse]
	[AttributeUsage(AttributeTargets.Method)]
	public class RLSetupAttribute : Attribute { }
}

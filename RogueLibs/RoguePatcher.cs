using BepInEx;
using System;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>A class to simplify Harmony patching.</para>
	/// </summary>
	public class RoguePatcher
	{
		private readonly BaseUnityPlugin myPlugin;
		/// <summary>
		///   <para>Type, that this <see cref="RoguePatcher"/> will search patch methods in.</para>
		/// </summary>
		public Type TypeWithPatches { get; set; }

		/// <summary>
		///   <para>Initializes a new instance of <see cref="RoguePatcher"/> for the specified <paramref name="plugin"/> with <paramref name="typeWithPatches"/>.</para>
		/// </summary>
		public RoguePatcher(BaseUnityPlugin plugin, Type typeWithPatches)
		{
			myPlugin = plugin;
			TypeWithPatches = typeWithPatches;
		}

		/// <summary>
		///   <para>Changes this <see cref="RoguePatcher"/>'s target type.</para>
		/// </summary>
		public void SwitchTo(Type newClassWithPatches) => TypeWithPatches = newClassWithPatches;

		/// <summary>
		///   <para>Patches an original method with a prefix-method called "<paramref name="type"/>_<paramref name="methodName"/>" in this <see cref="TypeWithPatches"/>.</para>
		/// </summary>
		public bool Prefix(Type type, string methodName, Type[] types = null) => myPlugin.PatchPrefix(type, methodName, TypeWithPatches, type.Name + '_' + methodName, types);
		/// <summary>
		///   <para>Patches an original method with a postfix-method called "<paramref name="type"/>_<paramref name="methodName"/>" in this <see cref="TypeWithPatches"/>.</para>
		/// </summary>
		public bool Postfix(Type type, string methodName, Type[] types = null) => myPlugin.PatchPostfix(type, methodName, TypeWithPatches, type.Name + '_' + methodName, types);
	}
}

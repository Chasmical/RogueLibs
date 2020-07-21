using BepInEx;
using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>A collection of useful functions for modding Streets of Rogue.</para>
	/// </summary>
	public static class RogueLibs
	{
		/// <summary>
		///   <para><see cref="RogueLibs"/>' GUID. Use it in your <see cref="BepInDependency"/> attribute.</para>
		/// </summary>
		public const string pluginGuid = "abbysssal.streetsofrogue.roguelibs";
		/// <summary>
		///   <para><see cref="RogueLibs"/>' display name.</para>
		/// </summary>
		public const string pluginName = "RogueLibs";
		/// <summary>
		///   <para>Do not use this constant in your BepInDependency attribute!</para>
		/// </summary>
		public const string pluginVersion = "1.4.0";

		public static RogueLibsPlugin PluginInstance;
		internal static ManualLogSource Logger;

		/// <summary>
		///   <para>List of initialized <see cref="CustomName"/>s.</para>
		/// </summary>
		public static List<CustomName> CustomNames { get; set; } = new List<CustomName>();
		/// <summary>
		///   <para>List of initialized <see cref="CustomMutator"/>s.</para>
		/// </summary>
		public static List<CustomMutator> CustomMutators { get; set; } = new List<CustomMutator>();
		/// <summary>
		///   <para>List of initialized <see cref="CustomItem"/>s.</para>
		/// </summary>
		public static List<CustomItem> CustomItems { get; set; } = new List<CustomItem>();
		/// <summary>
		///   <para>List of initialized <see cref="CustomAbility"/>s.</para>
		/// </summary>
		public static List<CustomAbility> CustomAbilities { get; set; } = new List<CustomAbility>();

		/// <summary>
		///   <para>Finds an existing <see cref="CustomName"/> by its <paramref name="id"/> and <paramref name="type"/>.</para>
		/// </summary>
		public static CustomName GetCustomName(string id, string type) => CustomNames.Find(n => n.Id == id && n.Type == type);
		/// <summary>
		///   <para>Creates a new <see cref="CustomName"/> with the specified <paramref name="id"/>, <paramref name="type"/> and <paramref name="info"/>.</para>
		/// </summary>
		public static CustomName CreateCustomName(string id, string type, CustomNameInfo info)
		{
			CustomName customName = GetCustomName(id, type);
			if (customName != null)
			{
				string message = string.Concat("A CustomName with Id \"", id, "\" and Type \"", type, "\" already exists!");
				Logger.LogError(message);
				throw new ArgumentException(message, nameof(id));
			}
			CustomNames.Add(customName = new CustomName(id, type, info.ToArray()));

			Logger.LogDebug(string.Concat("A CustomName with Id \"", id, "\" and Type \"", type, "\" was created."));

			return customName;
		}

		/// <summary>
		///   <para>Finds an existing <see cref="CustomMutator"/> by its <paramref name="id"/>.</para>
		/// </summary>
		public static CustomMutator GetCustomMutator(string id) => CustomMutators.Find(m => m.Id == id);
		/// <summary>
		///   <para>Creates a new <see cref="CustomMutator"/> with the specified <paramref name="id"/>, <paramref name="name"/> and <paramref name="description"/>.</para>
		/// </summary>
		public static CustomMutator CreateCustomMutator(string id, bool unlockedFromStart, CustomNameInfo name, CustomNameInfo description)
		{
			CustomMutator customMutator = GetCustomMutator(id);
			if (customMutator != null)
			{
				string message = string.Concat("A CustomMutator with Id \"", id, "\" already exists!");
				Logger.LogError(message);
				throw new ArgumentException(message, nameof(id));
			}
			CustomMutators.Add(customMutator = new CustomMutator(id, CreateCustomName(id, "Unlock", name), CreateCustomName("D_" + id, "Unlock", description));

			Logger.LogDebug(string.Concat("A CustomMutator with Id \"", id, "\" was created."));

			return customMutator;
		}









	}
}

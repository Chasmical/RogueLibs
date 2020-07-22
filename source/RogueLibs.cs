using BepInEx;
using BepInEx.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
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

		/// <summary>
		///   <para>Main <see cref="RogueLibsPlugin"/> instance.</para>
		/// </summary>
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
			CustomNames.Add(customName = new CustomName(id, type, info));

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
		public static CustomMutator CreateCustomMutator(string id, CustomNameInfo name, CustomNameInfo description)
		{
			CustomMutator customMutator = GetCustomMutator(id);
			if (customMutator != null)
			{
				string message = string.Concat("A CustomMutator with Id \"", id, "\" already exists!");
				Logger.LogError(message);
				throw new ArgumentException(message, nameof(id));
			}
			CustomMutators.Add(customMutator = new CustomMutator(id,
				CreateCustomName(id, "Unlock", name),
				CreateCustomName("D_" + id, "Unlock", description)
				));

			Logger.LogDebug(string.Concat("A CustomMutator with Id \"", id, "\" was created."));

			return customMutator;
		}

		/// <summary>
		///   <para>Finds an existing <see cref="CustomItem"/> by its <paramref name="id"/>.</para>
		/// </summary>
		public static CustomItem GetCustomItem(string id) => CustomItems.Find(i => i.Id == id);
		/// <summary>
		///   <para>Creates a new <see cref="CustomItem"/> with the specified <paramref name="id"/>, <paramref name="sprite"/>, <paramref name="name"/> and <paramref name="description"/>.</para>
		/// </summary>
		public static CustomItem CreateCustomItem(string id, Sprite sprite, CustomNameInfo name, CustomNameInfo description, Action<InvItem> setupDetails)
		{
			CustomItem customItem = GetCustomItem(id);
			if (customItem != null)
			{
				string message = string.Concat("A CustomItem with Id \"", id, "\" already exists!");
				Logger.LogError(message);
				throw new ArgumentException(message, nameof(id));
			}
			CustomItems.Add(customItem = new CustomItem(id,
				CreateCustomName(id, "Item", name),
				CreateCustomName(id, "Description", description)
				));
			customItem.Sprite = sprite;
			customItem.SetupDetails = setupDetails;

			Logger.LogDebug(string.Concat("A CustomItem with Id \"", id, "\" was created."));

			return customItem;
		}

		/// <summary>
		///   <para>Finds an existing <see cref="CustomAbility"/> by its <paramref name="id"/>.</para>
		/// </summary>
		public static CustomAbility GetCustomAbility(string id) => CustomAbilities.Find(a => a.Id == id);
		/// <summary>
		///   <para>Creates a new <see cref="CustomAbility"/> with the specified <paramref name="id"/>, <paramref name="sprite"/>, <paramref name="name"/> and <paramref name="description"/>.</para>
		/// </summary>
		public static CustomAbility CreateCustomAbility(string id, Sprite sprite, CustomNameInfo name, CustomNameInfo description, Action<InvItem> setupDetails = null)
			=> CreateCustomAbility(CreateCustomItem(id, sprite, name, description, setupDetails));
		/// <summary>
		///   <para>Creates a new <see cref="CustomAbility"/> based on the specified <paramref name="customItem"/>.</para>
		/// </summary>
		public static CustomAbility CreateCustomAbility(CustomItem customItem)
		{
			CustomAbility customAbility = GetCustomAbility(customItem.Id);
			if (customAbility != null)
			{
				string message = string.Concat("A CustomAbility with Id \"", customItem.Id, "\" already exists!");
				Logger.LogError(message);
				throw new ArgumentException(message, nameof(customItem.Id));
			}
			CustomAbilities.Add(customAbility = new CustomAbility(customItem));

			Logger.LogDebug(string.Concat("A CustomAbility with Id \"", customItem.Id, "\" was created."));

			return customAbility;
		}






	}
}

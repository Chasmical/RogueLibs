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
	public class RogueLibs
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

		internal static RogueLibsPlugin PluginInstance { get; set; }
		/// <summary>
		///   <para>An instance of <see cref="RogueLibs"/>, containing all <see cref="CustomMutator"/>s and <see cref="CustomName"/>s.</para>
		/// </summary>
		public static RogueLibs Instance { get; internal set; }

		internal ManualLogSource Logger { get; set; }

		internal string DataPath { get; set; }
		/// <summary>
		///   <para>List of all <see cref="CustomMutator"/>s.</para>
		/// </summary>
		public List<CustomMutator> Mutators { get; set; }
		/// <summary>
		///   <para>List of all <see cref="CustomItem"/>s.</para>
		/// </summary>
		public List<CustomItem> Items { get; set; }
		/// <summary>
		///   <para>List of all <see cref="CustomAbility"/>s.</para>
		/// </summary>
		public List<CustomAbility> Abilities { get; set; }
		/// <summary>
		///   <para>List of all <see cref="CustomName"/>s.</para>
		/// </summary>
		public List<CustomName> Names { get; set; }

		internal List<RandomListInfo> RandomLists { get; set; }
		
		internal Dictionary<string, bool> MutatorsStates { get; set; }
		internal Dictionary<string, int> AbilityIds { get; set; }

		internal void Start(string dataPath)
		{
			DataPath = dataPath;
			ResetData();

			LoadData(DataPath);
			SaveData();
		}
		internal void ResetData()
		{
			Mutators = new List<CustomMutator>();
			Items = new List<CustomItem>();
			Abilities = new List<CustomAbility>();
			Names = new List<CustomName>();

			RandomLists = new List<RandomListInfo>();

			MutatorsStates = new Dictionary<string, bool>();
			AbilityIds = new Dictionary<string, int>();
		}

		internal void LoadData(string dataPath, bool throwException = false)
		{
			ResetData();

			XmlReader rootR = null;
			XmlReader subdirR = null;
			try
			{
				rootR = XmlReader.Create(dataPath);
				while (rootR.Read())
				{
					rootR.MoveToContent();
					if (rootR.Name == "MutatorsData")
					{
						subdirR = rootR.ReadSubtree();
						while (subdirR.Read())
						{
							subdirR.MoveToContent();
							if (subdirR.Name == "Mutator")
							{
								string mutatorId = subdirR.GetAttribute("Id");
								if (!bool.TryParse(subdirR.GetAttribute("Unlocked"), out bool unlocked))
									unlocked = false;
								if (!MutatorsStates.ContainsKey(mutatorId))
									MutatorsStates.Add(mutatorId, unlocked);
							}
						}
						subdirR.Close();
					}
				}
				rootR.Close();
			}
			catch (Exception e)
			{
				//throw e;

				rootR?.Close();
				subdirR?.Close();

				if (throwException) throw e;
				try
				{
					Logger.LogWarning(Path.GetFileName(dataPath) + " is corrupted or does not exist! Trying to load the backup file...");
					LoadData(dataPath + ".backup", true);
				}
				catch
				{
					Logger.LogWarning("Both " + Path.GetFileName(dataPath) + " and its backup are corrupted or do not exist! Creating a new configuration file...");
					ResetData();
					SaveData();
				}
			}
		}
		internal void SaveData()
		{
			StreamWriter sw = File.CreateText(DataPath + ".temp");
			XmlWriter writer = XmlWriter.Create(sw);

			writer.WriteStartElement("DATA");

			writer.WriteStartElement("MutatorsData");
			foreach (CustomMutator mutator in Mutators)
			{
				writer.WriteStartElement("Mutator");
				writer.WriteAttributeString("Id", mutator.Id);
				writer.WriteAttributeString("Unlocked", mutator.Unlocked.ToString());
				writer.WriteEndElement();
			}
			writer.WriteEndElement();

			writer.WriteEndElement();
			writer.Close();
			sw.Close();

			if (!File.Exists(DataPath))
				File.Move(DataPath + ".temp", DataPath);
			else
				File.Replace(DataPath + ".temp", DataPath, DataPath + ".backup");
		}

		/// <summary>
		///   <para>Gets in-game position of the mouse cursor.</para>
		/// </summary>
		public static Vector2 MouseIngamePosition()
		{
			Plane plane = new Plane(new Vector3(0, 0, 1), new Vector3(0, 0, 0));
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			return plane.Raycast(ray, out float enter) ? (Vector2)ray.GetPoint(enter) : (default);
		}

		/// <summary>
		///   <para>Spawns an <see cref="Agent"/> with <paramref name="agentId"/> at <paramref name="position"/>.</para>
		/// </summary>
		public static Agent SpawnAgent(Vector2 position, string agentId) => GameController.gameController.spawnerMain.SpawnAgent(position, agentId, 0);
		/// <summary>
		///   <para>Spawns an <see cref="Item"/> with <paramref name="itemId"/> (<paramref name="amount"/>) at <paramref name="position"/>.</para>
		/// </summary>
		public static Item SpawnItem(Vector2 position, string itemId, int amount)
		{
			InvItem invItem = new InvItem
			{
				invItemName = itemId,
				invItemCount = amount
			};
			invItem.ItemSetup(false);
			return GameController.gameController.spawnerMain.SpawnItem(position, invItem);
		}

		/// <summary>
		///   <para>An array of game languages.</para>
		/// </summary>
		public static readonly string[] languages = new string[]
		{ "english", "schinese", "german", "spanish", "brazilian", "russian", "french", "koreana" };

		/// <summary>
		///   <para>Gets a <see cref="CustomName"/> with the specified <paramref name="id"/> and <paramref name="type"/>.</para>
		/// </summary>
		public static CustomName GetCustomName(string id, string type) => Instance.Names.Find(n => n.Id == id && n.Type == type);
		/// <summary>
		///   <para>Creates or updates a <see cref="CustomName"/> using the specified <paramref name="id"/>, <paramref name="type"/> and <paramref name="info"/>. If you don't know which <paramref name="type"/> you need, use <see langword="null"/>.</para>
		/// </summary>
		public static CustomName SetCustomName(string id, string type, CustomNameInfo info)
		{
			CustomName name = Instance.Names.Find(n => n.Id == id && n.Type == type);
			bool createNew = name == null;
			if (createNew)
				Instance.Names.Add(name = new CustomName(id, type));
			name.SetTranslations(info);

			Instance.Logger.LogInfo("CustomName " + id + " (" + name.English + ") was " + (createNew ? "created" : "updated") + ".");

			return name;
		}

		/// <summary>
		///   <para>Deletes a <see cref="CustomName"/> with the specified <paramref name="id"/> and <paramref name="type"/>.</para>
		/// </summary>
		public static bool DeleteCustomName(string id, string type)
		{
			CustomName found = Instance.Names.Find(n => n.Id == id && n.Type == type);
			return found != null && DeleteCustomName(found);
		}
		/// <summary>
		///   <para>Deletes the specified <paramref name="customName"/>.</para>
		/// </summary>
		public static bool DeleteCustomName(CustomName customName)
		{
			bool res = Instance.Names.Remove(customName);
			if (res) Instance.Logger.LogInfo("CustomName " + customName.Id + " (" + customName.English + ") was deleted.");
			return res;
		}

		/// <summary>
		///   <para>Gets a <see cref="CustomMutator"/> with the specified <paramref name="id"/>.</para>
		/// </summary>
		public static CustomMutator GetMutator(string id) => Instance.Mutators.Find(m => m.Id == id);
		/// <summary>
		///   <para>Creates or updates a <see cref="CustomMutator"/> using the specified <paramref name="id"/>, <paramref name="name"/> and <paramref name="description"/>.</para>
		/// </summary>
		public static CustomMutator SetMutator(string id, bool unlockedFromStart, CustomNameInfo name, CustomNameInfo description)
		{
			CustomMutator mutator = Instance.Mutators.Find(m => m.Id == id);
			bool createNew = mutator == null;
			if (createNew)
			{
				Instance.Mutators.Add(mutator = new CustomMutator(id, unlockedFromStart));
				Instance.SaveData();

				if (!unlockedFromStart && Instance.MutatorsStates.ContainsKey(id))
					mutator.Unlocked = Instance.MutatorsStates[id];
			}
			mutator.Name = SetCustomName(id, "Unlock", name);
			mutator.Description = SetCustomName("D_" + id, "Unlock", description);

			Instance.Logger.LogInfo("CustomMutator " + id + " (" + mutator.Name?.English + ") was " + (createNew ? "created" : "updated") + ".");

			return mutator;
		}

		/// <summary>
		///   <para>Deletes a <see cref="CustomMutator"/> with the specified <paramref name="id"/>.</para>
		/// </summary>
		public static bool DeleteMutator(string id)
		{
			CustomMutator found = Instance.Mutators.Find(m => m.Id == id);
			return found != null && DeleteMutator(found);
		}
		/// <summary>
		///   <para>Deletes the specified <paramref name="customMutator"/>.</para>
		/// </summary>
		public static bool DeleteMutator(CustomMutator customMutator)
		{
			DeleteCustomName(customMutator.Name);
			DeleteCustomName(customMutator.Description);

			bool res = Instance.Mutators.Remove(customMutator);
			if (res)
			{
				Instance.Logger.LogInfo("CustomMutator " + customMutator.Id + " (" + customMutator.Name?.English + ") was deleted.");
				Instance.SaveData();
			}
			return res;
		}

		/// <summary>
		///   <para>Gets a <see cref="CustomItem"/> with the specified <paramref name="id"/>.</para>
		/// </summary>
		public static CustomItem GetItem(string id) => Instance.Items.Find(i => i.Id == id);
		/// <summary>
		///   <para>Creates or updates a <see cref="CustomItem"/> using the specified <paramref name="id"/>, <paramref name="name"/>, <paramref name="description"/>, <paramref name="sprite"/> and <paramref name="setupDetails"/> delegate.</para>
		/// </summary>
		public static CustomItem SetItem(string id, Sprite sprite, CustomNameInfo name, CustomNameInfo description, Action<InvItem> setupDetails)
		{
			CustomItem item = Instance.Items.Find(i => i.Id == id);
			bool createNew = item == null;
			if (createNew)
				Instance.Items.Add(item = new CustomItem(id));

			item.Sprite = sprite;
			GameController.gameController?.gameResources?.itemDic?.Add(item.Id, item.Sprite);
			GameController.gameController?.gameResources?.itemList?.Add(item.Sprite);
			item.Name = SetCustomName(id, "Item", name);
			item.Description = SetCustomName(id, "Description", description);
			item.SetupDetails = setupDetails;

			Instance.Logger.LogInfo("CustomItem " + id + " (" + item.Name?.English + ") was " + (createNew ? "created" : "updated") + ".");

			return item;
		}

		/// <summary>
		///   <para>Deletes a <see cref="CustomItem"/> with the specified <paramref name="id"/>.</para>
		/// </summary>
		public static bool DeleteItem(string id)
		{
			CustomItem found = Instance.Items.Find(i => i.Id == id);
			return found != null && DeleteItem(found);
		}
		/// <summary>
		///   <para>Deletes the specified <paramref name="customItem"/>.</para>
		/// </summary>
		public static bool DeleteItem(CustomItem customItem)
		{
			DeleteCustomName(customItem.Name);
			DeleteCustomName(customItem.Description);

			bool res = Instance.Items.Remove(customItem);
			if (res) Instance.Logger.LogInfo("CustomItem " + customItem.Id + " (" + customItem.Name?.English + ") was deleted.");
			return res;
		}

		internal static RandomList GetRandomList(string name, string category, string objectType)
		{
			if (GameController.gameController?.rnd?.randomListTable == null) return null;
			foreach (RandomList list in GameController.gameController.rnd.randomListTable.Values)
				if (list.rName == name && list.rCategory == category && list.rObjectType == objectType)
					return list;
			return null;
		}
		internal static RandomList SetRandomList(string name, string category, string objectType)
		{
			RandomList list = GetRandomList(name, category, objectType);
			if (list == null)
			{
				list = GameController.gameController.rnd.CreateRandomList(name, category, objectType);
				RandomListInfo info = new RandomListInfo(name, category, objectType);
				Instance.RandomLists.Add(info);
			}
			return list;
		}

		/// <summary>
		///   <para>Gets a <see cref="CustomAbility"/> with the specified <paramref name="id"/>.</para>
		/// </summary>
		public static CustomAbility GetAbility(string id) => Instance.Abilities.Find(a => a.Id == id);
		/// <summary>
		///   <para>Creates or updates a <see cref="CustomAbility"/> using the specified <paramref name="customItem"/>.</para>
		/// </summary>
		public static CustomAbility SetAbility(CustomItem customItem)
		{
			CustomAbility ability = Instance.Abilities.Find(a => a.Id == customItem.Id);
			bool createNew = ability == null;
			if (createNew)
			{
				Instance.Abilities.Add(ability = new CustomAbility(customItem));
				Instance.AbilityIds.Add(ability.Id, ability.Id.GetHashCode());
			}

			Instance.Logger.LogInfo("CustomAbility " + customItem.Id + " (" + customItem.Name?.English + ") was " + (createNew ? "created" : "updated") + ".");

			return ability;
		}

		/// <summary>
		///   <para>Deletes a <see cref="CustomAbility"/> with the specified <paramref name="id"/>.</para>
		/// </summary>
		public static bool DeleteAbility(string id)
		{
			CustomAbility found = Instance.Abilities.Find(i => i.Id == id);
			return found != null && DeleteAbility(found);
		}
		/// <summary>
		///   <para>Deletes the specified <paramref name="customAbility"/>.</para>
		/// </summary>
		public static bool DeleteAbility(CustomAbility customAbility)
		{
			DeleteItem(customAbility.Item);

			bool res = Instance.Abilities.Remove(customAbility);
			if (res) Instance.Logger.LogInfo("CustomItem " + customAbility.Id + " (" + customAbility.Name?.English + ") was deleted.");
			return res;
		}

	}
	internal struct RandomListInfo
	{
		public string name;
		public string category;
		public string objectType;

		public RandomListInfo(string n, string c, string o)
		{
			name = n;
			category = c;
			objectType = o;
		}
	}
}

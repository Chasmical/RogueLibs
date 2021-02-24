using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;

namespace RogueLibsCore
{
	public static class RogueLibs
	{
		public const string GUID = "abbysssal.streetsofrogue.roguelibs";
		public const string Name = "RogueLibs";
		public const string Version = "3.0";

		internal static RogueLibsPlugin Plugin { get; set; }
		internal static ManualLogSource Logger { get; set; }

		internal static readonly List<IHookFactory<InvItem>> InvItemFactories = new List<IHookFactory<InvItem>>();
		internal static readonly List<IHookFactory<Agent>> AgentFactories = new List<IHookFactory<Agent>>();
		internal static readonly List<IHookFactory<ObjectReal>> ObjectRealFactories = new List<IHookFactory<ObjectReal>>();
		internal static readonly List<IHookFactory<StatusEffect>> StatusEffectFactories = new List<IHookFactory<StatusEffect>>();
		internal static readonly List<IHookFactory<Trait>> TraitFactories = new List<IHookFactory<Trait>>();

		internal static readonly List<RogueSprite> CustomSprites = new List<RogueSprite>();
		internal static readonly Dictionary<string, List<CustomName>> CustomNames = new Dictionary<string, List<CustomName>>();

		internal static readonly List<UnlockWrapper> Unlocks = new List<UnlockWrapper>();

		internal static readonly Dictionary<string, Sprite> extraSprites = new Dictionary<string, Sprite>();

		public static ItemInfo AddCustomItem<T>()
			where T : CustomItem, new()
		{
			CustomItemFactory<T> factory = new CustomItemFactory<T>();
			InvItemFactories.Add(factory);
			return new ItemInfo(factory);
		}

		public static RogueSprite AddCustomSprite(string name, SpriteScope scope, byte[] rawData, float ppu = 64f)
		{
			if (string.IsNullOrEmpty(name)) throw new ArgumentException("Sprite's name cannot be null or empty!", nameof(name));
			if (rawData == null) throw new ArgumentNullException(nameof(rawData));
			RogueSprite sprite = new RogueSprite(name, scope, rawData, null, ppu);
			CustomSprites.Add(sprite);
			sprite.Define();
			return sprite;
		}
		public static RogueSprite AddCustomSprite(string name, SpriteScope scope, byte[] rawData, Rect region, float ppu = 64f)
		{
			if (string.IsNullOrEmpty(name)) throw new ArgumentException("Sprite's name cannot be null or empty!", nameof(name));
			if (rawData == null) throw new ArgumentNullException(nameof(rawData));
			RogueSprite sprite = new RogueSprite(name, scope, rawData, region, ppu);
			CustomSprites.Add(sprite);
			sprite.Define();
			return sprite;
		}

		public static CustomName AddCustomName(string name, string type, CustomNameInfo info)
		{
			if (!CustomNames.TryGetValue(type, out List<CustomName> category))
				CustomNames.Add(type, category = new List<CustomName>());
			CustomName customName = new CustomName(name, type, info);
			category.Add(customName);
			return customName;
		}

		public static void AddCustomUnlock(UnlockWrapper wrapper)
		{
			UnlockWrapper old = Unlocks.Find(w => w.Name == wrapper.Name && w.Type == wrapper.Type);
			if (old != null) Unlocks.Remove(old);
			Unlocks.Add(wrapper);
			if (GameController.gameController?.unlocks == null) return;
			RogueLibsPlugin.AddCustomUnlockFull(wrapper);
		}
		public static void AddCustomUnlock(UnlockWrapper unlock, CustomNameInfo name, CustomNameInfo description)
		{
			AddCustomUnlock(unlock);
			AddCustomName(unlock.Name, unlock.Unlock.unlockNameType, name);
			AddCustomName(unlock is MutatorUnlock ? "D_" + unlock.Name : unlock.Name, unlock.Unlock.unlockDescriptionType, description);
		}
		public class ItemInfo
		{
			public ItemInfo(ICustomItemFactory factory) => ItemFactory = factory;
			public ICustomItemFactory ItemFactory { get; }
			public CustomItemInfo Info { get; }
			public CustomName Name { get; private set; }
			public CustomName Description { get; private set; }
			public ItemUnlock Unlock { get; private set; }
			public RogueSprite Sprite { get; private set; }

			public ItemInfo WithSprite(byte[] rawData, float ppu = 64f)
			{
				Sprite = AddCustomSprite(ItemFactory.ItemInfo.Name, SpriteScope.Items, rawData, ppu);
				return this;
			}
			public ItemInfo WithSprite(byte[] rawData, Rect region, float ppu = 64f)
			{
				Sprite = AddCustomSprite(ItemFactory.ItemInfo.Name, SpriteScope.Items, rawData, region, ppu);
				return this;
			}
			public ItemInfo WithName(CustomNameInfo name)
			{
				Name = AddCustomName(ItemFactory.ItemInfo.Name, "Item", name);
				return this;
			}
			public ItemInfo WithName(CustomNameInfo name, CustomNameInfo description)
				=> WithName(name).WithDescription(description);
			public ItemInfo WithDescription(CustomNameInfo description)
			{
				Description = AddCustomName(ItemFactory.ItemInfo.Name, "Description", description);
				return this;
			}
			public ItemInfo WithUnlock()
			{
				Unlock = new ItemUnlock(ItemFactory.ItemInfo.Name, true);
				return this;
			}
			public ItemInfo WithUnlock(ItemUnlock unlock)
			{
				AddCustomUnlock(Unlock = unlock);
				return this;
			}
		}
	}
}

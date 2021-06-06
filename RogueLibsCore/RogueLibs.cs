using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using BepInEx.Logging;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para><b>Don't touch anything in here unless you're completely sure you know what you're doing.</b><br/>Internal RogueLibs collections and properties.</para>
	/// </summary>
	public static class RogueLibsInternals
	{
		/// <summary>
		///   <para>RogueLibs plugin instance.</para>
		/// </summary>
		public static RogueLibsPlugin Plugin { get; internal set; }
		/// <summary>
		///   <para>RogueLibs' logger.</para>
		/// </summary>
		public static ManualLogSource Logger { get; internal set; }

		public static readonly CustomItemFactory CustomItemFactory = new CustomItemFactory();
		/// <summary>
		///   <para>Collection of initialized <see cref="IHookFactory{T}"/> for <see cref="InvItem"/>s.</para>
		/// </summary>
		public static readonly List<IHookFactory<InvItem>> InvItemFactories = new List<IHookFactory<InvItem>> { CustomItemFactory };

		/// <summary>
		///   <para>Collection of initialized <see cref="IHookFactory{T}"/> for <see cref="Agent"/>s.</para>
		/// </summary>
		public static readonly List<IHookFactory<Agent>> AgentFactories = new List<IHookFactory<Agent>>();

		/// <summary>
		///   <para>Collection of initialized <see cref="IHookFactory{T}"/> for <see cref="ObjectReal"/>s.</para>
		/// </summary>
		public static readonly List<IHookFactory<ObjectReal>> ObjectRealFactories = new List<IHookFactory<ObjectReal>>();

		public static readonly CustomEffectFactory CustomEffectFactory = new CustomEffectFactory();
		/// <summary>
		///   <para>Collection of initialized <see cref="IHookFactory{T}"/> for <see cref="StatusEffect"/>s.</para>
		/// </summary>
		public static readonly List<IHookFactory<StatusEffect>> EffectFactories = new List<IHookFactory<StatusEffect>> { CustomEffectFactory };

		public static readonly CustomTraitFactory CustomTraitFactory = new CustomTraitFactory();
		/// <summary>
		///   <para>Collection of initialized <see cref="IHookFactory{T}"/> for <see cref="Trait"/>s.</para>
		/// </summary>
		public static readonly List<IHookFactory<Trait>> TraitFactories = new List<IHookFactory<Trait>> { CustomTraitFactory };

		/// <summary>
		///   <para>Collection of initialized <see cref="CustomName"/>s.</para>
		/// </summary>
		public static readonly Dictionary<string, Dictionary<string, ICustomName>> CustomNames = new Dictionary<string, Dictionary<string, ICustomName>>();

		/// <summary>
		///   <para>Collection of initialized <see cref="UnlockWrapper"/>s (both custom and original unlocks).</para>
		/// </summary>
		public static readonly List<UnlockWrapper> Unlocks = new List<UnlockWrapper>();
		internal static readonly List<UnlockWrapper> CustomUnlocks = new List<UnlockWrapper>();

		/// <summary>
		///   <para><b>Usage of this feature is not recommended.</b><br/>Collection of extra sprites, that will be used if a sprite in the appropriate collection is not found.</para>
		/// </summary>
		public static readonly Dictionary<string, Sprite> ExtraSprites = new Dictionary<string, Sprite>();
	}
	/// <summary>
	///   <para>RogueLibs' core class.</para>
	/// </summary>
	public static class RogueLibs
	{
		/// <summary>
		///   <para>The RogueLibs' GUID (Globally Unique ID). Use it in your mod's <see cref="BepInEx.BepInDependency"/> attribute.</para>
		/// </summary>
		public const string GUID = "abbysssal.streetsofrogue.roguelibs";
		/// <summary>
		///   <para>The RogueLibs' human-readable name.</para>
		/// </summary>
		public const string Name = "RogueLibs";
		/// <summary>
		///   <para>Version of RogueLibs that is currently in use.</para>
		/// </summary>
		public static string Version => "3.0";
		/// <summary>
		///   <para>Version of RogueLibs that the current mod was compiled with.</para>
		/// </summary>
		public const string CompiledVersion = "3.0";

		/// <summary>
		///   <para>Adds the specified <typeparamref name="TItem"/> type to the game and returns <see cref="ItemBuilder"/> with it.</para>
		/// </summary>
		/// <typeparam name="TItem">Type of the <see cref="CustomItem"/> to add.</typeparam>
		/// <returns><see cref="ItemBuilder"/> for the created <typeparamref name="TItem"/>.</returns>
		public static ItemBuilder CreateCustomItem<TItem>()
			where TItem : CustomItem, new()
		{
			ItemInfo info = RogueLibsInternals.CustomItemFactory.AddItem<TItem>();
			return new ItemBuilder(info);
		}
		/// <summary>
		///   <para>Adds the specified <typeparamref name="TTrait"/> type to the game and returns <see cref="TraitBuilder"/> with it.</para>
		/// </summary>
		/// <typeparam name="TTrait">Type of the <see cref="CustomTrait"/> to add.</typeparam>
		/// <returns><see cref="TraitBuilder"/> for the created <typeparamref name="TTrait"/>.</returns>
		public static TraitBuilder CreateCustomTrait<TTrait>()
			where TTrait : CustomTrait, new()
		{
			TraitInfo info = RogueLibsInternals.CustomTraitFactory.AddTrait<TTrait>();
			return new TraitBuilder(info);
		}
		/// <summary>
		///   <para>Adds the specified <typeparamref name="TEffect"/> type to the game and returns <see cref="EffectBuilder"/> with it.</para>
		/// </summary>
		/// <typeparam name="TEffect">Type of the <see cref="CustomEffect"/> to add.</typeparam>
		/// <returns><see cref="EffectBuilder"/> for the created <typeparamref name="TEffect"/>.</returns>
		public static EffectBuilder CreateCustomEffect<TEffect>()
			where TEffect : CustomEffect, new()
		{
			EffectInfo info = RogueLibsInternals.CustomEffectFactory.AddEffect<TEffect>();
			return new EffectBuilder(info);
		}

		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> from the provided data and defines it as soon as possible.</para>
		/// </summary>
		/// <param name="name">Name/id of the sprite.</param>
		/// <param name="scope">Scope that the sprite is going to be used in.</param>
		/// <param name="rawData">PNG- or JPEG-encoded image.</param>
		/// <param name="ppu">Pixels-per-unit.</param>
		/// <returns>Created <see cref="RogueSprite"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public static RogueSprite CreateCustomSprite(string name, SpriteScope scope, byte[] rawData, float ppu = 64f)
		{
			if (name is null) throw new ArgumentNullException(nameof(name));
			if (rawData is null) throw new ArgumentNullException(nameof(rawData));
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			RogueSprite sprite = new RogueSprite(name, scope, rawData, null, ppu);
			sprite.Define();
			return sprite;
		}
		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> from the provided data and defines it as soon as possible.</para>
		/// </summary>
		/// <param name="name">Name/id of the sprite.</param>
		/// <param name="scope">Scope that the sprite is going to be used in.</param>
		/// <param name="rawData">PNG- or JPEG-encoded image.</param>
		/// <param name="region">Region of the texture to use.</param>
		/// <param name="ppu">Pixels-per-unit.</param>
		/// <returns>Created <see cref="RogueSprite"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public static RogueSprite CreateCustomSprite(string name, SpriteScope scope, byte[] rawData, Rect region, float ppu = 64f)
		{
			if (name is null) throw new ArgumentNullException(nameof(name));
			if (rawData is null) throw new ArgumentNullException(nameof(rawData));
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			RogueSprite sprite = new RogueSprite(name, scope, rawData, region, ppu);
			sprite.Define();
			return sprite;
		}

		/// <summary>
		///   <para>Creates a <see cref="CustomName"/> with the specified <paramref name="name"/> and <paramref name="type"/> and fills it with the translations from the specified <paramref name="info"/>.</para>
		/// </summary>
		/// <param name="name">Name/id of the custom name.</param>
		/// <param name="type">Type of the custom name.</param>
		/// <param name="info">Translations for different languages.</param>
		/// <returns>Created <see cref="CustomName"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="type"/> is <see langword="null"/>.</exception>
		public static CustomName CreateCustomName(string name, string type, CustomNameInfo info)
		{
			if (name is null) throw new ArgumentNullException(nameof(name));
			if (type is null) throw new ArgumentNullException(nameof(type));
			if (!RogueLibsInternals.CustomNames.TryGetValue(type, out Dictionary<string, ICustomName> category))
				RogueLibsInternals.CustomNames.Add(type, category = new Dictionary<string, ICustomName>());
			CustomName customName = new CustomName(name, type, info);
			category.Add(name, customName);
			return customName;
		}

		/// <summary>
		///   <para>Initializes the specified <paramref name="unlock"/> and adds it to the game.</para>
		/// </summary>
		/// <param name="unlock"><see cref="UnlockWrapper"/> to initialize.</param>
		/// <exception cref="ArgumentNullException"><paramref name="unlock"/> is <see langword="null"/>.</exception>
		public static void CreateCustomUnlock(UnlockWrapper unlock)
		{
			if (unlock is null) throw new ArgumentNullException(nameof(unlock));
			RogueLibsInternals.Unlocks.Add(unlock);
			RogueLibsInternals.CustomUnlocks.Add(unlock);
			if (GameController.gameController?.unlocks is null) return;
			RogueLibsPlugin.AddUnlockFull(unlock);
		}
		/// <summary>
		///   <para>Initializes the specified <paramref name="unlock"/> and adds it to the game and creates <paramref name="name"/> and <paramref name="description"/> custom names, associated with it.</para>
		/// </summary>
		/// <param name="unlock"><see cref="UnlockWrapper"/> to initialize.</param>
		/// <param name="name">Name of the custom unlock.</param>
		/// <param name="description">Description of the custom unlock.</param>
		/// <exception cref="ArgumentNullException"><paramref name="unlock"/> is <see langword="null"/>.</exception>
		public static void CreateCustomUnlock(UnlockWrapper unlock, CustomNameInfo name, CustomNameInfo description)
		{
			CreateCustomUnlock(unlock);
			CreateCustomName(unlock.Name, unlock.Unlock.unlockNameType, name);
			CreateCustomName(unlock is MutatorUnlock || unlock is BigQuestUnlock ? "D_" + unlock.Name : unlock.Name,
				unlock is BigQuestUnlock ? "Unlock" : unlock.Unlock.unlockDescriptionType, description);
		}

		/// <summary>
		///   <para>Returns an <see cref="UnlockWrapper"/>, attached to the unlock with the specified <paramref name="name"/> and <paramref name="type"/>.</para>
		/// </summary>
		/// <param name="name">Name/id of the unlock.</param>
		/// <param name="type">Type of the unlock.</param>
		/// <returns><see cref="UnlockWrapper"/>, attached to the unlock with the specified <paramref name="name"/> and <paramref name="type"/>.</returns>
		public static UnlockWrapper GetUnlock(string name, string type) => RogueLibsInternals.Unlocks.Find(u => u.Name == name && u.Type == type);
		/// <summary>
		///   <para>Returns an <see cref="UnlockWrapper"/> of the specified <typeparamref name="TUnlock"/> type, attached to the unlock with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <typeparam name="TUnlock">Type of the <see cref="UnlockWrapper"/>.</typeparam>
		/// <param name="name">Name/id of the unlock.</param>
		/// <returns><typeparamref name="TUnlock"/>, attached to the unlock with the specified <paramref name="name"/>.</returns>
		public static TUnlock GetUnlock<TUnlock>(string name) where TUnlock : UnlockWrapper => (TUnlock)RogueLibsInternals.Unlocks.Find(u => u is TUnlock && u.Name == name);
	}
	/// <summary>
	///   <para>Helper class, that provides methods for defining additional data about a custom item.</para>
	/// </summary>
	public class ItemBuilder
	{
		/// <summary>
		///   <para>Initializes a new instance of <see cref="ItemBuilder"/> class with the specified <paramref name="info"/>.</para>
		/// </summary>
		/// <param name="info">The custom item information.</param>
		public ItemBuilder(ItemInfo info) => Info = info;
		/// <summary>
		///   <para>Gets the default information about the current item, specified in the type's attributes.</para>
		/// </summary>
		public ItemInfo Info { get; }

		/// <summary>
		///   <para>Gets the name of the current item.</para>
		/// </summary>
		public CustomName Name { get; private set; }
		/// <summary>
		///   <para>Gets the description of the current item.</para>
		/// </summary>
		public CustomName Description { get; private set; }
		/// <summary>
		///   <para>Gets the custom unlock of the current item.</para>
		/// </summary>
		public ItemUnlock Unlock { get; private set; }
		/// <summary>
		///   <para>Gets the custom sprite of the current item.</para>
		/// </summary>
		public RogueSprite Sprite { get; private set; }

		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> from the specified <paramref name="rawData"/> and with the specified <paramref name="ppu"/> and attaches it to the current item.</para>
		/// </summary>
		/// <param name="rawData">PNG- pr JPEG-encoded image.</param>
		/// <param name="ppu">Pixels-per-unit.</param>
		/// <returns>The current instance of <see cref="ItemBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public ItemBuilder WithSprite(byte[] rawData, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Items, rawData, ppu);
			return this;
		}
		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> from the specified <paramref name="rawData"/> and <paramref name="region"/> and with the specified <paramref name="ppu"/> and attaches it to the current item.</para>
		/// </summary>
		/// <param name="rawData">PNG- pr JPEG-encoded image.</param>
		/// <param name="region">Region of the texture to use.</param>
		/// <param name="ppu">Pixels-per-unit.</param>
		/// <returns>The current instance of <see cref="ItemBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public ItemBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Items, rawData, region, ppu);
			return this;
		}
		/// <summary>
		///   <para>Creates a <see cref="CustomName"/> from the specified <paramref name="name"/> translations and attaches it to the current item.</para>
		/// </summary>
		/// <param name="name">Translations of the item's name.</param>
		/// <returns>The current instance of <see cref="ItemBuilder"/>, for chaining purposes.</returns>
		public ItemBuilder WithName(CustomNameInfo name)
		{
			Name = RogueLibs.CreateCustomName(Info.Name, "Item", name);
			return this;
		}
		/// <summary>
		///   <para>Creates a <see cref="CustomName"/> from the specified <paramref name="description"/> translations and attaches it to the current item.</para>
		/// </summary>
		/// <param name="description">Translations of the item's description.</param>
		/// <returns>The current instance of <see cref="ItemInfo"/>, for chaining purposes.</returns>
		public ItemBuilder WithDescription(CustomNameInfo description)
		{
			Description = RogueLibs.CreateCustomName(Info.Name, "Description", description);
			return this;
		}
		/// <summary>
		///   <para>Initializes a default <see cref="ItemUnlock"/> for the current item. Unlocked by default.</para>
		/// </summary>
		/// <returns>The current instance of <see cref="ItemBuilder"/>, for chaining purposes.</returns>
		public ItemBuilder WithUnlock() => WithUnlock(new ItemUnlock(Info.Name, true));
		/// <summary>
		///   <para>Initializes the specified <paramref name="unlock"/> for the current item.</para>
		/// </summary>
		/// <param name="unlock"><see cref="ItemUnlock"/> for the current item.</param>
		/// <returns>The current instance of <see cref="ItemBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="unlock"/> is <see langword="null"/>.</exception>
		public ItemBuilder WithUnlock(ItemUnlock unlock)
		{
			unlock.Name = Info.Name;
			RogueLibs.CreateCustomUnlock(unlock);
			Unlock = unlock;
			return this;
		}
	}
	public class TraitBuilder
	{
		public TraitBuilder(TraitInfo info) => Info = info;
		public TraitInfo Info { get; }

		public CustomName Name { get; private set; }
		public CustomName Description { get; private set; }
		public TraitUnlock Unlock { get; private set; }
		public RogueSprite Sprite { get; private set; }

		public TraitBuilder WithSprite(byte[] rawData, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Extra, rawData, ppu);
			return this;
		}
		public TraitBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Extra, rawData, region, ppu);
			return this;
		}
		public TraitBuilder WithName(CustomNameInfo name)
		{
			Name = RogueLibs.CreateCustomName(Info.Name, "StatusEffect", name);
			return this;
		}
		public TraitBuilder WithDescription(CustomNameInfo description)
		{
			Description = RogueLibs.CreateCustomName(Info.Name, "Description", description);
			return this;
		}
		public TraitBuilder WithUnlock() => WithUnlock(new TraitUnlock(Info.Name, true));
		public TraitBuilder WithUnlock(TraitUnlock unlock)
		{
			unlock.Name = Info.Name;
			RogueLibs.CreateCustomUnlock(unlock);
			Unlock = unlock;
			return this;
		}
	}
	public class EffectBuilder
	{
		public EffectBuilder(EffectInfo info) => Info = info;
		public EffectInfo Info { get; }

		public CustomName Name { get; private set; }
		public CustomName Description { get; private set; }
		public RogueSprite Sprite { get; private set; }

		public EffectBuilder WithSprite(byte[] rawData, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Extra, rawData, ppu);
			return this;
		}
		public EffectBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Extra, rawData, region, ppu);
			return this;
		}
		public EffectBuilder WithName(CustomNameInfo name)
		{
			Name = RogueLibs.CreateCustomName(Info.Name, "StatusEffect", name);
			return this;
		}
		public EffectBuilder WithDescription(CustomNameInfo description)
		{
			Description = RogueLibs.CreateCustomName(Info.Name, "Description", description);
			return this;
		}
	}
}

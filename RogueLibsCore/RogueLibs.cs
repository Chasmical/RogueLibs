using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;
using UnityEngine;
using System.IO;
using System.Threading;
using UnityEngine.Networking;
using BepInEx;
using JetBrains.Annotations;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Main RogueLibs class, that is used to initialize custom content.</para>
	/// </summary>
	public static class RogueLibs
	{
		static RogueLibs()
		{
			RogueFramework.ItemFactories.Add(ItemFactory);
			RogueFramework.TraitFactories.Add(TraitFactory);
			RogueFramework.EffectFactories.Add(EffectFactory);
			RogueFramework.NameProviders.Add(NameProvider);
			RogueFramework.NameProviders.Add(new DialogueNameProvider());
		}

		/// <summary>
		///   <para>RogueLibs' GUID.</para>
		/// </summary>
		public const string GUID = "abbysssal.streetsofrogue.roguelibscore";
		/// <summary>
		///   <para>RogueLibs' Name.</para>
		/// </summary>
		public const string Name = "RogueLibsCore";

		internal const string AssemblyVersion = "3.1.0.0";
		/// <summary>
		///   <para>Version of RogueLibs that the current assembly is compiled with.</para>
		/// </summary>
		public const string CompiledVersion = "3.1.0";
		/// <summary>
		///   <para>Semantic version of RogueLibs that the current assembly is compiled with. Don't use it in BepInPlugin.</para>
		/// </summary>
		public const string CompiledSemanticVersion = "3.1.0";

		/// <summary>
		///   <para>Currently installed and running version of RogueLibs.</para>
		/// </summary>
		public static string Version { [MethodImpl(MethodImplOptions.NoInlining)] get => CompiledVersion; }
		/// <summary>
		///   <para>Currently installed and running semantic version of RogueLibs.</para>
		/// </summary>
		public static string SemanticVersion { [MethodImpl(MethodImplOptions.NoInlining)] get => CompiledSemanticVersion; }

		private static readonly CustomItemFactory ItemFactory = new CustomItemFactory();
		private static readonly CustomTraitFactory TraitFactory = new CustomTraitFactory();
		private static readonly CustomEffectFactory EffectFactory = new CustomEffectFactory();
		private static readonly CustomNameProvider NameProvider = new CustomNameProvider();

		/// <summary>
		///   <para>Creates a <typeparamref name="TItem"/> custom item. Chain "With" methods to attach extra information.</para>
		/// </summary>
		/// <typeparam name="TItem">The <see cref="CustomItem"/> type. Must have a parameterless constructor.</typeparam>
		/// <returns>An <see cref="ItemBuilder"/> with the specified item's metadata.</returns>
		public static ItemBuilder CreateCustomItem<TItem>() where TItem : CustomItem, new()
		{
			if (typeof(CustomAbility).IsAssignableFrom(typeof(TItem)))
				throw new ArgumentException($"The specified type is a CustomAbility! Use {nameof(CreateCustomAbility)} instead.", nameof(TItem));
			ItemInfo info = ItemFactory.AddItem<TItem>();
			return new ItemBuilder(info);
		}
		/// <summary>
		///   <para>Creates a <typeparamref name="TAbility"/> custom ability. Chain "With" methods to attach extra information.</para>
		/// </summary>
		/// <typeparam name="TAbility">The <see cref="CustomAbility"/> type. Must have a parameterless constructor.</typeparam>
		/// <returns>An <see cref="AbilityBuilder"/> with the specified ability's metadata.</returns>
		public static AbilityBuilder CreateCustomAbility<TAbility>() where TAbility : CustomAbility, new()
		{
			ItemInfo info = ItemFactory.AddItem<TAbility>();
			return new AbilityBuilder(info);
		}
		/// <summary>
		///   <para>Creates a <typeparamref name="TTrait"/> custom trait. Chain "With" methods to attach extra information.</para>
		/// </summary>
		/// <typeparam name="TTrait">The <see cref="CustomTrait"/> type. Must have a parameterless constructor.</typeparam>
		/// <returns>An <see cref="TraitBuilder"/> with the specified trait's metadata.</returns>
		public static TraitBuilder CreateCustomTrait<TTrait>() where TTrait : CustomTrait, new()
		{
			TraitInfo info = TraitFactory.AddTrait<TTrait>();
			return new TraitBuilder(info);
		}
		/// <summary>
		///   <para>Creates a <typeparamref name="TEffect"/> custom effect. Chain "With" methods to attach extra information.</para>
		/// </summary>
		/// <typeparam name="TEffect">The <see cref="CustomEffect"/> type. Must have a parameterless constructor.</typeparam>
		/// <returns>An <see cref="EffectBuilder"/> with the specified effect's metadata.</returns>
		public static EffectBuilder CreateCustomEffect<TEffect>() where TEffect : CustomEffect, new()
		{
			EffectInfo info = EffectFactory.AddEffect<TEffect>();
			return new EffectBuilder(info);
		}

		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> with the specified <paramref name="name"/>, <paramref name="scope"/>, with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/>.</para>
		/// </summary>
		/// <param name="name">The custom sprite's name.</param>
		/// <param name="scope">The custom sprite's scope.</param>
		/// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
		/// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
		/// <returns>The created <see cref="RogueSprite"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public static RogueSprite CreateCustomSprite(string name, SpriteScope scope, byte[] rawData, float ppu = 64f)
		{
			if (name is null || rawData is null) throw new ArgumentNullException(name is null ? nameof(name) : nameof(rawData));
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} is less than or equal to 0.");
			RogueSprite sprite = new RogueSprite(name, scope, rawData, null, ppu);
			sprite.Define();
			return sprite;
		}
		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> with the specified <paramref name="name"/>, <paramref name="scope"/>, with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/>.</para>
		/// </summary>
		/// <param name="name">The custom sprite's name.</param>
		/// <param name="scope">The custom sprite's scope.</param>
		/// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
		/// <param name="region">The region of the texture for the sprite to use.</param>
		/// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
		/// <returns>The created <see cref="RogueSprite"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public static RogueSprite CreateCustomSprite(string name, SpriteScope scope, byte[] rawData, Rect region, float ppu = 64f)
		{
			if (name is null || rawData is null) throw new ArgumentNullException(name is null ? nameof(name) : nameof(rawData));
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} is less than or equal to 0.");
			RogueSprite sprite = new RogueSprite(name, scope, rawData, region, ppu);
			sprite.Define();
			return sprite;
		}

		/// <summary>
		///   <para>Creates a custom <see cref="AudioClip"/> from <paramref name="rawData"/> using the specified audio <paramref name="format"/> and adds it to the game under the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">The custom audioclip's name.</param>
		/// <param name="rawData">The byte array containing a raw audio file.</param>
		/// <param name="format">The audio file's format.</param>
		/// <returns>The created <see cref="AudioClip"/>.</returns>
		/// <exception cref="IOException">An I/O error occured while opening the file.</exception>
		/// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
		/// <exception cref="NotSupportedException">The specified <paramref name="format"/> is not supported.</exception>
		/// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
		public static AudioClip CreateCustomAudio(string name, byte[] rawData, AudioType format)
		{
			AudioClip clip = RogueUtilities.ConvertToAudioClip(rawData, format);
			clip.name = name;
			if (GameController.gameController?.audioHandler != null)
			{
				GameController.gameController.audioHandler.audioClipList.Add(name);
				GameController.gameController.audioHandler.audioClipRealList.Add(clip);
				GameController.gameController.audioHandler.audioClipDic.Add(name, clip);
			}
			else RogueLibsPlugin.preparedClips.Add(clip);
			return clip;
		}

		/// <summary>
		///   <para>Creates a localizable string with the specified <paramref name="name"/>, <paramref name="type"/> and localization <paramref name="info"/>.</para>
		/// </summary>
		/// <param name="name">The name of the localizable string to create.</param>
		/// <param name="type">The type of the localizable string to create.</param>
		/// <param name="info">The localization data to initialize the localizable string with.</param>
		/// <returns>The created <see cref="CustomName"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="type"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentException">A localizable string with the specified <paramref name="name"/> and <paramref name="type"/> already exists in the <see cref="CustomNameProvider"/>'s dictionary.</exception>
		public static CustomName CreateCustomName(string name, string type, CustomNameInfo info)
			=> NameProvider.AddName(name, type, info);

		/// <summary>
		///   <para>Integrates the specified <paramref name="unlock"/> into the game.</para>
		/// </summary>
		/// <param name="unlock">The unlock to integrate into the game.</param>
		/// <exception cref="ArgumentNullException"><paramref name="unlock"/> is <see langword="null"/>.</exception>
		public static UnlockBuilder CreateCustomUnlock(UnlockWrapper unlock)
		{
			if (unlock is null) throw new ArgumentNullException(nameof(unlock));
			RogueFramework.Unlocks.Add(unlock);
			RogueFramework.CustomUnlocks.Add(unlock);
			if (GameController.gameController?.unlocks != null)
				RogueLibsPlugin.AddUnlockFull(unlock);
			return new UnlockBuilder(unlock);
		}

		/// <summary>
		///   <para>Gets an unlock with the specified <paramref name="name"/> and <paramref name="type"/>.</para>
		/// </summary>
		/// <param name="name">The name of the unlock to search for.</param>
		/// <param name="type">The type of the unlock to search for.</param>
		/// <returns>The unlock with the specified <paramref name="name"/> and <paramref name="type"/>, if found; otherwise, <see langword="null"/>.</returns>
		public static UnlockWrapper GetUnlock(string name, string type)
			=> RogueFramework.Unlocks.Find(u => u.Name == name && u.Type == type);
		/// <summary>
		///   <para>Gets an unlock of the specified <typeparamref name="TUnlock"/> type and with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <typeparam name="TUnlock">The type of the unlock to search for.</typeparam>
		/// <param name="name">The name of the unlock to search for.</param>
		/// <returns>The unlock of the specified <typeparamref name="TUnlock"/> type and with the specified <paramref name="name"/>, if found; otherwise, <see langword="null"/>.</returns>
		public static TUnlock GetUnlock<TUnlock>(string name) where TUnlock : UnlockWrapper
			=> (TUnlock)RogueFramework.Unlocks.Find(u => u is TUnlock && u.Name == name);

		/// <summary>
		///   <para>Invokes all static methods marked with a <see cref="RLSetupAttribute"/> in the current assembly.</para>
		/// </summary>
		public static void LoadFromAssembly()
		{
			MethodBase caller = new StackTrace().GetFrame(1).GetMethod();
			Assembly assembly = caller.ReflectedType.Assembly;
			foreach (Type type in assembly.GetTypes())
				foreach (MethodInfo method in type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
				{
					if (method.GetCustomAttributes<RLSetupAttribute>().Any())
					{
						if (method.GetParameters().Length != 0)
						{
							RogueFramework.LogError($"{assembly.FullName}: Methods marked with [RLSetup] cannot have any parameters!");
							continue;
						}
						if (!method.IsStatic)
						{
							RogueFramework.LogError($"{assembly.FullName}: Methods marked with [RLSetup] must be static!");
							ConstructorInfo ctor = method.DeclaringType.GetConstructor(new Type[0]);
							if (ctor != null)
							{
								object instance = ctor.Invoke(null);
								try { method.Invoke(instance, null); }
								catch (Exception e) { RogueFramework.LogError(e.ToString()); }
								RogueFramework.LogWarning($"The issue was temporarily resolved by creating an instance of {method.DeclaringType} type.");
							}
							continue;
						}
						try { method.Invoke(null, null); }
						catch (Exception e) { RogueFramework.LogError(e.ToString()); }
					}
				}
		}
	}
	/// <summary>
	///   <para>Indicates that this method should be executed when <see cref="RogueLibs.LoadFromAssembly()"/> is called.</para>
	/// </summary>
	[MeansImplicitUse]
	[AttributeUsage(AttributeTargets.Method)]
	public class RLSetupAttribute : Attribute { }
	/// <summary>
	///   <para>Repesents a <see cref="CustomItem"/> builder, that attaches additional information to the item.</para>
	/// </summary>
	public class ItemBuilder
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="ItemBuilder"/> class with the specified <paramref name="info"/>.</para>
		/// </summary>
		/// <param name="info">The item metadata to use.</param>
		public ItemBuilder(ItemInfo info) => Info = info;
		/// <summary>
		///   <para>The used item metadata.</para>
		/// </summary>
		public ItemInfo Info { get; }

		/// <summary>
		///   <para>Gets the item's localizable name.</para>
		/// </summary>
		public CustomName Name { get; private set; }
		/// <summary>
		///   <para>Gets the item's localizable description.</para>
		/// </summary>
		public CustomName Description { get; private set; }
		/// <summary>
		///   <para>Gets the item's sprite.</para>
		/// </summary>
		public RogueSprite Sprite { get; private set; }
		/// <summary>
		///   <para>Gets the item's unlock.</para>
		/// </summary>
		public ItemUnlock Unlock { get; private set; }

		/// <summary>
		///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the item's name.</para>
		/// </summary>
		/// <param name="info">The localization data to initialize the localizable string with.</param>
		/// <returns>The current instance of <see cref="ItemBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentException">A localizable string that acts as the item's name already exists.</exception>
		public ItemBuilder WithName(CustomNameInfo info)
		{
			Name = RogueLibs.CreateCustomName(Info.Name, NameTypes.Item, info);
			return this;
		}
		/// <summary>
		///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the item's description.</para>
		/// </summary>
		/// <param name="info">The localization data to initialize the localizable string with.</param>
		/// <returns>The current instance of <see cref="ItemBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentException">A localizable string that acts as the item's description already exists.</exception>
		public ItemBuilder WithDescription(CustomNameInfo info)
		{
			Description = RogueLibs.CreateCustomName(Info.Name, NameTypes.Description, info);
			return this;
		}
		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the item's sprite.</para>
		/// </summary>
		/// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
		/// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
		/// <returns>The current instance of <see cref="ItemBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public ItemBuilder WithSprite(byte[] rawData, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Items, rawData, ppu);
			return this;
		}
		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the item's sprite.</para>
		/// </summary>
		/// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
		/// <param name="region">The region of the texture for the sprite to use.</param>
		/// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
		/// <returns>The current instance of <see cref="ItemBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public ItemBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Items, rawData, region, ppu);
			return this;
		}
		/// <summary>
		///   <para>Creates a default <see cref="ItemUnlock"/> for the item, that is unlocked by default.</para>
		/// </summary>
		/// <returns>The current instance of <see cref="ItemBuilder"/>, for chaining purposes.</returns>
		public ItemBuilder WithUnlock() => WithUnlock(new ItemUnlock(Info.Name, true));
		/// <summary>
		///   <para>Creates the specified <paramref name="unlock"/> for the item.</para>
		/// </summary>
		/// <param name="unlock">The unlock information to initialize.</param>
		/// <returns>The current instance of <see cref="ItemBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="unlock"/> is <see langword="null"/>.</exception>
		public ItemBuilder WithUnlock(ItemUnlock unlock)
		{
			if (unlock is null) throw new ArgumentNullException(nameof(unlock));
			unlock.Name = Info.Name;
			RogueLibs.CreateCustomUnlock(unlock);
			Unlock = unlock;
			return this;
		}
	}
	/// <summary>
	///   <para>Represents a <see cref="CustomAbility"/> builder, that attaches additional information to the ability.</para>
	/// </summary>
	public class AbilityBuilder
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="ItemBuilder"/> class with the specified <paramref name="info"/>.</para>
		/// </summary>
		/// <param name="info">The item metadata to use.</param>
		public AbilityBuilder(ItemInfo info) => Info = info;
		/// <summary>
		///   <para>The used item metadata.</para>
		/// </summary>
		public ItemInfo Info { get; }

		/// <summary>
		///   <para>Gets the ability's localizable name.</para>
		/// </summary>
		public CustomName Name { get; private set; }
		/// <summary>
		///   <para>Gets the ability's localizable description.</para>
		/// </summary>
		public CustomName Description { get; private set; }
		/// <summary>
		///   <para>Gets the ability's sprite.</para>
		/// </summary>
		public RogueSprite Sprite { get; private set; }
		/// <summary>
		///   <para>Gets the ability's unlock.</para>
		/// </summary>
		public AbilityUnlock Unlock { get; private set; }

		/// <summary>
		///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the ability's name.</para>
		/// </summary>
		/// <param name="info">The localization data to initialize the localizable string with.</param>
		/// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentException">A localizable string that acts as the ability's name already exists.</exception>
		public AbilityBuilder WithName(CustomNameInfo info)
		{
			Name = RogueLibs.CreateCustomName(Info.Name, NameTypes.Item, info);
			return this;
		}
		/// <summary>
		///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the ability's description.</para>
		/// </summary>
		/// <param name="info">The localization data to initialize the localizable string with.</param>
		/// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentException">A localizable string that acts as the ability's description already exists.</exception>
		public AbilityBuilder WithDescription(CustomNameInfo info)
		{
			Description = RogueLibs.CreateCustomName(Info.Name, NameTypes.Description, info);
			return this;
		}
		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the ability's sprite.</para>
		/// </summary>
		/// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
		/// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
		/// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public AbilityBuilder WithSprite(byte[] rawData, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Items, rawData, ppu);
			return this;
		}
		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the ability's sprite.</para>
		/// </summary>
		/// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
		/// <param name="region">The region of the texture for the sprite to use.</param>
		/// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
		/// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public AbilityBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Items, rawData, region, ppu);
			return this;
		}
		/// <summary>
		///   <para>Creates a default <see cref="AbilityUnlock"/> for the ability, that is unlocked by default.</para>
		/// </summary>
		/// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
		public AbilityBuilder WithUnlock() => WithUnlock(new AbilityUnlock(Info.Name, true));
		/// <summary>
		///   <para>Creates the specified <paramref name="unlock"/> for the ability.</para>
		/// </summary>
		/// <param name="unlock">The unlock information to initialize.</param>
		/// <returns>The current instance of <see cref="AbilityBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="unlock"/> is <see langword="null"/>.</exception>
		public AbilityBuilder WithUnlock(AbilityUnlock unlock)
		{
			if (unlock is null) throw new ArgumentNullException(nameof(unlock));
			unlock.Name = Info.Name;
			RogueLibs.CreateCustomUnlock(unlock);
			Unlock = unlock;
			return this;
		}
	}
	/// <summary>
	///   <para>Represents a <see cref="CustomTrait"/> builder, that attaches additional information to the trait.</para>
	/// </summary>
	public class TraitBuilder
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="TraitBuilder"/> class with the specified <paramref name="info"/>.</para>
		/// </summary>
		/// <param name="info">The trait metadata to use.</param>
		public TraitBuilder(TraitInfo info) => Info = info;
		/// <summary>
		///   <para>The used trait metadata.</para>
		/// </summary>
		public TraitInfo Info { get; }

		/// <summary>
		///   <para>Gets the trait's localizable name.</para>
		/// </summary>
		public CustomName Name { get; private set; }
		/// <summary>
		///   <para>Gets the trait's localizable description.</para>
		/// </summary>
		public CustomName Description { get; private set; }
		/// <summary>
		///   <para>Gets the trait's sprite.</para>
		/// </summary>
		public RogueSprite Sprite { get; private set; }
		/// <summary>
		///   <para>Gets the trait's unlock.</para>
		/// </summary>
		public TraitUnlock Unlock { get; private set; }

		/// <summary>
		///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the trait's name.</para>
		/// </summary>
		/// <param name="info">The localization data to initialize the localizable string with.</param>
		/// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentException">A localizable string that acts as the trait's name already exists.</exception>
		public TraitBuilder WithName(CustomNameInfo info)
		{
			Name = RogueLibs.CreateCustomName(Info.Name, NameTypes.StatusEffect, info);
			return this;
		}
		/// <summary>
		///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the trait's description.</para>
		/// </summary>
		/// <param name="info">The localization data to initialize the localizable string with.</param>
		/// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentException">A localizable string that acts as the trait's description already exists.</exception>
		public TraitBuilder WithDescription(CustomNameInfo info)
		{
			Description = RogueLibs.CreateCustomName(Info.Name, NameTypes.Description, info);
			return this;
		}
		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the trait's sprite.</para>
		/// </summary>
		/// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
		/// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
		/// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public TraitBuilder WithSprite(byte[] rawData, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Extra, rawData, ppu);
			return this;
		}
		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the trait's sprite.</para>
		/// </summary>
		/// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
		/// <param name="region">The region of the texture for the sprite to use.</param>
		/// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
		/// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public TraitBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Extra, rawData, region, ppu);
			return this;
		}
		/// <summary>
		///   <para>Creates a default <see cref="TraitUnlock"/> for the trait, that is unlocked by default.</para>
		/// </summary>
		/// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
		public TraitBuilder WithUnlock() => WithUnlock(new TraitUnlock(Info.Name, true));
		/// <summary>
		///   <para>Creates the specified <paramref name="unlock"/> for the trait.</para>
		/// </summary>
		/// <param name="unlock">The unlock information to initialize.</param>
		/// <returns>The current instance of <see cref="TraitBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="unlock"/> is <see langword="null"/>.</exception>
		public TraitBuilder WithUnlock(TraitUnlock unlock)
		{
			if (unlock is null) throw new ArgumentNullException(nameof(unlock));
			unlock.Name = Info.Name;
			RogueLibs.CreateCustomUnlock(unlock);
			Unlock = unlock;
			return this;
		}
	}
	/// <summary>
	///   <para>Represents a <see cref="CustomEffect"/> builder, that attaches additional information to the effect.</para>
	/// </summary>
	public class EffectBuilder
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="EffectBuilder"/> class with the specified <paramref name="info"/>.</para>
		/// </summary>
		/// <param name="info">The effect metadata to use.</param>
		public EffectBuilder(EffectInfo info) => Info = info;
		/// <summary>
		///   <para>The used effect metadata.</para>
		/// </summary>
		public EffectInfo Info { get; }

		/// <summary>
		///   <para>Gets the effect's localizable name.</para>
		/// </summary>
		public CustomName Name { get; private set; }
		/// <summary>
		///   <para>Gets the effect's localizable description.</para>
		/// </summary>
		public CustomName Description { get; private set; }
		/// <summary>
		///   <para>Gets the effect's sprite.</para>
		/// </summary>
		public RogueSprite Sprite { get; private set; }

		/// <summary>
		///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the effect's name.</para>
		/// </summary>
		/// <param name="info">The localization data to initialize the localizable string with.</param>
		/// <returns>The current instance of <see cref="EffectBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentException">A localizable string that acts as the effect's name already exists.</exception>
		public EffectBuilder WithName(CustomNameInfo info)
		{
			Name = RogueLibs.CreateCustomName(Info.Name, NameTypes.StatusEffect, info);
			return this;
		}
		/// <summary>
		///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the effect's description.</para>
		/// </summary>
		/// <param name="info">The localization data to initialize the localizable string with.</param>
		/// <returns>The current instance of <see cref="EffectBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentException">A localizable string that acts as the effect's description already exists.</exception>
		public EffectBuilder WithDescription(CustomNameInfo info)
		{
			Description = RogueLibs.CreateCustomName(Info.Name, NameTypes.Description, info);
			return this;
		}
		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the effect's sprite.</para>
		/// </summary>
		/// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
		/// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
		/// <returns>The current instance of <see cref="EffectBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public EffectBuilder WithSprite(byte[] rawData, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Extra, rawData, ppu);
			return this;
		}
		/// <summary>
		///   <para>Creates a <see cref="RogueSprite"/> with a texture from <paramref name="rawData"/> with the specified <paramref name="ppu"/> to act as the effect's sprite.</para>
		/// </summary>
		/// <param name="rawData">The byte array containing a raw PNG- or JPEG-encoded image.</param>
		/// <param name="region">The region of the texture for the sprite to use.</param>
		/// <param name="ppu">The pixels-per-unit of the custom sprite's texture.</param>
		/// <returns>The current instance of <see cref="EffectBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public EffectBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Extra, rawData, region, ppu);
			return this;
		}
	}
	/// <summary>
	///   <para>Represents a <see cref="UnlockWrapper"/> builder, that attaches additional information to the unlock.</para>
	/// </summary>
	public class UnlockBuilder
	{
		/// <summary>
		///   <para>Initializes a new instance of the <see cref="UnlockBuilder"/> class with the specified <paramref name="unlock"/>.</para>
		/// </summary>
		/// <param name="unlock">The unlock wrapper to use.</param>
		public UnlockBuilder(UnlockWrapper unlock) => Unlock = unlock;
		/// <summary>
		///   <para>The used unlock wrapper.</para>
		/// </summary>
		public UnlockWrapper Unlock { get; }

		/// <summary>
		///   <para>Gets the unlock's localizable name.</para>
		/// </summary>
		public CustomName Name { get; private set; }
		/// <summary>
		///   <para>Gets the unlock's localizable description.</para>
		/// </summary>
		public CustomName Description { get; private set; }

		/// <summary>
		///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the unlock's name.</para>
		/// </summary>
		/// <param name="info">The localization data to initialize the localizable string with.</param>
		/// <returns>The current instance of <see cref="UnlockBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentException">A localizable string that acts as the unlock's name already exists.</exception>
		public UnlockBuilder WithName(CustomNameInfo info)
		{
			Name = RogueLibs.CreateCustomName(Unlock.Name, Unlock.Unlock.unlockNameType, info);
			return this;
		}
		/// <summary>
		///   <para>Creates a localizable string with the specified localization <paramref name="info"/> to act as the unlock's description.</para>
		/// </summary>
		/// <param name="info">The localization data to initialize the localizable string with.</param>
		/// <returns>The current instance of <see cref="UnlockBuilder"/>, for chaining purposes.</returns>
		/// <exception cref="ArgumentException">A localizable string that acts as the unlock's description already exists.</exception>
		public UnlockBuilder WithDescription(CustomNameInfo info)
		{
			Description = RogueLibs.CreateCustomName(Unlock is MutatorUnlock || Unlock is BigQuestUnlock ? "D_" + Unlock.Name : Unlock.Name,
				Unlock is BigQuestUnlock ? NameTypes.Unlock : Unlock.Unlock.unlockDescriptionType, info);
			return this;
		}
	}
}

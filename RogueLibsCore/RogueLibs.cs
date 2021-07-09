using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using System.IO;
using System.Threading;
using UnityEngine.Networking;
using BepInEx;

namespace RogueLibsCore
{
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

		public const string GUID = "abbysssal.streetsofrogue.roguelibscore";
		public const string Name = "RogueLibsCore";

		public const string CompiledVersion = "3.0";
		public const string CompiledSemanticVersion = "3.0.0-beta.8";
		internal const string AssemblyVersion = "3.0.0.0";

		public static string Version { [MethodImpl(MethodImplOptions.NoInlining)] get => CompiledVersion; }
		public static string SemanticVersion { [MethodImpl(MethodImplOptions.NoInlining)] get => CompiledSemanticVersion; }

		private static readonly CustomItemFactory ItemFactory = new CustomItemFactory();
		private static readonly CustomTraitFactory TraitFactory = new CustomTraitFactory();
		private static readonly CustomEffectFactory EffectFactory = new CustomEffectFactory();
		private static readonly CustomNameProvider NameProvider = new CustomNameProvider();

		public static ItemBuilder CreateCustomItem<TItem>()
			where TItem : CustomItem, new()
		{
			ItemInfo info = ItemFactory.AddItem<TItem>();
			return new ItemBuilder(info);
		}
		public static AbilityBuilder CreateCustomAbility<TAbility>()
			where TAbility : CustomAbility, new()
		{
			ItemInfo info = ItemFactory.AddItem<TAbility>();
			return new AbilityBuilder(info);
		}
		public static TraitBuilder CreateCustomTrait<TTrait>()
			where TTrait : CustomTrait, new()
		{
			TraitInfo info = TraitFactory.AddTrait<TTrait>();
			return new TraitBuilder(info);
		}
		public static EffectBuilder CreateCustomEffect<TEffect>()
			where TEffect : CustomEffect, new()
		{
			EffectInfo info = EffectFactory.AddEffect<TEffect>();
			return new EffectBuilder(info);
		}

		public static RogueSprite CreateCustomSprite(string name, SpriteScope scope, byte[] rawData, float ppu = 64f)
		{
			if (name is null) throw new ArgumentNullException(nameof(name));
			if (rawData is null) throw new ArgumentNullException(nameof(rawData));
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			RogueSprite sprite = new RogueSprite(name, scope, rawData, null, ppu);
			sprite.Define();
			return sprite;
		}
		public static RogueSprite CreateCustomSprite(string name, SpriteScope scope, byte[] rawData, Rect region, float ppu = 64f)
		{
			if (name is null) throw new ArgumentNullException(nameof(name));
			if (rawData is null) throw new ArgumentNullException(nameof(rawData));
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			RogueSprite sprite = new RogueSprite(name, scope, rawData, region, ppu);
			sprite.Define();
			return sprite;
		}

		internal static string audioCachePath;
		public static AudioClip CreateCustomAudio(string name, byte[] rawData)
		{
			string myPath = Path.Combine(audioCachePath, name + ".ogg.request");
			try
			{
				File.WriteAllBytes(myPath, rawData);

				UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file:///" + myPath, AudioType.OGGVORBIS);
				request.SendWebRequest();
				while (!request.isDone) Thread.Sleep(1);
				AudioClip clip = DownloadHandlerAudioClip.GetContent(request);
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
			finally
			{
				File.Delete(myPath);
			}
		}

		public static CustomName CreateCustomName(string name, string type, CustomNameInfo info)
			=> NameProvider.AddName(name, type, info);

		public static void CreateCustomUnlock(UnlockWrapper unlock)
		{
			if (unlock is null) throw new ArgumentNullException(nameof(unlock));
			RogueFramework.Unlocks.Add(unlock);
			RogueFramework.CustomUnlocks.Add(unlock);
			if (GameController.gameController?.unlocks is null) return;
			RogueLibsPlugin.AddUnlockFull(unlock);
		}
		public static void CreateCustomUnlock(UnlockWrapper unlock, CustomNameInfo name, CustomNameInfo description)
		{
			CreateCustomUnlock(unlock);
			CreateCustomName(unlock.Name, unlock.Unlock.unlockNameType, name);
			CreateCustomName(unlock is MutatorUnlock || unlock is BigQuestUnlock ? "D_" + unlock.Name : unlock.Name,
				unlock is BigQuestUnlock ? "Unlock" : unlock.Unlock.unlockDescriptionType, description);
		}

		public static UnlockWrapper GetUnlock(string name, string type)
			=> RogueFramework.Unlocks.Find(u => u.Name == name && u.Type == type);
		public static TUnlock GetUnlock<TUnlock>(string name) where TUnlock : UnlockWrapper
			=> (TUnlock)RogueFramework.Unlocks.Find(u => u is TUnlock && u.Name == name);
	}
	public class ItemBuilder
	{
		public ItemBuilder(ItemInfo info) => Info = info;
		public ItemInfo Info { get; }

		public CustomName Name { get; private set; }
		public CustomName Description { get; private set; }
		public RogueSprite Sprite { get; private set; }
		public ItemUnlock Unlock { get; private set; }

		public ItemBuilder WithName(CustomNameInfo name)
		{
			Name = RogueLibs.CreateCustomName(Info.Name, "Item", name);
			return this;
		}
		public ItemBuilder WithDescription(CustomNameInfo description)
		{
			Description = RogueLibs.CreateCustomName(Info.Name, "Description", description);
			return this;
		}
		public ItemBuilder WithSprite(byte[] rawData, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Items, rawData, ppu);
			return this;
		}
		public ItemBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Items, rawData, region, ppu);
			return this;
		}
		public ItemBuilder WithUnlock() => WithUnlock(new ItemUnlock(Info.Name, true));
		public ItemBuilder WithUnlock(ItemUnlock unlock)
		{
			unlock.Name = Info.Name;
			RogueLibs.CreateCustomUnlock(unlock);
			Unlock = unlock;
			return this;
		}
	}
	public class AbilityBuilder
	{
		public AbilityBuilder(ItemInfo info) => Info = info;
		public ItemInfo Info { get; }

		public CustomName Name { get; private set; }
		public CustomName Description { get; private set; }
		public RogueSprite Sprite { get; private set; }
		public AbilityUnlock Unlock { get; private set; }

		public AbilityBuilder WithName(CustomNameInfo name)
		{
			Name = RogueLibs.CreateCustomName(Info.Name, "Item", name);
			return this;
		}
		public AbilityBuilder WithDescription(CustomNameInfo description)
		{
			Description = RogueLibs.CreateCustomName(Info.Name, "Description", description);
			return this;
		}
		public AbilityBuilder WithSprite(byte[] rawData, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Items, rawData, ppu);
			return this;
		}
		public AbilityBuilder WithSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			Sprite = RogueLibs.CreateCustomSprite(Info.Name, SpriteScope.Items, rawData, region, ppu);
			return this;
		}
		public AbilityBuilder WithUnlock() => WithUnlock(new AbilityUnlock(Info.Name, true));
		public AbilityBuilder WithUnlock(AbilityUnlock unlock)
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
		public RogueSprite Sprite { get; private set; }
		public TraitUnlock Unlock { get; private set; }

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
	}
}

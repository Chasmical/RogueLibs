using System;
using System.Linq;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;
using UnityEngine;
using System.IO;

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

        internal const string AssemblyVersion = "3.5.0.0";
        /// <summary>
        ///   <para>Version of RogueLibs that the current assembly is compiled with.</para>
        /// </summary>
        public const string CompiledVersion = "3.5.0";
        /// <summary>
        ///   <para>Semantic version of RogueLibs that the current assembly is compiled with. Don't use it in BepInPlugin.</para>
        /// </summary>
        public const string CompiledSemanticVersion = "3.5.0-beta.3";

        /// <summary>
        ///   <para>Currently installed and running version of RogueLibs.</para>
        /// </summary>
        public static string Version { [MethodImpl(MethodImplOptions.NoInlining)] get => CompiledVersion; }
        /// <summary>
        ///   <para>Currently installed and running semantic version of RogueLibs.</para>
        /// </summary>
        public static string SemanticVersion { [MethodImpl(MethodImplOptions.NoInlining)] get => CompiledSemanticVersion; }

        internal static readonly CustomItemFactory ItemFactory = new CustomItemFactory();
        internal static readonly CustomTraitFactory TraitFactory = new CustomTraitFactory();
        internal static readonly CustomEffectFactory EffectFactory = new CustomEffectFactory();
        internal static readonly CustomNameProvider NameProvider = new CustomNameProvider();

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
        /// <param name="name">The name of the clip.</param>
        /// <param name="rawData">The byte array containing a raw audio file.</param>
        /// <param name="format">The audio file's format.</param>
        /// <returns>The created <see cref="AudioClip"/>.</returns>
        /// <exception cref="IOException">An I/O error occurred while opening the file.</exception>
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
        public static UnlockWrapper? GetUnlock(string name, string type)
            => RogueFramework.Unlocks.Find(u => u.Name == name && u.Type == type);
        /// <summary>
        ///   <para>Gets an unlock of the specified <typeparamref name="TUnlock"/> type and with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <typeparam name="TUnlock">The type of the unlock to search for.</typeparam>
        /// <param name="name">The name of the unlock to search for.</param>
        /// <returns>The unlock of the specified <typeparamref name="TUnlock"/> type and with the specified <paramref name="name"/>, if found; otherwise, <see langword="null"/>.</returns>
        public static TUnlock? GetUnlock<TUnlock>(string name) where TUnlock : UnlockWrapper
            => (TUnlock?)RogueFramework.Unlocks.Find(u => u is TUnlock && u.Name == name);

        /// <summary>
        ///   <para>Invokes all static methods marked with a <see cref="RLSetupAttribute"/> in the current assembly.</para>
        /// </summary>
        public static void LoadFromAssembly()
        {
            MethodBase caller = new StackTrace().GetFrame(1).GetMethod();
            Assembly assembly = caller.ReflectedType!.Assembly;
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
                            ConstructorInfo? ctor = method.DeclaringType!.GetConstructor(Type.EmptyTypes);
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

        public static VersionText CreateVersionText(string id, string? text)
        {
            VersionText versionText = RogueLibsPlugin.versionLines.Find(v => v.Id == id);
            if (versionText != null)
            {
                if (text != null) versionText.Text = text;
                return versionText;
            }
            RogueLibsPlugin.versionLines.Add(versionText = new VersionText(id, text));
            if (RogueLibsPlugin.versionLinesReady)
            {
                GameObject versionObj = GameObject.Find("VersionText2");
                versionText.AssignText(RogueLibsPlugin.AttachVersionText(versionObj, id, text));
            }
            return versionText;
        }
    }
}

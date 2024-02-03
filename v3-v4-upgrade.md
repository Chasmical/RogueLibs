# Breaking changes:

## Hooks, hook controllers and factories

- 💥 `object IHook.Instance` property setter was removed.
- 💥 `T IHook<T>.Instance` property setter was removed.
- 💥 `void IHook.Initialize()` now takes an extra parameter, attached instance (`void IHook.Initialize(object)`). The hooks must set their current instance to the provided argument.

- 💥 `protected T HookBase<T>.Instance` property getter is now public, and the setter was removed.

- 💥 `IHook[] IHookController.GetHooks()` now returns `IEnumerable<T>`.
- 💥 `void IHookController<T>.AddHook(IHook<T>)` method was removed.
- 💥 `bool IHookController<T>.RemoveHook(IHook<T>)` method was removed.

- 💥 `HookController..ctor(T)` constructor is now private.
- 💥 `HookController<T>`s will be instantiated with the type of the object they're attached to, not the base `PlayfieldObject` (you should use `IHookController<T>` instead in these cases).
- 💥 `void HookController<T>.AddHook(IHook<T>)` method's parameter is now of type `IHook`.
- 💥 `bool HookController<T>.RemoveHook(IHook<T>)` method's parameter is now of type `IHook`.
- 💥 `IEnumerable<IHook<T>> HookController<T>.GetHooks()` method now returns type `IEnumerable<IHook>`.
- 💥 `THook HookController<T>.AddHook<THook>()` method was removed.
- 💥 `bool HookController<T>.RemoveHook<THook>()` method was removed.
- 💥 `THook[] HookController<T>.GetHooks<THook>()` method was removed.
- 💥 `void HookController<T>.Dispose()` is now private.

- 💥 `IHookFactory<T>.TryCreate` method was removed.
- 💥 `bool IHookFactory.TryCreate(object, out IHook)` was replaced with `IHook IHookFactory.TryCreateHook(object)`.

## GetItem/Trait/Effect (by type), GetHook

- 💥 `IHook<InvItem> RogueExtensions.GetItem(this InvDatabase, Type)` method now returns type `IHook`.
- 💥 `IEnumerable<IHook<InvItem>> RogueExtensions.GetItems(this InvDatabase, Type)` method now returns type `IEnumerable<IHook>`.
- 💥 `IHook<InvItem> RogueExtensions.GetAbility(this Agent, Type)` method now returns type `IHook`.
- 💥 `IHook<Trait> RogueExtensions.GetTrait(this Agent, Type)` method now returns type `IHook`.
- 💥 `IEnumerable<IHook<Trait>> RogueExtensions.GetTraits(this Agent, Type)` method now returns type `IEnumerable<IHook>`.
- 💥 `IHook<StatusEffect> RogueExtensions.GetEffect(this Agent, Type)` method now returns type `IHook`.
- 💥 `IEnumerable<IHook<StatusEffect>> RogueExtensions.GetEffects(this Agent, Type)` method now returns type `IEnumerable<IHook>`.

- 💥 `UnlockWrapper HookExtensions.GetHook(this Unlock)` method was moved to the `HookSystem` class.
- 💥 `THook HookExtensions.GetHook<THook>(this Unlock)` method was moved to the `HookSystem` class.
- 💥 `StatusEffects HookExtensions.GetStatusEffects(this StatusEffect)` method was moved to the `HookSystem` class.
- 💥 `StatusEffects HookExtensions.GetStatusEffects(this Trait)` method was moved to the `HookSystem` class.

## Miscellaneous

- 💥 `RogueUtilities.Empty` field was removed.

- 💥 `void LanguageService.RegisterLanguageCode(string, LanguageCode)` now returns the registered code, instead of allowing the user to define it - `LanguageCode LanguageService.RegisterLanguageCode(string)`.

- 💥 `RogueLibs.Name` property is now internal.

- 💥 `__RogueLibsHooks`, `__RogueLibsCustom` and `__RogueLibsContainer` patched fields were removed (not that they were exposed to the user in any way, but just in case).





# Deprecation and upgrade warnings:

## Renamed types

- ⚠️ `ItemInfo`'s functionality was moved to `CustomItemMetadata`.
- ⚠️ `TraitInfo`'s functionality was moved to `CustomTraitMetadata`.
- ⚠️ `EffectInfo`'s functionality was moved to `CustomEffectMetadata`.
- ⚠️ `DisasterInfo`'s functionality was moved to `CustomDisasterMetadata`.

## Obsolete types and members

- ⚠️ `IHookFactory<T>` interface is now marked as obsolete.

- ⚠️ `DebugFlags` enum is now marked as obsolete.
- ⚠️ `DebugFlags RogueFramework.DebugFlags` property is marked as obsolete.
- ⚠️ `bool RogueFramework.IsDebugEnabled(DebugFlags)` method is marked as obsolete.

- ⚠️ `VersionText` class is now marked as obsolete.
- ⚠️ `VersionText RogueLibs.CreateVersionText(string, string)` method is now marked as obsolete.

- ⚠️ `AudioClip RogueLibs.CreateCustomAudio(byte[], AudioType)`, `AudioClip RogueUtilities.ConvertToAudioClip(byte[], AudioType)`, `AudioClip RogueUtilities.ConvertToAudioClip(string, AudioType)` methods are now marked as obsolete. Use overloads without the `AudioType` parameter - RogueLibs will auto-detect the audio format.

## Extra notes

- ⚠️ `void HookBase<T>.Initialize()` method is now virtual.

- ⚠️ Generic type parameter `T` in `IHook<T>` and `IHookController<T>` is now covariant, and has a `notnull` constraint.
- ⚠️ Generic type parameter `T` in `HookBase<T>`, `HookFactoryBase<T>` and `HookController<T>` now has a `notnull` constraint.
- ⚠️ Generic type parameter `THook` of `THook HookExtensions.AddHook<THook>(this InvItem/PlayfieldObject/StatusEffect/Trait)` now has a reference type constraint.
- ⚠️ Generic type parameter `THook` of `THook HookExtensions.GetOrAddHook<THook>(this InvItem/PlayfieldObject/StatusEffect/Trait)` now has a reference type constraint.

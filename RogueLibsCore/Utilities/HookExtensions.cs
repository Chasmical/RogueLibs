using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
	public static class HookExtensions
	{
		private static HookController<T> GetHookController<T>(T obj, ref object field, bool create)
		{
			HookController<T> controller = field as HookController<T>;
			if (controller is null && create) field = controller = new HookController<T>(obj);
			return controller;
		}

		public static void AddHook(this InvItem obj, IHook<InvItem> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		}
		public static void AddHook(this Agent obj, IHook<Agent> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		}
		public static void AddHook(this ObjectReal obj, IHook<ObjectReal> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		}
		public static void AddHook(this StatusEffect obj, IHook<StatusEffect> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		}
		public static void AddHook(this Trait obj, IHook<Trait> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		}

		public static THook AddHook<THook>(this InvItem obj) where THook : IHook<InvItem>, new()
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		}
		public static THook AddHook<THook>(this Agent obj) where THook : IHook<Agent>, new()
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		}
		public static THook AddHook<THook>(this ObjectReal obj) where THook : IHook<ObjectReal>, new()
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		}
		public static THook AddHook<THook>(this StatusEffect obj) where THook : IHook<StatusEffect>, new()
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		}
		public static THook AddHook<THook>(this Trait obj) where THook : IHook<Trait>, new()
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		}

		public static bool RemoveHook(this InvItem obj, IHook<InvItem> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		public static bool RemoveHook(this Agent obj, IHook<Agent> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		public static bool RemoveHook(this ObjectReal obj, IHook<ObjectReal> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		public static bool RemoveHook(this StatusEffect obj, IHook<StatusEffect> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		public static bool RemoveHook(this Trait obj, IHook<Trait> hook)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}

		public static bool RemoveHook<THook>(this InvItem obj) where THook : IHook<InvItem>
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		}
		public static bool RemoveHook<THook>(this Agent obj) where THook : IHook<Agent>
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		}
		public static bool RemoveHook<THook>(this ObjectReal obj) where THook : IHook<ObjectReal>
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		}
		public static bool RemoveHook<THook>(this StatusEffect obj) where THook : IHook<StatusEffect>
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		}
		public static bool RemoveHook<THook>(this Trait obj) where THook : IHook<Trait>
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		}

		public static THook GetHook<THook>(this InvItem obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			HookController<InvItem> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		public static THook GetHook<THook>(this Agent obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			HookController<Agent> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		public static THook GetHook<THook>(this ObjectReal obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			HookController<ObjectReal> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		public static THook GetHook<THook>(this StatusEffect obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			HookController<StatusEffect> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		public static THook GetHook<THook>(this Trait obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			HookController<Trait> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		public static UnlockWrapper GetHook(this Unlock obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return (UnlockWrapper)obj.__RogueLibsCustom;
		}

		public static IEnumerable<THook> GetHooks<THook>(this InvItem obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		public static IEnumerable<THook> GetHooks<THook>(this Agent obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		public static IEnumerable<THook> GetHooks<THook>(this ObjectReal obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		public static IEnumerable<THook> GetHooks<THook>(this StatusEffect obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		public static IEnumerable<THook> GetHooks<THook>(this Trait obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			return GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}

		public static StatusEffects GetStatusEffects(this StatusEffect statusEffect)
		{
			if (statusEffect is null) throw new ArgumentNullException(nameof(statusEffect));
			return (StatusEffects)statusEffect.__RogueLibsContainer;
		}
		public static StatusEffects GetStatusEffects(this Trait trait)
		{
			if (trait is null) throw new ArgumentNullException(nameof(trait));
			return (StatusEffects)trait.__RogueLibsContainer;
		}
	}
}

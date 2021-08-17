using System;
using System.Linq;
using System.Collections.Generic;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>The collection of hook extensions.</para>
	/// </summary>
	public static class HookExtensions
	{
		private static IHookController<T> GetHookController<T>(T obj, ref object field, bool create)
		{
			HookController<T> controller = field as HookController<T>;
			if (controller is null && create) field = controller = new HookController<T>(obj);
			return controller;
		}

		/// <summary>
		///   <para>Attaches the specified <paramref name="hook"/> to the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <param name="hook">The hook to attach to the <paramref name="instance"/>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="hook"/> is <see langword="null"/>.</exception>
		public static void AddHook(this InvItem instance, IHook<InvItem> hook)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(instance, ref instance.__RogueLibsHooks, true).AddHook(hook);
		}
		/// <summary>
		///   <para>Attaches the specified <paramref name="hook"/> to the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <param name="hook">The hook to attach to the <paramref name="instance"/>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="hook"/> is <see langword="null"/>.</exception>
		public static void AddHook(this Agent instance, IHook<Agent> hook)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(instance, ref instance.__RogueLibsHooks, true).AddHook(hook);
		}
		/// <summary>
		///   <para>Attaches the specified <paramref name="hook"/> to the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <param name="hook">The hook to attach to the <paramref name="instance"/>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="hook"/> is <see langword="null"/>.</exception>
		public static void AddHook(this ObjectReal instance, IHook<ObjectReal> hook)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(instance, ref instance.__RogueLibsHooks, true).AddHook(hook);
		}
		/// <summary>
		///   <para>Attaches the specified <paramref name="hook"/> to the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <param name="hook">The hook to attach to the <paramref name="instance"/>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="hook"/> is <see langword="null"/>.</exception>
		public static void AddHook(this StatusEffect instance, IHook<StatusEffect> hook)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(instance, ref instance.__RogueLibsHooks, true).AddHook(hook);
		}
		/// <summary>
		///   <para>Attaches the specified <paramref name="hook"/> to the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <param name="hook">The hook to attach to the <paramref name="instance"/>.</param>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> or <paramref name="hook"/> is <see langword="null"/>.</exception>
		public static void AddHook(this Trait instance, IHook<Trait> hook)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			if (hook is null) throw new ArgumentNullException(nameof(hook));
			GetHookController(instance, ref instance.__RogueLibsHooks, true).AddHook(hook);
		}

		/// <summary>
		///   <para>Creates a hook of the specified <typeparamref name="THook"/> type and attaches it to the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hook to create and attach to the <paramref name="instance"/>.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The created hook.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static THook AddHook<THook>(this InvItem instance) where THook : IHook<InvItem>, new()
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			THook hook = new THook();
			GetHookController(instance, ref instance.__RogueLibsHooks, true).AddHook(hook);
			return hook;
		}
		/// <summary>
		///   <para>Creates a hook of the specified <typeparamref name="THook"/> type and attaches it to the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hook to create and attach to the <paramref name="instance"/>.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The created hook.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static THook AddHook<THook>(this Agent instance) where THook : IHook<Agent>, new()
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			THook hook = new THook();
			GetHookController(instance, ref instance.__RogueLibsHooks, true).AddHook(hook);
			return hook;
		}
		/// <summary>
		///   <para>Creates a hook of the specified <typeparamref name="THook"/> type and attaches it to the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hook to create and attach to the <paramref name="instance"/>.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The created hook.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static THook AddHook<THook>(this ObjectReal instance) where THook : IHook<ObjectReal>, new()
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			THook hook = new THook();
			GetHookController(instance, ref instance.__RogueLibsHooks, true).AddHook(hook);
			return hook;
		}
		/// <summary>
		///   <para>Creates a hook of the specified <typeparamref name="THook"/> type and attaches it to the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hook to create and attach to the <paramref name="instance"/>.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The created hook.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static THook AddHook<THook>(this StatusEffect instance) where THook : IHook<StatusEffect>, new()
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			THook hook = new THook();
			GetHookController(instance, ref instance.__RogueLibsHooks, true).AddHook(hook);
			return hook;
		}
		/// <summary>
		///   <para>Creates a hook of the specified <typeparamref name="THook"/> type and attaches it to the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hook to create and attach to the <paramref name="instance"/>.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The created hook.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static THook AddHook<THook>(this Trait instance) where THook : IHook<Trait>, new()
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			THook hook = new THook();
			GetHookController(instance, ref instance.__RogueLibsHooks, true).AddHook(hook);
			return hook;
		}

		/// <summary>
		///   <para>Detaches the specified <paramref name="hook"/> from the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <param name="hook">The hook to detach from the <paramref name="instance"/>.</param>
		/// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static bool RemoveHook(this InvItem instance, IHook<InvItem> hook)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return GetHookController(instance, ref instance.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		/// <summary>
		///   <para>Detaches the specified <paramref name="hook"/> from the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <param name="hook">The hook to detach from the <paramref name="instance"/>.</param>
		/// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static bool RemoveHook(this Agent instance, IHook<Agent> hook)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return GetHookController(instance, ref instance.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		/// <summary>
		///   <para>Detaches the specified <paramref name="hook"/> from the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <param name="hook">The hook to detach from the <paramref name="instance"/>.</param>
		/// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static bool RemoveHook(this ObjectReal instance, IHook<ObjectReal> hook)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return GetHookController(instance, ref instance.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		/// <summary>
		///   <para>Detaches the specified <paramref name="hook"/> from the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <param name="hook">The hook to detach from the <paramref name="instance"/>.</param>
		/// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static bool RemoveHook(this StatusEffect instance, IHook<StatusEffect> hook)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return GetHookController(instance, ref instance.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}
		/// <summary>
		///   <para>Detaches the specified <paramref name="hook"/> from the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <param name="hook">The hook to detach from the <paramref name="instance"/>.</param>
		/// <returns><see langword="true"/>, if the hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static bool RemoveHook(this Trait instance, IHook<Trait> hook)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return GetHookController(instance, ref instance.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		}

		/// <summary>
		///   <para>Detaches a hook of the specified <typeparamref name="THook"/> type from the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <typeparam name="THook">The type of a hook to detach from the <paramref name="instance"/>.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns><see langword="true"/>, if a hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static bool RemoveHook<THook>(this InvItem instance) where THook : IHook<InvItem>
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			IHookController<InvItem> controller = GetHookController(instance, ref instance.__RogueLibsHooks, false);
			if (controller is null) return false;
			IHook<InvItem> hook = controller.GetHook<THook>();
			return controller.RemoveHook(hook);
		}
		/// <summary>
		///   <para>Detaches a hook of the specified <typeparamref name="THook"/> type from the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <typeparam name="THook">The type of a hook to detach from the <paramref name="instance"/>.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns><see langword="true"/>, if a hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static bool RemoveHook<THook>(this Agent instance) where THook : IHook<Agent>
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			IHookController<Agent> controller = GetHookController(instance, ref instance.__RogueLibsHooks, false);
			if (controller is null) return false;
			IHook<Agent> hook = controller.GetHook<THook>();
			return controller.RemoveHook(hook);
		}
		/// <summary>
		///   <para>Detaches a hook of the specified <typeparamref name="THook"/> type from the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <typeparam name="THook">The type of a hook to detach from the <paramref name="instance"/>.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns><see langword="true"/>, if a hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static bool RemoveHook<THook>(this ObjectReal instance) where THook : IHook<ObjectReal>
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			IHookController<ObjectReal> controller = GetHookController(instance, ref instance.__RogueLibsHooks, false);
			if (controller is null) return false;
			IHook<ObjectReal> hook = controller.GetHook<THook>();
			return controller.RemoveHook(hook);
		}
		/// <summary>
		///   <para>Detaches a hook of the specified <typeparamref name="THook"/> type from the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <typeparam name="THook">The type of a hook to detach from the <paramref name="instance"/>.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns><see langword="true"/>, if a hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static bool RemoveHook<THook>(this StatusEffect instance) where THook : IHook<StatusEffect>
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			IHookController<StatusEffect> controller = GetHookController(instance, ref instance.__RogueLibsHooks, false);
			if (controller is null) return false;
			IHook<StatusEffect> hook = controller.GetHook<THook>();
			return controller.RemoveHook(hook);
		}
		/// <summary>
		///   <para>Detaches a hook of the specified <typeparamref name="THook"/> type from the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <typeparam name="THook">The type of a hook to detach from the <paramref name="instance"/>.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns><see langword="true"/>, if a hook was successfully detached; otherwise, <see langword="false"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static bool RemoveHook<THook>(this Trait instance) where THook : IHook<Trait>
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			IHookController<Trait> controller = GetHookController(instance, ref instance.__RogueLibsHooks, false);
			if (controller is null) return false;
			IHook<Trait> hook = controller.GetHook<THook>();
			return controller.RemoveHook(hook);
		}

		/// <summary>
		///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of a hook to search for.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static THook GetHook<THook>(this InvItem instance)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			IHookController<InvItem> controller = GetHookController(instance, ref instance.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		/// <summary>
		///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of a hook to search for.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static THook GetHook<THook>(this Agent instance)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			IHookController<Agent> controller = GetHookController(instance, ref instance.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		/// <summary>
		///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of a hook to search for.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static THook GetHook<THook>(this ObjectReal instance)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			IHookController<ObjectReal> controller = GetHookController(instance, ref instance.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		/// <summary>
		///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of a hook to search for.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static THook GetHook<THook>(this StatusEffect instance)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			IHookController<StatusEffect> controller = GetHookController(instance, ref instance.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		/// <summary>
		///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of a hook to search for.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static THook GetHook<THook>(this Trait instance)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			IHookController<Trait> controller = GetHookController(instance, ref instance.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		/// <summary>
		///   <para>Returns the <see cref="UnlockWrapper"/> attached to the current <paramref name="instance"/>.</para>
		/// </summary>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The attached <see cref="UnlockWrapper"/> hook, if found; otherwise, <see langword="null"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static UnlockWrapper GetHook(this Unlock instance)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return (UnlockWrapper)instance.__RogueLibsCustom;
		}
		/// <summary>
		///   <para>Returns a hook attached to the current <paramref name="instance"/>, that is assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of a hook to search for.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>The hook that is assignable to a variable of <typeparamref name="THook"/> type, if found; otherwise, <see langword="default"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static THook GetHook<THook>(this Unlock instance) where THook : UnlockWrapper
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return instance.__RogueLibsCustom is THook tHook ? tHook : null;
		}

		/// <summary>
		///   <para>Returns an enumerable collection of all hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hooks to search for.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>An enumerable collection of hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static IEnumerable<THook> GetHooks<THook>(this InvItem instance)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return GetHookController(instance, ref instance.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		/// <summary>
		///   <para>Returns an enumerable collection of all hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hooks to search for.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>An enumerable collection of hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static IEnumerable<THook> GetHooks<THook>(this Agent instance)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return GetHookController(instance, ref instance.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		/// <summary>
		///   <para>Returns an enumerable collection of all hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hooks to search for.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>An enumerable collection of hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static IEnumerable<THook> GetHooks<THook>(this ObjectReal instance)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return GetHookController(instance, ref instance.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		/// <summary>
		///   <para>Returns an enumerable collection of all hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hooks to search for.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>An enumerable collection of hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static IEnumerable<THook> GetHooks<THook>(this StatusEffect instance)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return GetHookController(instance, ref instance.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}
		/// <summary>
		///   <para>Returns an enumerable collection of all hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">The type of the hooks to search for.</typeparam>
		/// <param name="instance">The instance of a hookable type.</param>
		/// <returns>An enumerable collection of hooks attached to the current <paramref name="instance"/>, that are assignable to a variable of <typeparamref name="THook"/> type.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="instance"/> is <see langword="null"/>.</exception>
		public static IEnumerable<THook> GetHooks<THook>(this Trait instance)
		{
			if (instance is null) throw new ArgumentNullException(nameof(instance));
			return GetHookController(instance, ref instance.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		}

		/// <summary>
		///   <para>Returns the <see cref="StatusEffects"/> instance containing the current <paramref name="statusEffect"/>.</para>
		/// </summary>
		/// <param name="statusEffect">The current instance of <see cref="StatusEffect"/>.</param>
		/// <returns>The <see cref="StatusEffects"/> instance containing the current <paramref name="statusEffect"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="statusEffect"/> is <see langword="null"/>.</exception>
		public static StatusEffects GetStatusEffects(this StatusEffect statusEffect)
		{
			if (statusEffect is null) throw new ArgumentNullException(nameof(statusEffect));
			return (StatusEffects)statusEffect.__RogueLibsContainer;
		}
		/// <summary>
		///   <para>Returns the <see cref="StatusEffects"/> instance containing the current <paramref name="trait"/>.</para>
		/// </summary>
		/// <param name="trait">The current instance of <see cref="Trait"/>.</param>
		/// <returns>The <see cref="StatusEffects"/> instance containing the current <paramref name="trait"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="trait"/> is <see langword="null"/>.</exception>
		public static StatusEffects GetStatusEffects(this Trait trait)
		{
			if (trait is null) throw new ArgumentNullException(nameof(trait));
			return (StatusEffects)trait.__RogueLibsContainer;
		}
	}
}

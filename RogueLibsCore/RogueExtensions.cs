using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>RogueLibs' extension methods.</para>
	/// </summary>
	public static class RogueExtensions
	{
		private static HookController<T> GetHookController<T>(T obj, ref object field, bool create)
		{
			HookController<T> controller = field as HookController<T>;
			if (controller == null && create) field = controller = new HookController<T>(obj);
			return controller;
		}

		/// <summary>
		///   <para>Adds the specified <paramref name="hook"/> to the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object to attach a hook to.</param>
		/// <param name="hook">Hook to attach.</param>
		public static void AddHook(this InvItem obj, IHook<InvItem> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		/// <summary>
		///   <para>Adds the specified <paramref name="hook"/> to the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object to attach a hook to.</param>
		/// <param name="hook">Hook to attach.</param>
		public static void AddHook(this Agent obj, IHook<Agent> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		/// <summary>
		///   <para>Adds the specified <paramref name="hook"/> to the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object to attach a hook to.</param>
		/// <param name="hook">Hook to attach.</param>
		public static void AddHook(this ObjectReal obj, IHook<ObjectReal> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		/// <summary>
		///   <para>Adds the specified <paramref name="hook"/> to the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object to attach a hook to.</param>
		/// <param name="hook">Hook to attach.</param>
		public static void AddHook(this StatusEffect obj, IHook<StatusEffect> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);
		/// <summary>
		///   <para>Adds the specified <paramref name="hook"/> to the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object to attach a hook to.</param>
		/// <param name="hook">Hook to attach.</param>
		public static void AddHook(this Trait obj, IHook<Trait> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook(hook);

		/// <summary>
		///   <para>Creates a hook of the specified <typeparamref name="THook"/> type using the default constructor and adds it to the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to create and attach.</typeparam>
		/// <param name="obj">Object to attach a hook to.</param>
		public static THook AddHook<THook>(this InvItem obj) where THook : IHook<InvItem>, new()
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		/// <summary>
		///   <para>Creates a hook of the specified <typeparamref name="THook"/> type using the default constructor and adds it to the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to create and attach.</typeparam>
		/// <param name="obj">Object to attach a hook to.</param>
		public static THook AddHook<THook>(this Agent obj) where THook : IHook<Agent>, new()
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		/// <summary>
		///   <para>Creates a hook of the specified <typeparamref name="THook"/> type using the default constructor and adds it to the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to create and attach.</typeparam>
		/// <param name="obj">Object to attach a hook to.</param>
		public static THook AddHook<THook>(this ObjectReal obj) where THook : IHook<ObjectReal>, new()
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		/// <summary>
		///   <para>Creates a hook of the specified <typeparamref name="THook"/> type using the default constructor and adds it to the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to create and attach.</typeparam>
		/// <param name="obj">Object to attach a hook to.</param>
		public static THook AddHook<THook>(this StatusEffect obj) where THook : IHook<StatusEffect>, new()
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();
		/// <summary>
		///   <para>Creates a hook of the specified <typeparamref name="THook"/> type using the default constructor and adds it to the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to create and attach.</typeparam>
		/// <param name="obj">Object to attach a hook to.</param>
		public static THook AddHook<THook>(this Trait obj) where THook : IHook<Trait>, new()
			=> GetHookController(obj, ref obj.__RogueLibsHooks, true).AddHook<THook>();

		/// <summary>
		///   <para>Removes the specified <paramref name="hook"/> from the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object to remove the <paramref name="hook"/> from.</param>
		/// <param name="hook">Hook to be removed.</param>
		/// <returns><see langword="true"/>, if the hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public static bool RemoveHook(this InvItem obj, IHook<InvItem> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		/// <summary>
		///   <para>Removes the specified <paramref name="hook"/> from the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object to remove the <paramref name="hook"/> from.</param>
		/// <param name="hook">Hook to be removed.</param>
		/// <returns><see langword="true"/>, if the hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public static bool RemoveHook(this Agent obj, IHook<Agent> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		/// <summary>
		///   <para>Removes the specified <paramref name="hook"/> from the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object to remove the <paramref name="hook"/> from.</param>
		/// <param name="hook">Hook to be removed.</param>
		/// <returns><see langword="true"/>, if the hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public static bool RemoveHook(this ObjectReal obj, IHook<ObjectReal> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		/// <summary>
		///   <para>Removes the specified <paramref name="hook"/> from the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object to remove the <paramref name="hook"/> from.</param>
		/// <param name="hook">Hook to be removed.</param>
		/// <returns><see langword="true"/>, if the hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public static bool RemoveHook(this StatusEffect obj, IHook<StatusEffect> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;
		/// <summary>
		///   <para>Removes the specified <paramref name="hook"/> from the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object to remove the <paramref name="hook"/> from.</param>
		/// <param name="hook">Hook to be removed.</param>
		/// <returns><see langword="true"/>, if the hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public static bool RemoveHook(this Trait obj, IHook<Trait> hook)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook(hook) == true;

		/// <summary>
		///   <para>Removes a hook of the specified <typeparamref name="THook"/> type from the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to be removed.</typeparam>
		/// <param name="obj">Object to remove a hook of the specified <typeparamref name="THook"/> type from.</param>
		/// <returns><see langword="true"/>, if a hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public static bool RemoveHook<THook>(this InvItem obj) where THook : IHook<InvItem>
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		/// <summary>
		///   <para>Removes a hook of the specified <typeparamref name="THook"/> type from the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to be removed.</typeparam>
		/// <param name="obj">Object to remove a hook of the specified <typeparamref name="THook"/> type from.</param>
		/// <returns><see langword="true"/>, if a hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public static bool RemoveHook<THook>(this Agent obj) where THook : IHook<Agent>
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		/// <summary>
		///   <para>Removes a hook of the specified <typeparamref name="THook"/> type from the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to be removed.</typeparam>
		/// <param name="obj">Object to remove a hook of the specified <typeparamref name="THook"/> type from.</param>
		/// <returns><see langword="true"/>, if a hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public static bool RemoveHook<THook>(this ObjectReal obj) where THook : IHook<ObjectReal>
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		/// <summary>
		///   <para>Removes a hook of the specified <typeparamref name="THook"/> type from the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to be removed.</typeparam>
		/// <param name="obj">Object to remove a hook of the specified <typeparamref name="THook"/> type from.</param>
		/// <returns><see langword="true"/>, if a hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public static bool RemoveHook<THook>(this StatusEffect obj) where THook : IHook<StatusEffect>
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;
		/// <summary>
		///   <para>Removes a hook of the specified <typeparamref name="THook"/> type from the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to be removed.</typeparam>
		/// <param name="obj">Object to remove a hook of the specified <typeparamref name="THook"/> type from.</param>
		/// <returns><see langword="true"/>, if a hook was successfully removed; otherwise, <see langword="false"/>.</returns>
		public static bool RemoveHook<THook>(this Trait obj) where THook : IHook<Trait>
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.RemoveHook<THook>() == true;

		/// <summary>
		///   <para>Searches for a hook of the specified <typeparamref name="THook"/> type in the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to search for.</typeparam>
		/// <param name="obj">Object to search for the hook of the specified <typeparamref name="THook"/> type in.</param>
		/// <returns>First occurence of a hook of the specified <typeparamref name="THook"/> type, if found; otherwise, <see langword="null"/>.</returns>
		public static THook GetHook<THook>(this InvItem obj)
		{
			HookController<InvItem> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		/// <summary>
		///   <para>Searches for a hook of the specified <typeparamref name="THook"/> type in the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to search for.</typeparam>
		/// <param name="obj">Object to search for the hook of the specified <typeparamref name="THook"/> type in.</param>
		/// <returns>First occurence of a hook of the specified <typeparamref name="THook"/> type, if found; otherwise, <see langword="null"/>.</returns>
		public static THook GetHook<THook>(this Agent obj)
		{
			HookController<Agent> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		/// <summary>
		///   <para>Searches for a hook of the specified <typeparamref name="THook"/> type in the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to search for.</typeparam>
		/// <param name="obj">Object to search for the hook of the specified <typeparamref name="THook"/> type in.</param>
		/// <returns>First occurence of a hook of the specified <typeparamref name="THook"/> type, if found; otherwise, <see langword="null"/>.</returns>
		public static THook GetHook<THook>(this ObjectReal obj)
		{
			HookController<ObjectReal> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		/// <summary>
		///   <para>Searches for a hook of the specified <typeparamref name="THook"/> type in the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to search for.</typeparam>
		/// <param name="obj">Object to search for the hook of the specified <typeparamref name="THook"/> type in.</param>
		/// <returns>First occurence of a hook of the specified <typeparamref name="THook"/> type, if found; otherwise, <see langword="null"/>.</returns>
		public static THook GetHook<THook>(this StatusEffect obj)
		{
			HookController<StatusEffect> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}
		/// <summary>
		///   <para>Searches for a hook of the specified <typeparamref name="THook"/> type in the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hook to search for.</typeparam>
		/// <param name="obj">Object to search for the hook of the specified <typeparamref name="THook"/> type in.</param>
		/// <returns>First occurence of a hook of the specified <typeparamref name="THook"/> type, if found; otherwise, <see langword="null"/>.</returns>
		public static THook GetHook<THook>(this Trait obj)
		{
			HookController<Trait> controller = GetHookController(obj, ref obj.__RogueLibsHooks, false);
			return controller != null ? controller.GetHook<THook>() : default;
		}

		/// <summary>
		///   <para>Iterates through hooks of the specified <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hooks to search for.</typeparam>
		/// <param name="obj">Object to search hooks of the specified <typeparamref name="THook"/> type in.</param>
		/// <returns>Hooks of the specified <typeparamref name="THook"/> type, or an empty collection.</returns>
		public static IEnumerable<THook> GetHooks<THook>(this InvItem obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		/// <summary>
		///   <para>Iterates through hooks of the specified <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hooks to search for.</typeparam>
		/// <param name="obj">Object to search hooks of the specified <typeparamref name="THook"/> type in.</param>
		/// <returns>Hooks of the specified <typeparamref name="THook"/> type, or an empty collection.</returns>
		public static IEnumerable<THook> GetHooks<THook>(this Agent obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		/// <summary>
		///   <para>Iterates through hooks of the specified <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hooks to search for.</typeparam>
		/// <param name="obj">Object to search hooks of the specified <typeparamref name="THook"/> type in.</param>
		/// <returns>Hooks of the specified <typeparamref name="THook"/> type, or an empty collection.</returns>
		public static IEnumerable<THook> GetHooks<THook>(this ObjectReal obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		/// <summary>
		///   <para>Iterates through hooks of the specified <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hooks to search for.</typeparam>
		/// <param name="obj">Object to search hooks of the specified <typeparamref name="THook"/> type in.</param>
		/// <returns>Hooks of the specified <typeparamref name="THook"/> type, or an empty collection.</returns>
		public static IEnumerable<THook> GetHooks<THook>(this StatusEffect obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();
		/// <summary>
		///   <para>Iterates through hooks of the specified <typeparamref name="THook"/> type.</para>
		/// </summary>
		/// <typeparam name="THook">Type of the hooks to search for.</typeparam>
		/// <param name="obj">Object to search hooks of the specified <typeparamref name="THook"/> type in.</param>
		/// <returns>Hooks of the specified <typeparamref name="THook"/> type, or an empty collection.</returns>
		public static IEnumerable<THook> GetHooks<THook>(this Trait obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false)?.GetHooks<THook>() ?? Enumerable.Empty<THook>();

		/// <summary>
		///   <para>Gets a <see cref="HookController{T}"/> associated with the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object whose <see cref="HookController{T}"/> is to be returned.</param>
		/// <returns><see cref="HookController{T}"/> associated with the specified <paramref name="obj"/>, if it exists; otherwise, <see langword="null"/>.</returns>
		public static HookController<InvItem> GetHookController(this InvItem obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false);
		/// <summary>
		///   <para>Gets a <see cref="HookController{T}"/> associated with the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object whose <see cref="HookController{T}"/> is to be returned.</param>
		/// <returns><see cref="HookController{T}"/> associated with the specified <paramref name="obj"/>, if it exists; otherwise, <see langword="null"/>.</returns>
		public static HookController<Agent> GetHookController(this Agent obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false);
		/// <summary>
		///   <para>Gets a <see cref="HookController{T}"/> associated with the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object whose <see cref="HookController{T}"/> is to be returned.</param>
		/// <returns><see cref="HookController{T}"/> associated with the specified <paramref name="obj"/>, if it exists; otherwise, <see langword="null"/>.</returns>
		public static HookController<ObjectReal> GetHookController(this ObjectReal obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false);
		/// <summary>
		///   <para>Gets a <see cref="HookController{T}"/> associated with the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object whose <see cref="HookController{T}"/> is to be returned.</param>
		/// <returns><see cref="HookController{T}"/> associated with the specified <paramref name="obj"/>, if it exists; otherwise, <see langword="null"/>.</returns>
		public static HookController<StatusEffect> GetHookController(this StatusEffect obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false);
		/// <summary>
		///   <para>Gets a <see cref="HookController{T}"/> associated with the specified <paramref name="obj"/>.</para>
		/// </summary>
		/// <param name="obj">Object whose <see cref="HookController{T}"/> is to be returned.</param>
		/// <returns><see cref="HookController{T}"/> associated with the specified <paramref name="obj"/>, if it exists; otherwise, <see langword="null"/>.</returns>
		public static HookController<Trait> GetHookController(this Trait obj)
			=> GetHookController(obj, ref obj.__RogueLibsHooks, false);

		/// <summary>
		///   <para>Gets the <paramref name="statusEffect"/>'s parent <see cref="StatusEffects"/> object.</para>
		/// </summary>
		/// <param name="statusEffect">Object to get the parent <see cref="StatusEffects"/> for.</param>
		/// <returns><see cref="StatusEffects"/> that holds the specified <paramref name="statusEffect"/>.</returns>
		public static StatusEffects GetStatusEffects(this StatusEffect statusEffect)
			=> (StatusEffects)statusEffect.__RogueLibsContainer;
		/// <summary>
		///   <para>Gets the <paramref name="trait"/>'s parent <see cref="StatusEffects"/> object.</para>
		/// </summary>
		/// <param name="trait">Object to get the parent <see cref="StatusEffects"/> for.</param>
		/// <returns><see cref="StatusEffects"/> that holds the specified <paramref name="trait"/>.</returns>
		public static StatusEffects GetStatusEffects(this Trait trait)
			=> (StatusEffects)trait.__RogueLibsContainer;

		/// <summary>
		///   <para>Gets the <see cref="InventoryEvents"/> associated with the specified <paramref name="inventory"/>.</para>
		/// </summary>
		/// <param name="inventory">Inventory to get <see cref="InventoryEvents"/> for.</param>
		/// <returns><see cref="InventoryEvents"/> associated with the specified <paramref name="inventory"/>.</returns>
		public static InventoryEvents GetEvents(this InvDatabase inventory)
		{
			if (inventory.__RogueLibsEvents is InventoryEvents events) return events;
			inventory.__RogueLibsEvents = events = new InventoryEvents(inventory);
			return events;
		}

		/// <summary>
		///   <para>Creates a new item of the specified <typeparamref name="T"/> type and adds it to the specified <paramref name="inventory"/>.</para>
		/// </summary>
		/// <typeparam name="T">Type of the custom item to create and add to the specified <paramref name="inventory"/>.</typeparam>
		/// <param name="inventory">Inventory to add the created custom item to.</param>
		/// <param name="count">Amount of the custom item to add to the specified <paramref name="inventory"/>.</param>
		/// <returns><typeparamref name="T"/> hook for the created custom item.</returns>
		public static T AddItem<T>(this InvDatabase inventory, int count)
			where T : CustomItem
		{
			InvItem item = inventory.AddItem(CustomItemInfo.Get<T>().Name, count);
			return item.GetHook<T>();
		}
		/// <summary>
		///   <para>Searches for a custom item of the specified <typeparamref name="T"/> type and returns the first occurence.</para>
		/// </summary>
		/// <typeparam name="T">Type of the custom item to search for.</typeparam>
		/// <param name="inventory">Inventory to search for a custom item of the specified <typeparamref name="T"/> type in.</param>
		/// <returns>First occurence of a custom item of the specified <typeparamref name="T"/> type, if found; otherwise, <see langword="null"/>.</returns>
		public static T GetItem<T>(this InvDatabase inventory)
			where T : CustomItem
		{
			InvItem item = inventory.FindItem(CustomItemInfo.Get<T>().Name);
			return item?.GetHook<T>();
		}

		/// <summary>
		///   <para>Gets the state of the specified <paramref name="buttonData"/> as an <see cref="UnlockButtonState"/> value.</para>
		/// </summary>
		/// <param name="buttonData">Button data to get the state from.</param>
		/// <returns><see cref="UnlockButtonState"/> representing the current state of the specified <paramref name="buttonData"/>.</returns>
		public static UnlockButtonState GetState(this ButtonData buttonData)
		{
			if (buttonData.scrollingHighlighted) return UnlockButtonState.Selected;
			if (buttonData.scrollingHighlighted2) return UnlockButtonState.Purchasable;
			if (buttonData.scrollingHighlighted3) return UnlockButtonState.Locked;
			if (buttonData.scrollingHighlighted4) return UnlockButtonState.Disabled;
			else return UnlockButtonState.Normal;
		}
		/// <summary>
		///   <para>Sets the state of the specified <paramref name="buttonData"/> from an <see cref="UnlockButtonState"/> value.</para>
		/// </summary>
		/// <param name="buttonData">Button data to set the state for.</param>
		/// <param name="value"><see cref="UnlockButtonState"/> representing a state of the button.</param>
		public static void SetState(this ButtonData buttonData, UnlockButtonState value)
		{
			if (value == UnlockButtonState.Selected)
			{
				buttonData.scrollingHighlighted = true;
				buttonData.scrollingHighlighted2 = false;
				buttonData.scrollingHighlighted3 = false;
				buttonData.scrollingHighlighted4 = false;
				buttonData.highlightedSprite = buttonData.scrollingMenu?.solidObjectButtonSelected ?? buttonData.characterCreation.solidObjectButtonSelected;
			}
			else if (value == UnlockButtonState.Purchasable)
			{
				buttonData.scrollingHighlighted = false;
				buttonData.scrollingHighlighted2 = true;
				buttonData.scrollingHighlighted3 = false;
				buttonData.scrollingHighlighted4 = false;
				buttonData.highlightedSprite = buttonData.scrollingMenu?.solidObjectButtonLocked ?? buttonData.characterCreation.solidObjectButtonLocked;
			}
			else if (value == UnlockButtonState.Locked)
			{
				buttonData.scrollingHighlighted = false;
				buttonData.scrollingHighlighted2 = false;
				buttonData.scrollingHighlighted3 = true;
				buttonData.scrollingHighlighted4 = false;
				buttonData.highlightedSprite = buttonData.scrollingMenu?.solidObjectButtonRed ?? buttonData.characterCreation.solidObjectButtonRed;
			}
			else if (value == UnlockButtonState.Disabled)
			{
				buttonData.scrollingHighlighted = false;
				buttonData.scrollingHighlighted2 = false;
				buttonData.scrollingHighlighted3 = false;
				buttonData.scrollingHighlighted4 = true;
				buttonData.highlightedSprite = buttonData.scrollingMenu?.solidObjectButton ?? buttonData.characterCreation.solidObjectButton;
			}
			else
			{
				buttonData.scrollingHighlighted = false;
				buttonData.scrollingHighlighted2 = false;
				buttonData.scrollingHighlighted3 = false;
				buttonData.scrollingHighlighted4 = false;
				buttonData.highlightedSprite = buttonData.scrollingMenu?.solidObjectButton ?? buttonData.characterCreation.solidObjectButton;
			}
		}
	}
}

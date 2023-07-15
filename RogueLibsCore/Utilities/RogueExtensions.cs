using System;
using System.Linq;
using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The collection of useful hook-related extension methods.</para>
    /// </summary>
    public static class RogueExtensions
    {
        internal static bool IsDefault<T>([System.Diagnostics.CodeAnalysis.NotNullWhen(false)] this T? value)
        {
            EqualityComparer<T?> comparer = EqualityComparer<T?>.Default;
            return comparer.Equals(value, default);
        }

        /// <summary>
        ///   <para>Adds the specified <paramref name="amount"/> of the <typeparamref name="TItem"/> item to the current <paramref name="inventory"/>.</para>
        /// </summary>
        /// <typeparam name="TItem">The type of the item to add to the <paramref name="inventory"/>.</typeparam>
        /// <param name="inventory">The current inventory.</param>
        /// <param name="amount">The amount of the item to add.</param>
        /// <returns>The added item, if found in the inventory; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inventory"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="amount"/> is less than or equal to 0.</exception>
        public static TItem? AddItem<TItem>(this InvDatabase inventory, int amount) where TItem : CustomItem
        {
            if (inventory is null) throw new ArgumentNullException(nameof(inventory));
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), amount, $"{nameof(amount)} is less than or equal to 0.");
            InvItem? item = inventory.AddItem(CustomItemMetadata.Get<TItem>().Name, amount);
            return item?.GetHook<TItem>();
        }
        /// <summary>
        ///   <para>Finds an item hook that is assignable to a variable of <typeparamref name="TItem"/> type in the current <paramref name="inventory"/>.</para>
        /// </summary>
        /// <typeparam name="TItem">The type of the item hook to search for.</typeparam>
        /// <param name="inventory">The current inventory.</param>
        /// <returns>An item hook assignable to a variable of <typeparamref name="TItem"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inventory"/> is <see langword="null"/>.</exception>
        public static TItem? GetItem<TItem>(this InvDatabase inventory)
        {
            if (inventory is null) throw new ArgumentNullException(nameof(inventory));
            InvItem? item = inventory.InvItemList.Find(static i => !i.GetHook<TItem>().IsDefault());
            return item != null ? item.GetHook<TItem>() : default;
        }
        /// <summary>
        ///   <para>Finds all item hooks that are assignable to a variable of <typeparamref name="TItem"/> type in the current <paramref name="inventory"/>.</para>
        /// </summary>
        /// <typeparam name="TItem">The type of the item hooks to search for.</typeparam>
        /// <param name="inventory">The current inventory.</param>
        /// <returns>An enumerable collection of item hooks that are assignable to a variable of <typeparamref name="TItem"/> type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inventory"/> is <see langword="null"/>.</exception>
        public static IEnumerable<TItem> GetItems<TItem>(this InvDatabase inventory)
        {
            if (inventory is null) throw new ArgumentNullException(nameof(inventory));
            return inventory.InvItemList.SelectMany(static i => i.GetHooks<TItem>()).Where(static i => !i.IsDefault()).ToArray();
        }
        /// <summary>
        ///   <para>Determines whether the current <paramref name="inventory"/> contains an item hook that is assignable to a variable of <typeparamref name="TItem"/> type.</para>
        /// </summary>
        /// <typeparam name="TItem">The type of the item hook to search for.</typeparam>
        /// <param name="inventory">The current inventory.</param>
        /// <returns><see langword="true"/>, if the <paramref name="inventory"/> contains an item that has a hook that is assignable to a variable of <typeparamref name="TItem"/> type; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inventory"/> is <see langword="null"/>.</exception>
        public static bool HasItem<TItem>(this InvDatabase inventory)
        {
            if (inventory is null) throw new ArgumentNullException(nameof(inventory));
            return inventory.InvItemList.Exists(static i => !i.GetHook<TItem>().IsDefault());
        }
        /// <summary>
        ///   <para>Determines whether the sum of item counts of the items, that have hooks that are assignable to a variable of <typeparamref name="TItem"/> type, is larger than or equal to the specified <paramref name="amount"/>.</para>
        /// </summary>
        /// <typeparam name="TItem">The type of the item hooks to search for.</typeparam>
        /// <param name="inventory">The current inventory.</param>
        /// <param name="amount">The required amount of items.</param>
        /// <returns><see langword="true"/>, if the sum of item counts of the found items is larger than or equal to the specified <paramref name="amount"/>; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inventory"/> is <see langword="null"/>.</exception>
        public static bool HasItem<TItem>(this InvDatabase inventory, int amount)
        {
            if (inventory is null) throw new ArgumentNullException(nameof(inventory));
            int sum = inventory.InvItemList.FindAll(static i => !i.GetHook<TItem>().IsDefault()).Sum(static i => i.invItemCount);
            return sum >= amount;
        }

        /// <summary>
        ///   <para>Adds the specified <paramref name="amount"/> of the item of the specified <paramref name="itemType"/> to the current <paramref name="inventory"/>.</para>
        /// </summary>
        /// <param name="inventory">The current inventory.</param>
        /// <param name="itemType">The type of the item to add to the <paramref name="inventory"/>.</param>
        /// <param name="amount">The amount of the item to add.</param>
        /// <returns>The added item, if found in the inventory; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inventory"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="amount"/> is less than or equal to 0.</exception>
        public static CustomItem? AddItem(this InvDatabase inventory, Type itemType, int amount)
        {
            if (inventory is null) throw new ArgumentNullException(nameof(inventory));
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), amount, $"{nameof(amount)} is less than or equal to 0.");
            InvItem item = inventory.AddItem(CustomItemMetadata.Get(itemType).Name, amount);
            return item?.GetHooks<CustomItem>().FirstOrDefault(itemType.IsInstanceOfType);
        }
        /// <summary>
        ///   <para>Finds an item hook that is assignable to a variable of the specified <paramref name="itemType"/> in the current <paramref name="inventory"/>.</para>
        /// </summary>
        /// <param name="inventory">The current inventory.</param>
        /// <param name="itemType">The type of the item hook to search for.</param>
        /// <returns>An item hook assignable to a variable of the specified <paramref name="itemType"/>, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inventory"/> is <see langword="null"/>.</exception>
        public static IHook<InvItem>? GetItem(this InvDatabase inventory, Type itemType)
        {
            if (inventory is null) throw new ArgumentNullException(nameof(inventory));
            return inventory.InvItemList.SelectMany(static i => i.GetHooks<IHook<InvItem>>()).FirstOrDefault(itemType.IsInstanceOfType);
        }
        /// <summary>
        ///   <para>Finds all item hooks that are assignable to a variable of the specified <paramref name="itemType"/> in the current <paramref name="inventory"/>.</para>
        /// </summary>
        /// <param name="inventory">The current inventory.</param>
        /// <param name="itemType">The type of the item hook to search for.</param>
        /// <returns>An enumerable collection of item hooks that are assignable to a variable of the specified <paramref name="itemType"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inventory"/> is <see langword="null"/>.</exception>
        public static IEnumerable<IHook<InvItem>> GetItems(this InvDatabase inventory, Type itemType)
        {
            if (inventory is null) throw new ArgumentNullException(nameof(inventory));
            return inventory.InvItemList.SelectMany(static i => i.GetHooks<IHook<InvItem>>()).Where(itemType.IsInstanceOfType).ToArray();
        }
        /// <summary>
        ///   <para>Determines whether the current <paramref name="inventory"/> contains an item hook that is assignable to a variable of the specified <paramref name="itemType"/>.</para>
        /// </summary>
        /// <param name="inventory">The current inventory.</param>
        /// <param name="itemType">The type of the item hook to search for.</param>
        /// <returns><see langword="true"/>, if the <paramref name="inventory"/> contains an item that has a hook that is assignable to a variable of the specified <paramref name="itemType"/>; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inventory"/> is <see langword="null"/>.</exception>
        public static bool HasItem(this InvDatabase inventory, Type itemType)
        {
            if (inventory is null) throw new ArgumentNullException(nameof(inventory));
            return inventory.InvItemList.Exists(i => i.GetHooks<IHook<InvItem>>().Any(itemType.IsInstanceOfType));
        }
        /// <summary>
        ///   <para>Determines whether the sum of item counts of the items, that have hooks that are assignable to a variable of the specified <paramref name="itemType"/>, is larger than or equal to the specified <paramref name="amount"/>.</para>
        /// </summary>
        /// <param name="inventory">The current inventory.</param>
        /// <param name="itemType">The type of the item hook to search for.</param>
        /// <param name="amount">The required amount of items.</param>
        /// <returns><see langword="true"/>, if the sum of item counts of the found items is larger than or equal to the specified <paramref name="amount"/>; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="inventory"/> is <see langword="null"/>.</exception>
        public static bool HasItem(this InvDatabase inventory, Type itemType, int amount)
        {
            if (inventory is null) throw new ArgumentNullException(nameof(inventory));
            int sum = inventory.InvItemList.Where(i => i.GetHooks<IHook<InvItem>>().Any(itemType.IsInstanceOfType)).Sum(static i => i.invItemCount);
            return sum >= amount;
        }

        /// <summary>
        ///   <para>Gives the specified <typeparamref name="TAbility"/> ability to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <typeparam name="TAbility">The ability type to give to the <paramref name="agent"/>.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <returns>The given ability.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static TAbility? GiveAbility<TAbility>(this Agent agent) where TAbility : CustomAbility
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            string abilityName = CustomItemMetadata.Get<TAbility>().Name;
            agent.statusEffects.GiveSpecialAbility(abilityName);
            return agent.inventory.equippedSpecialAbility.GetHook<TAbility>();
        }
        /// <summary>
        ///   <para>Returns the <see cref="CustomAbility"/> hook associated with the current <paramref name="agent"/>'s special ability.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <returns>The <see cref="CustomAbility"/> hook associated with the <paramref name="agent"/>, if found; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static CustomAbility? GetAbility(this Agent agent)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.inventory.equippedSpecialAbility?.GetHook<CustomAbility>();
        }
        /// <summary>
        ///   <para>Finds an item hook assignable to a variable of the specified <typeparamref name="TAbility"/> type associated with the current <paramref name="agent"/>'s special ability.</para>
        /// </summary>
        /// <typeparam name="TAbility">The type of the item hook to search for.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <returns>The item hook assignable to a variable of the specified <typeparamref name="TAbility"/> type associated with the <paramref name="agent"/>'s special ability, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static TAbility? GetAbility<TAbility>(this Agent agent)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            InvItem item = agent.inventory.equippedSpecialAbility;
            return item != null ? item.GetHook<TAbility>() : default;
        }
        /// <summary>
        ///   <para>Determines whether the current agent has an item hook assignable to a variable of the specified <typeparamref name="TAbility"/> type associated with the current <paramref name="agent"/>'s special ability.</para>
        /// </summary>
        /// <typeparam name="TAbility">The type of the item hook to search for.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <returns><see langword="true"/>, if the current agent's special ability contains an item hook that is assignable to a variable of the <typeparamref name="TAbility"/> type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static bool HasAbility<TAbility>(this Agent agent)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            InvItem item = agent.inventory.equippedSpecialAbility;
            return item != null && !item.GetHook<TAbility>().IsDefault();
        }

        /// <summary>
        ///   <para>Gives an ability of the specified <paramref name="abilityType"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="abilityType">Type of the ability to give to the <paramref name="agent"/>.</param>
        /// <returns>The given ability.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static CustomAbility? GiveAbility(this Agent agent, Type abilityType)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            string abilityName = CustomItemMetadata.Get(abilityType).Name;
            agent.statusEffects.GiveSpecialAbility(abilityName);
            return agent.inventory.equippedSpecialAbility.GetHooks<CustomAbility>().FirstOrDefault(abilityType.IsInstanceOfType);
        }
        /// <summary>
        ///   <para>Finds an item hook assignable to a variable of the specified <paramref name="abilityType"/> associated with the current <paramref name="agent"/>'s special ability.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="abilityType">Type of the ability to search for.</param>
        /// <returns>The item hook assignable to a variable of the specified <paramref name="abilityType"/> associated with the <paramref name="agent"/>'s special ability, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static IHook<InvItem>? GetAbility(this Agent agent, Type abilityType)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.inventory.equippedSpecialAbility?.GetHooks<IHook<InvItem>>().FirstOrDefault(abilityType.IsInstanceOfType);
        }
        /// <summary>
        ///   <para>Determines whether the current agent has an item hook assignable to a variable of the specified <paramref name="abilityType"/> associated with the current <paramref name="agent"/>'s special ability.</para>
        /// </summary>
        /// <param name="abilityType">Type of the ability to search for.</param>
        /// <param name="agent">The current agent.</param>
        /// <returns><see langword="true"/>, if the current agent's special ability contains an item hook that is assignable to a variable of the <paramref name="abilityType"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static bool HasAbility(this Agent agent, Type abilityType)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            InvItem item = agent.inventory.equippedSpecialAbility;
            return item != null && item.GetHooks<IHook<InvItem>>().Any(abilityType.IsInstanceOfType);
        }

        /// <summary>
        ///   <para>Adds the specified <typeparamref name="TTrait"/> trait to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <typeparam name="TTrait">The type of the trait to add to the <paramref name="agent"/>.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <returns>The added trait, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static TTrait? AddTrait<TTrait>(this Agent agent) where TTrait : CustomTrait
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            string traitName = CustomTraitMetadata.Get<TTrait>().Name;
            agent.statusEffects.AddTrait(traitName);
            return agent.statusEffects.TraitList.Find(t => t.traitName == traitName)?.GetHook<TTrait>();
        }
        /// <summary>
        ///   <para>Finds a trait hook that is assignable to a variable of <typeparamref name="TTrait"/> type on the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <typeparam name="TTrait">The type of the trait hook to search for.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <returns>A trait hook assignable to a variable of <typeparamref name="TTrait"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static TTrait? GetTrait<TTrait>(this Agent agent)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            Trait trait = agent.statusEffects.TraitList.Find(static t => !t.GetHook<TTrait>().IsDefault());
            return trait != null ? trait.GetHook<TTrait>() : default;
        }
        /// <summary>
        ///   <para>Finds all trait hooks that are assignable to a variable of <typeparamref name="TTrait"/> type on the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <typeparam name="TTrait">The type of the trait hooks to search for.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <returns>An enumerable collection of trait hooks that are assignable to a variable of <typeparamref name="TTrait"/> type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static IEnumerable<TTrait> GetTraits<TTrait>(this Agent agent)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.TraitList.SelectMany(static t => t.GetHooks<TTrait>()).Where(static t => !t.IsDefault()).ToArray();
        }
        /// <summary>
        ///   <para>Determines whether the current <paramref name="agent"/> has a trait with a hook that is assignable to a variable of <typeparamref name="TTrait"/> type.</para>
        /// </summary>
        /// <typeparam name="TTrait">The type of the trait hook to search for.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <returns><see langword="true"/>, if the <paramref name="agent"/> has a trait that has a hook that is assignable to a variable of <typeparamref name="TTrait"/> type; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static bool HasTrait<TTrait>(this Agent agent)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.TraitList.Exists(static t => !t.GetHook<TTrait>().IsDefault());
        }

        /// <summary>
        ///   <para>Adds a trait of the specified <paramref name="traitType"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="traitType">The type of the trait to add to the <paramref name="agent"/>.</param>
        /// <returns>The added trait, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static CustomTrait? AddTrait(this Agent agent, Type traitType)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            string traitName = CustomTraitMetadata.Get(traitType).Name;
            agent.statusEffects.AddTrait(traitName);
            return (CustomTrait?)agent.GetTrait(traitType);
        }
        /// <summary>
        ///   <para>Finds a trait hook that is assignable to a variable of the specified <paramref name="traitType"/> on the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="traitType">The type of the trait hook to search for.</param>
        /// <returns>A trait hook assignable to a variable of the specified <paramref name="traitType"/>, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static IHook<Trait>? GetTrait(this Agent agent, Type traitType)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.TraitList.SelectMany(static t => t.GetHooks<IHook<Trait>>()).FirstOrDefault(traitType.IsInstanceOfType);
        }
        /// <summary>
        ///   <para>Finds all trait hooks that are assignable to a variable of the specified <paramref name="traitType"/> on the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="traitType">The type of the trait hook to search for.</param>
        /// <returns>An enumerable collection of trait hooks that are assignable to a variable of the specified <paramref name="traitType"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static IEnumerable<IHook<Trait>> GetTraits(this Agent agent, Type traitType)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.TraitList.SelectMany(static t => t.GetHooks<IHook<Trait>>()).Where(traitType.IsInstanceOfType).ToArray();
        }
        /// <summary>
        ///   <para>Determines whether the current <paramref name="agent"/> has a trait with a hook that is assignable to a variable of the specified <paramref name="traitType"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="traitType">The type of the trait hook to search for.</param>
        /// <returns><see langword="true"/>, if the <paramref name="agent"/> has a trait that has a hook that is assignable to a variable of the specified <paramref name="traitType"/>; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static bool HasTrait(this Agent agent, Type traitType)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.TraitList.Exists(t => t.GetHooks<IHook<Trait>>().Any(traitType.IsInstanceOfType));
        }

        /// <summary>
        ///   <para>Adds a trait with the specified <paramref name="traitName"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="traitName">The name of the trait to add.</param>
        /// <returns>The added trait, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static Trait? AddTrait(this Agent agent, string traitName)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            agent.statusEffects.AddTrait(traitName);
            return agent.GetTrait(traitName);
        }
        /// <summary>
        ///   <para>Finds a trait with the specified <paramref name="traitName"/> on the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="traitName">The name of the trait to search for.</param>
        /// <returns>The trait, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static Trait? GetTrait(this Agent agent, string traitName)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.TraitList.Find(t => t.traitName == traitName);
        }
        /// <summary>
        ///   <para>Determines whether the current <paramref name="agent"/> has a trait with the specified <paramref name="traitName"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="traitName">The name of the trait to search for.</param>
        /// <returns><see langword="true"/>, if the current <paramref name="agent"/> has a trait with the specified <paramref name="traitName"/>; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static bool HasTrait(this Agent agent, string traitName)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.hasTrait(traitName);
        }

        /// <summary>
        ///   <para>Adds the specified <typeparamref name="TEffect"/> effect to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <typeparam name="TEffect">The type of the effect to add to the <paramref name="agent"/>.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <returns>The added effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static TEffect? AddEffect<TEffect>(this Agent agent) where TEffect : CustomEffect
            => AddEffect<TEffect>(agent, default(CreateEffectInfo));
        /// <summary>
        ///   <para>Adds the specified <typeparamref name="TEffect"/> effect with the <paramref name="specificTime"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <typeparam name="TEffect">The type of the effect to add to the <paramref name="agent"/>.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <param name="specificTime">The effect's time.</param>
        /// <returns>The added effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static TEffect? AddEffect<TEffect>(this Agent agent, int specificTime) where TEffect : CustomEffect
            => AddEffect<TEffect>(agent, new CreateEffectInfo(specificTime));
        /// <summary>
        ///   <para>Adds the specified <typeparamref name="TEffect"/> effect with the specified <paramref name="causerAgent"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <typeparam name="TEffect">The type of the effect to add to the <paramref name="agent"/>.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <param name="causerAgent">The agent that caused this effect.</param>
        /// <returns>The added effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static TEffect? AddEffect<TEffect>(this Agent agent, Agent causerAgent) where TEffect : CustomEffect
            => AddEffect<TEffect>(agent, new CreateEffectInfo(causerAgent));
        /// <summary>
        ///   <para>Adds the specified <typeparamref name="TEffect"/> effect with the specified <paramref name="causerAgent"/> and <paramref name="specificTime"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <typeparam name="TEffect">The type of the effect to add to the <paramref name="agent"/>.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <param name="causerAgent">The agent that caused this effect.</param>
        /// <param name="specificTime">The effect's time.</param>
        /// <returns>The added effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static TEffect? AddEffect<TEffect>(this Agent agent, Agent causerAgent, int specificTime) where TEffect : CustomEffect
            => AddEffect<TEffect>(agent, new CreateEffectInfo(causerAgent, specificTime));
        /// <summary>
        ///   <para>Adds the specified <typeparamref name="TEffect"/> effect with the specified <paramref name="info"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <typeparam name="TEffect">The type of the effect to add to the <paramref name="agent"/>.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <param name="info">The struct containing effect initialization info.</param>
        /// <returns>The added effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static TEffect? AddEffect<TEffect>(this Agent agent, CreateEffectInfo info) where TEffect : CustomEffect
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            string effectName = CustomEffectMetadata.Get<TEffect>().Name;
            agent.statusEffects.AddStatusEffect(effectName, !info.DontShowText, info.CauserAgent,
                agent.objectMult.IsFromClient(), info.IgnoreElectronic, info.SpecificTime != 0 ? info.SpecificTime : -1);
            return agent.GetEffect<TEffect>();
        }

        /// <summary>
        ///   <para>Adds an effect of the specified <paramref name="effectType"/> with the specified <paramref name="info"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="effectType">The type of the effect to add to the <paramref name="agent"/>.</param>
        /// <param name="info">The struct containing effect initialization info.</param>
        /// <returns>The added effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static CustomEffect? AddEffect(this Agent agent, Type effectType, CreateEffectInfo info)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            string effectName = CustomEffectMetadata.Get(effectType).Name;
            agent.statusEffects.AddStatusEffect(effectName, !info.DontShowText, info.CauserAgent, agent.objectMult.IsFromClient(), info.IgnoreElectronic, info.SpecificTime != 0 ? info.SpecificTime : -1);
            return (CustomEffect?)agent.GetEffect(effectType);
        }

        /// <summary>
        ///   <para>Finds an effect hook that is assignable to a variable of <typeparamref name="TEffect"/> type on the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <typeparam name="TEffect">The type of the effect hook to search for.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <returns>An effect hook assignable to a variable of <typeparamref name="TEffect"/> type, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static TEffect? GetEffect<TEffect>(this Agent agent)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            StatusEffect? effect = agent.statusEffects.StatusEffectList.Find(static s => !s.GetHook<TEffect>().IsDefault());
            return effect != null ? effect.GetHook<TEffect>() : default;
        }
        /// <summary>
        ///   <para>Finds all effect hooks that are assignable to a variable of <typeparamref name="TEffect"/> type on the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <typeparam name="TEffect">The type of the effect hooks to search for.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <returns>An enumerable collection of effect hooks that are assignable to a variable of <typeparamref name="TEffect"/> type.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static IEnumerable<TEffect> GetEffects<TEffect>(this Agent agent)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.StatusEffectList.SelectMany(static s => s.GetHooks<TEffect>()).Where(static e => !e.IsDefault()).ToArray();
        }
        /// <summary>
        ///   <para>Determines whether the current <paramref name="agent"/> has an effect with a hook that is assignable to a variable of <typeparamref name="TEffect"/> type.</para>
        /// </summary>
        /// <typeparam name="TEffect">The type of the effect hook to search for.</typeparam>
        /// <param name="agent">The current agent.</param>
        /// <returns><see langword="true"/>, if the <paramref name="agent"/> has an effect that has a hook that is assignable to a variable of <typeparamref name="TEffect"/> type; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static bool HasEffect<TEffect>(this Agent agent)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.StatusEffectList.Exists(static s => !s.GetHook<TEffect>().IsDefault());
        }

        /// <summary>
        ///   <para>Finds an effect hook that is assignable to a variable of the specified <paramref name="effectType"/> on the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="effectType">The type of the effect hook to search for.</param>
        /// <returns>An effect hook assignable to a variable of the specified <paramref name="effectType"/>, if found; otherwise, <see langword="default"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static IHook<StatusEffect>? GetEffect(this Agent agent, Type effectType)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.StatusEffectList.SelectMany(static s => s.GetHooks<IHook<StatusEffect>>())
                        .FirstOrDefault(effectType.IsInstanceOfType);
        }
        /// <summary>
        ///   <para>Finds all effect hooks that are assignable to a variable of the specified <paramref name="effectType"/> on the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="effectType">The type of the effect hook to search for.</param>
        /// <returns>An enumerable collection of effect hooks that are assignable to a variable of the specified <paramref name="effectType"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static IEnumerable<IHook<StatusEffect>> GetEffects(this Agent agent, Type effectType)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.StatusEffectList.SelectMany(static s => s.GetHooks<IHook<StatusEffect>>())
                        .Where(effectType.IsInstanceOfType).ToArray();
        }
        /// <summary>
        ///   <para>Determines whether the current <paramref name="agent"/> has an effect with a hook that is assignable to a variable of the specified <paramref name="effectType"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="effectType">The type of the effect hook to search for.</param>
        /// <returns><see langword="true"/>, if the <paramref name="agent"/> has an effect that has a hook that is assignable to a variable of the specified <paramref name="effectType"/>; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static bool HasEffect(this Agent agent, Type effectType)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.StatusEffectList.Any(s => s.GetHooks<IHook<StatusEffect>>().Any(effectType.IsInstanceOfType));
        }

        /// <summary>
        ///   <para>Adds an effect with the specified <paramref name="effectName"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="effectName">The name of the effect to add.</param>
        /// <returns>The added effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static StatusEffect? AddEffect(this Agent agent, string effectName)
            => AddEffect(agent, effectName, default(CreateEffectInfo));
        /// <summary>
        ///   <para>Adds an effect with the specified <paramref name="effectName"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="effectName">The name of the effect to add.</param>
        /// <param name="specificTime">The effect's time.</param>
        /// <returns>The added effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static StatusEffect? AddEffect(this Agent agent, string effectName, int specificTime)
            => AddEffect(agent, effectName, new CreateEffectInfo(specificTime));
        /// <summary>
        ///   <para>Adds an effect with the specified <paramref name="effectName"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="effectName">The name of the effect to add.</param>
        /// <param name="causerAgent">The agent that caused this effect.</param>
        /// <returns>The added effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static StatusEffect? AddEffect(this Agent agent, string effectName, Agent causerAgent)
            => AddEffect(agent, effectName, new CreateEffectInfo(causerAgent));
        /// <summary>
        ///   <para>Adds an effect with the specified <paramref name="effectName"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="effectName">The name of the effect to add.</param>
        /// <param name="causerAgent">The agent that caused this effect.</param>
        /// <param name="specificTime">The effect's time.</param>
        /// <returns>The added effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static StatusEffect? AddEffect(this Agent agent, string effectName, Agent causerAgent, int specificTime)
            => AddEffect(agent, effectName, new CreateEffectInfo(causerAgent, specificTime));
        /// <summary>
        ///   <para>Adds an effect with the specified <paramref name="effectName"/> and <paramref name="info"/> to the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="effectName">The name of the effect to add.</param>
        /// <param name="info">The struct containing effect initialization info.</param>
        /// <returns>The added effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static StatusEffect? AddEffect(this Agent agent, string effectName, CreateEffectInfo info)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            agent.statusEffects.AddStatusEffect(effectName, !info.DontShowText, info.CauserAgent,
                agent.objectMult.IsFromClient(), info.IgnoreElectronic, info.SpecificTime != 0 ? info.SpecificTime : -1);
            return agent.GetEffect(effectName);
        }

        /// <summary>
        ///   <para>Finds an effect with the specified <paramref name="effectName"/> on the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="effectName">The name of the effect to search for.</param>
        /// <returns>The effect, if found on the character; otherwise, <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static StatusEffect? GetEffect(this Agent agent, string effectName)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.StatusEffectList.Find(s => s.statusEffectName == effectName);
        }
        /// <summary>
        ///   <para>Determines whether the current <paramref name="agent"/> has an effect with the specified <paramref name="effectName"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="effectName">The name of the effect to search for.</param>
        /// <returns><see langword="true"/>, if the current <paramref name="agent"/> has an effect with the specified <paramref name="effectName"/>; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static bool HasEffect(this Agent agent, string effectName)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.statusEffects.StatusEffectList.Exists(s => s.statusEffectName == effectName);
        }

        /// <summary>
        ///   <para>Changes the current <paramref name="agent"/>'s health by the specified <paramref name="healthChange"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="healthChange">The health delta.</param>
        public static void ChangeHealth(this Agent agent, float healthChange)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            agent.statusEffects.ChangeHealth(healthChange);
        }
        /// <summary>
        ///   <para>Changes the current <paramref name="agent"/>'s health by the specified <paramref name="healthChange"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <param name="healthChange">The health delta.</param>
        /// <param name="causer">The object that damaged the current agent.</param>
        public static void ChangeHealth(this Agent agent, float healthChange, PlayfieldObject causer)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            agent.statusEffects.ChangeHealth(healthChange, causer);
        }
        /// <summary>
        ///   <para>Returns the last <see cref="Bullet"/> fired by the current <paramref name="agent"/>.</para>
        /// </summary>
        /// <param name="agent">The current agent.</param>
        /// <returns>The last <see cref="Bullet"/> fired by the current <paramref name="agent"/>, or <see langword="null"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="agent"/> is <see langword="null"/>.</exception>
        public static Bullet? GetLastFiredBullet(this Agent agent)
        {
            if (agent is null) throw new ArgumentNullException(nameof(agent));
            return agent.GetHook<LastFiredBulletHook>()?.LastFiredBullet;
        }
    }
}

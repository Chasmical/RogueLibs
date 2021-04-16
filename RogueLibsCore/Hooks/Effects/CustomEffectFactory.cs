using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Base interface for <see cref="CustomEffectFactory{TEffect}"/>.</para>
	/// </summary>
	public interface ICustomEffectFactory
	{
		/// <summary>
		///   <para>Default information about a custom status effect, defined in the type's attributes.</para>
		/// </summary>
		CustomEffectInfo EffectInfo { get; }
	}
	/// <summary>
	///   <para>Represents a specialized <see cref="IHookFactory{T}"/> for the <typeparamref name="TEffect"/> custom status effect type.</para>
	/// </summary>
	/// <typeparam name="TEffect">Custom status effect's type.</typeparam>
	public sealed class CustomEffectFactory<TEffect> : HookFactoryBase<StatusEffect>, ICustomEffectFactory where TEffect : CustomEffect, new()
	{
		/// <inheritdoc/>
		public CustomEffectInfo EffectInfo { get; } = CustomEffectInfo.Get(typeof(TEffect));
		/// <inheritdoc/>
		public override bool CanCreate(StatusEffect obj) => !(obj is null) && obj.statusEffectName == EffectInfo.Name;
		/// <inheritdoc/>
		public override IHook<StatusEffect> CreateHook(StatusEffect obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			IHook<StatusEffect> hook = new TEffect() { EffectInfo = EffectInfo };
			hook.Instance = obj;
			return hook;
		}
	}
}

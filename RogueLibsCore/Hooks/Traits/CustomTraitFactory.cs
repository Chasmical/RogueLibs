using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Base interface for <see cref="CustomTraitFactory{TTrait}"/>.</para>
	/// </summary>
	public interface ICustomTraitFactory
	{
		/// <summary>
		///   <para>Default information about a custom trait, defined in the type's attributes.</para>
		/// </summary>
		CustomTraitInfo TraitInfo { get; }
	}
	/// <summary>
	///   <para>Represents a specialized <see cref="IHookFactory{T}"/> for the <typeparamref name="TTrait"/> custom trait type.</para>
	/// </summary>
	/// <typeparam name="TTrait">Custom trait's type.</typeparam>
	public sealed class CustomTraitFactory<TTrait> : HookFactoryBase<Trait>, ICustomTraitFactory where TTrait : CustomTrait, new()
	{
		/// <inheritdoc/>
		public CustomTraitInfo TraitInfo { get; } = CustomTraitInfo.Get(typeof(TTrait));
		/// <inheritdoc/>
		public override bool CanCreate(Trait obj) => !(obj is null) && obj.traitName == TraitInfo.Name;
		/// <inheritdoc/>
		public override IHook<Trait> CreateHook(Trait obj)
		{
			if (obj is null) throw new ArgumentNullException(nameof(obj));
			IHook<Trait> hook = new TTrait() { TraitInfo = TraitInfo };
			hook.Instance = obj;
			return hook;
		}
	}
}

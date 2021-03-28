using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a base class for all custom effects.</para>
	/// </summary>
	public abstract class CustomEffect : HookBase<StatusEffect>
	{
		/// <inheritdoc/>
		protected override sealed void Initialize() => OnAdded();

		public abstract void OnAdded();
		public abstract void OnRemoved();
		public abstract void OnUpdated(ref float nextUpdateDelay);

		/// <summary>
		///   <para>Default information about a custom status effect, defined in the type's attributes.</para>
		/// </summary>
		public CustomEffectInfo EffectInfo { get; internal set; }
	}
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
	/// <summary>
	///   <para>Default information about a <see cref="CustomEffect"/>, specified in the type's attributes.</para>
	/// </summary>
	public sealed class CustomEffectInfo
	{
		/// <summary>
		///   <para>Gets the status effect's name/id.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Gets the status effect's default time. 9999 is infinite time.</para>
		/// </summary>
		public int DefaultTime { get; }
		/// <summary>
		///   <para>Gets the status effect's default hate, that is added when applied to a non-player agent.</para>
		/// </summary>
		public int DefaultHate { get; }
		/// <summary>
		///   <para>Determines whether the status effect is positive.</para>
		/// </summary>
		public bool IsPositive { get; }
		/// <summary>
		///   <para>Determines whether the status effect is affected by the Antidote's "Stable System" effect.</para>
		/// </summary>
		public bool IsCurable { get; }

		private static readonly Dictionary<Type, CustomEffectInfo> infos = new Dictionary<Type, CustomEffectInfo>();
		/// <summary>
		///   <para>Gets a <see cref="CustomEffectInfo"/> for the specified <paramref name="type"/>.</para>
		/// </summary>
		/// <param name="type"><see cref="CustomEffect"/> type.</param>
		/// <returns><see cref="CustomEffectInfo"/> containing the default information about the specified custom effect <paramref name="type"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="type"/> is not a <see cref="CustomEffect"/>.</exception>
		public static CustomEffectInfo Get(Type type) => infos.TryGetValue(type, out CustomEffectInfo info) ? info : (infos[type] = new CustomEffectInfo(type));
		/// <summary>
		///   <para>Gets a <see cref="CustomEffectInfo"/> for the specified <typeparamref name="TEffect"/>.</para>
		/// </summary>
		/// <typeparam name="TEffect"><see cref="CustomEffect"/> type.</typeparam>
		/// <returns><see cref="CustomEffectInfo"/> containing the default information about the specified custom effect <typeparamref name="TEffect"/>.</returns>
		public static CustomEffectInfo Get<TEffect>() where TEffect : CustomEffect => Get(typeof(TEffect));

		private CustomEffectInfo(Type type)
		{
			if (!typeof(CustomEffect).IsAssignableFrom(type)) throw new ArgumentException($"The specified type is not a {nameof(CustomEffect)}!", nameof(type));
			EffectNameAttribute attr = type.GetCustomAttribute<EffectNameAttribute>();
			Name = attr?.Name ?? type.Name;
			DefaultTime = attr?.DefaultTime ?? 30;
			DefaultHate = attr?.DefaultHate ?? 5;
			IsPositive = attr?.IsPositive ?? false;
			IsCurable = attr?.IsCurable ?? false;
		}
	}
	/// <summary>
	///   <para>Specifies the custom status effect's name and other parameters. If not used, the type's name and default values are used instead.</para>
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class EffectNameAttribute : Attribute
	{
		/// <summary>
		///   <para>Name/id of the status effect.</para>
		/// </summary>
		public string Name { get; }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="EffectNameAttribute"/>.</para>
		/// </summary>
		public EffectNameAttribute() { }
		/// <summary>
		///   <para>Initializes a new instance of <see cref="EffectNameAttribute"/> with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="name">Name/id of the custom effect.</param>
		/// <exception cref="ArgumentNullException"><paramref name="name"/> is <see langword="null"/>.</exception>
		public EffectNameAttribute(string name) => Name = name ?? throw new ArgumentNullException(nameof(name));

		private int defaultTime = 30;
		/// <summary>
		///   <para>Gets/sets the status effect's default time, in seconds. 9999 is infinite time. Default value: 30.</para>
		/// </summary>
		public int DefaultTime
		{
			get => defaultTime;
			set
			{
				if (defaultTime < 0) throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(DefaultTime)} must be larger than or equal to 0.");
				defaultTime = value;
			}
		}
		/// <summary>
		///   <para>Gets/sets the status effect's default hate, that is added when applied to a non-player agent. Default value: 5.</para>
		/// </summary>
		public int DefaultHate { get; set; } = 5;
		/// <summary>
		///   <para>Gets/sets whether the status effect is positive. Default value: <see langword="false"/>.</para>
		/// </summary>
		public bool IsPositive { get; set; }
		/// <summary>
		///   <para>Gets/sets whether the status effect is affected by the Antidote's "Stable System" effect. Default value: <see langword="false"/>.</para>
		/// </summary>
		public bool IsCurable { get; set; }
	}
}

using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom ability.</para>
	/// </summary>
	public abstract class CustomAbility : CustomItem
	{
		/// <inheritdoc/>
		public override void SetupDetails()
		{
			Item.stackable = true;
			Item.initCount = 0;
			Item.lowCountThreshold = 100;
		}

		/// <summary>
		///   <para>The method that is called when the special ability is added.</para>
		/// </summary>
		public abstract void OnAdded();
		/// <summary>
		///   <para>The method that is called when the special ability is pressed.</para>
		/// </summary>
		public abstract void OnPressed();
		internal float lastHeld;

		/// <summary>
		///   <para>The method that is called to determine the special ability indicator over the current target.</para>
		/// </summary>
		/// <returns>The sprite to display over the current target.</returns>
		public virtual Sprite GetIndicator() => gc.gameResources.itemDic.TryGetValue(ItemInfo.Name, out Sprite sprite) ? sprite : null;

		/// <summary>
		///   <para>Gets the last <see cref="PlayfieldObject"/> returned by the <see cref="IAbilityTargetable.FindTarget"/> method.</para>
		/// </summary>
		public PlayfieldObject CurrentTarget { get; internal set; }
	}
}

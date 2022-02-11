using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Collection of extension methods for the <see cref="ButtonData"/> class.</para>
    /// </summary>
    public static class ButtonDataExtensions
    {
        /// <summary>
        ///   <para>Gets the current <paramref name="buttonData"/>'s state represented by the <see cref="UnlockButtonState"/> enumeration.</para>
        /// </summary>
        /// <param name="buttonData">The current button.</param>
        /// <returns>The <see cref="UnlockButtonState"/> enumeration representing the current <paramref name="buttonData"/>'s state.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="buttonData"/> is <see langword="null"/>.</exception>
        public static UnlockButtonState GetState(this ButtonData buttonData)
        {
            if (buttonData is null) throw new ArgumentNullException(nameof(buttonData));
            if (buttonData.scrollingHighlighted) return UnlockButtonState.Selected;
            if (buttonData.scrollingHighlighted2) return UnlockButtonState.Purchasable;
            if (buttonData.scrollingHighlighted3) return UnlockButtonState.Locked;
            if (buttonData.scrollingHighlighted4) return UnlockButtonState.Disabled;
            else return UnlockButtonState.Normal;
        }
        /// <summary>
        ///   <para>Sets the current <paramref name="buttonData"/>'s state represented by the specified <see cref="UnlockButtonState"/> <paramref name="value"/>.</para>
        /// </summary>
        /// <param name="buttonData">The current button.</param>
        /// <param name="value">The <see cref="UnlockButtonState"/> representing the button's state.</param>
        /// <exception cref="ArgumentNullException"><paramref name="buttonData"/> is <see langword="null"/>.</exception>
        public static void SetState(this ButtonData buttonData, UnlockButtonState value)
        {
            if (buttonData is null) throw new ArgumentNullException(nameof(buttonData));
            buttonData.scrollingHighlighted = value == UnlockButtonState.Selected;
            buttonData.scrollingHighlighted2 = value == UnlockButtonState.Purchasable;
            buttonData.scrollingHighlighted3 = value == UnlockButtonState.Locked;
            buttonData.scrollingHighlighted4 = value == UnlockButtonState.Disabled;
            buttonData.highlightedSprite
                = value == UnlockButtonState.Selected
                    ? buttonData.scrollingMenu?.solidObjectButtonSelected ?? buttonData.characterCreation.solidObjectButtonSelected
                : value == UnlockButtonState.Purchasable
                    ? buttonData.scrollingMenu?.solidObjectButtonLocked ?? buttonData.characterCreation.solidObjectButtonLocked
                : value == UnlockButtonState.Locked
                    ? buttonData.scrollingMenu?.solidObjectButtonRed ?? buttonData.characterCreation.solidObjectButtonRed
                : value == UnlockButtonState.Disabled
                    ? buttonData.scrollingMenu?.solidObjectButton ?? buttonData.characterCreation.solidObjectButton
                : buttonData.scrollingMenu?.solidObjectButton ?? buttonData.characterCreation.solidObjectButton;
        }
    }
}

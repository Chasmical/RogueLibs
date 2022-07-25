using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents an interaction.</para>
    /// </summary>
    public abstract class Interaction : IComparable<Interaction>
    {
        /// <summary>
        ///   <para>Gets the <see cref="InteractionModel"/> that the interaction was created for.</para>
        /// </summary>
        public InteractionModel Model { get; internal set; } = null!; // initialized immediately in InteractionModel
        /// <summary>
        ///   <para>Gets the object that the interaction is for.</para>
        /// </summary>
        public PlayfieldObject Object => Model.Object;
        /// <summary>
        ///   <para>Gets the agent that started the interaction.</para>
        /// </summary>
        public Agent Agent => Model.Agent;
        /// <summary>
        ///   <para>Gets the <see cref="InteractionHelper"/> of the interaction.</para>
        /// </summary>
        public InteractionHelper Helper => Model.Helper;

        /// <summary>
        ///   <para>Determines whether the interaction is implicit and should be automatically triggered if it's the only button in the menu.</para>
        /// </summary>
        public virtual bool ImplicitAction => false;
        /// <summary>
        ///   <para>Gets or sets the sorting order of the interaction.</para>
        /// </summary>
        public int SortingOrder { get; set; }
        /// <summary>
        ///   <para>Gets or sets the sorting index of the interaction.</para>
        /// </summary>
        public int SortingIndex { get; set; }

        /// <inheritdoc/>
        public virtual int CompareTo(Interaction? other)
        {
            if (other is null) return 1;
            int res = SortingOrder.CompareTo(other.SortingOrder);
            return res != 0 ? res : SortingIndex.CompareTo(other.SortingIndex);
        }

        /// <summary>
        ///   <para>Gets the interaction's button name.</para>
        /// </summary>
        public string? ButtonName { get; private set; }
        /// <summary>
        ///   <para>Gets the interaction's button price, or <see langword="null"/> if it's not defined.</para>
        /// </summary>
        public int? ButtonPrice { get; private set; }
        /// <summary>
        ///   <para>Gets the interaction's button extra information string that is appended to the button's text.</para>
        /// </summary>
        public string? ButtonExtra { get; private set; }

        /// <summary>
        ///   <para>Initializes the interaction's button with the specified <paramref name="buttonName"/>.</para>
        /// </summary>
        /// <param name="buttonName">The button's name.</param>
        /// <returns><see langword="true"/>, to be used as a return value of <see cref="SetupButton"/>.</returns>
        protected bool SetButton(string buttonName)
            => SetButton(buttonName, null, null);
        /// <summary>
        ///   <para>Initializes the interaction's button with the specified <paramref name="buttonName"/> and <paramref name="buttonExtra"/>.</para>
        /// </summary>
        /// <param name="buttonName">The button's name.</param>
        /// <param name="buttonExtra">The button's extra information, or <see langword="null"/>.</param>
        /// <returns><see langword="true"/>, to be used as a return value of <see cref="SetupButton"/>.</returns>
        protected bool SetButton(string buttonName, string? buttonExtra)
            => SetButton(buttonName, null, buttonExtra);
        /// <summary>
        ///   <para>Initializes the interaction's button with the specified <paramref name="buttonName"/> and <paramref name="buttonPrice"/>.</para>
        /// </summary>
        /// <param name="buttonName">The button's name.</param>
        /// <param name="buttonPrice">The button's price, or <see langword="null"/>.</param>
        /// <returns><see langword="true"/>, to be used as a return value of <see cref="SetupButton"/>.</returns>
        protected bool SetButton(string buttonName, int? buttonPrice)
            => SetButton(buttonName, buttonPrice, null);
        /// <summary>
        ///   <para>Initializes the interaction's button with the specified <paramref name="buttonName"/>, <paramref name="buttonPrice"/> and <paramref name="buttonExtra"/>.</para>
        /// </summary>
        /// <param name="buttonName">The button's name.</param>
        /// <param name="buttonPrice">The button's price, or <see langword="null"/>.</param>
        /// <param name="buttonExtra">The button's extra information, or <see langword="null"/>.</param>
        /// <returns><see langword="true"/>, to be used as a return value of <see cref="SetupButton"/>.</returns>
        protected bool SetButton(string buttonName, int? buttonPrice, string? buttonExtra)
        {
            ButtonName = buttonName;
            ButtonPrice = buttonPrice;
            ButtonExtra = buttonExtra;
            return true;
        }

        /// <summary>
        ///   <para>Stops the current interaction completely.</para>
        /// </summary>
        protected void StopInteraction() => Model.StopInteraction();

        /// <summary>
        ///   <para>Sets up the interaction's button.</para>
        /// </summary>
        /// <returns><see langword="true"/>, if the interaction's button was set up successfully; otherwise, <see langword="false"/>.</returns>
        public abstract bool SetupButton();
        /// <summary>
        ///   <para>Gets called when the interaction's button is pressed.</para>
        /// </summary>
        public abstract void OnPressed();
        /// <summary>
        ///   <para>Gets called when the interaction's button is the only one in the menu and is pressed implicitly.</para>
        /// </summary>
        public virtual void OnPressedImplicitly() => OnPressed();

        // TODO
        // public virtual void OnOpen() { }
        // public virtual void WhileOpen() { }
        // public virtual void OnClose() { }

        // public virtual void OnMouseEnter() { }
        // public virtual void OnMouseOver() { }
        // public virtual void OnMouseExit() { }

    }
    /// <summary>
    ///   <para>Represents an interaction provider.</para>
    /// </summary>
    public interface IInteractionProvider
    {
        /// <summary>
        ///   <para>Returns interactions provided by this instance for the specified interaction <paramref name="model"/>.</para>
        /// </summary>
        /// <param name="model">The <see cref="InteractionModel"/> to get the interactions for.</param>
        /// <returns>An array of interactions provided for the specified interaction <paramref name="model"/>.</returns>
        Interaction[] GetInteractions(InteractionModel model);
    }
}

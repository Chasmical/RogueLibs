using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a custom tooltip.</para>
    /// </summary>
    public struct CustomTooltip
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="text"/>.</para>
        /// </summary>
        /// <param name="text">The tooltip's text.</param>
        public CustomTooltip(string text)
        {
            Text = text;
            Color = null;
        }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="obj"/>.</para>
        /// </summary>
        /// <param name="obj">An object representing the tooltip's text.</param>
        public CustomTooltip(object obj)
        {
            Text = obj?.ToString();
            Color = null;
        }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="text"/> and <paramref name="color"/>.</para>
        /// </summary>
        /// <param name="text">The tooltip's text.</param>
        /// <param name="color">The tooltip's text color.</param>
        public CustomTooltip(string text, Color color)
        {
            Text = text;
            Color = color;
        }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="obj"/> and <paramref name="color"/>.</para>
        /// </summary>
        /// <param name="obj">An object representing the tooltip's text.</param>
        /// <param name="color">The tooltip's text color.</param>
        public CustomTooltip(object obj, Color color)
        {
            Text = obj?.ToString();
            Color = color;
        }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="name"/>.</para>
        /// </summary>
        /// <param name="name">The tooltip's localizable string.</param>
        public CustomTooltip(IName name)
        {
            Text = name.GetCurrentOrDefault();
            Color = null;
        }

        /// <summary>
        ///   <para>Gets the tooltip's text.</para>
        /// </summary>
        public string Text { get; }
        /// <summary>
        ///   <para>Gets the tooltip's text color.</para>
        /// </summary>
        public Color? Color { get; }

        /// <summary>
        ///   <para>Implicitly converts a <see cref="string"/> into a <see cref="CustomTooltip"/>.</para>
        /// </summary>
        /// <param name="text">The tooltip's text.</param>
        public static implicit operator CustomTooltip(string text) => new CustomTooltip(text);
        /// <summary>
        ///   <para>Implicitly converts an <see cref="int"/> into a <see cref="CustomTooltip"/>.</para>
        /// </summary>
        /// <param name="number">The tooltip's text.</param>
        public static implicit operator CustomTooltip(int number) => new CustomTooltip(number.ToString());
        /// <summary>
        ///   <para>Implicitly converts a <see cref="float"/> into a <see cref="CustomTooltip"/>.</para>
        /// </summary>
        /// <param name="number">The tooltip's text.</param>
        public static implicit operator CustomTooltip(float number) => new CustomTooltip(number.ToString());
        /// <summary>
        ///   <para>Implicitly converts a <see cref="CustomName"/> into a <see cref="CustomTooltip"/>.</para>
        /// </summary>
        /// <param name="name">The tooltip's localizable string.</param>
        public static implicit operator CustomTooltip(CustomName name) => new CustomTooltip(name);
        /// <summary>
        ///   <para>Implicitly converts a <see cref="CustomNameInfo"/> into a <see cref="CustomTooltip"/>.</para>
        /// </summary>
        /// <param name="nameInfo">The tooltip's localizable string.</param>
        public static implicit operator CustomTooltip(CustomNameInfo nameInfo) => new CustomTooltip(nameInfo);
    }
}

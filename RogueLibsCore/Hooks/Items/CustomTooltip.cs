using System.Globalization;
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
        /// <param name="text">The text of the tooltip.</param>
        public CustomTooltip(string? text)
        {
            Text = text;
            Color = null;
        }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="text"/> and <paramref name="color"/>.</para>
        /// </summary>
        /// <param name="text">The text of the tooltip.</param>
        /// <param name="color">The color of the text.</param>
        public CustomTooltip(string? text, Color color)
        {
            Text = text;
            Color = color;
        }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="obj"/>.</para>
        /// </summary>
        /// <param name="obj">An object representing the text of the tooltip.</param>
        public CustomTooltip(object? obj)
        {
            Text = obj?.ToString();
            Color = null;
        }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="CustomTooltip"/> structure with the specified <paramref name="obj"/> and <paramref name="color"/>.</para>
        /// </summary>
        /// <param name="obj">An object representing the text of the tooltip.</param>
        /// <param name="color">The color of the tooltip text.</param>
        public CustomTooltip(object? obj, Color color)
        {
            Text = obj?.ToString();
            Color = color;
        }

        /// <summary>
        ///   <para>Gets the text of the tooltip.</para>
        /// </summary>
        public string? Text { get; }
        /// <summary>
        ///   <para>Gets the color of the tooltip text.</para>
        /// </summary>
        public Color? Color { get; }

        /// <summary>
        ///   <para>Implicitly converts a <see cref="string"/> into a <see cref="CustomTooltip"/>.</para>
        /// </summary>
        /// <param name="text">The text of the tooltip.</param>
        public static implicit operator CustomTooltip(string text) => new CustomTooltip(text);
        /// <summary>
        ///   <para>Implicitly converts an <see cref="int"/> into a <see cref="CustomTooltip"/>.</para>
        /// </summary>
        /// <param name="number">The text of the tooltip.</param>
        public static implicit operator CustomTooltip(int number) => new CustomTooltip(number.ToString());
        /// <summary>
        ///   <para>Implicitly converts a <see cref="float"/> into a <see cref="CustomTooltip"/>.</para>
        /// </summary>
        /// <param name="number">The text of the tooltip.</param>
        public static implicit operator CustomTooltip(float number) => new CustomTooltip(number.ToString(CultureInfo.InvariantCulture));
        /// <summary>
        ///   <para>Implicitly converts a <see cref="CustomName"/> into a <see cref="CustomTooltip"/>.</para>
        /// </summary>
        /// <param name="name">The localizable string representing the text of the tooltip.</param>
        public static implicit operator CustomTooltip(CustomName name) => new CustomTooltip(name.GetCurrentOrDefault());
        /// <summary>
        ///   <para>Implicitly converts a <see cref="CustomNameInfo"/> into a <see cref="CustomTooltip"/>.</para>
        /// </summary>
        /// <param name="nameInfo">The localizable string representing the text of the tooltip.</param>
        public static implicit operator CustomTooltip(CustomNameInfo nameInfo) => new CustomTooltip(nameInfo.GetCurrentOrDefault());
    }
}

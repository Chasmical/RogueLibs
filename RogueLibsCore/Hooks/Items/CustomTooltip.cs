using System;
using System.Globalization;
using UnityEngine;

namespace RogueLibsCore
{
    public struct CustomTooltip : IEquatable<CustomTooltip>
    {
        public string? Text { get; set; }
        public Color? Color { get; set; }

        public CustomTooltip(string? text) : this(text, null) { }
        public CustomTooltip(object? obj) : this(obj?.ToString(), null) { }
        public CustomTooltip(object? obj, Color? color) : this(obj?.ToString(), color) { }
        public CustomTooltip(string? text, Color? color)
        {
            Text = text;
            Color = color;
        }

        public readonly bool Equals(CustomTooltip other) => Color == other.Color && Text == other.Text;
        public readonly override bool Equals(object obj) => obj is CustomTooltip other && Equals(other);
        public readonly override int GetHashCode() => (Text?.GetHashCode() ?? 0) ^ (Color?.GetHashCode() ?? 0);
        public readonly override string ToString() => Text ?? "";

        public static CustomTooltip Coalesce(CustomTooltip left, CustomTooltip right)
            => new CustomTooltip(left.Text ?? right.Text, left.Color ?? right.Color);

        public static implicit operator CustomTooltip(string text) => new CustomTooltip(text);
        public static implicit operator CustomTooltip(int number) => new CustomTooltip(number.ToString(CultureInfo.InvariantCulture));
        public static implicit operator CustomTooltip(float number) => new CustomTooltip(number.ToString(CultureInfo.InvariantCulture));

    }
}

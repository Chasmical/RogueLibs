using System;
using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The default implementation of the <see cref="INameProvider"/> interface that uses instances of the <see cref="CustomName"/> class.</para>
    /// </summary>
    public sealed class CustomNameProvider : INameProvider
    {
        /// <summary>
        ///   <para>The <see cref="CustomName"/> dictionary used by the provider, organized by type and name.</para>
        /// </summary>
        public readonly Dictionary<string, Dictionary<string, CustomName>> CustomNames = new Dictionary<string, Dictionary<string, CustomName>>();

        public CustomName FindEntry(string name, string type)
            => CustomNames.TryGetValue(type, out Dictionary<string, CustomName> category)
               && category.TryGetValue(name, out CustomName customName) ? customName : null;
        /// <inheritdoc/>
        public void GetName(string name, string type, ref string result)
        {
            if (name != null && type != null
                && CustomNames.TryGetValue(type, out Dictionary<string, CustomName> category)
                && category.TryGetValue(name, out CustomName customName))
                result = customName.GetCurrentOrDefault();
        }
        /// <summary>
        ///   <para>Adds a <see cref="CustomName"/> with the specified <paramref name="name"/>, <paramref name="type"/> and localization <paramref name="info"/>.</para>
        /// </summary>
        /// <param name="name">The name of the <see cref="CustomName"/> to create.</param>
        /// <param name="type">The type of the <see cref="CustomName"/> to create.</param>
        /// <param name="info">The localization data to initialize <see cref="CustomName"/> with.</param>
        /// <returns>The initialized <see cref="CustomName"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> or <paramref name="type"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentException">A localizable string with the specified <paramref name="name"/> and <paramref name="type"/> already exists in the provider's dictionary.</exception>
        public CustomName AddName(string name, string type, CustomNameInfo info)
        {
            if (name is null || type is null)
                throw new ArgumentNullException(name is null ? nameof(name) : nameof(type));
            if (RogueFramework.IsDebugEnabled(DebugFlags.Names))
                RogueFramework.LogDebug($"Added \"{name}\" name ({type}): {info.GetCurrentOrDefault()}");

            CustomName customName = new CustomName(name, type, info);
            if (!CustomNames.TryGetValue(type, out Dictionary<string, CustomName> category))
                CustomNames.Add(type, category = new Dictionary<string, CustomName>());
            category.Add(name, customName);
            return customName;
        }
    }
}

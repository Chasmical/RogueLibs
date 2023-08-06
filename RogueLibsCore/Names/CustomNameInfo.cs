using System;
using System.Collections;
using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The <see langword="struct"/> implementation of the <see cref="IName"/> interface. Provides properties for getting and setting the 8 default languages' localization texts.</para>
    /// </summary>
    public struct CustomNameInfo : IName, IUsesNameContainer
    {
        /// <summary>
        ///   <para>Initializes a new instance of <see cref="CustomNameInfo"/> structure with the specified <paramref name="english"/> localization text.</para>
        /// </summary>
        /// <param name="english">The English localization text.</param>
        public CustomNameInfo(string english)
            => container = english ?? throw new ArgumentNullException(nameof(english));
        /// <summary>
        ///   <para>Initializes a new instance of <see cref="CustomNameInfo"/> structure with localization texts from the specified <paramref name="dictionary"/>.</para>
        /// </summary>
        /// <param name="dictionary">The dictionary with localization texts.</param>
        public CustomNameInfo(IEnumerable<KeyValuePair<LanguageCode, string>> dictionary)
        {
            if (dictionary is null) throw new ArgumentNullException(nameof(dictionary));
            if (dictionary is IUsesNameContainer name)
                container = NameContainer.Clone(name.GetNameContainer());
            else
            {
                foreach (KeyValuePair<LanguageCode, string> entry in dictionary)
                    container = NameContainer.Set(container, entry.Key, entry.Value);
            }
        }

        /// <summary>
        ///   <para>Gets or sets the English localization text.</para>
        /// </summary>
        public string? English { readonly get => this[LanguageCode.English]; set => this[LanguageCode.English] = value; }
        /// <summary>
        ///   <para>Gets or sets the Spanish localization text.</para>
        /// </summary>
        public string? Spanish { readonly get => this[LanguageCode.Spanish]; set => this[LanguageCode.Spanish] = value; }
        /// <summary>
        ///   <para>Gets or sets the Chinese localization text.</para>
        /// </summary>
        public string? Chinese { readonly get => this[LanguageCode.Chinese]; set => this[LanguageCode.Chinese] = value; }
        /// <summary>
        ///   <para>Gets or sets the German localization text.</para>
        /// </summary>
        public string? German { readonly get => this[LanguageCode.German]; set => this[LanguageCode.German] = value; }
        /// <summary>
        ///   <para>Gets or sets the Brazilian localization text.</para>
        /// </summary>
        public string? Brazilian { readonly get => this[LanguageCode.Brazilian]; set => this[LanguageCode.Brazilian] = value; }
        /// <summary>
        ///   <para>Gets or sets the French localization text.</para>
        /// </summary>
        public string? French { readonly get => this[LanguageCode.French]; set => this[LanguageCode.French] = value; }
        /// <summary>
        ///   <para>Gets or sets the Russian localization text.</para>
        /// </summary>
        public string? Russian { readonly get => this[LanguageCode.Russian]; set => this[LanguageCode.Russian] = value; }
        /// <summary>
        ///   <para>Gets or sets the Korean localization text.</para>
        /// </summary>
        public string? Korean { readonly get => this[LanguageCode.Korean]; set => this[LanguageCode.Korean] = value; }

        private object? container;
        readonly object? IUsesNameContainer.GetNameContainer() => container;

        /// <inheritdoc/>
        public string? this[LanguageCode language]
        {
            readonly get => NameContainer.Get(container, language);
            set => container = NameContainer.Set(container, language, value);
        }

        /// <inheritdoc/>
        public IEnumerator<KeyValuePair<LanguageCode, string>> GetEnumerator()
            => NameContainer.Enumerate(container);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

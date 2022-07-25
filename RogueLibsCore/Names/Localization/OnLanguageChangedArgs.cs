using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Provides data for the <see cref="LanguageService.OnCurrentChanged"/> and <see cref="LanguageService.OnFallBackChanged"/> events.</para>
    /// </summary>
    public class OnLanguageChangedArgs : EventArgs
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="OnLanguageChangedArgs"/> class with the specified <paramref name="previous"/> value and current <paramref name="value"/>.</para>
        /// </summary>
        /// <param name="previous">The previous language.</param>
        /// <param name="value">The current language.</param>
        public OnLanguageChangedArgs(LanguageCode previous, LanguageCode value)
        {
            PreviousValue = previous;
            Value = value;
        }
        /// <summary>
        ///   <para>Gets the previously set language.</para>
        /// </summary>
        public LanguageCode PreviousValue { get; }
        /// <summary>
        ///   <para>Gets the currently set language.</para>
        /// </summary>
        public LanguageCode Value { get; }
    }
}

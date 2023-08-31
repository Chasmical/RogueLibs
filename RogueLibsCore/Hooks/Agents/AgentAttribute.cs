using System;
using System.Collections.ObjectModel;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Specifies custom agent's categories.</para>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AgentCategoriesAttribute : Attribute
    {
        /// <summary>
        ///   <para>Gets the collection of custom agent's categories.</para>
        /// </summary>
        public ReadOnlyCollection<string> Categories { get; }
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="AgentCategoriesAttribute"/> class with the specified <paramref name="categories"/>.</para>
        /// </summary>
        /// <param name="categories">The custom agent's categories.</param>
        public AgentCategoriesAttribute(params string[] categories)
        {
            if (categories is null) throw new ArgumentNullException(nameof(categories));
            Categories = new ReadOnlyCollection<string>(Array.FindAll(categories, static c => c != null));
        }
    }
}

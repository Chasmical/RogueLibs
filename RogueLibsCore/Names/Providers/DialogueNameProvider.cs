using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The implementation of the <see cref="INameProvider"/> interface that resolves dialogue names with "NA_" prefix (No Agent).</para>
    /// </summary>
    public sealed class DialogueNameProvider : INameProvider
    {
        /// <inheritdoc/>
        public void GetName(string? name, string? type, ref string? result)
        {
            if (name is not null && type is not null && result is null
                && type == NameTypes.Dialogue && name.StartsWith("NA_", StringComparison.Ordinal))
            {
                string sub = name.Substring("NA_".Length);
                string newResult = LanguageService.NameDB.GetName(sub, type);
                if (!newResult.StartsWith("E_", StringComparison.Ordinal)) result = newResult;
            }
        }
    }
}

using System;

namespace RogueLibsCore
{
    public static partial class RogueFramework
    {
        /// <summary>
        ///   <para>Determines the RogueLibs' enabled debugging flags.</para>
        /// </summary>
        [Obsolete("DebugFlags enum and all related functionality were removed in RogueLibs v4.0.0.")]
        public static DebugFlags DebugFlags { get; set; }

        /// <summary>
        ///   <para>Determines whether any of the specified <paramref name="flags"/> is enabled.</para>
        /// </summary>
        /// <param name="flags">The flags to test for.</param>
        /// <returns><see langword="true"/>, if any of the specified <paramref name="flags"/> is enabled; otherwise, <see langword="false"/>.</returns>
        [Obsolete("DebugFlags enum and all related functionality were removed in RogueLibs v4.0.0.")]
        public static bool IsDebugEnabled(DebugFlags flags) => (DebugFlags & flags) != 0;
    }
}

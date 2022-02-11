using System;
using System.Reflection;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a recorded patch information.</para>
    /// </summary>
    public class PatchRecord
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="PatchRecord"/> class with the specified <paramref name="patchType"/>, <paramref name="target"/> method, <paramref name="patch"/> method, <paramref name="elapsed"/> time and <paramref name="success"/> indicating whether it succeeded or failed.</para>
        /// </summary>
        /// <param name="patchType">The Harmony patch type.</param>
        /// <param name="target">The target method.</param>
        /// <param name="patch">The patch method.</param>
        /// <param name="elapsed">The elapsed time.</param>
        /// <param name="success">Determines whether the patch succeeded or failed.</param>
        public PatchRecord(string patchType, MethodInfo? target, MethodInfo? patch, TimeSpan elapsed, bool success)
        {
            PatchType = patchType;
            Target = target;
            Patch = patch;
            Elapsed = elapsed;
            Success = success;
        }
        /// <summary>
        ///   <para>Gets the Harmony patch type.</para>
        /// </summary>
        public string PatchType { get; }
        /// <summary>
        ///   <para>Gets the target method.</para>
        /// </summary>
        public MethodInfo? Target { get; }
        /// <summary>
        ///   <para>Gets the patch method.</para>
        /// </summary>
        public MethodInfo? Patch { get; }
        /// <summary>
        ///   <para>Gets the elapsed time.</para>
        /// </summary>
        public TimeSpan Elapsed { get; }
        /// <summary>
        ///   <para>Determines whether the patch succeeded or failed.</para>
        /// </summary>
        public bool Success { get; }
    }
}

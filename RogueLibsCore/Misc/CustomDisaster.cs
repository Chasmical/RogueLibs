using System.Collections;
using UnityEngine;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a custom disaster.</para>
    /// </summary>
    public abstract class CustomDisaster
    {
        /// <summary>
        ///   <para>Determines whether this disaster is currently active.</para>
        /// </summary>
        public bool IsActive => gc.levelFeeling == Metadata.Name;

        /// <summary>
        ///   <para>Gets the index of the current district (0 - Slums, 1 - Industrial, 2 - Park, 3 - Downtown, 4 - Uptown, 5 - Mayor Village).</para>
        /// </summary>
        public int CurrentDistrict => gc.levelTheme;
        /// <summary>
        ///   <para>Gets the index of the floor of the current district (from 0 to 2, or from 0 to 1 if Quick Game is on).</para>
        /// </summary>
        public int CurrentFloor => gc.sessionDataBig.curLevel % (gc.challenges.Contains("QuickGame") || gc.loadLevel.quickGame ? 2 : 3);
        /// <summary>
        ///   <para>Gets the index of the current level (0-2 - Slums, 3-5 - Industrial, 6-8 - Park, 9-11 - Downtown, 12-14 - Uptown, 15 - Mayor Village (or 0-1, 2-3, 4-5, 6-7, 8-9 if Quick Game is on), and more in Endless mode).</para>
        /// </summary>
        public int CurrentLevel => gc.sessionDataBig.curLevel;

        private CustomDisasterMetadata? metadata;
        /// <summary>
        ///   <para>Gets the custom disaster's metadata.</para>
        /// </summary>
        public CustomDisasterMetadata Metadata => metadata ??= CustomDisasterMetadata.Get(GetType());

        /// <summary>
        ///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
        // ReSharper disable once InconsistentNaming
        public static GameController gc => GameController.gameController;

        /// <summary>
        ///   <para>Determines whether the teleportation is allowed during this disaster. Default value: <see langword="false"/>.</para>
        /// </summary>
        public virtual bool AllowTeleport => false;

        /// <summary>
        ///   <para>Determines if the disaster <u>must</u> be applied to the current level. Default return value: <see langword="false"/>.</para>
        /// </summary>
        /// <returns><see langword="true"/>, if the disaster must be applied to the current level; otherwise, <see langword="false"/>.</returns>
        public virtual bool TestForced() => false;
        /// <summary>
        ///   <para>Determines if the disaster <u>can</u> be applied to the current level. Default return value: <see langword="true"/>.</para>
        /// </summary>
        /// <returns><see langword="true"/>, if the disaster can be applied to the current level; otherwise, <see langword="false"/>.</returns>
        public virtual bool Test() => true;

        /// <summary>
        ///   <para>Initializes the custom disaster.</para>
        /// </summary>
        public abstract void Start();
        /// <summary>
        ///   <para>Finishes and cleans up after the custom disaster.</para>
        /// </summary>
        public abstract void Finish();
        /// <summary>
        ///   <para>Updates the custom disaster using a <see cref="Coroutine"/>; starts after the notification is displayed. Return <see langword="null"/>, if no updating is needed.</para>
        /// </summary>
        /// <returns>The enumerator representing the custom disaster's updating coroutine.</returns>
        public abstract IEnumerator? Updating();

    }
}

using System.Collections;
using UnityEngine;

namespace RogueLibsCore
{
    public abstract class CustomDisaster
    {
        public bool IsActive => gc.levelFeeling == DisasterInfo.Name;

        public int CurrentDistrict => gc.levelTheme;
        public int CurrentFloor => gc.sessionDataBig.curLevel % (gc.challenges.Contains("QuickGame") || gc.loadLevel.quickGame ? 2 : 3);
        public int CurrentLevel => gc.sessionDataBig.curLevel;

        private DisasterInfo? disasterInfo;
        public DisasterInfo DisasterInfo => disasterInfo ??= DisasterInfo.Get(GetType());

        /// <summary>
        ///   <para>Gets the currently used instance of <see cref="GameController"/>.</para>
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE1006:Naming Styles", Justification = "Usage of gc fields in SoR")]
        // ReSharper disable once InconsistentNaming
        public static GameController gc => GameController.gameController;

        // is teleportation during the disaster allowed?
        public virtual bool AllowTeleport => false;

        // test if the disaster MUST be triggered on this level
        public virtual bool TestForced() => false;
        // test if the disaster should be triggered for this level
        public abstract bool Test();

        // start the disaster
        public abstract void Start();
        // clean up after the disaster
        public abstract void Finish();
        // update the disaster using a coroutine
        public virtual IEnumerator Updating() => null!;
        internal Coroutine? updatingCoroutine;

    }
}

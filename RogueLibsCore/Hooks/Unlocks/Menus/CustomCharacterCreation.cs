using System.Collections.Generic;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The <see cref="CharacterCreation"/> implementation of the <see cref="UnlocksMenu"/> class.</para>
    /// </summary>
    public class CustomCharacterCreation : UnlocksMenu
    {
        /// <summary>
        ///   <para>Initializes a new instance of the <see cref="CustomCharacterCreation"/> class with the specified <paramref name="cc"/> and <paramref name="unlocks"/> list.</para>
        /// </summary>
        /// <param name="cc">The <see cref="CharacterCreation"/> instance.</param>
        /// <param name="unlocks">The list of unlocks displayed in the menu.</param>
        public CustomCharacterCreation(CharacterCreation cc, List<DisplayedUnlock> unlocks)
            : base(unlocks)
        {
            CC = cc;
            Type = UnlocksMenuType.CharacterCreation;
        }
        /// <summary>
        ///   <para>Gets the <see cref="CharacterCreation"/> instance.</para>
        /// </summary>
        public CharacterCreation CC { get; }
        /// <inheritdoc/>
        public override Agent Agent => CC.agent;

        /// <inheritdoc/>
        public override void PlaySound(string clipName) => GameController.gameController.audioHandler.PlayMust(Agent, clipName);
        /// <inheritdoc/>
        public override void UpdateMenu()
        {
            (CC.selectedSpace == "Items" ? CC.scrollerControllerItems
            : CC.selectedSpace == "Traits" ? CC.scrollerControllerTraits
            : CC.selectedSpace == "Abilities" ? CC.scrollerControllerAbilities
            : CC.selectedSpace == "BigQuest" ? CC.scrollerControllerBigQuests
            : CC.selectedSpace == "Load" ? CC.scrollerControllerLoad
            : null)?.myScroller.RefreshActiveCellViews();

            CC.CreatePointTallyText();
        }
    }
}

namespace RogueLibsCore.Test
{
    [ItemCategories(RogueCategories.Social, RogueCategories.Stealth,
        RogueCategories.Technology, RogueCategories.Usable)]
    public class SPYTRON3000 : CustomItem, IItemTargetable
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomItem<SPYTRON3000>()
                .WithName(new CustomNameInfo("SPYTRON 3000"))
                .WithDescription(new CustomNameInfo("Always wanted to be someone else? Now you can!"))
                .WithSprite(Properties.Resources.SPYTRON3000)
                .WithUnlock(new ItemUnlock
                {
                    UnlockCost = 10,
                    LoadoutCost = 2,
                    CharacterCreationCost = 3,
                    Prerequisites = { VanillaItems.BodySwapper },
                });

            DisguiseCursorText = RogueLibs.CreateCustomName("Disguise", NameTypes.Interface, new CustomNameInfo("Disguise as"));
        }
        private static CustomName DisguiseCursorText = null!;

        public override void SetupDetails()
        {
            Item.itemType = ItemTypes.Tool;
            Item.itemValue = 40;
            Item.initCount = 2;
            Item.rewardCount = 3;
            Item.stackable = true;
            Item.goesInToolbar = true;
        }
        public bool TargetFilter(PlayfieldObject target) => target is Agent a && a != Owner;
        public bool TargetObject(PlayfieldObject targetObj)
        {
            if (!TargetFilter(targetObj)) return false;
            Agent target = (Agent)targetObj;

            string prev = Owner.agentName;
            Owner.agentName = target.agentName;

            Owner.relationships.CopyLooks(target);
            foreach (Relationship rel in target.relationships.RelList)
            {
                Relationship otherRel = rel.agent.relationships.GetRelationship(target);

                Owner.relationships.SetRel(rel.agent, rel.relType);
                Owner.relationships.SetRelHate(rel.agent, 0);
                Owner.relationships.GetRelationship(rel.agent).secretHate = rel.secretHate;
                Owner.relationships.GetRelationship(rel.agent).mechHate = rel.mechHate;

                rel.agent.relationships.SetRel(Owner, otherRel.relType);
                rel.agent.relationships.SetRelHate(Owner, 0);
                rel.agent.relationships.GetRelationship(Owner).secretHate = otherRel.secretHate;
                rel.agent.relationships.GetRelationship(Owner).mechHate = otherRel.mechHate;
            }
            target.relationships.SetRel(Owner, "Hateful");
            target.relationships.SetRelHate(Owner, 25);

            Owner.agentName = prev;

            Owner.gc.audioHandler.Play(Owner, VanillaAudio.Spawn);
            Owner.gc.spawnerMain.SpawnParticleEffect("Spawn", Owner.tr.position, 0f);

            Count--;
            Item.invInterface.HideTarget();
            return true;
        }
        public CustomTooltip TargetCursorText(PlayfieldObject? _) => DisguiseCursorText;
    }
}

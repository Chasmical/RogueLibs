using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueLibsCore.Test
{
    public class Hug : CustomAbility, IAbilityTargetable
    {
        [RLSetup]
        public static void Setup()
        {
            RogueLibs.CreateCustomAbility<Hug>()
                .WithName(new CustomNameInfo("Hug"))
                .WithDescription(new CustomNameInfo("Sneak up behind people. And HUG THEM!!"))
                .WithSprite(Properties.Resources.Hug)
                .WithUnlock(new AbilityUnlock { UnlockCost = 5, CharacterCreationCost = 5 });

            RogueLibs.CreateCustomName("HugNegative1", NameTypes.Dialogue, new CustomNameInfo("Huh? What are you doing?"));
            RogueLibs.CreateCustomName("HugNegative2", NameTypes.Dialogue, new CustomNameInfo("Excuse me?!"));
            RogueLibs.CreateCustomName("HugNegative3", NameTypes.Dialogue, new CustomNameInfo("Stop it!"));
            RogueLibs.CreateCustomName("HugPositive1", NameTypes.Dialogue, new CustomNameInfo("Oh.. Thanks."));
            RogueLibs.CreateCustomName("HugPositive2", NameTypes.Dialogue, new CustomNameInfo("Um.. Okay.."));
            RogueLibs.CreateCustomName("HugPositive3", NameTypes.Dialogue, new CustomNameInfo("?.."));
            RogueLibs.CreateCustomName("HugForgive1", NameTypes.Dialogue, new CustomNameInfo("Oh.. Okay, I forgive you."));
            RogueLibs.CreateCustomName("HugForgive2", NameTypes.Dialogue, new CustomNameInfo("Alright, I forgive you."));
            RogueLibs.CreateCustomName("HugForgive3", NameTypes.Dialogue, new CustomNameInfo("Okay... Don't worry about that.."));
        }

        public override void OnAdded() { }
        public PlayfieldObject? FindTarget()
        {
            Agent? closest = null;
            float distance = float.MaxValue;
            foreach (Agent agent in Owner!.interactionHelper.TriggerList
                .Where(static go => go.CompareTag("AgentSprite"))
                .Select(static go => go.GetComponent<ObjectSprite>().agent))
            {
                if (!huggedList.Contains(agent) && !agent.dead && !agent.ghost && !Owner.ghost && !agent.hologram
                    && agent.go.activeSelf && !agent.mechFilled && !agent.mechEmpty)
                {
                    float dist = Vector2.Distance(Owner.curPosition, agent.curPosition);
                    if (dist < distance)
                    {
                        closest = agent;
                        distance = dist;
                    }
                }
            }
            return closest;
        }
        private readonly List<Agent> huggedList = new List<Agent>();
        public override void OnPressed()
        {
            if (CurrentTarget is null)
            {
                gc.audioHandler.Play(Owner, VanillaAudio.CantDo);
            }
            else
            {
                Agent target = (Agent)CurrentTarget;
                int rnd = new System.Random().Next(3) + 1;

                relStatus code = target.relationships.GetRelCode(Owner);
                if (code is relStatus.Friendly or relStatus.Submissive)
                {
                    target.SayDialogue("HugPositive" + rnd);
                    target.relationships.SetRel(Owner, "Loyal");
                }
                else if (code == relStatus.Loyal)
                {
                    target.SayDialogue("HugPositive" + rnd);
                    target.relationships.SetRel(Owner, "Aligned");
                }
                else if (code == relStatus.Aligned)
                {
                    target.SayDialogue("HugPositive" + rnd);
                }
                else if (code == relStatus.Neutral)
                {
                    target.SayDialogue("HugNegative" + rnd);
                    target.relationships.SetRel(Owner, "Annoyed");
                    target.relationships.SetStrikes(Owner, 2);
                    target.statusEffects.annoyeders.Add(Owner);
                    gc.audioHandler.Play(target, VanillaAudio.AgentAnnoyed);
                    return;
                }
                else if (code == relStatus.Annoyed)
                {
                    target.SayDialogue("HugForgive" + rnd);
                    target.relationships.SetRel(Owner, "Neutral");
                }
                else if (code == relStatus.Hostile)
                {
                    return;
                }
                target.relationships.SetStrikes(Owner, 0);
                gc.audioHandler.Play(target, VanillaAudio.AgentOK);
                huggedList.Add(target);
            }
        }
    }
}

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>The collection of agent categories used in the game. Use it to avoid typos.</para>
    /// </summary>
    public static class AgentCategories
    {
        /// <summary>
        ///   <para>Specifies that the agent can defense yourself.
        ///   <br/>Examples: Alien, Athlete, Bouncer, Comedian, Cop.</para>
        /// </summary>
        public const string Defense = "Defense";
        /// <summary>
        ///   <para>Specifies that the agent can complete levels without bustle.
        ///   <br/>Examples: Doctor, MechPilot, Thief, Vampire, Werewolf.</para>
        /// </summary>
        public const string Stealth = "Stealth";
        /// <summary>
        ///   <para>Specifies that the agent can fast move.
        ///   <br/>Examples: Alien, Athlete, Cannibal, Courier, Hacker, Thief.</para>
        /// </summary>
        public const string Movement = "Movement";
        /// <summary>
        ///   <para>Specifies that the agent usually use Melee weapon.
        ///   <br/>Examples: Vampire, Worker, Wrestler, Zombie, Athlete, Bouncer.</para>
        /// </summary>
        public const string Melee = "Melee";
        /// <summary>
        ///   <para>Specifies that the agent usually in a normal relationship with other agents.
        ///   <br/>Examples: Businessman, Doctor, Firefighter, GangbangerB, Gorilla, Mafia.</para>
        /// </summary>
        public const string Social = "Social";
        /// <summary>
        ///   <para>Specifies that the agent usually use ranged weapon.
        ///   <br/>Examples: Mafia, RobotPlayer, Scientist, Shopkeeper, Slavemaster, Soldier.</para>
        /// </summary>
        public const string Guns = "Guns";
        /// <summary>
        ///   <para>Specifies that the agent usually can trade with other agents.
        ///   <br/>Examples: Werewolf, Bartender, Businessman, MechPilot, Shopkeeper, .</para>
        /// </summary>
        public const string Trade = "Trade";
    }
}

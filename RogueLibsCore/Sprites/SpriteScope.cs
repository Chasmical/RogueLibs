using System;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a type of game resources that a <see cref="RogueSprite"/> will be integrated into.</para>
    /// </summary>
    [Flags]
    public enum SpriteScope
    {
        /// <summary>
        ///   <para>The RogueLibs extra sprites. Will be used if a sprite is not found in an appropriate collection.</para>
        /// </summary>
        Extra   = 1 << 31,

        /// <summary>
        ///   <para>Don't define the sprite anywhere.</para>
        /// </summary>
        None    = 0,

        /// <summary>
        ///   <para>The item sprites.</para>
        /// </summary>
        Items   = 1 << 0,
        /// <summary>
        ///   <para>The object sprites.</para>
        /// </summary>
        Objects = 1 << 1,
        /// <summary>
        ///   <para>The floor sprites.</para>
        /// </summary>
        Floors  = 1 << 2,

        Bullets = 1 << 3,

        Hair = 1 << 4,

        FacialHair = 1 << 5,

        HeadPieces = 1 << 6,

        Agents = 1 << 7,

        Bodies = 1 << 8,

        Wreckage = 1 << 9,

        Interface = 1 << 10,

        Decals = 1 << 11,

        WallTops = 1 << 12,

        Walls = 1 << 13,

        Spawners = 1 << 14,


    }
}

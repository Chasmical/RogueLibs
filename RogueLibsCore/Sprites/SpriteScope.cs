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
        /// <summary>
        ///   <para>The projectile sprites.</para>
        /// </summary>
        Bullets = 1 << 3,
        /// <summary>
        ///   <para>The hair sprites.</para>
        /// </summary>
        Hair = 1 << 4,
        /// <summary>
        ///   <para>The facial hair sprites.</para>
        /// </summary>
        FacialHair = 1 << 5,
        /// <summary>
        ///   <para>The head piece sprites.</para>
        /// </summary>
        HeadPieces = 1 << 6,
        /// <summary>
        ///   <para>The agent sprites.</para>
        /// </summary>
        Agents = 1 << 7,
        /// <summary>
        ///   <para>The agent body sprites.</para>
        /// </summary>
        Bodies = 1 << 8,
        /// <summary>
        ///   <para>The wreckage sprites.</para>
        /// </summary>
        Wreckage = 1 << 9,
        /// <summary>
        ///   <para>The interface sprites.</para>
        /// </summary>
        Interface = 1 << 10,
        /// <summary>
        ///   <para>The decal sprites.</para>
        /// </summary>
        Decals = 1 << 11,
        /// <summary>
        ///   <para>The wall top sprites.</para>
        /// </summary>
        WallTops = 1 << 12,
        /// <summary>
        ///   <para>The wall sprites.</para>
        /// </summary>
        Walls = 1 << 13,
        /// <summary>
        ///   <para>The spawner sprites, used in the Level Editor.</para>
        /// </summary>
        Spawners = 1 << 14,
        /// <summary>
        ///   <para>The shadow sprites.</para>
        /// </summary>
        Shadows = 1 << 15,
        /// <summary>
        ///   <para>The tile shadow sprites.</para>
        /// </summary>
        TileShadows = 1 << 16,

    }
}

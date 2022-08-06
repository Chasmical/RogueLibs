using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BepInEx;
using System.IO;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RogueLibsCore
{
    /// <summary>
    ///   <para>Represents a custom sprite.</para>
    /// </summary>
    public sealed class RogueSprite
    {
        private Texture2D? texture;
        /// <summary>
        ///   <para>Gets or sets the sprite's texture.</para>
        /// </summary>
        /// <exception cref="ArgumentNullException">The sprite is defined and <see langword="value"/> is <see langword="null"/>. Only thrown when setting the property value.</exception>
        public Texture2D? Texture
        {
            get => texture;
            set
            {
                bool defined = IsDefined || isPrepared;
                if (defined && value is null) throw new ArgumentNullException(nameof(value));
                Undefine();
                texture = value;
                if (value != null)
                {
                    value.name = Name;
                    value.filterMode = FilterMode.Point;
                }
                Material = null;
                LightUpMaterial = null;
                Sprite = CreateSprite();
                if (defined) Define();
            }
        }
        private float pixelsPerUnit;
        /// <summary>
        ///   <para>Gets or sets the pixels-per-unit of the sprite.</para>
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">The sprite is defined and <see langword="value"/> is <see langword="null"/>. Only thrown when setting the property value.</exception>
        public float PixelsPerUnit
        {
            get => pixelsPerUnit;
            set
            {
                bool defined = IsDefined || isPrepared;
                if (defined && value <= 0f)
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(value)} is less than or equal to 0.");
                Undefine();
                pixelsPerUnit = value;
                Material = null;
                LightUpMaterial = null;
                Sprite = CreateSprite();
                if (defined) Define();
            }
        }
        private string name;
        /// <summary>
        ///   <para>Gets or sets the sprite's name.</para>
        /// </summary>
        /// <exception cref="ArgumentNullException">The sprite is defined and <see langword="value"/> is <see langword="null"/>. Only thrown when setting the property value.</exception>
        public string Name
        {
            get => name;
            set
            {
                bool defined = IsDefined || isPrepared;
                if (defined && value is null) throw new ArgumentNullException(nameof(value));
                Undefine();
                name = value;
                if (Texture != null) Texture.name = value;
                if (Sprite != null) Sprite.name = value;
                if (defined) Define();
            }
        }
        private SpriteScope scope;
        /// <summary>
        ///   <para>Gets or sets the sprite's scope.</para>
        /// </summary>
        public SpriteScope Scope
        {
            get => scope;
            set
            {
                bool defined = IsDefined || isPrepared;
                Undefine();
                scope = value;
                if (defined) Define();
            }
        }
        private Rect? region;
        /// <summary>
        ///   <para>Gets or sets the region of the texture for the sprite to use. Use <see langword="null"/> to use the entire texture.</para>
        /// </summary>
        public Rect? Region
        {
            get => region;
            set
            {
                bool defined = IsDefined || isPrepared;
                Undefine();
                region = value;
                Material = null;
                LightUpMaterial = null;
                Sprite = CreateSprite();
                if (defined) Define();
            }
        }

        private List<CustomTk2dDefinition>? definitions;
        /// <summary>
        ///   <para>Gets the collection of integrated <see cref="CustomTk2dDefinition"/>s, or <see langword="null"/> if the sprite is not defined.</para>
        /// </summary>
        public ReadOnlyCollection<CustomTk2dDefinition>? Definitions { get; private set; }
        /// <summary>
        ///   <para>Gets or sets whether the sprite is defined and integrated into the game.</para>
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Name"/> or <see cref="Texture"/> is <see langword="null"/>, or <see cref="PixelsPerUnit"/> is less than or equal to 0. Only thrown when setting the property value.</exception>
        public bool IsDefined
        {
            get => definitions != null;
            set
            {
                if (value) Define();
                else Undefine();
            }
        }

        /// <summary>
        ///   <para>Gets the created sprite, or <see langword="null"/> if invalid data was provided.</para>
        /// </summary>
        public Sprite? Sprite { get; private set; }
        private Sprite? CreateSprite()
        {
            if (texture is null || pixelsPerUnit <= 0f) return null;

            static Rect FlipRegion(Rect reg, float height)
                => Rect.MinMaxRect(reg.xMin, height - reg.yMax, reg.xMax, height - reg.yMin);

            Rect spriteRegion = region is not null
                ? FlipRegion(region.Value, texture.height)
                : new Rect(0, 0, texture.width, texture.height);
            Sprite sprite = Sprite.Create(texture, spriteRegion, new Vector2(0.5f, 0.5f), pixelsPerUnit);
            sprite.name = Name;
            return sprite;
        }

        /// <summary>
        ///   <para>A read-only collection of all values in the <see cref="SpriteScope"/> enumeration, including <see cref="SpriteScope.None"/>.</para>
        /// </summary>
        public static readonly ReadOnlyCollection<SpriteScope> AllScopes;

        static RogueSprite()
        {
            Array array = Enum.GetValues(typeof(SpriteScope));
            int length = array.Length;
            SpriteScope[] allScopes = new SpriteScope[length];
            for (int i = 0; i < length; i++)
            {
                SpriteScope scope = (SpriteScope)array.GetValue(i);
                prepared.Add(scope, new List<RogueSprite>());
                allScopes[i] = scope;
            }
            AllScopes = new ReadOnlyCollection<SpriteScope>(allScopes);
        }

        internal static readonly Dictionary<SpriteScope, tk2dSpriteCollectionData> registered
            = new Dictionary<SpriteScope, tk2dSpriteCollectionData>();
        internal static readonly Dictionary<SpriteScope, List<RogueSprite>> prepared = new Dictionary<SpriteScope, List<RogueSprite>>();
        internal bool isPrepared;
        internal static void DefinePrepared(tk2dSpriteCollectionData collection, SpriteScope scope)
        {
            registered[scope] = collection;
            if (prepared.TryGetValue(scope, out List<RogueSprite> sprites))
            {
                if (RogueFramework.IsDebugEnabled(DebugFlags.Sprites))
                    RogueFramework.LogDebug($"Initializing ${sprites.Count} prepared sprites in scope {scope}:");

                foreach (RogueSprite sprite in sprites)
                {
                    sprite.isPrepared = false;
                    sprite.DefineInternal(collection, scope);
                }
            }
        }

        private static readonly Dictionary<byte[], Texture2D> loadedTextures = new Dictionary<byte[], Texture2D>();

        internal RogueSprite(string spriteName, SpriteScope spriteScope, byte[] rawData, Rect? spriteRegion, float ppu = 64f)
        {
            if (!loadedTextures.TryGetValue(rawData, out Texture2D? tex))
            {
                tex = new Texture2D(13, 6) { name = spriteName, filterMode = FilterMode.Point };
                tex.LoadImage(rawData);
                loadedTextures.Add(rawData, tex);
            }
            texture = tex;
            name = spriteName;
            scope = spriteScope;
            pixelsPerUnit = ppu;
            region = spriteRegion;
            Sprite = CreateSprite();
        }

        private static tk2dSpriteCollectionData? GetCollection(SpriteScope scope)
            => registered.TryGetValue(scope, out tk2dSpriteCollectionData collection) ? collection : null;
        /// <summary>
        ///   <para>Defines the current sprite and integrates it into the game.</para>
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="Name"/> or <see cref="Texture"/> is <see langword="null"/>, or <see cref="PixelsPerUnit"/> is less than or equal to 0.</exception>
        public void Define()
        {
            if (IsDefined || isPrepared || Scope == SpriteScope.None) return;
            if (Name is null) throw new InvalidOperationException($"{nameof(Name)} is null.");
            if (Texture is null) throw new InvalidOperationException($"{nameof(Texture)} is null.");
            if (PixelsPerUnit <= 0f) throw new InvalidOperationException($"{nameof(PixelsPerUnit)} is less than or equal to 0.");

            definitions = new List<CustomTk2dDefinition>();
            Definitions = new ReadOnlyCollection<CustomTk2dDefinition>(definitions);
            for (int i = 0, length = AllScopes.Count; i < length; i++)
            {
                SpriteScope mask = AllScopes[i];
                DefineScope(Scope & mask);
            }
        }
        private void DefineScope(SpriteScope targetScope)
        {
            if (targetScope == SpriteScope.None) return;
            tk2dSpriteCollectionData? coll = GetCollection(targetScope);
            if (coll is null && targetScope != SpriteScope.Extra)
            {
                isPrepared = true;
                if (prepared.TryGetValue(targetScope, out List<RogueSprite> sprites))
                {
                    if (RogueFramework.IsDebugEnabled(DebugFlags.Sprites))
                        RogueFramework.LogDebug($"Prepared sprite \"{Name}\" for initialization.");
                    sprites.Add(this);
                }
                else RogueFramework.LogError($"Pseudo-prepared sprite \"{Name}\" for initialization.");
            }
            else DefineInternal(coll, targetScope);
        }

        internal Material? Material { get; private set; }
        internal Material? LightUpMaterial { get; private set; }
        internal void DefineInternal(tk2dSpriteCollectionData? coll, SpriteScope targetScope)
        {
            if (RogueFramework.IsDebugEnabled(DebugFlags.Sprites))
                RogueFramework.LogDebug($"Defining \"{Name}\" sprite in scope {targetScope}.");

            if (coll != null)
            {
                tk2dSpriteDefinition def = CreateDefinition(texture!, region, 64f / PixelsPerUnit / coll.invOrthoSize / coll.halfTargetHeight);
                AddDefinition(coll, def);
                def.__RogueLibsCustom = this;
                definitions!.Add(new CustomTk2dDefinition(coll, def, targetScope));

                Material ??= def.material;
                if (Material is null) RogueFramework.LogWarning($"Material is null! ({coll.name})");
                LightUpMaterial ??= Object.Instantiate(Material);
                if (LightUpMaterial is not null)
                    LightUpMaterial.shader = Shader.Find("tk2d/BlendAdditiveVertexColor");
            }
            else definitions!.Add(new CustomTk2dDefinition(null, null, targetScope));

            GameResources gr = GameResources.gameResources;
            if (gr is null)
            {
                GameController gc = GameController.gameController;
                if (gc is null) GameController.gameController = gc = GameObject.Find("GameController").GetComponent<GameController>();
                if (GameObject.Find("GameResources") == null)
                {
                    Debug.Log("Instantiate GameResources");
                    gc.gameResources = Object.Instantiate(gc.gameResourcesPrefab);
                    gc.gameResources.name = "GameResources";
                    gc.gameResources.RealAwake();
                    gc.gameResources.SetupDics();
                }
                else
                {
                    gc.gameResources = GameResources.gameResources;
                    gc.gameResources.RealAwake();
                    gc.gameResources.SetupDics();
                }
                gr = gc.gameResources;
            }

            switch (targetScope)
            {
                case SpriteScope.Items: gr.itemDic[Name] = Sprite; gr.itemList.Add(Sprite); break;
                case SpriteScope.Objects: gr.objectDic[Name] = Sprite; gr.objectList.Add(Sprite); break;
                case SpriteScope.Floors: gr.floorDic[Name] = Sprite; gr.floorList.Add(Sprite); break;
                case SpriteScope.Hair: gr.hairDic[Name] = Sprite; gr.hairList.Add(Sprite); break;
                case SpriteScope.FacialHair: gr.facialHairDic[Name] = Sprite; gr.facialHairList.Add(Sprite); break;
                case SpriteScope.HeadPieces: gr.headPiecesDic[Name] = Sprite; gr.headPiecesList.Add(Sprite); break;
                case SpriteScope.Agents:
                    gr.headDic[Name] = Sprite; gr.headList.Add(Sprite);
                    gr.eyesDic[Name] = Sprite; gr.eyesList.Add(Sprite);
                    break;
                case SpriteScope.Bodies: gr.bodyDic[Name] = Sprite; gr.bodyList.Add(Sprite); break;
                case SpriteScope.Walls: gr.wallDic[Name] = Sprite; gr.wallList.Add(Sprite); break;
                case SpriteScope.Extra: RogueFramework.ExtraSprites[Name] = Sprite!; break;
            }
        }
        /// <summary>
        ///   <para>Undefines the current sprite and disintegrates it from the game.</para>
        /// </summary>
        public void Undefine()
        {
            if (isPrepared)
            {
                isPrepared = false;
                if (prepared.TryGetValue(Scope, out List<RogueSprite> list))
                    list.Remove(this);
                else RogueFramework.LogWarning($"Undefined a pseudo-prepared sprite \"{Name}\".");
                return;
            }
            if (!IsDefined) return;

            foreach (CustomTk2dDefinition def in definitions!)
                UndefineInternal(def);
            definitions = null;
            Definitions = null;
        }
        private void UndefineInternal(CustomTk2dDefinition def)
        {
            if (RogueFramework.IsDebugEnabled(DebugFlags.Sprites))
                RogueFramework.LogDebug($"Undefining sprite \"{Name}\" from scope {def.Scope}.");

            if (def.Collection != null)
                RemoveDefinition(def.Collection, def.Definition!);

            GameResources gr = GameResources.gameResources;
            switch (def.Scope)
            {
                case SpriteScope.Items: gr.itemDic.Remove(Name); gr.itemList.Remove(Sprite); break;
                case SpriteScope.Objects: gr.objectDic.Remove(Name); gr.objectList.Remove(Sprite); break;
                case SpriteScope.Floors: gr.floorDic.Remove(Name); gr.floorList.Remove(Sprite); break;
                case SpriteScope.Hair: gr.hairDic.Remove(Name); gr.hairList.Remove(Sprite); break;
                case SpriteScope.FacialHair: gr.facialHairDic.Remove(Name); gr.facialHairList.Remove(Sprite); break;
                case SpriteScope.HeadPieces: gr.headPiecesDic.Remove(Name); gr.headPiecesList.Remove(Sprite); break;
                case SpriteScope.Agents:
                    gr.headDic.Remove(Name); gr.headList.Remove(Sprite);
                    gr.eyesDic.Remove(Name); gr.eyesList.Remove(Sprite);
                    break;
                case SpriteScope.Bodies: gr.bodyDic.Remove(Name); gr.bodyList.Remove(Sprite); break;
                case SpriteScope.Walls: gr.wallDic.Remove(Name); gr.wallList.Remove(Sprite); break;
                case SpriteScope.Extra: RogueFramework.ExtraSprites.Remove(Name); break;
            }
        }

        /// <summary>
        ///   <para>Creates a <see cref="tk2dSpriteDefinition"/> from the specified <paramref name="texture"/> using the specified <paramref name="uvRegion"/> and <paramref name="scale"/>.</para>
        /// </summary>
        /// <param name="texture">The texture to create a <see cref="tk2dSpriteDefinition"/> with.</param>
        /// <param name="uvRegion">The region of the texture to use. Use <see langword="null"/> to use the entire texture.</param>
        /// <param name="scale">The scale to create a <see cref="tk2dSpriteDefinition"/> with.</param>
        /// <returns>The created <see cref="tk2dSpriteDefinition"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="texture"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="scale"/> is less than or equal to 0.</exception>
        public static tk2dSpriteDefinition CreateDefinition(Texture2D texture, Rect? uvRegion, float scale)
        {
            if (texture is null) throw new ArgumentNullException(nameof(texture));
            if (scale <= 0f) throw new ArgumentOutOfRangeException(nameof(scale), scale, $"{nameof(scale)} is less than or equal to 0.");

            Rect region = uvRegion ?? new Rect(0f, 0f, texture.width, texture.height);
            Vector2 anchor = region.center - region.position;
            Vector2 texDim = new Vector2(texture.width, texture.height);

            const float epsilon = 0.001f;
            Vector2 uvTopLeft = new Vector2(region.xMin + epsilon, texDim.y - region.yMax - epsilon) / texDim;
            Vector2 uvBottomRight = new Vector2(region.xMax - epsilon, texDim.y - region.yMin + epsilon) / texDim;

            Vector3 posBottomLeft = new Vector3(-anchor.x, anchor.y - region.height) * scale;
            Vector3 posTopRight = new Vector3(region.width - anchor.x, anchor.y) * scale;

            Vector3 b = new Vector3(-anchor.x, anchor.y - region.height) * scale;
            Vector3 a = new Vector3(region.width - anchor.x, anchor.y) * scale;

            Material mat = new Material(Shader.Find("tk2d/BlendVertexColor")) { name = texture.name, mainTexture = texture };
            return new tk2dSpriteDefinition
            {
                material = mat,
                materialInst = mat,
                flipped = tk2dSpriteDefinition.FlipMode.None,
                extractRegion = false,
                name = texture.name,
                colliderType = tk2dSpriteDefinition.ColliderType.Unset,
                positions = new Vector3[]
                {
                    new Vector3(posBottomLeft.x, posBottomLeft.y),
                    new Vector3(posTopRight.x, posBottomLeft.y),
                    new Vector3(posBottomLeft.x, posTopRight.y),
                    new Vector3(posTopRight.x, posTopRight.y),
                },
                uvs = new Vector2[]
                {
                    new Vector2(uvTopLeft.x, uvTopLeft.y),
                    new Vector2(uvBottomRight.x, uvTopLeft.y),
                    new Vector2(uvTopLeft.x, uvBottomRight.y),
                    new Vector2(uvBottomRight.x, uvBottomRight.y),
                },
                normals = Array.Empty<Vector3>(),
                tangents = Array.Empty<Vector4>(),
                indices = new int[] { 0, 3, 1, 2, 3, 0 },
                boundsData = new Vector3[] { (a + b) / 2f, a - b },
                untrimmedBoundsData = new Vector3[] { (a + b) / 2f, a - b },
                texelSize = new Vector2(scale, scale),
            };
        }
        /// <summary>
        ///   <para>Adds the specified <paramref name="definition"/> to the <paramref name="collection"/>.</para>
        /// </summary>
        /// <param name="collection">The collection to add the specified <paramref name="definition"/> to.</param>
        /// <param name="definition">The definition to add to the specified <paramref name="collection"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="definition"/> is <see langword="null"/>.</exception>
        public static void AddDefinition(tk2dSpriteCollectionData collection, tk2dSpriteDefinition definition)
        {
            if (collection is null || definition is null)
                throw new ArgumentNullException(collection is null ? nameof(collection) : nameof(definition));

            tk2dSpriteDefinition[] newDefinitions = new tk2dSpriteDefinition[collection.spriteDefinitions.Length + 1];
            Array.Copy(collection.spriteDefinitions, 0, newDefinitions, 0, collection.spriteDefinitions.Length);
            newDefinitions[newDefinitions.Length - 1] = definition;
            collection.spriteDefinitions = newDefinitions;

            Material[] newMats = new Material[collection.materials.Length + 1];
            Array.Copy(collection.materials, 0, newMats, 0, collection.materials.Length);
            newMats[newMats.Length - 1] = definition.material;
            if (Array.IndexOf(newMats, null) != -1)
                newMats = Array.FindAll(newMats, static m => m != null);
            collection.materials = newMats;

            Texture[] newTextures = new Texture[collection.textures.Length + 1];
            Array.Copy(collection.textures, 0, newTextures, 0, collection.textures.Length);
            newTextures[newTextures.Length - 1] = definition.material.mainTexture;
            if (Array.IndexOf(newTextures, null) != -1)
                newTextures = Array.FindAll(newTextures, static m => m != null);
            collection.textures = newTextures;

            collection.inst.materialIdsValid = false;
            collection.InitMaterialIds();
            collection.ClearDictionary();
            collection.InitDictionary();
        }
        /// <summary>
        ///   <para>Removes the specified <paramref name="definition"/> from the <paramref name="collection"/>.</para>
        /// </summary>
        /// <param name="collection">The collection to remove the specified <paramref name="definition"/> from.</param>
        /// <param name="definition">The definition to remove from the specified <paramref name="collection"/>.</param>
        /// <returns><see langword="true"/>, if the definition was removed successfully; otherwise, <see langword="false"/>.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="collection"/> or <paramref name="definition"/> is <see langword="null"/>.</exception>
        public static bool RemoveDefinition(tk2dSpriteCollectionData collection, tk2dSpriteDefinition definition)
        {
            if (collection is null || definition is null)
                throw new ArgumentNullException(collection is null ? nameof(collection) : nameof(definition));

            int index = Array.IndexOf(collection.spriteDefinitions, definition);
            if (index is -1) return false;

            tk2dSpriteDefinition[] newDefinitions = new tk2dSpriteDefinition[collection.spriteDefinitions.Length - 1];
            Array.Copy(collection.spriteDefinitions, 0, newDefinitions, 0, index);
            Array.Copy(collection.spriteDefinitions, index + 1, newDefinitions, index, collection.spriteDefinitions.Length - index - 1);
            collection.spriteDefinitions = newDefinitions;

            Material[] newMats = new Material[collection.materials.Length - 1];
            Array.Copy(collection.materials, 0, newMats, 0, index);
            Array.Copy(collection.materials, index + 1, newMats, index, collection.materials.Length - index - 1);
            collection.materials = newMats;

            Texture[] newTextures = new Texture[collection.textures.Length - 1];
            Array.Copy(collection.textures, 0, newTextures, 0, index);
            Array.Copy(collection.textures, index + 1, newTextures, index, collection.textures.Length - index - 1);
            collection.textures = newTextures;

            collection.inst.materialIdsValid = false;
            collection.InitMaterialIds();
            collection.ClearDictionary();
            collection.InitDictionary();
            definition.__RogueLibsCustom = null;
            return true;
        }

        /// <summary>
        ///   <para>Represents a custom <see cref="tk2dSpriteDefinition"/>.</para>
        /// </summary>
        public class CustomTk2dDefinition
        {
            internal CustomTk2dDefinition(tk2dSpriteCollectionData? collection, tk2dSpriteDefinition? definition, SpriteScope scope)
            {
                Collection = collection;
                Definition = definition;
                Scope = scope;
            }
            /// <summary>
            ///   <para>Gets the collection that the sprite is defined in.</para>
            /// </summary>
            public tk2dSpriteCollectionData? Collection { get; }
            /// <summary>
            ///   <para>Gets the created definition.</para>
            /// </summary>
            public tk2dSpriteDefinition? Definition { get; }
            /// <summary>
            ///   <para>Gets the scope of the sprite's definition.</para>
            /// </summary>
            public SpriteScope Scope { get; }
        }

        /// <summary>
        ///   <para>Dumps all tk2d sprites from the specified <paramref name="collection"/> into a "tk2d_{CollectionName}" folder in the game's root directory.</para>
        /// </summary>
        /// <param name="collection">The collection whose sprites to dump.</param>
        public static void Dump(tk2dSpriteCollectionData collection)
        {
            Dictionary<Texture, Texture2D> cache = new Dictionary<Texture, Texture2D>();

            string directoryPath = Path.Combine(Paths.GameRootPath, "tk2d_" + collection.name);
            Directory.CreateDirectory(directoryPath);

            foreach (tk2dSpriteDefinition def in collection.spriteDefinitions)
            {
                float minX = def.uvs.Min(static uv => uv.x) * def.material.mainTexture.width;
                float maxX = def.uvs.Max(static uv => uv.x) * def.material.mainTexture.width;
                float minY = def.uvs.Min(static uv => uv.y) * def.material.mainTexture.height;
                float maxY = def.uvs.Max(static uv => uv.y) * def.material.mainTexture.height;
                Texture tex = def.material.mainTexture;
                Vector2 pos = new Vector2(minX, minY);
                Vector2 size = new Vector2(maxX - minX, maxY - minY);

                bool errors = false;
                if (pos.x < 0 || pos.y < 0)
                {
                    if (!errors) RogueFramework.LogError($"{def.name}: Invalid ({pos.x}, {pos.y} - {size.x}, {size.y}) on {tex.width}, {tex.height}");
                    if (pos.x < 0) pos.x = 0;
                    if (pos.y < 0) pos.y = 0;
                    errors = true;
                }
                if (pos.x + size.x > tex.width || pos.y + size.y > tex.height)
                {
                    if (!errors) RogueFramework.LogError($"{def.name}: Invalid ({pos.x}, {pos.y} - {size.x}, {size.y}) on {tex.width}, {tex.height}");
                    if (pos.x + size.x > tex.width) size.x = tex.width - pos.x;
                    if (pos.y + size.y > tex.height)  size.y = tex.height - pos.y;
                    errors = true;
                }
                if (errors) RogueFramework.LogError($"{def.name}: Resolved as ({pos.x}, {pos.y} - {size.x}, {size.y}) on {tex.width}, {tex.height}");
                try
                {
                    string cleanName = def.name.Replace("/", "$").Replace("\\", "$");
                    string path = Path.Combine(directoryPath, cleanName + ".png");
                    if (File.Exists(path)) continue;

                    if (!cache.TryGetValue(def.material.mainTexture, out Texture2D readable))
                    {
                        readable = RogueUtilities.MakeTextureReadable((Texture2D)def.material.mainTexture);
                        cache.Add(def.material.mainTexture, readable);
                    }
                    int width = Mathf.RoundToInt(size.x);
                    int height = Mathf.RoundToInt(size.y);
                    Color[] colors = readable.GetPixels(
                        Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y),
                        width, height);

                    if (def.flipped != tk2dSpriteDefinition.FlipMode.None)
                    {
                        RogueFramework.LogDebug($"Flipping {def.name}");
                        Color[] temp = new Color[colors.Length];
                        for (int i = 0; i < width; i++)
                            for (int j = 0; j < height; j++)
                            {
                                int index = i * height + j;
                                int otherIndex = j * width + i;
                                temp[index] = colors[otherIndex];
                            }
                        colors = temp;
                        size = new Vector2(size.y, size.x);
                        width = Mathf.RoundToInt(size.x);
                        height = Mathf.RoundToInt(size.y);
                    }

                    Texture2D tex2 = new Texture2D(width, height);
                    tex2.SetPixels(colors);
                    byte[] encoded = tex2.EncodeToPNG();
                    File.WriteAllBytes(path, encoded);
                }
                catch (Exception e)
                {
                    RogueFramework.LogError($"{def.name} ({pos.x}, {pos.y} - {size.x}, {size.y}) on {tex.width}, {tex.height}:");
                    RogueFramework.LogError(e.ToString());
                }
            }
        }
    }
}

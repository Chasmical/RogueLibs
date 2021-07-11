using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Represents a custom sprite.</para>
	/// </summary>
	public sealed class RogueSprite
	{
		private Texture2D texture;
		/// <summary>
		///   <para>Gets or sets the sprite's texture.</para>
		/// </summary>
		/// <exception cref="ArgumentNullException">The sprite is defined and <see langword="value"/> is <see langword="null"/>. Only thrown when setting the property value.</exception>
		public Texture2D Texture
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

		private List<CustomTk2dDefinition> definitions;
		/// <summary>
		///   <para>Gets the collection of integrated <see cref="CustomTk2dDefinition"/>s, or <see langword="null"/> if the sprite is not defined.</para>
		/// </summary>
		public ReadOnlyCollection<CustomTk2dDefinition> Definitions { get; private set; }
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
		public Sprite Sprite { get; private set; }
		private Sprite CreateSprite()
		{
			if (Name is null || Texture is null || PixelsPerUnit <= 0f) return null;
			Rect reg = Region ?? new Rect(0, 0, Texture.width, Texture.height);
			Sprite sprite = Sprite.Create(Texture, reg, reg.size / 2f, PixelsPerUnit);
			sprite.name = Name;
			return sprite;
		}

		internal static readonly Dictionary<SpriteScope, List<RogueSprite>> prepared = new Dictionary<SpriteScope, List<RogueSprite>>
		{
			[SpriteScope.Items] = new List<RogueSprite>(),
			[SpriteScope.Objects] = new List<RogueSprite>(),
			[SpriteScope.Floors] = new List<RogueSprite>()
		};
		internal bool isPrepared;
		internal static void DefinePrepared(tk2dSpriteCollectionData collection, SpriteScope scope)
		{
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

		internal RogueSprite(string spriteName, SpriteScope spriteScope, byte[] rawData, Rect? spriteRegion, float ppu = 64f)
		{
			texture = new Texture2D(13, 6) { name = name = spriteName, filterMode = FilterMode.Point };
			scope = spriteScope;
			texture.LoadImage(rawData);
			pixelsPerUnit = ppu;
			region = spriteRegion;
			Sprite = CreateSprite();
		}

		private static tk2dSpriteCollectionData GetCollection(SpriteScope scope)
		{
			GameController gc = GameController.gameController;
			switch (scope)
			{
				case SpriteScope.Items: return gc?.spawnerMain?.itemSprites;
				case SpriteScope.Objects: return gc?.spawnerMain?.objectSprites;
				case SpriteScope.Floors: return gc?.spawnerMain?.floorSprites;
				default: return null;
			}
		}
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
			DefineScope(Scope & SpriteScope.Items);
			DefineScope(Scope & SpriteScope.Objects);
			DefineScope(Scope & SpriteScope.Floors);
			DefineScope(Scope & SpriteScope.Extra);
		}
		private void DefineScope(SpriteScope scope)
		{
			if (scope == SpriteScope.None) return;
			tk2dSpriteCollectionData coll = GetCollection(scope);
			if (coll is null && scope != SpriteScope.Extra)
			{
				isPrepared = true;
				if (prepared.TryGetValue(scope, out List<RogueSprite> sprites))
				{
					if (RogueFramework.IsDebugEnabled(DebugFlags.Sprites))
						RogueFramework.LogDebug($"Prepared sprite \"{Name}\" for initialization.");
					sprites.Add(this);
				}
				else RogueFramework.LogError($"Pseudo-prepared sprite \"{Name}\" for initialization.");
			}
			else DefineInternal(coll, scope);
		}

		internal Material Material { get; private set; }
		internal Material LightUpMaterial { get; private set; }
		internal void DefineInternal(tk2dSpriteCollectionData coll, SpriteScope scope)
		{
			if (RogueFramework.IsDebugEnabled(DebugFlags.Sprites))
				RogueFramework.LogDebug($"Defining \"{Name}\" sprite in scope {scope}.");

			if (coll != null)
			{
				tk2dSpriteDefinition def = CreateDefinition(texture, region, 1f / coll.invOrthoSize / coll.halfTargetHeight);
				AddDefinition(coll, def);
				def.__RogueLibsCustom = this;
				definitions.Add(new CustomTk2dDefinition(coll, def, scope));

				if (Material is null) Material = def.material;
				if (LightUpMaterial is null) LightUpMaterial = UnityEngine.Object.Instantiate(Material);
				LightUpMaterial.shader = GameController.gameController.lightUpShader;
			}
			else definitions.Add(new CustomTk2dDefinition(null, null, scope));

			GameResources gr = GameResources.gameResources;

			if (scope == SpriteScope.Items) { gr.itemDic[Name] = Sprite; gr.itemList.Add(Sprite); }
			else if (scope == SpriteScope.Objects) { gr.objectDic[Name] = Sprite; gr.objectList.Add(Sprite); }
			else if (scope == SpriteScope.Floors) { gr.floorDic[Name] = Sprite; gr.floorList.Add(Sprite); }
			else if (scope == SpriteScope.Extra) RogueFramework.ExtraSprites[Name] = Sprite;
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

			foreach (CustomTk2dDefinition def in definitions)
				UndefineInternal(def);
			definitions = null;
			Definitions = null;
		}
		private void UndefineInternal(CustomTk2dDefinition def)
		{
			if (RogueFramework.IsDebugEnabled(DebugFlags.Sprites))
				RogueFramework.LogDebug($"Undefining sprite \"{Name}\" from scope {def.Scope}.");

			if (def.Collection != null)
				RemoveDefinition(def.Collection, def.Definition);

			GameResources gr = GameResources.gameResources;
			if (Scope == SpriteScope.Items) { gr.itemDic.Remove(Name); gr.itemList.Remove(Sprite); }
			if (Scope == SpriteScope.Objects) { gr.objectDic.Remove(Name); gr.objectList.Remove(Sprite); }
			if (Scope == SpriteScope.Floors) { gr.floorDic.Remove(Name); gr.floorList.Remove(Sprite); }
			if (Scope == SpriteScope.Extra) RogueFramework.ExtraSprites.Remove(Name);
		}

		/// <summary>
		///   <para>Creates a <see cref="tk2dSpriteDefinition"/> from the specified <paramref name="texture"/> using the specified <paramref name="region"/> and <paramref name="scale"/>.</para>
		/// </summary>
		/// <param name="texture">The texture to create a <see cref="tk2dSpriteDefinition"/> with.</param>
		/// <param name="region">The region of the texture to use. Use <see langword="null"/> to use the entire texture.</param>
		/// <param name="scale">The scale to create a <see cref="tk2dSpriteDefinition"/> with.</param>
		/// <returns>The created <see cref="tk2dSpriteDefinition"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="texture"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="scale"/> is less than or equal to 0.</exception>
		public static tk2dSpriteDefinition CreateDefinition(Texture2D texture, Rect? region, float scale)
		{
			if (texture is null) throw new ArgumentNullException(nameof(texture));
			if (scale <= 0f) throw new ArgumentOutOfRangeException(nameof(scale), scale, $"{nameof(scale)} is less than or equal to 0.");

			float x = texture.width;
			float y = texture.height;
			Rect uvRegion = region ?? new Rect(0f, 0f, x, y);
			Vector2 anchor = new Vector2(0.5f * x, 0.5f * y);
			Rect trimRect = new Rect(0f, 0f, 0f, 0f);

			Vector2 vector = new Vector2(0.001f, 0.001f);
			Vector2 vector2 = new Vector2((uvRegion.x + vector.x) / x, 1f - (uvRegion.y + uvRegion.height + vector.y) / y);
			Vector2 vector3 = new Vector2((uvRegion.x + uvRegion.width - vector.x) / x, 1f - (uvRegion.y - vector.y) / y);
			Vector2 vector4 = new Vector2(trimRect.x - anchor.x, -trimRect.y + anchor.y) * scale;
			Vector3 vector5 = new Vector3(-anchor.x * scale, anchor.y * scale, 0f);
			Vector3 vector6 = vector5 + new Vector3(trimRect.width * scale, -trimRect.height * scale, 0f);
			Vector3 vector7 = new Vector3(0f, -y * scale, 0f);
			Vector3 vector8 = vector7 + new Vector3(x * scale, y * scale, 0f);

			Vector3 b = new Vector3(vector5.x, vector6.y, 0f);
			Vector3 a = new Vector3(vector6.x, vector5.y, 0f);

			return new tk2dSpriteDefinition
			{
				name = texture.name,
				material = new Material(Shader.Find("tk2d/BlendVertexColor")) { name = texture.name, mainTexture = texture },
				normals = new Vector3[0],
				tangents = new Vector4[0],
				indices = new int[6] { 0, 3, 1, 2, 3, 0 },
				positions = new Vector3[]
				{
					new Vector3(vector7.x + vector4.x, vector7.y + vector4.y, 0f),
					new Vector3(vector8.x + vector4.x, vector7.y + vector4.y, 0f),
					new Vector3(vector7.x + vector4.x, vector8.y + vector4.y, 0f),
					new Vector3(vector8.x + vector4.x, vector8.y + vector4.y, 0f)
				},
				uvs = new Vector2[]
				{
					new Vector2(vector2.x, vector2.y),
					new Vector2(vector3.x, vector2.y),
					new Vector2(vector2.x, vector3.y),
					new Vector2(vector3.x, vector3.y)
				},
				boundsData = new Vector3[] { (a + b) / 2f, a - b },
				untrimmedBoundsData = new Vector3[] { (a + b) / 2f, a - b },
				texelSize = new Vector2(scale, scale)
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

			tk2dSpriteDefinition[] newDefs = new tk2dSpriteDefinition[collection.spriteDefinitions.Length + 1];
			Array.Copy(collection.spriteDefinitions, 0, newDefs, 0, collection.spriteDefinitions.Length);
			newDefs[newDefs.Length - 1] = definition;
			collection.spriteDefinitions = newDefs;

			Material[] newMats = new Material[collection.materials.Length + 1];
			Array.Copy(collection.materials, 0, newMats, 0, collection.materials.Length);
			newMats[newMats.Length - 1] = definition.material;
			collection.materials = newMats;

			Texture[] newTextures = new Texture[collection.textures.Length + 1];
			Array.Copy(collection.textures, 0, newTextures, 0, collection.textures.Length);
			newTextures[newTextures.Length - 1] = definition.material.mainTexture;
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

			tk2dSpriteDefinition[] newDefs = new tk2dSpriteDefinition[collection.spriteDefinitions.Length - 1];
			Array.Copy(collection.spriteDefinitions, 0, newDefs, 0, index);
			Array.Copy(collection.spriteDefinitions, index + 1, newDefs, index, collection.spriteDefinitions.Length - index - 1);
			collection.spriteDefinitions = newDefs;

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
			internal CustomTk2dDefinition(tk2dSpriteCollectionData collection, tk2dSpriteDefinition definition, SpriteScope scope)
			{
				Collection = collection;
				Definition = definition;
				Scope = scope;
			}
			/// <summary>
			///   <para>Gets the collection that the sprite is defined in.</para>
			/// </summary>
			public tk2dSpriteCollectionData Collection { get; }
			/// <summary>
			///   <para>Gets the created definition.</para>
			/// </summary>
			public tk2dSpriteDefinition Definition { get; }
			/// <summary>
			///   <para>Gets the scope of the sprite's definition.</para>
			/// </summary>
			public SpriteScope Scope { get; }
		}
	}
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
	}
}

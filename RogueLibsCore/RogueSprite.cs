using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RogueLibsCore
{
	public class RogueSprite
	{
		public tk2dSpriteCollectionData Collection { get; private set; }
		public tk2dSpriteDefinition Definition { get; private set; }
		public Sprite Sprite { get; private set; }

		private Texture2D texture;
		public Texture2D Texture
		{
			get => texture;
			set
			{
				bool defined = IsDefined || willBeAddedOnGCAwake;
				Undefine();
				(texture = value).name = Name;
				Sprite = CreateSprite();
				if (defined) Define();
			}
		}
		private float pixelsPerUnit;
		public float PixelsPerUnit
		{
			get => pixelsPerUnit;
			set
			{
				bool defined = IsDefined || willBeAddedOnGCAwake;
				Undefine();
				pixelsPerUnit = value;
				Sprite = CreateSprite();
				if (defined) Define();
			}
		}

		private string name;
		public string Name
		{
			get => name;
			set
			{
				bool defined = IsDefined || willBeAddedOnGCAwake;
				Undefine();
				Texture.name = Sprite.name = name = value;
				if (defined) Define();
			}
		}
		private SpriteScope scope;
		public SpriteScope Scope
		{
			get => scope;
			set
			{
				bool defined = IsDefined || willBeAddedOnGCAwake;
				Undefine();
				scope = value;
				if (defined) Define();
			}
		}

		private Rect? region;
		public Rect? Region
		{
			get => region;
			set
			{
				bool defined = IsDefined || willBeAddedOnGCAwake;
				Undefine();
				region = value;
				Sprite = CreateSprite();
				if (defined) Define();
			}
		}

		public bool IsDefined
		{
			get => Definition != null;
			set
			{
				if (value) Define();
				else Undefine();
			}
		}

		internal static readonly List<RogueSprite>[] addOnGCAwakeList = new List<RogueSprite>[(int)SpriteScope.Extra + 1]
		{
			null,
			new List<RogueSprite>(),
			new List<RogueSprite>(),
			new List<RogueSprite>()
		};
		internal bool willBeAddedOnGCAwake;

		internal RogueSprite(string spriteName, SpriteScope spriteScope, byte[] rawData, Rect? spriteRegion, float ppu = 64f)
		{
			if (spriteName == null) throw new ArgumentNullException(nameof(spriteName));
			if (rawData == null) throw new ArgumentNullException(nameof(rawData));
			texture = new Texture2D(13, 6) { name = name = spriteName };
			scope = spriteScope;
			texture.LoadImage(rawData);
			pixelsPerUnit = ppu;
			region = spriteRegion;
			Sprite = CreateSprite();
		}

		public void LoadFromData(byte[] rawData)
		{
			Texture2D newTexture = new Texture2D(11, 7);
			newTexture.LoadImage(rawData);
			Texture = newTexture;
		}
		public void LoadFromData(byte[] rawData, float ppu)
		{
			Texture2D newTexture = new Texture2D(11, 7);
			newTexture.LoadImage(rawData);
			pixelsPerUnit = ppu;
			Texture = newTexture;
		}

		private Sprite CreateSprite()
		{
			RogueLibs.Logger.LogInfo($"Creating sprite: {Texture?.name} ({Texture?.width}x{Texture?.height}) / {PixelsPerUnit}p/u");
			Sprite sprite = Sprite.Create(Texture, Region ?? new Rect(0, 0, Texture.width, Texture.height), Vector2.zero, PixelsPerUnit);
			sprite.name = Name;
			return sprite;
		}
		private tk2dSpriteCollectionData GetCollection()
		{
			GameController gc = GameController.gameController;
			if (Scope == SpriteScope.Items) return gc?.spawnerMain?.itemSprites;
			else if (Scope == SpriteScope.Objects) return gc?.spawnerMain?.objectSprites;
			else return null;
		}

		public void Define()
		{
			if (IsDefined || willBeAddedOnGCAwake || Scope == SpriteScope.None) return;

			tk2dSpriteCollectionData coll = GetCollection();
			if (coll == null)
			{
				addOnGCAwakeList[(int)Scope].Add(this);
				willBeAddedOnGCAwake = true;
				return;
			}
			DefineToCollection(coll);
		}
		internal void DefineToCollection(tk2dSpriteCollectionData coll)
		{
			Collection = coll;
			Definition = AddDefinition(coll, Texture, Region);

			GameResources gr = GameResources.gameResources;

			if (Scope == SpriteScope.Items) { gr.itemDic[Name] = Sprite; gr.itemList.Add(Sprite); }
			else if (Scope == SpriteScope.Objects) { gr.objectDic[Name] = Sprite; gr.objectList.Add(Sprite); }
			else if (Scope == SpriteScope.Extra) RogueLibs.extraSprites[Name] = Sprite;
		}
		public void Undefine()
		{
			if (willBeAddedOnGCAwake)
			{
				addOnGCAwakeList[(int)Scope].Remove(this);
				willBeAddedOnGCAwake = false;
				return;
			}
			if (!IsDefined) return;

			RemoveDefinition(Collection, Definition);
			Collection = null;
			Definition = null;

			GameResources gr = GameResources.gameResources;

			if (Scope == SpriteScope.Items) { gr.itemDic.Remove(Name); gr.itemList.Remove(Sprite); }
			else if (Scope == SpriteScope.Objects) { gr.objectDic.Remove(Name); gr.objectList.Remove(Sprite); }
			else if (Scope == SpriteScope.Extra) RogueLibs.extraSprites.Remove(Name);
		}

		public static tk2dSpriteDefinition CreateDefinition(Texture2D texture, Rect? region, float scale)
		{
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
		private static tk2dSpriteDefinition AddDefinition(tk2dSpriteCollectionData coll, Texture2D texture, Rect? region)
		{
			tk2dSpriteDefinition definition = CreateDefinition(texture, region, 1f / coll.invOrthoSize / coll.halfTargetHeight);

			tk2dSpriteDefinition[] newDefs = new tk2dSpriteDefinition[coll.spriteDefinitions.Length + 1];
			Array.Copy(coll.spriteDefinitions, 0, newDefs, 0, coll.spriteDefinitions.Length);
			newDefs[newDefs.Length - 1] = definition;
			coll.spriteDefinitions = newDefs;

			Material[] newMats = new Material[coll.materials.Length + 1];
			Array.Copy(coll.materials, 0, newMats, 0, coll.materials.Length);
			newMats[newMats.Length - 1] = definition.material;
			coll.materials = newMats;

			Texture[] newTextures = new Texture[coll.textures.Length + 1];
			Array.Copy(coll.textures, 0, newTextures, 0, coll.textures.Length);
			newTextures[newTextures.Length - 1] = texture;
			coll.textures = newTextures;

			coll.inst.materialIdsValid = false;
			coll.InitMaterialIds();
			coll.ClearDictionary();
			coll.InitDictionary();

			return definition;
		}
		private static void RemoveDefinition(tk2dSpriteCollectionData coll, tk2dSpriteDefinition definition)
		{
			int index = Array.IndexOf(coll.spriteDefinitions, definition);
			if (index == -1) return;

			tk2dSpriteDefinition[] newDefs = new tk2dSpriteDefinition[coll.spriteDefinitions.Length - 1];
			Array.Copy(coll.spriteDefinitions, 0, newDefs, 0, index);
			Array.Copy(coll.spriteDefinitions, index + 1, newDefs, index, coll.spriteDefinitions.Length - index - 1);
			coll.spriteDefinitions = newDefs;

			Material[] newMats = new Material[coll.materials.Length - 1];
			Array.Copy(coll.materials, 0, newMats, 0, index);
			Array.Copy(coll.materials, index + 1, newMats, index, coll.materials.Length - index - 1);
			coll.materials = newMats;

			Texture[] newTextures = new Texture[coll.textures.Length - 1];
			Array.Copy(coll.textures, 0, newTextures, 0, index);
			Array.Copy(coll.textures, index + 1, newTextures, index, coll.textures.Length - index - 1);
			coll.textures = newTextures;

			coll.inst.materialIdsValid = false;
			coll.InitMaterialIds();
			coll.ClearDictionary();
			coll.InitDictionary();
		}

	}
	public enum SpriteScope
	{
		None    = 0,
		Items   = 1,
		Objects = 2,
		Extra   = 3
	}
}

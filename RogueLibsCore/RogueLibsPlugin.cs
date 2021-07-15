using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using BepInEx;
using HarmonyLib;
using System.IO;
using System.Threading;
using Light2D.Examples;

namespace RogueLibsCore
{
	[BepInPlugin(RogueLibs.GUID, RogueLibs.Name, RogueLibs.CompiledVersion)]
	[BepInIncompatibility("abbysssal.streetsofrogue.ectd")]
	[BepInIncompatibility("abbysssal.streetsofrogue.roguelibs")]
	internal sealed partial class RogueLibsPlugin : BaseUnityPlugin
	{
		public RoguePatcher Patcher;
		/*
		 * Code to extract object sprites from the game.
		 * Put any other tk2dCollectionData in there to extract textures from it.
		 * 
		public void Start()
		{
			tk2dSpriteCollectionData coll = GameController.gameController.spawnerMain.objectSprites;
			foreach (tk2dSpriteDefinition def in coll.spriteDefinitions)
			{
				if (def.name == "Safe" || def.name == "Elevator")
				{
					RogueFramework.LogError($"{def.name} - uvs:");
					foreach (Vector2 pos in def.uvs)
						RogueFramework.LogError($"---- {pos.x,6:#.######} {pos.y,6:#.######} ({pos.x * def.material.mainTexture.width,6:#.##} {pos.y * def.material.mainTexture.height,6:#.##})");
				}

				float minX = def.uvs.Min(uv => uv.x) * def.material.mainTexture.width;
				float maxX = def.uvs.Max(uv => uv.x) * def.material.mainTexture.width;
				float minY = def.uvs.Min(uv => uv.y) * def.material.mainTexture.height;
				float maxY = def.uvs.Max(uv => uv.y) * def.material.mainTexture.height;
				Vector2 posi = new Vector2(minX, minY);
				Vector2 size = new Vector2(maxX - minX, maxY - minY);

				Texture2D readable = RogueUtilities.MakeTextureReadable((Texture2D)def.material.mainTexture);
				int width = Mathf.RoundToInt(size.x);
				int height = Mathf.RoundToInt(size.y);
				Color[] colors = readable.GetPixels(
					Mathf.RoundToInt(posi.x), Mathf.RoundToInt(posi.y),
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

				string path = Path.Combine(@"D:\StreetsOfRogue\v94\SpritePack\OBJECTS", def.name + ".png");
				Texture2D tex = new Texture2D(width, height);
				tex.SetPixels(colors);
				byte[] encoded = tex.EncodeToPNG();
				File.WriteAllBytes(path, encoded);
			}
		}
		*/

		private static int awoken;
		public void Awake()
		{
			if (Interlocked.Exchange(ref awoken, 1) == 1)
			{
				Logger.LogError("A second instance of RogueLibs was awakened, so it was terminated immediately.");
				return;
			}
			Logger.LogInfo($"Running RogueLibs v{RogueLibs.CompiledSemanticVersion}.");
			Stopwatch sw = new Stopwatch();
			sw.Start();

			RogueFramework.Plugin = this;
			RogueFramework.Logger = Logger;

			Patcher = new RoguePatcher(this);
#if DEBUG
			Patcher.EnableStopwatch = true;
#endif
			PatchAbilities();
			PatchCharacterCreation();
			PatchItems();
			PatchMisc();
			PatchScrollingMenu();
			PatchSprites();
			PatchTraitsAndStatusEffects();
			PatchUnlocks();
			PatchAgents();
#if DEBUG
			Patcher.SortResults();
			Patcher.LogResults();
#endif
			sw.Stop();
			Logger.LogDebug($"RogueLibs took {sw.ElapsedMilliseconds,5:#####} ms to load.");
		}
	}
}

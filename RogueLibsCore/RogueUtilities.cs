using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using BepInEx;
using UnityEngine;
using UnityEngine.Networking;

namespace RogueLibsCore
{
	public static class RogueUtilities
	{
		public static Texture2D MakeTextureReadable(Texture2D original)
		{
			if (original.isReadable) return original;

			RenderTexture tmp = new RenderTexture(original.width, original.height, 0, RenderTextureFormat.Default, RenderTextureReadWrite.Linear);
			Graphics.Blit(original, tmp);

			RenderTexture prev = RenderTexture.active;
			RenderTexture.active = tmp;

			Texture2D texture = new Texture2D(original.width, original.height);
			texture.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
			texture.Apply();

			RenderTexture.active = prev;
			return texture;
		}

		public static Sprite ConvertToSprite(byte[] rawData, Rect region, float ppu = 64)
		{
			Texture2D texture = new Texture2D(15, 9);
			texture.LoadImage(rawData);
			return Sprite.Create(texture, region, Vector2.zero, ppu);
		}
		public static Sprite ConvertToSprite(byte[] rawData, float ppu = 64)
		{
			Texture2D texture = new Texture2D(15, 9);
			texture.LoadImage(rawData);
			return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, ppu);
		}
		public static Sprite ConvertToSprite(string filePath, float ppu = 64)
			=> ConvertToSprite(File.ReadAllBytes(filePath), ppu);
		public static Sprite ConvertToSprite(string filePath, Rect region, float ppu = 64)
			=> ConvertToSprite(File.ReadAllBytes(filePath), region, ppu);

		public static AudioClip ConvertToAudioClip(string filePath)
		{
			string extLow = Path.GetExtension(filePath);
			AudioType type = extLow == ".mp3" ? AudioType.MPEG
				: extLow == ".wav" || extLow == ".wave" ? AudioType.WAV
				: extLow == ".ogg" || extLow == ".ogv" || extLow == ".oga" || extLow == ".ogx"
					|| extLow == ".ogm" || extLow == ".spx" || extLow == ".opus" ? AudioType.OGGVORBIS
				: AudioType.UNKNOWN;

			UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file:///" + filePath, type);
			request.SendWebRequest();
			while (!request.isDone) Thread.Sleep(1);
			return DownloadHandlerAudioClip.GetContent(request);
		}
		public static AudioClip ConvertToAudioClip(byte[] rawData)
		{
			string name = ".roguelibs.audioclip." + Convert.ToString(new System.Random().Next(), 16).ToLowerInvariant();
			int postfix = 0;
			while (postfix == 0 ? File.Exists(name) : File.Exists(name + postfix)) postfix++;
			string filePath = Path.Combine(Paths.CachePath, name);

			File.WriteAllBytes(filePath, rawData);
			try
			{
				return ConvertToAudioClip(filePath);
			}
			finally
			{
				File.Delete(filePath);
			}
		}
	}
}

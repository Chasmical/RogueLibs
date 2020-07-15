using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Collection of some useful functions, that you might need.</para>
	/// </summary>
	public static class RogueUtilities
	{
		/// <summary>
		///   <para>Converts a .png or .jpg file into a <see cref="Sprite"/>.</para>
		/// </summary>
		public static Sprite ConvertToSprite(string filePath)
		{
			string path = Path.GetFullPath(filePath);
			Sprite sprite = null;
			try
			{
				byte[] data = File.ReadAllBytes(path);
				Texture2D texture = new Texture2D(7, 8);
				if (!texture.LoadImage(data))
					throw new Exception();
				sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 64);
			}
			catch (Exception e)
			{
				RogueLibs.PluginInstance.LogErrorWith("Could not load Sprite from \"" + path + "\"!", e);
			}
			return sprite;
		}
		/// <summary>
		///   <para>Converts a .png or .jpg file into a <see cref="Sprite"/> with the specified pixel-per-unit value (default - 64).</para>
		/// </summary>
		public static Sprite ConvertToSprite(string filePath, int ppu)
		{
			string path = Path.GetFullPath(filePath);
			Sprite sprite = null;
			try
			{
				byte[] data = File.ReadAllBytes(path);
				Texture2D texture = new Texture2D(7, 8);
				if (!texture.LoadImage(data))
					throw new Exception();
				sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, ppu);
			}
			catch (Exception e)
			{
				RogueLibs.PluginInstance.LogErrorWith("Could not load Sprite from \"" + path + "\"!", e);
			}
			return sprite;
		}
		/// <summary>
		///   <para>Converts a .png or .jpg byte array into a <see cref="Sprite"/>.</para>
		/// </summary>
		public static Sprite ConvertToSprite(byte[] data)
		{
			Sprite sprite = null;
			try
			{
				Texture2D texture = new Texture2D(14, 6);
				texture.LoadImage(data);
				sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, 64);
			}
			catch (Exception e)
			{

				RogueLibs.PluginInstance.LogErrorWith("Could not load Sprite from an array of bytes!", e);
			}
			return sprite;
		}
		/// <summary>
		///   <para>Converts a .png or .jpg byte array into a <see cref="Sprite"/> with the specified pixel-per-unit value (default - 64).</para>
		/// </summary>
		public static Sprite ConvertToSprite(byte[] data, int ppu)
		{
			Sprite sprite = null;
			try
			{
				Texture2D texture = new Texture2D(14, 6);
				texture.LoadImage(data);
				sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, ppu);
			}
			catch (Exception e)
			{

				RogueLibs.PluginInstance.LogErrorWith("Could not load Sprite from an array of bytes!", e);
			}
			return sprite;
		}

		/// <summary>
		///   <para>Converts a .mp3, .ogg, .wav or .aiff (it is recommended to use .ogg, since other formats might not load properly) file into an <see cref="AudioClip"/>.</para>
		/// </summary>
		public static AudioClip ConvertToAudioClip(string filePath)
		{
			string path = Path.GetFullPath(filePath);
			AudioClip clip = null;
			AudioType type;
			switch (Path.GetExtension(path).ToLower())
			{
				case ".mp3":
					type = AudioType.MPEG; break;
				case ".ogg":
					type = AudioType.OGGVORBIS; break;
				case ".wav":
					type = AudioType.WAV; break;
				case ".aiff":
					type = AudioType.AIFF; break;
				default:
					type = AudioType.UNKNOWN; break;
			}
			try
			{
				UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file:///" + path, type);
				request.SendWebRequest();
				clip = DownloadHandlerAudioClip.GetContent(request);
			}
			catch (Exception e)
			{
				RogueLibs.PluginInstance.LogErrorWith("Could not load AudioClip from \"" + path + "\"!", e);
			}
			return clip;
		}

		/// <summary>
		///   <para>Cross conflicts all <paramref name="mutators"/>, so it will be possible to enable only one of them at a time.</para>
		/// </summary>
		public static void CrossConflict(params CustomMutator[] mutators)
		{
			foreach (CustomMutator mutator in mutators)
				foreach (CustomMutator mutator2 in mutators)
					if (mutator.Id != mutator2.Id)
						mutator.AddConflicting(mutator2);
		}
		/// <summary>
		///   <para>Conflicts all <paramref name="mutators"/> with all mutators in the <paramref name="conflicts"/> collection, so it won't be possible to enable any of the <see cref="CustomMutator"/>s with any mutator from the <paramref name="conflicts"/> collection.</para>
		/// </summary>
		public static void EachConflict(IEnumerable<string> conflicts, params CustomMutator[] mutators)
		{
			foreach (CustomMutator mutator in mutators)
				mutator.AddConflicting(conflicts.ToArray());
		}
	}
}

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
	/// <summary>
	///   <para>Collection of useful methods, primarily for converting different formats of data.</para>
	/// </summary>
	public static class RogueUtilities
	{
		/// <summary>
		///   <para>Returns a copy of the <paramref name="original"/> texture, that can be read from.</para>
		/// </summary>
		/// <param name="original">Original non-readable texture.</param>
		/// <returns>Copy of the <paramref name="original"/> texture, that can be read from.</returns>
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

		/// <summary>
		///   <para>Converts the specified <paramref name="rawData"/> into a <see cref="Sprite"/> with the specified <paramref name="region"/> and <paramref name="ppu"/>.</para>
		/// </summary>
		/// <param name="rawData">PNG- or JPEG-encoded image data.</param>
		/// <param name="region">Region of the texture to use.</param>
		/// <param name="ppu">Pixels-per-unit.</param>
		/// <returns>Created <see cref="Sprite"/>.</returns>
		public static Sprite ConvertToSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			Texture2D texture = new Texture2D(15, 9);
			texture.LoadImage(rawData);
			return Sprite.Create(texture, region, Vector2.zero, ppu);
		}
		/// <summary>
		///   <para>Converts the specified <paramref name="rawData"/> into a <see cref="Sprite"/> with the specified <paramref name="ppu"/>.</para>
		/// </summary>
		/// <param name="rawData">PNG- or JPEG-encoded image data.</param>
		/// <param name="ppu">Pixels-per-unit.</param>
		/// <returns>Created <see cref="Sprite"/>.</returns>
		public static Sprite ConvertToSprite(byte[] rawData, float ppu = 64f)
		{
			Texture2D texture = new Texture2D(15, 9);
			texture.LoadImage(rawData);
			return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero, ppu);
		}
		/// <summary>
		///   <para>Converts an image from the specified <paramref name="filePath"/> into a <see cref="Sprite"/> with the specified <paramref name="ppu"/>.</para>
		/// </summary>
		/// <param name="filePath">Path to the PNG- JPEG-encoded image file.</param>
		/// <param name="ppu">Pixels-per-unit.</param>
		/// <returns>Created <see cref="Sprite"/>.</returns>
		public static Sprite ConvertToSprite(string filePath, float ppu = 64f)
			=> ConvertToSprite(File.ReadAllBytes(filePath), ppu);
		/// <summary>
		///   <para>Converts an image from the specified <paramref name="filePath"/> into a <see cref="Sprite"/> with the specified <paramref name="region"/> and <paramref name="ppu"/>.</para>
		/// </summary>
		/// <param name="filePath">Path to the PNG- JPEG-encoded image file.</param>
		/// <param name="region">Region of the texture to use.</param>
		/// <param name="ppu">Pixels-per-unit.</param>
		/// <returns>Created <see cref="Sprite"/>.</returns>
		public static Sprite ConvertToSprite(string filePath, Rect region, float ppu = 64f)
			=> ConvertToSprite(File.ReadAllBytes(filePath), region, ppu);

		/// <summary>
		///   <para>Converts an audio file from the specified <paramref name="filePath"/> into an <see cref="AudioClip"/>. Detects the audio format by the file's extension.</para>
		///   <para>Supported audio formats: MP3 (.mp3), WAV (.wav, .wave) and Ogg (.ogg, .spx, .opus, .og_).</para>
		/// </summary>
		/// <param name="filePath">Path to the MP3-, WAV- or Ogg-encoded audio file.</param>
		/// <returns>Created <see cref="AudioClip"/>.</returns>
		public static AudioClip ConvertToAudioClip(string filePath)
		{
			string extLow = Path.GetExtension(filePath);
			AudioType type = extLow == ".mp3" ? AudioType.MPEG
				: extLow == ".wav" || extLow == ".wave" ? AudioType.WAV
				: extLow == ".ogg" || extLow == ".ogv" || extLow == ".oga" || extLow == ".ogx"
					|| extLow == ".ogm" || extLow == ".spx" || extLow == ".opus" ? AudioType.OGGVORBIS
				: AudioType.UNKNOWN;

			if (type == AudioType.UNKNOWN)
				RogueLibsInternals.Logger.LogWarning($"Unknown audio file extension \"{extLow}\"! Please, use one of the supported formats: MP3, WAV or Ogg.");

			return ConvertToAudioClip(filePath, type);
		}
		/// <summary>
		///   <para>Converts an audio file from the specified <paramref name="filePath"/> into an <see cref="AudioClip"/> using the specified audio <paramref name="format"/>.</para>
		///   <para>Supported audio formats: MP3 (.mp3), WAV (.wav, .wave) and Ogg (.ogg, .spx, .opus, .og_).</para>
		/// </summary>
		/// <param name="filePath">Path to the MP3-, WAV- or Ogg-encoded audio file.</param>
		/// <param name="format">Format of the audio file.</param>
		/// <returns>Created <see cref="AudioClip"/>.</returns>
		public static AudioClip ConvertToAudioClip(string filePath, AudioType format)
		{
			UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file:///" + filePath, format);
			request.SendWebRequest();
			while (!request.isDone) Thread.Sleep(1);
			return DownloadHandlerAudioClip.GetContent(request);
		}
		/// <summary>
		///   <para>Converts the specified <paramref name="rawData"/> into an <see cref="AudioClip"/>. Detects the audio format by the file's extension.</para>
		///   <para>Supported audio formats: MP3 (.mp3), WAV (.wav, .wave) and Ogg (.ogg, .spx, .opus, .og_).</para>
		/// </summary>
		/// <param name="rawData">MP3-, WAV- or Ogg-encoded audio data.</param>
		/// <returns>Created <see cref="AudioClip"/>.</returns>
		public static AudioClip ConvertToAudioClip(byte[] rawData)
		{
			string name = ".roguelibs.audioclip." + Convert.ToString(new System.Random().Next(), 16).ToLowerInvariant();
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
		/// <summary>
		///   <para>Converts the specified <paramref name="rawData"/> into an <see cref="AudioClip"/> using the specified audio <paramref name="format"/>.</para>
		///   <para>Supported audio formats: MP3 (.mp3), WAV (.wav, .wave) and Ogg (.ogg, .spx, .opus, .og_).</para>
		/// </summary>
		/// <param name="rawData">MP3-, WAV- or Ogg-encoded audio data.</param>
		/// <param name="format">Format of the audio file.</param>
		/// <returns>Created <see cref="AudioClip"/>.</returns>
		public static AudioClip ConvertToAudioClip(byte[] rawData, AudioType format)
		{
			string name = ".roguelibs.audioclip." + Convert.ToString(new System.Random().Next(), 16).ToLowerInvariant();
			string filePath = Path.Combine(Paths.CachePath, name);

			File.WriteAllBytes(filePath, rawData);
			try
			{
				return ConvertToAudioClip(filePath, format);
			}
			finally
			{
				File.Delete(filePath);
			}
		}
	}
}

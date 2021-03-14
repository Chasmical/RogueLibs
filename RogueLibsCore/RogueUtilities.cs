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
		/// <exception cref="ArgumentNullException"><paramref name="original"/> is <see langword="null"/>.</exception>
		public static Texture2D MakeTextureReadable(Texture2D original)
		{
			if (original is null) throw new ArgumentNullException(nameof(original));
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
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public static Sprite ConvertToSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			if (rawData is null) throw new ArgumentNullException(nameof(rawData));
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			Texture2D texture = new Texture2D(15, 9);
			texture.LoadImage(rawData);
			return Sprite.Create(texture, region, region.size / 2f, ppu);
		}
		/// <summary>
		///   <para>Converts the specified <paramref name="rawData"/> into a <see cref="Sprite"/> with the specified <paramref name="ppu"/>.</para>
		/// </summary>
		/// <param name="rawData">PNG- or JPEG-encoded image data.</param>
		/// <param name="ppu">Pixels-per-unit.</param>
		/// <returns>Created <see cref="Sprite"/>.</returns>
		/// <exception cref="ArgumentNullException"><paramref name="rawData"/> is <see langword="null"/>.</exception>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		public static Sprite ConvertToSprite(byte[] rawData, float ppu = 64f)
		{
			if (rawData is null) throw new ArgumentNullException(nameof(rawData));
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			Texture2D texture = new Texture2D(15, 9);
			texture.LoadImage(rawData);
			Rect region = new Rect(0, 0, texture.width, texture.height);
			return Sprite.Create(texture, region, region.size / 2f, ppu);
		}
		/// <summary>
		///   <para>Converts an image from the specified <paramref name="filePath"/> into a <see cref="Sprite"/> with the specified <paramref name="ppu"/>.</para>
		/// </summary>
		/// <param name="filePath">Path to the PNG- JPEG-encoded image file.</param>
		/// <param name="ppu">Pixels-per-unit.</param>
		/// <returns>Created <see cref="Sprite"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		/// <exception cref="ArgumentException"><paramref name="filePath"/> is an empty string or contains one or more invalid characters.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="filePath"/> is <see langword="null"/>.</exception>
		/// <exception cref="PathTooLongException"><paramref name="filePath"/> exceeds the system-defined maximum length.</exception>
		/// <exception cref="DirectoryNotFoundException"><paramref name="filePath"/> is invalid.</exception>
		/// <exception cref="IOException">An I/O error occured while opening the file.</exception>
		/// <exception cref="UnauthorizedAccessException"><paramref name="filePath"/> specifies a directory or the caller does not have the required permission.</exception>
		/// <exception cref="FileNotFoundException">File specified in <paramref name="filePath"/> was not found.</exception>
		/// <exception cref="NotSupportedException"><paramref name="filePath"/> is in invalid format.</exception>
		/// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
		public static Sprite ConvertToSprite(string filePath, float ppu = 64f)
		{
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			return ConvertToSprite(File.ReadAllBytes(filePath), ppu);
		}
		/// <summary>
		///   <para>Converts an image from the specified <paramref name="filePath"/> into a <see cref="Sprite"/> with the specified <paramref name="region"/> and <paramref name="ppu"/>.</para>
		/// </summary>
		/// <param name="filePath">Path to the PNG- JPEG-encoded image file.</param>
		/// <param name="region">Region of the texture to use.</param>
		/// <param name="ppu">Pixels-per-unit.</param>
		/// <returns>Created <see cref="Sprite"/>.</returns>
		/// <exception cref="ArgumentOutOfRangeException"><paramref name="ppu"/> is less than or equal to 0.</exception>
		/// <exception cref="ArgumentException"><paramref name="filePath"/> is an empty string or contains one or more invalid characters.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="filePath"/> is <see langword="null"/>.</exception>
		/// <exception cref="PathTooLongException"><paramref name="filePath"/> exceeds the system-defined maximum length.</exception>
		/// <exception cref="DirectoryNotFoundException"><paramref name="filePath"/> is invalid.</exception>
		/// <exception cref="IOException">An I/O error occured while opening the file.</exception>
		/// <exception cref="UnauthorizedAccessException"><paramref name="filePath"/> specifies a directory or the caller does not have the required permission.</exception>
		/// <exception cref="FileNotFoundException">File specified in <paramref name="filePath"/> was not found.</exception>
		/// <exception cref="NotSupportedException"><paramref name="filePath"/> is in invalid format.</exception>
		/// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
		public static Sprite ConvertToSprite(string filePath, Rect region, float ppu = 64f)
		{
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			return ConvertToSprite(File.ReadAllBytes(filePath), region, ppu);
		}

		/// <summary>
		///   <para>Converts an audio file from the specified <paramref name="filePath"/> into an <see cref="AudioClip"/>. Detects the audio format by the file's extension.</para>
		///   <para>Supported audio formats: MP3 (.mp3), WAV (.wav, .wave) and Ogg (.ogg, .spx, .opus, .og_).</para>
		/// </summary>
		/// <param name="filePath">Path to the MP3-, WAV- or Ogg-encoded audio file.</param>
		/// <returns>Created <see cref="AudioClip"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="filePath"/> is an empty string or contains one or more invalid characters.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="filePath"/> is <see langword="null"/>.</exception>
		/// <exception cref="PathTooLongException"><paramref name="filePath"/> exceeds the system-defined maximum length.</exception>
		/// <exception cref="DirectoryNotFoundException"><paramref name="filePath"/> is invalid.</exception>
		/// <exception cref="IOException">An I/O error occured while opening the file.</exception>
		/// <exception cref="UnauthorizedAccessException"><paramref name="filePath"/> specifies a directory or the caller does not have the required permission.</exception>
		/// <exception cref="FileNotFoundException">File specified in <paramref name="filePath"/> was not found.</exception>
		/// <exception cref="NotSupportedException"><paramref name="filePath"/> is in invalid format or the extension's format is not supported.</exception>
		/// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
		public static AudioClip ConvertToAudioClip(string filePath)
		{
			string extLow = Path.GetExtension(filePath);
			AudioType type = extLow == ".mp3" ? AudioType.MPEG
				: extLow == ".wav" || extLow == ".wave" ? AudioType.WAV
				: extLow == ".ogg" || extLow == ".ogv" || extLow == ".oga" || extLow == ".ogx"
					|| extLow == ".ogm" || extLow == ".spx" || extLow == ".opus" ? AudioType.OGGVORBIS
				: throw new NotSupportedException($"File is in unknown format {extLow}.");

			return ConvertToAudioClip(filePath, type);
		}
		/// <summary>
		///   <para>Converts an audio file from the specified <paramref name="filePath"/> into an <see cref="AudioClip"/> using the specified audio <paramref name="format"/>.</para>
		///   <para>Supported audio formats: MP3 (.mp3), WAV (.wav, .wave) and Ogg (.ogg, .spx, .opus, .og_).</para>
		/// </summary>
		/// <param name="filePath">Path to the MP3-, WAV- or Ogg-encoded audio file.</param>
		/// <param name="format">Format of the audio file.</param>
		/// <returns>Created <see cref="AudioClip"/>.</returns>
		/// <exception cref="ArgumentException"><paramref name="filePath"/> is an empty string or contains one or more invalid characters.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="filePath"/> is <see langword="null"/>.</exception>
		/// <exception cref="PathTooLongException"><paramref name="filePath"/> exceeds the system-defined maximum length.</exception>
		/// <exception cref="DirectoryNotFoundException"><paramref name="filePath"/> is invalid.</exception>
		/// <exception cref="IOException">An I/O error occured while opening the file.</exception>
		/// <exception cref="UnauthorizedAccessException"><paramref name="filePath"/> specifies a directory or the caller does not have the required permission.</exception>
		/// <exception cref="FileNotFoundException">File specified in <paramref name="filePath"/> was not found.</exception>
		/// <exception cref="NotSupportedException"><paramref name="filePath"/> is in invalid format or the specified <paramref name="format"/> is not supported.</exception>
		/// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
		public static AudioClip ConvertToAudioClip(string filePath, AudioType format)
		{
			if (format != AudioType.MPEG && format != AudioType.WAV && format != AudioType.OGGVORBIS)
				throw new NotSupportedException($"{format} is not supported. Supported audio formats: {AudioType.MPEG}, {AudioType.WAV} and {AudioType.OGGVORBIS}.");
			UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file:///" + filePath, format);
			request.SendWebRequest();
			while (!request.isDone) Thread.Sleep(1);
			return DownloadHandlerAudioClip.GetContent(request);
		}
		/// <summary>
		///   <para>Converts the specified <paramref name="rawData"/> into an <see cref="AudioClip"/> using the specified audio <paramref name="format"/>.</para>
		///   <para>Supported audio formats: MP3 (.mp3), WAV (.wav, .wave) and Ogg (.ogg, .spx, .opus, .og_).</para>
		/// </summary>
		/// <param name="rawData">MP3-, WAV- or Ogg-encoded audio data.</param>
		/// <param name="format">Format of the audio file.</param>
		/// <returns>Created <see cref="AudioClip"/>.</returns>
		/// <exception cref="IOException">An I/O error occured while opening the file.</exception>
		/// <exception cref="UnauthorizedAccessException">The caller does not have the required permission.</exception>
		/// <exception cref="NotSupportedException">The specified <paramref name="format"/> is not supported.</exception>
		/// <exception cref="System.Security.SecurityException">The caller does not have the required permission.</exception>
		public static AudioClip ConvertToAudioClip(byte[] rawData, AudioType format)
		{
			if (format != AudioType.MPEG && format != AudioType.WAV && format != AudioType.OGGVORBIS)
				throw new NotSupportedException($"{format} is not supported. Supported audio formats: {AudioType.MPEG}, {AudioType.WAV} and {AudioType.OGGVORBIS}.");
			string name = ".roguelibs.audioclip." + Convert.ToString(new System.Random().Next(), 16).ToLowerInvariant();
			string filePath = Path.Combine(Paths.CachePath, name);

			try
			{
				File.WriteAllBytes(filePath, rawData);
				return ConvertToAudioClip(filePath, format);
			}
			finally
			{
				File.Delete(filePath);
			}
		}
	}
}

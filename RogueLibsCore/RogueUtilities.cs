using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Threading;
using System.Linq;
using BepInEx;
using UnityEngine;
using UnityEngine.Networking;
using HarmonyLib;
using System.Reflection;

namespace RogueLibsCore
{
	/// <summary>
	///   <para>Collection of useful methods, primarily for converting different formats of data.</para>
	/// </summary>
	public static class RogueUtilities
	{
		/// <summary>
		///   <para>Static instance of an empty <see cref="ReadOnlyCollection{T}"/>.</para>
		/// </summary>
		public static readonly ReadOnlyCollection<string> Empty = new ReadOnlyCollection<string>(new string[0]);

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

		/// <summary>
		///   <para>Gets the current <paramref name="type"/>'s method, that implements the specified <paramref name="interfaceType"/>'s method with the specified <paramref name="name"/>.</para>
		/// </summary>
		/// <param name="type">This instance of <see cref="Type"/>.</param>
		/// <param name="interfaceType">The type of the interface.</param>
		/// <param name="name">The name of the interface's method.</param>
		/// <returns>The type's method, that implements the specified <paramref name="interfaceType"/>'s method with the specified <paramref name="name"/>.</returns>
		public static MethodInfo GetInterfaceMethod(this Type type, Type interfaceType, string name)
		{
			Type implementedInterface;
			if (interfaceType.IsGenericTypeDefinition)
			{
				implementedInterface = Array.Find(type.GetInterfaces(), i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);
				if (implementedInterface == null) return null;
			}
			else
			{
				implementedInterface = interfaceType;
				if (!type.GetInterfaces().Contains(interfaceType)) return null;
			}
			InterfaceMapping mapping = type.GetInterfaceMap(implementedInterface);

			int index = Array.FindIndex(mapping.InterfaceMethods, m => m.Name == name);
			if (index == -1) return null;
			return mapping.TargetMethods[index];
		}
	}
	/// <summary>
	///   <para>Collection of helper methods for writing transpiler patches.</para>
	/// </summary>
	public static class TranspilerHelper
	{
		/// <summary>
		///   <para>Removes the first occurence of a region of the <paramref name="code"/>, starting at an instruction, matched by <paramref name="begin"/> predicate, and ending at an instruction, matched by <paramref name="end"/> predicate.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="begin">Predicate that matches the first instruction of the region to remove.</param>
		/// <param name="end">Predicate that matches the last instruction of the region to remove.</param>
		/// <returns>Modified code, with the specified region removed.</returns>
		public static IEnumerable<CodeInstruction> RemoveRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool> begin,
			Func<CodeInstruction, bool> end)
			=> RemoveRegion(code, new Func<CodeInstruction, bool>[] { begin }, new Func<CodeInstruction, bool>[] { end });
		/// <summary>
		///   <para>Removes the first occurence of a region of the <paramref name="code"/>, matched by <paramref name="region"/> predicates.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="region">Predicates that match to the instructions of the region to remove.</param>
		/// <returns>Modified code, with the specified region removed.</returns>
		public static IEnumerable<CodeInstruction> RemoveRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] region)
			=> RemoveRegion(code, region, new Func<CodeInstruction, bool>[0]);

		/// <summary>
		///   <para>Removes the first occurence of a region of the <paramref name="code"/>, starting with instructions, matched by <paramref name="begin"/> predicates, and ending with instructions, matched by <paramref name="end"/> predicates.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="begin">Predicates that match to the first instructions of the region to remove.</param>
		/// <param name="end">Predicates that match to the last instructions of the region to remove.</param>
		/// <returns>Modified code, with the specified region removed.</returns>
		public static IEnumerable<CodeInstruction> RemoveRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] begin,
			Func<CodeInstruction, bool>[] end)
		{
			if (code is null) throw new ArgumentNullException(nameof(code));
			if (begin is null) throw new ArgumentNullException(nameof(begin));
			if (end is null) throw new ArgumentNullException(nameof(end));
			if (begin.Length == 0) throw new ArgumentException($"{nameof(begin)} cannot be empty.", nameof(begin));
			if (Array.Exists(begin, b => b is null)) throw new ArgumentException($"Delegates in {nameof(begin)} cannot be null.", nameof(begin));
			if (Array.Exists(end, b => b is null)) throw new ArgumentException($"Delegates in {nameof(end)} cannot be null.", nameof(end));

			return RemoveRegion2();
			IEnumerable<CodeInstruction> RemoveRegion2()
			{
				SearchState state = SearchState.Searching;
				int current = 0;
				CodeInstruction[] cache = new CodeInstruction[begin.Length];
				foreach (CodeInstruction instr in code)
				{
					if (state == SearchState.Passed)
						yield return instr;
					else if (state == SearchState.Searching)
					{
						if (begin[current](instr))
						{
							cache[current] = instr;
							if (++current == begin.Length)
							{
								state = end.Length > 0 ? SearchState.Found : SearchState.Passed;
								current = 0;
							}
						}
						else
						{
							if (current > 0)
							{
								for (int i = 0; i < current; i++)
									yield return cache[i];
								current = 0;
							}
							yield return instr;
						}
					}
					else // if (state == SearchState.Found)
					{
						if (end[current](instr))
						{
							if (++current == end.Length)
								state = SearchState.Passed;
						}
						else current = 0;
					}
				}
			}
		}



		/// <summary>
		///   <para>Adds the specified <paramref name="region"/> to the <paramref name="code"/> after the first occurence of an instruction, matched by <paramref name="after"/> predicate.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="after">Predicate that matches to the instruction to add the <paramref name="region"/> after.</param>
		/// <param name="region">Collection of the instructions to add.</param>
		/// <returns>Modified code, with the specified <paramref name="region"/> added.</returns>
		public static IEnumerable<CodeInstruction> AddRegionAfter(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool> after,
			IEnumerable<CodeInstruction> region)
			=> AddRegionAfter(code, new Func<CodeInstruction, bool>[] { after }, _ => region);
		/// <summary>
		///   <para>Adds the specified <paramref name="region"/> to the <paramref name="code"/> after the first occurence of a region, matched by <paramref name="after"/> predicates.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="after">Predicates that match to the instructions to add the <paramref name="region"/> after.</param>
		/// <param name="region">Collection of the instructions to add.</param>
		/// <returns>Modified code, with the specified <paramref name="region"/> added.</returns>
		public static IEnumerable<CodeInstruction> AddRegionAfter(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] after,
			IEnumerable<CodeInstruction> region)
			=> AddRegionAfter(code, after, _ => region);
		/// <summary>
		///   <para>Adds the specified <paramref name="region"/> to the <paramref name="code"/> after the first occurence of a region, matched by <paramref name="after"/> predicates.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="after">Predicates that match to the instructions to add the <paramref name="region"/> after.</param>
		/// <param name="region">Collection of functions that return the instructions to add. These functions take a region, matched by <paramref name="after"/> predicates, as a parameter.</param>
		/// <returns>Modified code, with the specified <paramref name="region"/> added.</returns>
		public static IEnumerable<CodeInstruction> AddRegionAfter(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] after,
			IEnumerable<Func<CodeInstruction[], CodeInstruction>> region)
			=> AddRegionAfter(code, after, m => region.Select(a => a(m)));

		/// <summary>
		///   <para>Adds the specified <paramref name="region"/> to the <paramref name="code"/> after the first occurence of a region, matched by <paramref name="after"/> predicates.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="after">Predicates that match to the instructions to add the <paramref name="region"/> after.</param>
		/// <param name="region">Function that returns a collection of the instructions to add. Takes a region, matched by <paramref name="after"/> predicates, as a parameter.</param>
		/// <returns>Modified code, with the specified <paramref name="region"/> added.</returns>
		public static IEnumerable<CodeInstruction> AddRegionAfter(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] after,
			Func<CodeInstruction[], IEnumerable<CodeInstruction>> region)
		{
			if (code is null) throw new ArgumentNullException(nameof(code));
			if (after is null) throw new ArgumentNullException(nameof(after));
			if (region is null) throw new ArgumentNullException(nameof(region));
			if (after.Length == 0) throw new ArgumentException($"{nameof(after)} cannot be empty.", nameof(after));
			if (Array.Exists(after, a => a is null)) throw new ArgumentException($"Delegates in {nameof(after)} cannot be null.", nameof(after));

			return AddRegionAfter2();
			IEnumerable<CodeInstruction> AddRegionAfter2()
			{
				SearchState state = SearchState.Searching;
				int current = 0;
				CodeInstruction[] matches = new CodeInstruction[after.Length];
				foreach (CodeInstruction instr in code)
				{
					if (state == SearchState.Passed)
						yield return instr;
					else if (state == SearchState.Searching)
					{
						yield return instr;
						if (after[current](instr))
						{
							matches[current] = instr;
							if (++current == after.Length)
							{
								state = SearchState.Passed;
								CodeInstruction[] arr = new CodeInstruction[matches.Length];
								matches.CopyTo(arr, 0);
								IEnumerable<CodeInstruction> added = region(arr);
								if (added is null) throw new ArgumentException($"{nameof(region)} cannot return null.");
								foreach (CodeInstruction instr2 in added)
								{
									if (instr2 is null) throw new ArgumentException($"Collection returned by {nameof(region)} cannot contain null.", nameof(region));
									yield return new CodeInstruction(instr2);
								}
							}
						}
						else current = 0;
					}
				}
			}
		}



		/// <summary>
		///   <para>Adds the specified <paramref name="region"/> to the <paramref name="code"/> in front of the first occurence of an instruction, matched by <paramref name="before"/> predicate.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="before">Predicate that matches to the instruction to add the <paramref name="region"/> in front of.</param>
		/// <param name="region">Collection of the instructions to add.</param>
		/// <returns>Modified code, with the specified <paramref name="region"/> added.</returns>
		public static IEnumerable<CodeInstruction> AddRegionBefore(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool> before,
			IEnumerable<CodeInstruction> region)
			=> AddRegionBefore(code, new Func<CodeInstruction, bool>[] { before }, _ => region);
		/// <summary>
		///   <para>Adds the specified <paramref name="region"/> to the <paramref name="code"/> in front of the first occurence of a region, matched by <paramref name="before"/> predicates.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="before">Predicates that match to the instructions to add the <paramref name="region"/> in front of.</param>
		/// <param name="region">Collection of the instructions to add.</param>
		/// <returns>Modified code, with the specified <paramref name="region"/> added.</returns>
		public static IEnumerable<CodeInstruction> AddRegionBefore(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] before,
			IEnumerable<CodeInstruction> region)
			=> AddRegionBefore(code, before, _ => region);
		/// <summary>
		///   <para>Adds the specified <paramref name="region"/> to the <paramref name="code"/> in front of the first occurence of a region, matched by <paramref name="before"/> predicates.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="before">Predicates that match to the instructions to add the <paramref name="region"/> in front of.</param>
		/// <param name="region">Collection of functions that return the instructions to add. These functions take a region, matched by <paramref name="before"/> predicates, as a parameter.</param>
		/// <returns>Modified code, with the specified <paramref name="region"/> added.</returns>
		public static IEnumerable<CodeInstruction> AddRegionBefore(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] before,
			IEnumerable<Func<CodeInstruction[], CodeInstruction>> region)
			=> AddRegionBefore(code, before, m => region.Select(a => a(m)));

		/// <summary>
		///   <para>Adds the specified <paramref name="region"/> to the <paramref name="code"/> in front of the first occurence of a region, matched by <paramref name="before"/> predicates.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="before">Predicates that match to the instructions to add the <paramref name="region"/> in front of.</param>
		/// <param name="region">Function that returns a collection of the instructions to add. Takes a region, matched by <paramref name="before"/> predicates, as a parameter.</param>
		/// <returns>Modified code, with the specified <paramref name="region"/> added.</returns>
		public static IEnumerable<CodeInstruction> AddRegionBefore(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] before,
			Func<CodeInstruction[], IEnumerable<CodeInstruction>> region)
		{
			if (code is null) throw new ArgumentNullException(nameof(code));
			if (before is null) throw new ArgumentNullException(nameof(before));
			if (region is null) throw new ArgumentNullException(nameof(region));
			if (before.Length == 0) throw new ArgumentException($"{nameof(before)} cannot be empty.", nameof(before));
			if (Array.Exists(before, b => b is null)) throw new ArgumentException($"Delegates in {nameof(before)} cannot be null.", nameof(before));

			return AddRegionBefore2();
			IEnumerable<CodeInstruction> AddRegionBefore2()
			{
				SearchState state = SearchState.Searching;
				int current = 0;
				CodeInstruction[] matches = new CodeInstruction[before.Length];
				foreach (CodeInstruction instr in code)
				{
					if (state == SearchState.Passed)
						yield return instr;
					else if (state == SearchState.Searching)
					{
						if (before[current](instr))
						{
							matches[current] = instr;
							if (++current == before.Length)
							{
								state = SearchState.Passed;
								CodeInstruction[] arr = new CodeInstruction[matches.Length];
								matches.CopyTo(arr, 0);
								IEnumerable<CodeInstruction> added = region(arr);
								if (added is null) throw new ArgumentException($"{nameof(region)} cannot return null.");
								foreach (CodeInstruction instr2 in added)
								{
									if (instr2 is null) throw new ArgumentException($"Collection returned by {nameof(region)} cannot contain null.", nameof(region));
									yield return new CodeInstruction(instr2);
								}
								for (int i = 0; i < current; i++)
									yield return matches[i];
							}
						}
						else
						{
							if (current > 0)
							{
								for (int i = 0; i < current; i++)
									yield return matches[i];
								current = 0;
							}
							yield return instr;
						}
					}
				}
			}
		}



		/// <summary>
		///   <para>Replaces a region of the <paramref name="code"/>, starting with instructions, matched by <paramref name="begin"/> predicates, and ending with instructions, matched by <paramref name="end"/> predicates, with the specified <paramref name="replacer"/> region.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="begin">Predicates that match to the first instructions of the region to replace.</param>
		/// <param name="end">Predicates that match to the last instructions of the region to replace.</param>
		/// <param name="replacer">Collection of the instructions to replace a region with.</param>
		/// <returns>Modified code, with the specified region replaced with <paramref name="replacer"/>.</returns>
		public static IEnumerable<CodeInstruction> ReplaceRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] begin,
			Func<CodeInstruction, bool>[] end, IEnumerable<CodeInstruction> replacer)
			=> ReplaceRegion(code, begin, end, (_, __) => replacer);
		/// <summary>
		///   <para>Replaces a region of the <paramref name="code"/>, starting with instructions, matched by <paramref name="begin"/> predicates, and ending with instructions, matched by <paramref name="end"/> predicates, with the specified <paramref name="replacer"/> region.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="begin">Predicates that match to the first instructions of the region to replace.</param>
		/// <param name="end">Predicates that match to the last instructions of the region to replace.</param>
		/// <param name="replacer">Collection of functions that return the instructions to replace a region with. These functions take regions, matched by <paramref name="begin"/> and <paramref name="end"/> predicates, as parameters.</param>
		/// <returns>Modified code, with the specified region replaced with <paramref name="replacer"/>.</returns>
		public static IEnumerable<CodeInstruction> ReplaceRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] begin,
			Func<CodeInstruction, bool>[] end, IEnumerable<Func<CodeInstruction[], CodeInstruction[], CodeInstruction>> replacer)
			=> ReplaceRegion(code, begin, end, (a, b) => replacer.Select(r => r(a, b)));

		/// <summary>
		///   <para>Replaces a region of the <paramref name="code"/>, matched by <paramref name="region"/> predicates, with the specified <paramref name="replacer"/> region.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="region">Predicates that match to the instructions of the region to remove.</param>
		/// <param name="replacer">Collection of the instructions to replace the specified <paramref name="region"/> with.</param>
		/// <returns>Modified code, with the specified <paramref name="region"/> replaced with <paramref name="replacer"/>.</returns>
		public static IEnumerable<CodeInstruction> ReplaceRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] region, IEnumerable<CodeInstruction> replacer)
			=> ReplaceRegion(code, region, new Func<CodeInstruction, bool>[0], (_, __) => replacer);
		/// <summary>
		///   <para>Replaces a region of the <paramref name="code"/>, matched by <paramref name="region"/> predicates, with the specified <paramref name="replacer"/> region.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="region">Predicates that match to the instructions of the region to remove.</param>
		/// <param name="replacer">Collection of functions that return the instructions to replace the specified <paramref name="region"/> with. These functions take a region, matched by <paramref name="region"/> predicates, as a parameter.</param>
		/// <returns>Modified code, with the specified <paramref name="region"/> replaced with <paramref name="replacer"/>.</returns>
		public static IEnumerable<CodeInstruction> ReplaceRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] region, IEnumerable<Func<CodeInstruction[], CodeInstruction>> replacer)
			=> ReplaceRegion(code, region, new Func<CodeInstruction, bool>[0], (replaced, _) => replacer.Select(r => r(replaced)));

		/// <summary>
		///   <para>Replaces a region of the <paramref name="code"/>, starting with instructions, matched by <paramref name="begin"/> predicates, and ending with instructions, matched by <paramref name="end"/> predicates, with the specified <paramref name="replacer"/> region.</para>
		/// </summary>
		/// <param name="code">Original method's code.</param>
		/// <param name="begin">Predicates that match to the first instructions of the region to replace.</param>
		/// <param name="end">Predicates that match to the last instructions of the region to replace.</param>
		/// <param name="replacer">Function that returns a collection of the instructions to replace a region with. Takes regions, matched by <paramref name="begin"/> and <paramref name="end"/> predicates, as parameters.</param>
		/// <returns>Modified code, with the specified region replaced with <paramref name="replacer"/>.</returns>
		public static IEnumerable<CodeInstruction> ReplaceRegion(this IEnumerable<CodeInstruction> code, Func<CodeInstruction, bool>[] begin, Func<CodeInstruction, bool>[] end, Func<CodeInstruction[], CodeInstruction[], IEnumerable<CodeInstruction>> replacer)
		{
			if (code is null) throw new ArgumentNullException(nameof(code));
			if (begin is null) throw new ArgumentNullException(nameof(begin));
			if (end is null) throw new ArgumentNullException(nameof(end));
			if (replacer is null) throw new ArgumentNullException(nameof(replacer));
			if (begin.Length == 0) throw new ArgumentException($"{nameof(begin)} cannot be empty.", nameof(begin));
			if (Array.Exists(begin, b => b is null)) throw new ArgumentException($"Delegates in {nameof(begin)} cannot be null.", nameof(begin));
			if (Array.Exists(end, e => e is null)) throw new ArgumentException($"Delegates in {nameof(end)} cannot be null.", nameof(end));

			return ReplaceRegion2();
			IEnumerable<CodeInstruction> ReplaceRegion2()
			{
				SearchState state = SearchState.Searching;
				int current = 0;
				CodeInstruction[] beginCache = new CodeInstruction[begin.Length];
				CodeInstruction[] endCache = new CodeInstruction[end.Length];
				foreach (CodeInstruction instr in code)
				{
					if (state == SearchState.Passed)
						yield return instr;
					else if (state == SearchState.Searching)
					{
						if (begin[current](instr))
						{
							beginCache[current] = instr;
							if (++current == begin.Length)
							{
								state = end.Length > 0 ? SearchState.Found : SearchState.Passed;
								if (state == SearchState.Passed)
								{
									IEnumerable<CodeInstruction> replaced = replacer(beginCache, endCache);
									if (replaced is null) throw new ArgumentException($"{nameof(replacer)} cannot return null.");
									foreach (CodeInstruction instr2 in replaced)
									{
										if (instr2 is null) throw new ArgumentException($"Collection returned by {nameof(replacer)} cannot contain null.", nameof(replacer));
										yield return new CodeInstruction(instr2);
									}
								}
								current = 0;
							}
						}
						else
						{
							if (current > 0)
							{
								for (int i = 0; i < current; i++)
									yield return beginCache[i];
								current = 0;
							}
							yield return instr;
						}
					}
					else // if (state == SearchState.Found)
					{
						if (end[current](instr))
						{
							endCache[current] = instr;
							if (++current == end.Length)
							{
								state = SearchState.Passed;
								IEnumerable<CodeInstruction> replaced = replacer(beginCache, endCache);
								if (replaced is null) throw new ArgumentException($"{nameof(replacer)} cannot return null.");
								foreach (CodeInstruction instr2 in replaced)
								{
									if (instr2 is null) throw new ArgumentException($"Collection returned by {nameof(replacer)} cannot contain null.", nameof(replacer));
									yield return new CodeInstruction(instr2);
								}
							}
						}
						else current = 0;
					}
				}
			}
		}



		private enum SearchState
		{
			Searching = 0,
			Found     = 1,
			Passed    = 2
		}

		/// <summary>
		///   <para>Copies all labels from the specified <paramref name="otherInstruction"/> into a copy of the current one.</para>
		/// </summary>
		/// <param name="instruction">The current instance of <see cref="CodeInstruction"/>.</param>
		/// <param name="otherInstruction">Another instance of <see cref="CodeInstruction"/> to copy labels from.</param>
		/// <returns>The copy of the current instance with labels from <see cref="CodeInstruction"/>.</returns>
		public static CodeInstruction WithLabels(this CodeInstruction instruction, CodeInstruction otherInstruction)
		{
			CodeInstruction instr = new CodeInstruction(instruction);
			instr.labels.AddRange(otherInstruction.labels);
			return instr;
		}
	}
}

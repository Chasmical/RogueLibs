using System;
using System.IO;
using System.Collections.ObjectModel;
using System.Reflection.Emit;
using System.Threading;
using System.Linq;
using BepInEx;
using UnityEngine;
using UnityEngine.Networking;
using System.Reflection;

namespace RogueLibsCore
{
	public static class RogueUtilities
	{
		public static readonly ReadOnlyCollection<string> Empty = new ReadOnlyCollection<string>(new string[0]);

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

		public static Sprite ConvertToSprite(byte[] rawData, Rect region, float ppu = 64f)
		{
			if (rawData is null) throw new ArgumentNullException(nameof(rawData));
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			Texture2D texture = new Texture2D(15, 9);
			texture.LoadImage(rawData);
			return Sprite.Create(texture, region, 0.5f * region.size, ppu);
		}
		public static Sprite ConvertToSprite(byte[] rawData, float ppu = 64f)
		{
			if (rawData is null) throw new ArgumentNullException(nameof(rawData));
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			Texture2D texture = new Texture2D(15, 9);
			texture.LoadImage(rawData);
			Rect region = new Rect(0, 0, texture.width, texture.height);
			return Sprite.Create(texture, region, 0.5f * region.size, ppu);
		}
		public static Sprite ConvertToSprite(string filePath, float ppu = 64f)
		{
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			return ConvertToSprite(File.ReadAllBytes(filePath), ppu);
		}
		public static Sprite ConvertToSprite(string filePath, Rect region, float ppu = 64f)
		{
			if (ppu <= 0f) throw new ArgumentOutOfRangeException(nameof(ppu), ppu, $"{nameof(ppu)} must be greater than 0.");
			return ConvertToSprite(File.ReadAllBytes(filePath), region, ppu);
		}

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
		public static AudioClip ConvertToAudioClip(string filePath, AudioType format)
		{
			if (format != AudioType.MPEG && format != AudioType.WAV && format != AudioType.OGGVORBIS)
				throw new NotSupportedException($"{format} is not supported. Supported audio formats: {AudioType.MPEG}, {AudioType.WAV} and {AudioType.OGGVORBIS}.");
			UnityWebRequest request = UnityWebRequestMultimedia.GetAudioClip("file:///" + filePath, format);
			request.SendWebRequest();
			while (!request.isDone) Thread.Sleep(1);
			return DownloadHandlerAudioClip.GetContent(request);
		}
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

		public static MethodInfo GetInterfaceMethod(this Type type, Type interfaceType, string name)
		{
			Type implementedInterface;
			if (interfaceType.IsGenericTypeDefinition)
			{
				implementedInterface = Array.Find(type.GetInterfaces(), i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);
				if (implementedInterface is null) return null;
			}
			else
			{
				implementedInterface = interfaceType;
				if (!type.GetInterfaces().Contains(interfaceType)) return null;
			}
			InterfaceMapping mapping = type.GetInterfaceMap(implementedInterface);

			int index = Array.FindIndex(mapping.InterfaceMethods, m => m.Name == name);
			if (index is -1) return null;
			return mapping.TargetMethods[index];
		}
		public static MethodInfo[] GetInterfaceMethods(this Type type, Type interfaceType, params string[] names)
		{
			Type implementedInterface;
			if (interfaceType.IsGenericTypeDefinition)
			{
				implementedInterface = Array.Find(type.GetInterfaces(), i => i.IsGenericType && i.GetGenericTypeDefinition() == interfaceType);
				if (implementedInterface is null) return null;
			}
			else
			{
				implementedInterface = interfaceType;
				if (!type.GetInterfaces().Contains(interfaceType)) return null;
			}
			InterfaceMapping mapping = type.GetInterfaceMap(implementedInterface);

			MethodInfo[] methods = new MethodInfo[names.Length];
			for (int i = 0; i < names.Length; i++)
			{
				int index = Array.FindIndex(mapping.InterfaceMethods, m => m.Name == names[i]);
				if (index is -1) return null;
				methods[i] = mapping.TargetMethods[index];
			}
			return methods;
		}
	}
}

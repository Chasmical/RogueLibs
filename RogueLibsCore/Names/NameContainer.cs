using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace RogueLibsCore
{
    internal static class NameContainer
    {
        public static string? Get(object? container, LanguageCode code)
        {
            if (container is null) return null;
            if (container is string text) return code == LanguageCode.English ? text : null;

            if (container is string?[] array) return GetArray(array, code);
            return GetDict((Dictionary<LanguageCode, string>)container, code);

            static string? GetArray(string?[] array, LanguageCode code)
                => (int)code < array.Length ? array[(int)code] : null;

            static string? GetDict(Dictionary<LanguageCode, string> dict, LanguageCode code)
                => dict.TryGetValue(code, out string? value) ? value : null;
        }

        [MustUseReturnValue]
        public static object? Set(object? container, LanguageCode code, string? value)
        {
            if (container is null)
                return value is null ? null : SetNew(code, value);
            if (container is string text)
                return SetString(text, code, value);
            if (container is string?[] array)
                return SetArray(array, code, value);
            return SetDict((Dictionary<LanguageCode, string>)container, code, value);
        }
        private static object SetNew(LanguageCode code, string value)
        {
            if (code == LanguageCode.English) return value;
            if ((int)code < 32)
            {
                string?[] array = new string?[LengthCeil8((int)code)];
                array[(int)code] = value;
                return array;
            }
            return new Dictionary<LanguageCode, string> { [code] = value };
        }
        private static object? SetString(string container, LanguageCode code, string? value)
        {
            if (code == LanguageCode.English) return value;
            if (value is null) return container;
            if ((int)code < 32)
            {
                string?[] array = new string?[LengthCeil8((int)code)];
                array[(int)LanguageCode.English] = container;
                array[(int)code] = value;
                return array;
            }
            return new Dictionary<LanguageCode, string>
            {
                [LanguageCode.English] = container,
                [code] = value,
            };
        }
        private static object SetArray(string?[] array, LanguageCode code, string? value)
        {
            if ((int)code >= array.Length)
            {
                if (value is null) return array;
                if ((int)code >= 32)
                {
                    Dictionary<LanguageCode, string> dict = new();
                    for (int i = 0; i < array.Length; i++)
                        if (array[i] is not null)
                            dict[(LanguageCode)i] = array[i]!;
                    dict[code] = value;
                    return dict;
                }
                Array.Resize(ref array, LengthCeil8((int)code));
            }
            array[(int)code] = value;
            return array;
        }
        private static object SetDict(Dictionary<LanguageCode, string> dict, LanguageCode code, string? value)
        {
            if (value is not null)
                dict[code] = value;
            else dict.Remove(code);
            return dict;
        }

        public static object? Clone(object? container)
        {
            if (container is null) return null;
            if (container is string) return container;
            if (container is string?[] array) return array.ToArray();
            return ((Dictionary<LanguageCode, string>)container).ToDictionary(static p => p);
        }

        public static IEnumerator<KeyValuePair<LanguageCode, string>> Enumerate(object? container)
        {
            if (container is null) yield break;
            if (container is string text)
            {
                yield return new KeyValuePair<LanguageCode, string>(LanguageCode.English, text);
            }
            else if (container is string?[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] is not null)
                        yield return new KeyValuePair<LanguageCode, string>((LanguageCode)i, array[i]!);
                }
            }
            else
            {
                foreach (KeyValuePair<LanguageCode, string> entry in (Dictionary<LanguageCode, string>)container)
                    yield return entry;
            }
        }

        private static int LengthCeil8(int num)
            => (num + 8) & ~0b111;

    }
    internal interface IUsesNameContainer
    {
        object? GetNameContainer();
    }
}

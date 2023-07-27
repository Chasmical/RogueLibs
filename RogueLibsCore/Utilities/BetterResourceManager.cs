using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace RogueLibsCore
{
    internal sealed class BetterResourceManager : ResourceManager
    {
        public BetterResourceManager(string baseName, Assembly assembly)
            : base(baseName, assembly) { }

        private readonly Dictionary<string, object> cache = new();

        public override object? GetObject(string name)
            => GetObject(name, CultureInfo.CurrentUICulture);
        public override object? GetObject(string name, CultureInfo culture)
        {
            if (!cache.TryGetValue(name, out object? obj))
                cache.Add(name, obj = base.GetObject(name, culture));
            return obj;
        }

        public override void ReleaseAllResources()
        {
            cache.Clear();
            base.ReleaseAllResources();
        }

    }
}

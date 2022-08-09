// ReSharper disable once CheckNamespace
namespace System.Diagnostics.CodeAnalysis
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property)]
    public sealed class AllowNullAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property)]
    public sealed class DisallowNullAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue)]
    public sealed class MaybeNullAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Parameter)]
    public sealed class MaybeNullWhenAttribute : Attribute { }
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property | AttributeTargets.ReturnValue, AllowMultiple = true)]
    public sealed class NotNullIfNotNullAttribute : Attribute { }
}

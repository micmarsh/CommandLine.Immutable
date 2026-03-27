using LanguageExt;
using static LanguageExt.Prelude;

namespace CommandLine.Immutable;

public static class OptionalInput
{
    public static System.CommandLine.Option<Option<T>> Opt<T>(string name, params string[] aliases) =>
        new (name, aliases)
        {
            DefaultValueFactory = _ => None,
            CustomParser = r => Optional(r.GetValueOrDefault<T>()),
            Required = false
        };
    
    public static System.CommandLine.Argument<Option<T>> Arg<T>(string name) =>
        new (name)
        {
            DefaultValueFactory = _ => None,
            CustomParser = r => Optional(r.GetValueOrDefault<T>())
        };   
}
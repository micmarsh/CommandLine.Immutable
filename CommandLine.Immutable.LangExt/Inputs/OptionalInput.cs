using System.CommandLine.Parsing;
using System.Reflection;
using CommandLine.Immutable.Utilities;
using LanguageExt;
using static LanguageExt.Prelude;

namespace CommandLine.Immutable;

public static class OptionalInput
{
    public static System.CommandLine.Option<Option<T>> Opt<T>(string name, params string[] aliases) =>
        new(name, aliases)
        {
            DefaultValueFactory = _ => None,
            Required = false,
            CustomParser = arg => OptionalArgResultParser<T>(name, arg)
        };

    private static Option<T> OptionalArgResultParser<T>(string name, ArgumentResult arg) =>
        arg.Tokens switch
        {
            [] => None,
            [{ Value: var str }] => ParseToOption<T>(str),
            [_, ..] => throw new ArgumentException($"Only single-token inputs are supported for {name}")
        };
    
    private static Option<T> ParseToOption<T>(string str)
    {
        var type = typeof(T);
        if (!ArgumentConverter.StringConverters.TryGetValue(type, out var converter))
        {
            throw new ArgumentException($"Could not find converter for {type.Name} (TODO: create introduce a mechanism to add global custom? What does System.CommandLine do?)")
        }
        if (converter(str, out var result))
        {
            return Optional((T?)result);
        }

        throw new ArgumentException($"Could not parse {str} into {type.Name}");
    }

    public static System.CommandLine.Argument<Option<T>> Arg<T>(string name) =>
        new (name)
        {
            DefaultValueFactory = _ => None,
            CustomParser = r => OptionalArgResultParser<T>(name, r)
        };   
}
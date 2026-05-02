using System.Reflection;
using LanguageExt;
using static LanguageExt.Prelude;

namespace CommandLine.Immutable;

public static class OptionalInput
{
    public static System.CommandLine.Option<Option<T>> Opt<T>(string name, params string[] aliases) 
        where T : IParsable<T> =>
       // typeof(T).GetMethod("Parse", BindingFlags.Static | BindingFlags.Public)
        new (name, aliases)
        {
            DefaultValueFactory = _ => None,
            CustomParser = r =>  r.Tokens switch
            {
                [] => None,
                [var token, ..] => Some(T.Parse(token.Value, null))
            },
            Required = false
        };
    
    public static System.CommandLine.Argument<Option<T>> Arg<T>(string name) 
        where T : IParsable<T> =>
        new (name)
        {
            DefaultValueFactory = _ => None,
            CustomParser = r => r.Tokens switch
            {
                [] => None,
                [var token, ..] => Some(T.Parse(token.Value, null))
            },
        };   
}
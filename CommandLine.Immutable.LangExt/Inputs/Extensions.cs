using System.CommandLine;
using System.CommandLine.Completions;
using System.CommandLine.Invocation;
using System.CommandLine.Parsing;
using LanguageExt;
using LanguageExt.Common;
using static CommandLine.Immutable.Parsing;

namespace CommandLine.Immutable;

public static class Extensions
{
    /// <summary>
    /// Helper method to make setting properties on Options immutable/functional, as well as auto-converting validation, parsing,
    /// and factory properties using <see cref="Parsing"/>
    /// </summary>
    public static System.CommandLine.Option<T> With<T>(this System.CommandLine.Option<T> opt,
        string? Name = null,
        IEnumerable<string>? Aliases = null,
        bool? Hidden = null,
        bool? Recursive = null,
        string? Description = null,
        bool? Required = null,
        bool? AllowMultipleArgumentsPerToken = null,
        string? HelpName = null,
        Func<ArgumentResult, Fin<T>>? DefaultValueFactory = null,
        Func<ArgumentResult, Fin<T>>? CustomParser = null,
        CommandLineAction? Action = null,
        ArgumentArity? Arity = null,
        IEnumerable<Func<OptionResult, Seq<Error>>>? Validators = null,
        IEnumerable<Func<CompletionContext, IEnumerable<CompletionItem>>>? CompletetionSources = null)
    {
        var result = new System.CommandLine.Option<T>(Name ?? opt.Name, (Aliases ?? opt.Aliases).ToArray())
        {
            Description = Description ?? opt.Description,
            DefaultValueFactory = DefaultValueFactory == null ? opt.DefaultValueFactory : factory(DefaultValueFactory),
            CustomParser = CustomParser == null? opt.CustomParser : factory(CustomParser),
            Required = Required ?? opt.Required,
            Action = Action ?? opt.Action,
            AllowMultipleArgumentsPerToken = AllowMultipleArgumentsPerToken ?? opt.AllowMultipleArgumentsPerToken,
            Arity = Arity ?? opt.Arity,
            HelpName = HelpName ?? opt.HelpName,
            Hidden = Hidden ?? opt.Hidden,
            Recursive = Recursive ?? opt.Recursive,
        };
        foreach (var source in (CompletetionSources ?? opt.CompletionSources))
            result.CompletionSources.Add(source);
        // "Parents" is not only read-only, but seemingly set elsewhere and not relevant here
        // foreach (var parent in  opt.Parents)
        foreach (var validator in (Validators?.Select(validate) ?? opt.Validators))
            result.Validators.Add(validator);
        return result;
    } 
    
    /// <summary>
    /// Helper method to make setting properties on Arguments immutable/functional, as well as auto-converting validation, parsing,
    /// and factory properties using <see cref="Parsing"/>
    /// </summary>
    public static Argument<T> With<T>(this System.CommandLine.Argument<T> opt,
        string? Name = null,
        bool? Hidden = null,
        string? Description = null,
        string? HelpName = null,
        Func<ArgumentResult, Fin<T>>? DefaultValueFactory = null,
        Func<ArgumentResult, Fin<T>>? CustomParser = null,
        ArgumentArity? Arity = null,
        IEnumerable<Func<ArgumentResult, Seq<Error>>>? Validators = null,
        IEnumerable<Func<CompletionContext, IEnumerable<CompletionItem>>>? CompletetionSources = null)
    {
        var result = new System.CommandLine.Argument<T>(Name ?? opt.Name)
        {
            Description = Description ?? opt.Description,
            DefaultValueFactory = DefaultValueFactory == null ? opt.DefaultValueFactory : factory(DefaultValueFactory),
            CustomParser = CustomParser == null? opt.CustomParser : factory(CustomParser),
            Arity = Arity ?? opt.Arity,
            HelpName = HelpName ?? opt.HelpName,
            Hidden = Hidden ?? opt.Hidden,
        };
        foreach (var source in (CompletetionSources ?? opt.CompletionSources))
            result.CompletionSources.Add(source);
        // "Parents" is not only read-only, but seemingly set elsewhere and not relevant here
        // foreach (var parent in  opt.Parents)
        foreach (var validator in (Validators?.Select(validate) ?? opt.Validators))
            result.Validators.Add(validator);
        return result;
    }
}
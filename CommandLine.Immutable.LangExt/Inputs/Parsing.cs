using System.CommandLine;
using System.CommandLine.Completions;
using System.CommandLine.Parsing;
using LanguageExt;
using LanguageExt.Common;

namespace CommandLine.Immutable;

public static class Parsing
{
    /// <summary>
    /// Use to convert a function to a suitable imperative action for <see cref="Argument.Validators"/>
    /// </summary>
    /// <param name="f">Function that returns a sequence of errors that are then set using <see cref="ArgumentResult.AddError"/>.
    /// Will recursively set <see cref="ManyErrors"/> as separate messages</param>
    /// <returns></returns>
    public static Action<ArgumentResult> validate(Func<ArgumentResult, Seq<Error>> f) => result =>
    {
        var err = f(result);
        setResultErrors(err, result);
    };
    
    /// <summary>
    /// Use to convert a function to a suitable imperative action for
    /// <see cref="System.CommandLine.Option.Validators"/>
    /// </summary>
    /// <param name="f">Function that returns a sequence of errors that are then set using <see cref="ArgumentResult.AddError"/>.
    /// Will recursively set <see cref="ManyErrors"/> as separate messages</param>
    /// <returns></returns>
    public static Action<OptionResult> validate(Func<OptionResult, Seq<Error>> f) => result =>
    {
        var err = f(result);
        setResultErrors(err, result);
    };

    /// <summary>
    /// Use to convert a pure function to a suitable imperative function for <see cref="System.CommandLine.Option{T}.DefaultValueFactory"/>,
    ///  <see cref="System.CommandLine.Option{T}.CustomParser"/>, <see cref="System.CommandLine.Argument{T}.DefaultValueFactory"/>, or
    ///  <see cref="System.CommandLine.Argument{T}.CustomParser"/>
    /// </summary>
    /// <param name="validate">Function that returns a <see cref="Fin"/>: success representing a successful value creation or parsing,
    /// and Error representing error messages (multiple errors can be represented with <see cref="ManyErrors"/>) to print</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static Func<ArgumentResult, T> factory<T>(Func<ArgumentResult, Fin<T>> validate) => argResult =>
    {
        return validate(argResult).Match(
            result => result,
            err =>
            {
                setResultErrors([err], argResult);
                return default;
            }
        );
    };
    
    private static void setResultErrors(Seq<Error> errs, SymbolResult result)
    {
        foreach (var err in errs)
            switch (err)
            {
                case Expected expected:
                    result.AddError(expected.Message);
                    break;
                case ManyErrors many:
                    setResultErrors(many.Errors, result);
                    break;
                default:
                    err.ToErrorException().Rethrow();
                    break;
            }
    }
}
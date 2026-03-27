using System.CommandLine;
using LanguageExt;
namespace CommandLine.Immutable.Generator;

public static class CmdTemplateExtensions
{
    // GENERATOR PROGRAM WILL DROP UP TO LINE 7 AND LAST LINE (WITH }), REWRITE THIS ACCORDINGLY
    
    public static CmdTemplate<PLACEHOLDER> WithAction<PLACEHOLDER>(this CmdTemplate<PLACEHOLDER> cmd, Func<PLACEHOLDER, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.placeholderFields.GetValue(parseResult))
                    // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static CmdTemplate<PLACEHOLDER> WithAction<PLACEHOLDER>(this CmdTemplate<PLACEHOLDER> cmd, Func<PLACEHOLDER, IO<Unit>> action) 
        => cmd.WithAction((placeHolder) => action(placeHolder).Map(_ => 0));
}
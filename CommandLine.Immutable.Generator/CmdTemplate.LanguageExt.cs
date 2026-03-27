using System.CommandLine;
using LanguageExt;
namespace CommandLine.Immutable.Generator;


public readonly partial record struct CmdTemplate<PLACEHOLDER>
{
    public CmdTemplate<PLACEHOLDER> WithAction(Func<PLACEHOLDER, IO<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.placeholderFields.GetValue(parseResult))
            // .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
                        .RunAsync(EnvIO.New(token: ct))
                        .AsTask())
        };
    }
    
    public CmdTemplate<PLACEHOLDER> WithAction(Func<PLACEHOLDER, IO<Unit>> action)
    {
        var self = this;
        return WithAction((placeHolder) => action(placeHolder).Map(_ => 0));
    }
}
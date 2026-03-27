using System.CommandLine;
using LanguageExt;

namespace CommandLine.Immutable.Generator;

public readonly partial record struct CmdTemplate<PLACEHOLDER>
{
    // public Command SetAction(Func<PLACEHOLDER, IO<int>> action)
    // {
    //     var result = new Command(Name, Description);
    //     placeholderFields.AddTo(result);
    //     var self = this;
    //     result.SetAction((parseResult, ct) => action(self.placeholderFields.GetValue(parseResult))
    //         .Catch(err => LangEx.defaultErrorHandler(err, parseResult))
    //         .RunAsync(EnvIO.New(token: ct))
    //         .AsTask());
    //     foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
    //     return result;
    // }
    
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
        return WithAction(placeHolder => action(placeHolder).Map(_ => 0));
    }
}
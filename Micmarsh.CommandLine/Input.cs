using System.CommandLine;

namespace Micmarsh.CommandLine;

public interface Input<T>
{
    T GetValue(ParseResult parseResult);
    void AddTo(Command command);
}

public readonly record struct Opt<T>(Option<T> Value) : Input<T>
{
    public T GetValue(ParseResult parseResult) => parseResult.GetRequiredValue(Value);
    public void AddTo(Command command) => command.Add(Value);
}

public readonly record struct Arg<T>(Argument<T> Value) : Input<T>
{
    public T GetValue(ParseResult parseResult) => parseResult.GetRequiredValue(Value);
    public void AddTo(Command command) => command.Add(Value);
}
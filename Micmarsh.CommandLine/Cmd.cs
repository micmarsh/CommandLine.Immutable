using System.CommandLine;

namespace Micmarsh.CommandLine.Generator;


// Script drops first three lines, adjust if any more imports are ever added!

public readonly record struct Cmd<A>(Input<A> input0, IEnumerable<Command> SubCommands)
{
    public Cmd<A, Next> AddOption<Next>(Option<Next> next) => 
        new(input0, new Opt<Next>(next), SubCommands);
    public Cmd<A, Next> AddArgument<Next>(Argument<Next> next) => 
        new(input0, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, int> action)
        => SetAction(name, description, (a, _) => Task.FromResult(action(a)));
    
    public Command SetAction(string name, string description, Func<A, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
        input0.AddTo(result);
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};
// Script drops first three lines, adjust if any more imports are ever added!

public readonly record struct Cmd<A, B>(Input<A> input0, Input<B> input1, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, Next> AddOption<Next>(Option<Next> next) => 
        new(input0, input1, new Opt<Next>(next), SubCommands);
    public Cmd<A, B, Next> AddArgument<Next>(Argument<Next> next) => 
        new(input0, input1, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, B, int> action)
        => SetAction(name, description, (a, b, _) => Task.FromResult(action(a, b)));
    
    public Command SetAction(string name, string description, Func<A, B, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
        input0.AddTo(result);
		input1.AddTo(result);
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};
// Script drops first three lines, adjust if any more imports are ever added!

public readonly record struct Cmd<A, B, C>(Input<A> input0, Input<B> input1, Input<C> input2, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, Next> AddOption<Next>(Option<Next> next) => 
        new(input0, input1, input2, new Opt<Next>(next), SubCommands);
    public Cmd<A, B, C, Next> AddArgument<Next>(Argument<Next> next) => 
        new(input0, input1, input2, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, B, C, int> action)
        => SetAction(name, description, (a, b, c, _) => Task.FromResult(action(a, b, c)));
    
    public Command SetAction(string name, string description, Func<A, B, C, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B, C> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};
// Script drops first three lines, adjust if any more imports are ever added!

public readonly record struct Cmd<A, B, C, D>(Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, D, Next> AddOption<Next>(Option<Next> next) => 
        new(input0, input1, input2, input3, new Opt<Next>(next), SubCommands);
    public Cmd<A, B, C, D, Next> AddArgument<Next>(Argument<Next> next) => 
        new(input0, input1, input2, input3, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, B, C, D, int> action)
        => SetAction(name, description, (a, b, c, d, _) => Task.FromResult(action(a, b, c, d)));
    
    public Command SetAction(string name, string description, Func<A, B, C, D, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B, C, D> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};
// Script drops first three lines, adjust if any more imports are ever added!

public readonly record struct Cmd<A, B, C, D, E>(Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, IEnumerable<Command> SubCommands)
{
    // public Cmd<A, B, C, D, E, Next> AddOption<Next>(Option<Next> next) => 
    //     new(input0, input1, input2, input3, input4, new Opt<Next>(next), SubCommands);
    // public Cmd<A, B, C, D, E, Next> AddArgument<Next>(Argument<Next> next) => 
    //     new(input0, input1, input2, input3, input4, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, B, C, D, E, int> action)
        => SetAction(name, description, (a, b, c, d, e, _) => Task.FromResult(action(a, b, c, d, e)));
    
    public Command SetAction(string name, string description, Func<A, B, C, D, E, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B, C, D, E> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};
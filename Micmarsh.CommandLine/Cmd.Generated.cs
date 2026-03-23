using System.CommandLine;

namespace Micmarsh.CommandLine.Generator;

public readonly record struct Cmd<A>(string Name, string Description, Input<A> input0, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public Cmd<A, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, input0, new Opt<Next>(next), SubCommands, SetAction);
    public Cmd<A, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, input0, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A> WithAction(Func<A, int> action)
        => WithAction((a, _) => Task.FromResult(action(a)));

    public Cmd<A> WithAction(Func<A, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B>(string Name, string Description, Input<A> input0, Input<B> input1, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public Cmd<A, B, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, input0, input1, new Opt<Next>(next), SubCommands, SetAction);
    public Cmd<A, B, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, input0, input1, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A, B> WithAction(Func<A, B, int> action)
        => WithAction((a, b, _) => Task.FromResult(action(a, b)));

    public Cmd<A, B> WithAction(Func<A, B, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
		input1.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A, B> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C>(string Name, string Description, Input<A> input0, Input<B> input1, Input<C> input2, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public Cmd<A, B, C, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, input0, input1, input2, new Opt<Next>(next), SubCommands, SetAction);
    public Cmd<A, B, C, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, input0, input1, input2, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A, B, C> WithAction(Func<A, B, C, int> action)
        => WithAction((a, b, c, _) => Task.FromResult(action(a, b, c)));

    public Cmd<A, B, C> WithAction(Func<A, B, C, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A, B, C> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D>(string Name, string Description, Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public Cmd<A, B, C, D, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, new Opt<Next>(next), SubCommands, SetAction);
    public Cmd<A, B, C, D, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A, B, C, D> WithAction(Func<A, B, C, D, int> action)
        => WithAction((a, b, c, d, _) => Task.FromResult(action(a, b, c, d)));

    public Cmd<A, B, C, D> WithAction(Func<A, B, C, D, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A, B, C, D> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E>(string Name, string Description, Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public Cmd<A, B, C, D, E, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, new Opt<Next>(next), SubCommands, SetAction);
    public Cmd<A, B, C, D, E, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A, B, C, D, E> WithAction(Func<A, B, C, D, E, int> action)
        => WithAction((a, b, c, d, e, _) => Task.FromResult(action(a, b, c, d, e)));

    public Cmd<A, B, C, D, E> WithAction(Func<A, B, C, D, E, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A, B, C, D, E> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F>(string Name, string Description, Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public Cmd<A, B, C, D, E, F, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, new Opt<Next>(next), SubCommands, SetAction);
    public Cmd<A, B, C, D, E, F, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A, B, C, D, E, F> WithAction(Func<A, B, C, D, E, F, int> action)
        => WithAction((a, b, c, d, e, f, _) => Task.FromResult(action(a, b, c, d, e, f)));

    public Cmd<A, B, C, D, E, F> WithAction(Func<A, B, C, D, E, F, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
		input5.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A, B, C, D, E, F> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G>(string Name, string Description, Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public Cmd<A, B, C, D, E, F, G, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, input6, new Opt<Next>(next), SubCommands, SetAction);
    public Cmd<A, B, C, D, E, F, G, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, input6, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A, B, C, D, E, F, G> WithAction(Func<A, B, C, D, E, F, G, int> action)
        => WithAction((a, b, c, d, e, f, g, _) => Task.FromResult(action(a, b, c, d, e, f, g)));

    public Cmd<A, B, C, D, E, F, G> WithAction(Func<A, B, C, D, E, F, G, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult),
					self.input6.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
		input5.AddTo(result);
		input6.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A, B, C, D, E, F, G> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G, H>(string Name, string Description, Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, Input<H> input7, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public Cmd<A, B, C, D, E, F, G, H, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, input6, input7, new Opt<Next>(next), SubCommands, SetAction);
    public Cmd<A, B, C, D, E, F, G, H, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, input6, input7, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A, B, C, D, E, F, G, H> WithAction(Func<A, B, C, D, E, F, G, H, int> action)
        => WithAction((a, b, c, d, e, f, g, h, _) => Task.FromResult(action(a, b, c, d, e, f, g, h)));

    public Cmd<A, B, C, D, E, F, G, H> WithAction(Func<A, B, C, D, E, F, G, H, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult),
					self.input6.GetValue(parseResult),
					self.input7.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
		input5.AddTo(result);
		input6.AddTo(result);
		input7.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A, B, C, D, E, F, G, H> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G, H, I>(string Name, string Description, Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, Input<H> input7, Input<I> input8, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public Cmd<A, B, C, D, E, F, G, H, I, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, input6, input7, input8, new Opt<Next>(next), SubCommands, SetAction);
    public Cmd<A, B, C, D, E, F, G, H, I, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, input6, input7, input8, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A, B, C, D, E, F, G, H, I> WithAction(Func<A, B, C, D, E, F, G, H, I, int> action)
        => WithAction((a, b, c, d, e, f, g, h, i, _) => Task.FromResult(action(a, b, c, d, e, f, g, h, i)));

    public Cmd<A, B, C, D, E, F, G, H, I> WithAction(Func<A, B, C, D, E, F, G, H, I, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult),
					self.input6.GetValue(parseResult),
					self.input7.GetValue(parseResult),
					self.input8.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
		input5.AddTo(result);
		input6.AddTo(result);
		input7.AddTo(result);
		input8.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A, B, C, D, E, F, G, H, I> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G, H, I, J>(string Name, string Description, Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, Input<H> input7, Input<I> input8, Input<J> input9, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public Cmd<A, B, C, D, E, F, G, H, I, J, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, new Opt<Next>(next), SubCommands, SetAction);
    public Cmd<A, B, C, D, E, F, G, H, I, J, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A, B, C, D, E, F, G, H, I, J> WithAction(Func<A, B, C, D, E, F, G, H, I, J, int> action)
        => WithAction((a, b, c, d, e, f, g, h, i, j, _) => Task.FromResult(action(a, b, c, d, e, f, g, h, i, j)));

    public Cmd<A, B, C, D, E, F, G, H, I, J> WithAction(Func<A, B, C, D, E, F, G, H, I, J, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult),
					self.input6.GetValue(parseResult),
					self.input7.GetValue(parseResult),
					self.input8.GetValue(parseResult),
					self.input9.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
		input5.AddTo(result);
		input6.AddTo(result);
		input7.AddTo(result);
		input8.AddTo(result);
		input9.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A, B, C, D, E, F, G, H, I, J> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G, H, I, J, K>(string Name, string Description, Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, Input<H> input7, Input<I> input8, Input<J> input9, Input<K> input10, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    public Cmd<A, B, C, D, E, F, G, H, I, J, K, Next> AddOption<Next>(Option<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, input10, new Opt<Next>(next), SubCommands, SetAction);
    public Cmd<A, B, C, D, E, F, G, H, I, J, K, Next> AddArgument<Next>(Argument<Next> next) => 
        new(Name, Description, input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, input10, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A, B, C, D, E, F, G, H, I, J, K> WithAction(Func<A, B, C, D, E, F, G, H, I, J, K, int> action)
        => WithAction((a, b, c, d, e, f, g, h, i, j, k, _) => Task.FromResult(action(a, b, c, d, e, f, g, h, i, j, k)));

    public Cmd<A, B, C, D, E, F, G, H, I, J, K> WithAction(Func<A, B, C, D, E, F, G, H, I, J, K, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult),
					self.input6.GetValue(parseResult),
					self.input7.GetValue(parseResult),
					self.input8.GetValue(parseResult),
					self.input9.GetValue(parseResult),
					self.input10.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
		input5.AddTo(result);
		input6.AddTo(result);
		input7.AddTo(result);
		input8.AddTo(result);
		input9.AddTo(result);
		input10.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A, B, C, D, E, F, G, H, I, J, K> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G, H, I, J, K, L>(string Name, string Description, Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, Input<H> input7, Input<I> input8, Input<J> input9, Input<K> input10, Input<L> input11, IEnumerable<Command> SubCommands, Action<Command>? SetAction)
    : ICmd
{
    // public Cmd<A, B, C, D, E, F, G, H, I, J, K, L, Next> AddOption<Next>(Option<Next> next) => 
    //     new(Name, Description, input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, input10, input11, new Opt<Next>(next), SubCommands, SetAction);
    // public Cmd<A, B, C, D, E, F, G, H, I, J, K, L, Next> AddArgument<Next>(Argument<Next> next) => 
    //     new(Name, Description, input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, input10, input11, new Arg<Next>(next), SubCommands, SetAction);

    public Cmd<A, B, C, D, E, F, G, H, I, J, K, L> WithAction(Func<A, B, C, D, E, F, G, H, I, J, K, L, int> action)
        => WithAction((a, b, c, d, e, f, g, h, i, j, k, l, _) => Task.FromResult(action(a, b, c, d, e, f, g, h, i, j, k, l)));

    public Cmd<A, B, C, D, E, F, G, H, I, J, K, L> WithAction(Func<A, B, C, D, E, F, G, H, I, J, K, L, CancellationToken, Task<int>> action)
    {
        var self = this;
        return self with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult),
					self.input6.GetValue(parseResult),
					self.input7.GetValue(parseResult),
					self.input8.GetValue(parseResult),
					self.input9.GetValue(parseResult),
					self.input10.GetValue(parseResult),
					self.input11.GetValue(parseResult), ct))
        };
    }

    public Command ToCommand()
    {
        var result = new Command(Name, Description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
		input5.AddTo(result);
		input6.AddTo(result);
		input7.AddTo(result);
		input8.AddTo(result);
		input9.AddTo(result);
		input10.AddTo(result);
		input11.AddTo(result);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        SetAction?.Invoke(result);
        return result;
    }

    public Cmd<A, B, C, D, E, F, G, H, I, J, K, L> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

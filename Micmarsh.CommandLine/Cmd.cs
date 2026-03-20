using System.CommandLine;

namespace Micmarsh.CommandLine.Generator;



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

public readonly record struct Cmd<A, B, C, D, E>(Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, D, E, Next> AddOption<Next>(Option<Next> next) => 
        new(input0, input1, input2, input3, input4, new Opt<Next>(next), SubCommands);
    public Cmd<A, B, C, D, E, Next> AddArgument<Next>(Argument<Next> next) => 
        new(input0, input1, input2, input3, input4, new Arg<Next>(next), SubCommands);

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

public readonly record struct Cmd<A, B, C, D, E, F>(Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, D, E, F, Next> AddOption<Next>(Option<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, new Opt<Next>(next), SubCommands);
    public Cmd<A, B, C, D, E, F, Next> AddArgument<Next>(Argument<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, int> action)
        => SetAction(name, description, (a, b, c, d, e, f, _) => Task.FromResult(action(a, b, c, d, e, f)));
    
    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
		input5.AddTo(result);
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B, C, D, E, F> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G>(Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, D, E, F, G, Next> AddOption<Next>(Option<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, input6, new Opt<Next>(next), SubCommands);
    public Cmd<A, B, C, D, E, F, G, Next> AddArgument<Next>(Argument<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, input6, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, int> action)
        => SetAction(name, description, (a, b, c, d, e, f, g, _) => Task.FromResult(action(a, b, c, d, e, f, g)));
    
    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
		input5.AddTo(result);
		input6.AddTo(result);
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult),
					self.input6.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B, C, D, E, F, G> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G, H>(Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, Input<H> input7, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, D, E, F, G, H, Next> AddOption<Next>(Option<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, input6, input7, new Opt<Next>(next), SubCommands);
    public Cmd<A, B, C, D, E, F, G, H, Next> AddArgument<Next>(Argument<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, input6, input7, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, H, int> action)
        => SetAction(name, description, (a, b, c, d, e, f, g, h, _) => Task.FromResult(action(a, b, c, d, e, f, g, h)));
    
    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, H, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
		input5.AddTo(result);
		input6.AddTo(result);
		input7.AddTo(result);
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult),
					self.input6.GetValue(parseResult),
					self.input7.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B, C, D, E, F, G, H> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G, H, I>(Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, Input<H> input7, Input<I> input8, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, D, E, F, G, H, I, Next> AddOption<Next>(Option<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, input6, input7, input8, new Opt<Next>(next), SubCommands);
    public Cmd<A, B, C, D, E, F, G, H, I, Next> AddArgument<Next>(Argument<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, input6, input7, input8, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, H, I, int> action)
        => SetAction(name, description, (a, b, c, d, e, f, g, h, i, _) => Task.FromResult(action(a, b, c, d, e, f, g, h, i)));
    
    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, H, I, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
        input0.AddTo(result);
		input1.AddTo(result);
		input2.AddTo(result);
		input3.AddTo(result);
		input4.AddTo(result);
		input5.AddTo(result);
		input6.AddTo(result);
		input7.AddTo(result);
		input8.AddTo(result);
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult),
					self.input6.GetValue(parseResult),
					self.input7.GetValue(parseResult),
					self.input8.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B, C, D, E, F, G, H, I> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G, H, I, J>(Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, Input<H> input7, Input<I> input8, Input<J> input9, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, D, E, F, G, H, I, J, Next> AddOption<Next>(Option<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, new Opt<Next>(next), SubCommands);
    public Cmd<A, B, C, D, E, F, G, H, I, J, Next> AddArgument<Next>(Argument<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, H, I, J, int> action)
        => SetAction(name, description, (a, b, c, d, e, f, g, h, i, j, _) => Task.FromResult(action(a, b, c, d, e, f, g, h, i, j)));
    
    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, H, I, J, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
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
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult),
					self.input6.GetValue(parseResult),
					self.input7.GetValue(parseResult),
					self.input8.GetValue(parseResult),
					self.input9.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B, C, D, E, F, G, H, I, J> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G, H, I, J, K>(Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, Input<H> input7, Input<I> input8, Input<J> input9, Input<K> input10, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, D, E, F, G, H, I, J, K, Next> AddOption<Next>(Option<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, input10, new Opt<Next>(next), SubCommands);
    public Cmd<A, B, C, D, E, F, G, H, I, J, K, Next> AddArgument<Next>(Argument<Next> next) => 
        new(input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, input10, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, H, I, J, K, int> action)
        => SetAction(name, description, (a, b, c, d, e, f, g, h, i, j, k, _) => Task.FromResult(action(a, b, c, d, e, f, g, h, i, j, k)));
    
    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, H, I, J, K, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
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
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
					self.input1.GetValue(parseResult),
					self.input2.GetValue(parseResult),
					self.input3.GetValue(parseResult),
					self.input4.GetValue(parseResult),
					self.input5.GetValue(parseResult),
					self.input6.GetValue(parseResult),
					self.input7.GetValue(parseResult),
					self.input8.GetValue(parseResult),
					self.input9.GetValue(parseResult),
					self.input10.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B, C, D, E, F, G, H, I, J, K> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};

public readonly record struct Cmd<A, B, C, D, E, F, G, H, I, J, K, L>(Input<A> input0, Input<B> input1, Input<C> input2, Input<D> input3, Input<E> input4, Input<F> input5, Input<G> input6, Input<H> input7, Input<I> input8, Input<J> input9, Input<K> input10, Input<L> input11, IEnumerable<Command> SubCommands)
{
    // public Cmd<A, B, C, D, E, F, G, H, I, J, K, L, Next> AddOption<Next>(Option<Next> next) => 
    //     new(input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, input10, input11, new Opt<Next>(next), SubCommands);
    // public Cmd<A, B, C, D, E, F, G, H, I, J, K, L, Next> AddArgument<Next>(Argument<Next> next) => 
    //     new(input0, input1, input2, input3, input4, input5, input6, input7, input8, input9, input10, input11, new Arg<Next>(next), SubCommands);

    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, H, I, J, K, L, int> action)
        => SetAction(name, description, (a, b, c, d, e, f, g, h, i, j, k, l, _) => Task.FromResult(action(a, b, c, d, e, f, g, h, i, j, k, l)));
    
    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, G, H, I, J, K, L, CancellationToken, Task<int>> action)
    {
        var result = new Command(name, description);
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
        var self = this;
        result.SetAction((parseResult, ct) => action(self.input0.GetValue(parseResult),
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
					self.input11.GetValue(parseResult), ct));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B, C, D, E, F, G, H, I, J, K, L> AddSub(Command cmd) => this with {SubCommands = SubCommands.Append(cmd)};
};
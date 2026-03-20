namespace Micmarsh.CommandLine;

using System.CommandLine;

public static class Cmd
{
    public static Cmd<A> AddOption<A>(Option<A> option) => new (option, []);
    
    public static RootCmd AddSub(Command cmd) => new ([cmd]);

    public static RootCommand AsRoot(this Command command)
    {
        var root =  new RootCommand(command.Description ?? string.Empty);
        foreach (var opt in command.Options) root.Options.Add(opt);
        foreach (var sub in command.Subcommands) root.Subcommands.Add(sub);
        //todo arguments and other things?
        return root;
    }
}

public record RootCmd(IEnumerable<Command> SubCommands)
{
    /// <summary>
    /// Remember to call <see cref="Cmd.AsRoot"/> at end of method chain if adding options to RootCmd
    /// </summary>
    public static Cmd<A> AddOption<A>(Option<A> option) => new (option, []);

    public RootCommand SetDescription(string description = "")
    {
        var result = new RootCommand(description);
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public RootCmd AddSub(Command cmd) => new(SubCommands.Append(cmd));
}

public record Cmd<A>(Option<A> option, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B> AddOption<B>(Option<B> option2) => new(option, option2, SubCommands);

    public Command SetAction(string name, string description, Func<A, int> action) =>
        SetAction(name, description, a => Task.FromResult(action(a)));

    public Command SetAction(string name, string description, Func<A, Task<int>> action)
    {
        var result =  new Command(name, description) {option};
        result.SetAction(parseResult => action(parseResult.GetRequiredValue(option)));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A> AddSub(Command cmd) => new(option, SubCommands.Append(cmd));
};

public record Cmd<A, B>(Option<A> option1, Option<B> option2, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C> AddOption<C>(Option<C> option3) =>
        new(option1, option2, option3, SubCommands);

    public Command SetAction(string name, string description, Func<A, B, int> action) =>
        SetAction(name, description, (a, b) => Task.FromResult(action(a, b)));

    public Command SetAction(string name, string description, Func<A, B, Task<int>> action)
    {
        var result =  new Command(name, description) {option1, option2};
        result.SetAction(parseResult => action(parseResult.GetRequiredValue(option1),
                                                parseResult.GetRequiredValue(option2)));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    internal IEnumerable<Command> SubCommands { get; init; } = [];

    public Cmd<A, B> AddSub(Command cmd) => new(option1, option2, SubCommands.Append(cmd));

};

public record Cmd<A, B, C>(Option<A> option1, Option<B> option2, Option<C> option3 , IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, D> AddOption<D>(Option<D> option4) =>
        new(option1, option2, option3, option4, SubCommands);
    
    public Command SetAction(string name, string description, Func<A, B, C, int> action) =>
        SetAction(name, description, (a, b, c) => Task.FromResult(action(a, b, c)));
    
    public Command SetAction(string name, string description, Func<A, B, C, Task<int>> action)
    {
        var result =  new Command(name, description) {option1, option2};
        result.SetAction(parseResult => action(parseResult.GetRequiredValue(option1),
            parseResult.GetRequiredValue(option2),
            parseResult.GetRequiredValue(option3)));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    internal IEnumerable<Command> SubCommands { get; init; } = [];

    public Cmd<A, B, C> AddSub(Command cmd) => new(option1, option2, option3, SubCommands.Append(cmd));

};


public record Cmd<A, B, C, D>(Option<A> option1, Option<B> option2, Option<C> option3, 
    Option<D> option4, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, D, E> AddOption<E>(Option<E> option5) =>
        new(option1, option2, option3, option4, option5, SubCommands);
    
    public Command SetAction(string name, string description, Func<A, B, C, D, int> action) =>
        SetAction(name, description, (a, b, c, d) => Task.FromResult(action(a, b, c, d)));
    
    public Command SetAction(string name, string description, Func<A, B, C, D, Task<int>> action)
    {
        var result =  new Command(name, description) {option1, option2};
        result.SetAction(parseResult => action(parseResult.GetRequiredValue(option1),
            parseResult.GetRequiredValue(option2),
            parseResult.GetRequiredValue(option3),
            parseResult.GetRequiredValue(option4)));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    internal IEnumerable<Command> SubCommands { get; init; } = [];

    public Cmd<A, B, C, D> AddSub(Command cmd) => new(option1, option2, option3, option4, SubCommands.Append(cmd));

};

public record Cmd<A, B, C, D, E>(Option<A> option1, Option<B> option2, 
    Option<C> option3, Option<D> option4, 
    Option<E> option5, IEnumerable<Command> SubCommands)
{
    public Cmd<A, B, C, D, E, F> AddOption<F>(Option<F> option6) =>
        new(option1, option2, option3, option4, option5, option6, SubCommands);

    public Command SetAction(string name, string description, Func<A, B, C, D, E, int> action) =>
        SetAction(name, description, (a, b, c, d, e) => Task.FromResult(action(a, b, c, d, e)));
    
    public Command SetAction(string name, string description, Func<A, B, C, D, E, Task<int>> action)
    {
        var result =  new Command(name, description) {option1, option2};
        result.SetAction(parseResult => action(parseResult.GetRequiredValue(option1),
            parseResult.GetRequiredValue(option2),
            parseResult.GetRequiredValue(option3),
            parseResult.GetRequiredValue(option4),
            parseResult.GetRequiredValue(option5)));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }
    
    public Cmd<A, B, C, D, E> AddSub(Command cmd) =>
        this with { SubCommands = SubCommands.Append(cmd) };

};

public record Cmd<A, B, C, D, E, F>(Option<A> option1, Option<B> option2,
    Option<C> option3, Option<D> option4, Option<E> option5,
    Option<F> option6, IEnumerable<Command> SubCommands)
{
   // public Cmd<A, B, C, D, E, F> AddOption<F>(Option<F> option6) => new (option1, option2, option3, option4, option5,  option6)
   //{ SubCommands = SubCommands };
   
   public Command SetAction(string name, string description, Func<A, B, C, D, E, F, int> action) =>
       SetAction(name, description, (a, b, c, d, e, f) => Task.FromResult(action(a, b, c, d, e, f)));
   
    public Command SetAction(string name, string description, Func<A, B, C, D, E, F, Task<int>> action)
    {
        var result =  new Command(name, description) {option1, option2};
        result.SetAction(parseResult => action(parseResult.GetRequiredValue(option1),
            parseResult.GetRequiredValue(option2),
            parseResult.GetRequiredValue(option3),
            parseResult.GetRequiredValue(option4),
            parseResult.GetRequiredValue(option5),
            parseResult.GetRequiredValue(option6)));
        foreach (var cmd in SubCommands) result.Subcommands.Add(cmd);
        return result;
    }

    public Cmd<A, B, C, D, E, F> AddSub(Command cmd) => this with { SubCommands = SubCommands.Append(cmd) };

};
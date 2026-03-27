
using System.CommandLine;
using LanguageExt;
namespace CommandLine.Immutable;

public static class CmdExtensions
{
        
    public static Cmd<A> WithAction<A>(this Cmd<A> cmd, Func<A, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A> WithAction<A>(this Cmd<A> cmd, Func<A, IO<Unit>> action) 
        => cmd.WithAction((a) => action(a).Map(_ => 0));
    
    public static Cmd<A, B> WithAction<A, B>(this Cmd<A, B> cmd, Func<A, B, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult),
					cmd.inputB.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A, B> WithAction<A, B>(this Cmd<A, B> cmd, Func<A, B, IO<Unit>> action) 
        => cmd.WithAction((a, b) => action(a, b).Map(_ => 0));
    
    public static Cmd<A, B, C> WithAction<A, B, C>(this Cmd<A, B, C> cmd, Func<A, B, C, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult),
					cmd.inputB.GetValue(parseResult),
					cmd.inputC.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A, B, C> WithAction<A, B, C>(this Cmd<A, B, C> cmd, Func<A, B, C, IO<Unit>> action) 
        => cmd.WithAction((a, b, c) => action(a, b, c).Map(_ => 0));
    
    public static Cmd<A, B, C, D> WithAction<A, B, C, D>(this Cmd<A, B, C, D> cmd, Func<A, B, C, D, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult),
					cmd.inputB.GetValue(parseResult),
					cmd.inputC.GetValue(parseResult),
					cmd.inputD.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A, B, C, D> WithAction<A, B, C, D>(this Cmd<A, B, C, D> cmd, Func<A, B, C, D, IO<Unit>> action) 
        => cmd.WithAction((a, b, c, d) => action(a, b, c, d).Map(_ => 0));
    
    public static Cmd<A, B, C, D, E> WithAction<A, B, C, D, E>(this Cmd<A, B, C, D, E> cmd, Func<A, B, C, D, E, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult),
					cmd.inputB.GetValue(parseResult),
					cmd.inputC.GetValue(parseResult),
					cmd.inputD.GetValue(parseResult),
					cmd.inputE.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A, B, C, D, E> WithAction<A, B, C, D, E>(this Cmd<A, B, C, D, E> cmd, Func<A, B, C, D, E, IO<Unit>> action) 
        => cmd.WithAction((a, b, c, d, e) => action(a, b, c, d, e).Map(_ => 0));
    
    public static Cmd<A, B, C, D, E, F> WithAction<A, B, C, D, E, F>(this Cmd<A, B, C, D, E, F> cmd, Func<A, B, C, D, E, F, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult),
					cmd.inputB.GetValue(parseResult),
					cmd.inputC.GetValue(parseResult),
					cmd.inputD.GetValue(parseResult),
					cmd.inputE.GetValue(parseResult),
					cmd.inputF.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A, B, C, D, E, F> WithAction<A, B, C, D, E, F>(this Cmd<A, B, C, D, E, F> cmd, Func<A, B, C, D, E, F, IO<Unit>> action) 
        => cmd.WithAction((a, b, c, d, e, f) => action(a, b, c, d, e, f).Map(_ => 0));
    
    public static Cmd<A, B, C, D, E, F, G> WithAction<A, B, C, D, E, F, G>(this Cmd<A, B, C, D, E, F, G> cmd, Func<A, B, C, D, E, F, G, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult),
					cmd.inputB.GetValue(parseResult),
					cmd.inputC.GetValue(parseResult),
					cmd.inputD.GetValue(parseResult),
					cmd.inputE.GetValue(parseResult),
					cmd.inputF.GetValue(parseResult),
					cmd.inputG.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A, B, C, D, E, F, G> WithAction<A, B, C, D, E, F, G>(this Cmd<A, B, C, D, E, F, G> cmd, Func<A, B, C, D, E, F, G, IO<Unit>> action) 
        => cmd.WithAction((a, b, c, d, e, f, g) => action(a, b, c, d, e, f, g).Map(_ => 0));
    
    public static Cmd<A, B, C, D, E, F, G, H> WithAction<A, B, C, D, E, F, G, H>(this Cmd<A, B, C, D, E, F, G, H> cmd, Func<A, B, C, D, E, F, G, H, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult),
					cmd.inputB.GetValue(parseResult),
					cmd.inputC.GetValue(parseResult),
					cmd.inputD.GetValue(parseResult),
					cmd.inputE.GetValue(parseResult),
					cmd.inputF.GetValue(parseResult),
					cmd.inputG.GetValue(parseResult),
					cmd.inputH.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A, B, C, D, E, F, G, H> WithAction<A, B, C, D, E, F, G, H>(this Cmd<A, B, C, D, E, F, G, H> cmd, Func<A, B, C, D, E, F, G, H, IO<Unit>> action) 
        => cmd.WithAction((a, b, c, d, e, f, g, h) => action(a, b, c, d, e, f, g, h).Map(_ => 0));
    
    public static Cmd<A, B, C, D, E, F, G, H, I> WithAction<A, B, C, D, E, F, G, H, I>(this Cmd<A, B, C, D, E, F, G, H, I> cmd, Func<A, B, C, D, E, F, G, H, I, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult),
					cmd.inputB.GetValue(parseResult),
					cmd.inputC.GetValue(parseResult),
					cmd.inputD.GetValue(parseResult),
					cmd.inputE.GetValue(parseResult),
					cmd.inputF.GetValue(parseResult),
					cmd.inputG.GetValue(parseResult),
					cmd.inputH.GetValue(parseResult),
					cmd.inputI.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A, B, C, D, E, F, G, H, I> WithAction<A, B, C, D, E, F, G, H, I>(this Cmd<A, B, C, D, E, F, G, H, I> cmd, Func<A, B, C, D, E, F, G, H, I, IO<Unit>> action) 
        => cmd.WithAction((a, b, c, d, e, f, g, h, i) => action(a, b, c, d, e, f, g, h, i).Map(_ => 0));
    
    public static Cmd<A, B, C, D, E, F, G, H, I, J> WithAction<A, B, C, D, E, F, G, H, I, J>(this Cmd<A, B, C, D, E, F, G, H, I, J> cmd, Func<A, B, C, D, E, F, G, H, I, J, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult),
					cmd.inputB.GetValue(parseResult),
					cmd.inputC.GetValue(parseResult),
					cmd.inputD.GetValue(parseResult),
					cmd.inputE.GetValue(parseResult),
					cmd.inputF.GetValue(parseResult),
					cmd.inputG.GetValue(parseResult),
					cmd.inputH.GetValue(parseResult),
					cmd.inputI.GetValue(parseResult),
					cmd.inputJ.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A, B, C, D, E, F, G, H, I, J> WithAction<A, B, C, D, E, F, G, H, I, J>(this Cmd<A, B, C, D, E, F, G, H, I, J> cmd, Func<A, B, C, D, E, F, G, H, I, J, IO<Unit>> action) 
        => cmd.WithAction((a, b, c, d, e, f, g, h, i, j) => action(a, b, c, d, e, f, g, h, i, j).Map(_ => 0));
    
    public static Cmd<A, B, C, D, E, F, G, H, I, J, K> WithAction<A, B, C, D, E, F, G, H, I, J, K>(this Cmd<A, B, C, D, E, F, G, H, I, J, K> cmd, Func<A, B, C, D, E, F, G, H, I, J, K, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult),
					cmd.inputB.GetValue(parseResult),
					cmd.inputC.GetValue(parseResult),
					cmd.inputD.GetValue(parseResult),
					cmd.inputE.GetValue(parseResult),
					cmd.inputF.GetValue(parseResult),
					cmd.inputG.GetValue(parseResult),
					cmd.inputH.GetValue(parseResult),
					cmd.inputI.GetValue(parseResult),
					cmd.inputJ.GetValue(parseResult),
					cmd.inputK.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A, B, C, D, E, F, G, H, I, J, K> WithAction<A, B, C, D, E, F, G, H, I, J, K>(this Cmd<A, B, C, D, E, F, G, H, I, J, K> cmd, Func<A, B, C, D, E, F, G, H, I, J, K, IO<Unit>> action) 
        => cmd.WithAction((a, b, c, d, e, f, g, h, i, j, k) => action(a, b, c, d, e, f, g, h, i, j, k).Map(_ => 0));
    
    public static Cmd<A, B, C, D, E, F, G, H, I, J, K, L> WithAction<A, B, C, D, E, F, G, H, I, J, K, L>(this Cmd<A, B, C, D, E, F, G, H, I, J, K, L> cmd, Func<A, B, C, D, E, F, G, H, I, J, K, L, IO<int>> action)
    {
        return cmd with
        {
            SetAction = command =>
                command.SetAction((parseResult, ct) => action(cmd.inputA.GetValue(parseResult),
					cmd.inputB.GetValue(parseResult),
					cmd.inputC.GetValue(parseResult),
					cmd.inputD.GetValue(parseResult),
					cmd.inputE.GetValue(parseResult),
					cmd.inputF.GetValue(parseResult),
					cmd.inputG.GetValue(parseResult),
					cmd.inputH.GetValue(parseResult),
					cmd.inputI.GetValue(parseResult),
					cmd.inputJ.GetValue(parseResult),
					cmd.inputK.GetValue(parseResult),
					cmd.inputL.GetValue(parseResult))
                    .Catch(err => ErrorHandlers.@default(err, parseResult))
                    .RunAsync(EnvIO.New(token: ct))
                    .AsTask())
        };
    }
    
    public static Cmd<A, B, C, D, E, F, G, H, I, J, K, L> WithAction<A, B, C, D, E, F, G, H, I, J, K, L>(this Cmd<A, B, C, D, E, F, G, H, I, J, K, L> cmd, Func<A, B, C, D, E, F, G, H, I, J, K, L, IO<Unit>> action) 
        => cmd.WithAction((a, b, c, d, e, f, g, h, i, j, k, l) => action(a, b, c, d, e, f, g, h, i, j, k, l).Map(_ => 0));
}


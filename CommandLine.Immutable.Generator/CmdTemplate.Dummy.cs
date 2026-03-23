using System.CommandLine;

namespace CommandLine.Immutable.Generator;

/// <summary>
/// Exists only so <see cref="CmdTemplate{PLACEHOLDER}"/> can compile, and thus remain more useful than a plaintext file
/// </summary>
public record CmdTemplate<A, B>(
    string name, 
    string desc,
    Input<A> a,
    Input<B> b,
    IEnumerable<ICmd> SubCommands,
    Action<Command>? SetAction);

using LanguageExt;

namespace CommandLine.Immutable.Tests;

public class OptionalInputTests
{
    private const int DefaultProgramReturn = 123;
    private static readonly Cmd<Option<int>> OptionalOptTestProgram = Cmd.New("test", "test")
        .AddOption(OptionalInput.Opt<int>("--test-int", "-ti"))
        .WithAction(test => test.IfNone(DefaultProgramReturn));

    [Fact]
    public void OptionalOption_WhenProvided_ShouldNotInfiniteLoop()
    {
        Assert.Equal(3, OptionalOptTestProgram.Run(["-ti", "3"]));
    }
    
    [Fact]
    public void OptionalOption_WhenNotProvided_ShouldReturnDefault()
    {
        Assert.Equal(DefaultProgramReturn, OptionalOptTestProgram.Run([]));
    }
}
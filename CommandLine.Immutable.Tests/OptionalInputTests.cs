using LanguageExt;

namespace CommandLine.Immutable.Tests;

public class OptionalInputTests
{
    private const int DefaultProgramReturn = 123;
    private static readonly ICmd OptionalOptTestProgram = Cmd.New("test", "test")
        .AddOption(OptionalInput.Opt<int>("--test-int", "-ti"))
        .AddArgument(OptionalInput.Arg<bool>("test-bool"))
        .WithAction((i, b) => i.IfNone(DefaultProgramReturn));

    [Fact]
    public void OptionalOption_WhenArgProvided_ShouldNotInfiniteLoop()
    {
        Assert.Equal(DefaultProgramReturn, OptionalOptTestProgram.Run(["false"]));
    }

    
    [Fact]
    public void OptionalOption_WhenOptProvided_ShouldNotInfiniteLoop()
    {
        Assert.Equal(3, OptionalOptTestProgram.Run(["-ti", "3"]));
    }
    
    [Fact]
    public void OptionalOption_WhenNotProvided_ShouldReturnDefault()
    {
        Assert.Equal(DefaultProgramReturn, OptionalOptTestProgram.Run([]));
    }
}
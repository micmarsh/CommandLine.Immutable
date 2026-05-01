using LanguageExt;

namespace CommandLine.Immutable.Tests;

public class OptionalInputTests
{
    private const int DefaultProgramReturn = 0;
    private static readonly Cmd<Option<int>> OptionalOptTestProgram = Cmd.New("test", "test")
        .AddOption(OptionalInput.Opt<int>("--test-int", "-ti"))
        .WithAction(test => test.IfNone(DefaultProgramReturn));

    [Fact]
    public void OptionalOption_WhenProvided_ShouldNotInfiniteLoop()
    {
        var testProgram = OptionalOptTestProgram;
        
        Assert.Equal(3, testProgram.ToRoot().Parse(["test", "-ti", "3"]).Invoke());
    }
    
    [Fact]
    public void OptionalOption_WhenNotProvided_ShouldReturnDefault()
    {
        var testProgram = OptionalOptTestProgram;
        
        Assert.Equal(DefaultProgramReturn, testProgram.ToRoot().Parse(["test"]).Invoke());
    }
}
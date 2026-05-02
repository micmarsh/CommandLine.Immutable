using LanguageExt;

namespace CommandLine.Immutable.Tests;

public class OptionalInputTests
{
    private const int DefaultProgramReturn = 123;
    private static readonly ICmd OptionalPrimitivesTestProgram = Cmd.New("test", "test")
        .AddOption(OptionalInput.Opt<int>("--test-int", "-ti"))
        .AddArgument(OptionalInput.Arg<bool>("test-bool"))
        .WithAction((i, b) => i.IfNone(DefaultProgramReturn));

    
    private static  ICmd GetFileSystemProgram<T>() 
        where T : FileSystemInfo
        => Cmd.New("test", "test")
            .AddOption(OptionalInput.Opt<T>("--test", "-t"))
            .AddArgument(OptionalInput.Arg<T>("test"))
            .WithAction((_1, _2) => 0);

    [Fact]
    public void OptionalOption_WhenArgProvided_ShouldNotInfiniteLoop()
    {
        Assert.Equal(DefaultProgramReturn, OptionalPrimitivesTestProgram.Run(["false"]));
    }

    
    [Fact]
    public void OptionalOption_WhenOptProvided_ShouldNotInfiniteLoop()
    {
        Assert.Equal(3, OptionalPrimitivesTestProgram.Run(["-ti", "3"]));
    }
    
    [Fact]
    public void OptionalOption_WhenNotProvided_ShouldReturnDefault()
    {
        Assert.Equal(DefaultProgramReturn, OptionalPrimitivesTestProgram.Run([]));
    }

    [Fact]
    public void OptionOption_WhenFileInfo_ShouldParse()
    {
        Assert.Equal(0, GetFileSystemProgram<FileInfo>().Run(["test.file", "--test", "test.file"]));
    }
    
    [Fact]
    public void OptionOption_WhenDirectoryInfo_ShouldParse()
    {
        Assert.Equal(0, GetFileSystemProgram<DirectoryInfo>().Run(["test/dir/", "--test", "test/dir/"]));
    }
    
    [Fact]
    public void OptionOption_WhenFileSystemInfo_ShouldParse()
    {
        Assert.Equal(0, GetFileSystemProgram<FileSystemInfo>().Run(["test/dir/", "--test", "test.file"]));
    }
}
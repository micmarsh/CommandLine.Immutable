using System.Text;
using LanguageExt;
using Xunit.Abstractions;

namespace CommandLine.Immutable.Tests;

public class OptionalInputTests
{
    private const int DefaultProgramReturn = 123;
    private static readonly ICmd OptionalPrimitivesTestProgram = Cmd.New("test", "test")
        .AddOption(OptionalInput.Opt<int>("--test-int", "-ti"))
        .AddArgument(OptionalInput.Arg<bool>("test-bool"))
        .WithAction((i, b) => i.IfNone(DefaultProgramReturn));


    private static readonly ICmd OptionalStringTestProgram = Cmd.New("test", "test")
        .AddArgument(OptionalInput.Arg<string>("test"))
        .AddOption(OptionalInput.Opt<string>("--test"))
        .WithAction((_1, _2) => DefaultProgramReturn);
    
    private static  ICmd GetFileSystemProgram<T>() 
        where T : FileSystemInfo
        => Cmd.New("test", "test")
            .AddOption(OptionalInput.Opt<T>("--test", "-t"))
            .AddArgument(OptionalInput.Arg<T>("test"))
            .WithAction((_1, _2) => 0);

    public OptionalInputTests(ITestOutputHelper output)
    {
        // this doesn't seem to work for some reason, but good to keep around 
        Console.SetOut(new TestOutputWriter(output));
        Console.SetError(new TestOutputWriter(output));
    }
    
    
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
    public void OptionalString_WhenProvided_ShouldWork()
    {
        Assert.Equal(DefaultProgramReturn, OptionalStringTestProgram.Run(["--test", "string1", "string2"]));
    }
    
    [Fact]
    public void OptionalOption_WhenNotProvided_ShouldReturnDefault()
    {
        Assert.Equal(DefaultProgramReturn, OptionalPrimitivesTestProgram.Run([]));
    }

    // still not working and not printing! even with hack! What gives?
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
    
    private class TestOutputWriter(ITestOutputHelper output) : TextWriter
    {
        public override Encoding Encoding => Console.OutputEncoding;

        public override void WriteLine(string message)
        {
            output.WriteLine(message);
        }
        public override void WriteLine(string format, params object[] args)
        {
            output.WriteLine(format, args);
        }

        private readonly List<char> Buffer = new List<char>();
        public override void Write(char value)
        {
            if (Environment.NewLine.Contains(value))
            {
                output.WriteLine(string.Join("", Buffer));
                Buffer.Clear();
            }
            else
            {
                Buffer.Add(value);
            }        
        }
    }
}
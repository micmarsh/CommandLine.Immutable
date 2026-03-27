using System.CommandLine;
using System.Runtime.CompilerServices;
using LanguageExt.Common;

namespace CommandLine.Immutable;

public static class ErrorHandlers
{
    /// <summary>
    /// Heavily adapted from decompiled <see cref="System.CommandLine.Invocation.InvocationPipeline.DefaultExceptionHandler"/> version 2.0.5
    /// </summary>
    public static int @default(Error error, ParseResult parseResult)
    {
        if (error.ToException() is not OperationCanceledException)
        {
            using var _ = new ConsoleHelpers.RedText();
            var errWriter = parseResult.InvocationConfiguration.Error;
            errWriter.WriteLine(error.ToException().ToString());
        }
        return error.Code == 0 ? 1 : error.Code;
    }
}

// This can be in main project, is nothing LangExt-specific
/// <summary>
/// Adapted (added disposable convenience class) from decompiled <see cref="System.CommandLine.ConsoleHelpers"/> version 2.0.5
/// </summary>
internal static class ConsoleHelpers
{
    internal class RedText : IDisposable
    {
        public RedText()
        {
            ResetTerminalForegroundColor();
            SetTerminalForegroundRed();
        }

        public void Dispose()
        {
            ResetTerminalForegroundColor();
        }
    }
    
    private static readonly bool ColorsAreSupported = GetColorsAreSupported();

    private static bool GetColorsAreSupported()
#if NET7_0_OR_GREATER
        => !(OperatingSystem.IsBrowser() || OperatingSystem.IsAndroid() || OperatingSystem.IsIOS() || OperatingSystem.IsTvOS())
#else
            => !(RuntimeInformation.IsOSPlatform(OSPlatform.Create("BROWSER"))
                    || RuntimeInformation.IsOSPlatform(OSPlatform.Create("ANDROID"))
                    || RuntimeInformation.IsOSPlatform(OSPlatform.Create("IOS"))
                    || RuntimeInformation.IsOSPlatform(OSPlatform.Create("TVOS")))
#endif
           && !Console.IsOutputRedirected;

    internal static void SetTerminalForegroundRed()
    {
        if (ColorsAreSupported)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
    }

    internal static void ResetTerminalForegroundColor()
    {
        if (ColorsAreSupported)
        {
            Console.ResetColor();
        }
    }
}
namespace CommandLine.Immutable.Utilities;

/// <summary>
/// Copy-pasted from decompiled <see cref="System.CommandLine.Binding.ArgumentConverter"/>
/// </summary>
public static class ArgumentConverter
{
    /// <summary>
    /// Copy-pasted from decompiled <see cref="System.CommandLine.Binding.ArgumentConverter.TryConvertString"/>
    /// </summary>
    private delegate bool TryConvertString(string token, out object? value);

    public static ConversionResult<T> Convert<T>(string value)
    {
        var type = typeof(T);
        if (!StringConverters.TryGetValue(type, out var converter))
        {
            return new NoConverter<T>();
        }
        if (converter(value, out var result))
        {
            return new Success<T>((T?)result);
        }

        return new ConvertFailed<T>();
    }
    
    /// <summary>
    /// Copy-pasted from decompiled <see cref="System.CommandLine.Binding.ArgumentConverter.StringConverters"/>
    /// </summary>
    private static readonly IReadOnlyDictionary<Type, TryConvertString> StringConverters = new Dictionary<Type, TryConvertString>()
    {
        [typeof(bool)] = (string token, out object? value) =>
        {
            if (bool.TryParse(token, out var parsed))
            {
                value = parsed;
                return true;
            }

            value = default;
            return false;
        },

#if NET6_0_OR_GREATER
        [typeof(DateOnly)] = (string input, out object? value) =>
        {
            if (DateOnly.TryParse(input, out var parsed))
            {
                value = parsed;
                return true;
            }

            value = default;
            return false;
        },
#endif

        [typeof(DateTime)] = (string input, out object? value) =>
        {
            if (DateTime.TryParse(input, out var parsed))
            {
                value = parsed;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(DateTimeOffset)] = (string input, out object? value) =>
        {
            if (DateTimeOffset.TryParse(input, out var parsed))
            {
                value = parsed;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(decimal)] = (string input, out object? value) =>
        {
            if (decimal.TryParse(input, out var parsed))
            {
                value = parsed;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(DirectoryInfo)] = (string path, out object? value) =>
        {
            if (string.IsNullOrEmpty(path))
            {
                value = default;
                return false;
            }
            value = new DirectoryInfo(path);
            return true;
        },

        [typeof(double)] = (string input, out object? value) =>
        {
            if (double.TryParse(input, out var parsed))
            {
                value = parsed;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(FileInfo)] = (string path, out object? value) =>
        {
            if (string.IsNullOrEmpty(path))
            {
                value = default;
                return false;
            }
            value = new FileInfo(path);
            return true;
        },

        [typeof(FileSystemInfo)] = (string path, out object? value) =>
        {
            if (string.IsNullOrEmpty(path))
            {
                value = default;
                return false;
            }
            if (Directory.Exists(path))
            {
                value = new DirectoryInfo(path);
            }
            else if (path.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal) ||
                     path.EndsWith(Path.AltDirectorySeparatorChar.ToString(), StringComparison.Ordinal))
            {
                value = new DirectoryInfo(path);
            }
            else
            {
                value = new FileInfo(path);
            }

            return true;
        },

        [typeof(float)] = (string input, out object? value) =>
        {
            if (float.TryParse(input, out var parsed))
            {
                value = parsed;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(Guid)] = (string input, out object? value) =>
        {
            if (Guid.TryParse(input, out var parsed))
            {
                value = parsed;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(int)] = (string token, out object? value) =>
        {
            if (int.TryParse(token, out var intValue))
            {
                value = intValue;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(long)] = (string token, out object? value) =>
        {
            if (long.TryParse(token, out var longValue))
            {
                value = longValue;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(short)] = (string token, out object? value) =>
        {
            if (short.TryParse(token, out var shortValue))
            {
                value = shortValue;
                return true;
            }

            value = default;
            return false;
        },

#if NET6_0_OR_GREATER
        [typeof(TimeOnly)] = (string input, out object? value) =>
        {
            if (TimeOnly.TryParse(input, out var parsed))
            {
                value = parsed;
                return true;
            }

            value = default;
            return false;
        },
#endif

        [typeof(uint)] = (string token, out object? value) =>
        {
            if (uint.TryParse(token, out var uintValue))
            {
                value = uintValue;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(sbyte)] = (string token, out object? value) =>
        {
            if (sbyte.TryParse(token, out var sbyteValue))
            {
                value = sbyteValue;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(byte)] = (string token, out object? value) =>
        {
            if (byte.TryParse(token, out var byteValue))
            {
                value = byteValue;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(string)] = (string input, out object? value) =>
        {
            value = input;
            return true;
        },

        [typeof(ulong)] = (string token, out object? value) =>
        {
            if (ulong.TryParse(token, out var ulongValue))
            {
                value = ulongValue;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(ushort)] = (string token, out object? value) =>
        {
            if (ushort.TryParse(token, out var ushortValue))
            {
                value = ushortValue;
                return true;
            }

            value = default;
            return false;
        },

        [typeof(TimeSpan)] = (string input, out object? value) =>
        {
            if (TimeSpan.TryParse(input, out var timeSpan))
            {
                value = timeSpan;
                return true;
            }

            value = default;
            return false;
        },
    };
}

public interface ConversionResult<T>;
public readonly record struct Success<T>(T? Value) : ConversionResult<T>;
public readonly record struct NoConverter<T> : ConversionResult<T>;
public readonly record struct ConvertFailed<T> : ConversionResult<T>;
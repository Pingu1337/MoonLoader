using H3rm.MoonLoader.Options;

namespace H3rm.MoonLoader.Core;

/// <summary>
/// Represents a moon loader that displays animated moon symbols.
/// </summary>
public class MoonLoader : IDisposable
{
    private int _moonIndex;
    private readonly TimeSpan _delay;
    private readonly MoonLoaderOptions _options = new();
    private static readonly string[] Moons = { "🌕", "🌖", "🌗", "🌘", "🌑", "🌒", "🌓", "🌔" };

    /// <summary>
    /// Initializes a new instance of the <see cref="MoonLoader"/> class.
    /// </summary>
    public MoonLoader()
    {
        Console.CursorVisible = !_options.HideCursor;
        _delay = _options.Delay;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MoonLoader"/> class with options.
    /// </summary>
    /// <param name="options">The options for the moon loader.</param>
    public MoonLoader(MoonLoaderOptions options)
    {
        _options = options;
        Console.CursorVisible = !options.HideCursor;
        _delay = options.Delay;
    }

    /// <summary>
    /// Gets a task that represents the loading process.
    /// </summary>
    public string Moon => LoadAsync().Result;

    /// <summary>
    /// Displays the current moon symbol to the console.
    /// </summary>
    public void Spin(params object?[] args)
    {
        args = InsertMoon(args);
        Console.Write($"\r{string.Join("", args)}");
    }

    private async Task<string> LoadAsync()
    {
        await Task.Delay(_delay);
        return GetCurrentMoon();
    }

    private string GetCurrentMoon()
    {
        var output = Moons[_moonIndex];
        _moonIndex = (_moonIndex + 1) % Moons.Length;
        return output;
    }

    public object?[] InsertMoon(object?[] args)
    {
        if (ArgsContainMoon(args))
        {
            return args.Select(arg => (object?)arg
                ?.ToString()
                ?.Replace("{moon}", Moon)).ToArray();
        }

        return args.Append(Moon).ToArray();
    }

    private static bool ArgsContainMoon(params object?[] args)
    {
        var stringArgs = args.Select(arg => arg?.ToString()).ToArray();
        return stringArgs.Any(arg => arg != null && arg.Contains("{moon}"));
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting resources.
    /// </summary>
    public void Dispose()
    {
        GC.SuppressFinalize(this);
        if (_options.HideCursor) Console.CursorVisible = true;
    }
}
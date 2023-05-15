namespace H3rm.MoonLoader.Options;

/// <summary>
/// Represents options for the MoonLoader class.
/// </summary>
public class MoonLoaderOptions
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MoonLoaderOptions"/> class.
    /// </summary>
    /// <param name="delay">The delay between each moon symbol animation (in milliseconds).</param>
    /// <param name="hideCursor">A value indicating whether to hide the cursor while displaying the moon symbols.</param>
    public MoonLoaderOptions(TimeSpan? delay = null, bool hideCursor = true)
    {
        Delay = delay ?? TimeSpan.FromMilliseconds(100);
        HideCursor = hideCursor;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="MoonLoaderOptions"/> class.
    /// </summary>
    public MoonLoaderOptions()
    {
        Delay = TimeSpan.FromMilliseconds(100);
    }

    /// <summary>
    /// Gets or sets the delay between each moon symbol animation (in milliseconds).
    /// </summary>
    public TimeSpan Delay { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to hide the cursor while displaying the moon symbols.
    /// </summary>
    public bool HideCursor { get; set; }
}
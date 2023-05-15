using H3rm.MoonLoader.Core;

namespace H3rm.MoonLoader.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="MoonLoader"/> class.
/// </summary>
public static class MoonLoaderExtensions
{
    /// <summary>
    /// Disposes the specified <see cref="MoonLoader"/> instance.
    /// </summary>
    /// <param name="moonLoader">The <see cref="MoonLoader"/> instance to dispose.</param>
    public static void DisposeLoader(this Core.MoonLoader moonLoader)
    {
        ((IDisposable)moonLoader).Dispose();
    }
}
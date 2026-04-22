namespace Cocona.Internal;

internal static class ThrowHelper
{
    [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
    public static void ThrowIfNull(object? argument, [System.Runtime.CompilerServices.CallerArgumentExpression("argument")] string? paramName = null)
    {
        ArgumentNullException.ThrowIfNull(argument, paramName);
    }
}

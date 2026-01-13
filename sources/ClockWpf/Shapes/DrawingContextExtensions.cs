using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

internal static class DrawingContextExtensions
{
    public static void WithTransform(this DrawingContext drawingContext, Transform transform, Action action)
    {
        if (drawingContext == null)
            return;

        if (transform != null)
            drawingContext.PushTransform(transform);

        action?.Invoke();

        if (transform != null)
            drawingContext.Pop();
    }
}

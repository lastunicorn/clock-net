using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

internal static class DrawingContextExtensions
{
    public static void WithTransform(this DrawingContext drawingContext, Transform transform, Action action)
    {
        drawingContext.PushTransform(transform);
        action();
        drawingContext.Pop();
    }
}

using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public class ShapeCanvas : Canvas
{
    private NotifyCollectionChangedEventHandler collectionChangedHandler;

#if PERFORMANCE_INFO

    public PerformanceInfo PerformanceInfo { get; } = new();

#endif

    public static readonly DependencyProperty ShapesProperty = DependencyProperty.Register(
        nameof(Shapes),
        typeof(ObservableCollection<Shape>),
        typeof(ShapeCanvas),
        new PropertyMetadata(null, OnShapesChanged));

    public ObservableCollection<Shape> Shapes
    {
        get => (ObservableCollection<Shape>)GetValue(ShapesProperty);
        set => SetValue(ShapesProperty, value);
    }

    private static void OnShapesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not ShapeCanvas canvas)
            return;

        if (e.OldValue is ObservableCollection<Shape> oldShapes)
        {
            oldShapes.CollectionChanged -= canvas.collectionChangedHandler;
            canvas.collectionChangedHandler = null;
        }

        if (e.NewValue is ObservableCollection<Shape> newShapes)
        {
            NotifyCollectionChangedEventHandler collectionChangedHandler = (s, args) => canvas.InvalidateVisual();

            canvas.collectionChangedHandler = collectionChangedHandler;
            newShapes.CollectionChanged += canvas.collectionChangedHandler;

            canvas.InvalidateVisual();
        }
    }

    public static readonly DependencyProperty KeepProportionsProperty = DependencyProperty.Register(
        nameof(KeepProportions),
        typeof(bool),
        typeof(ShapeCanvas),
        new PropertyMetadata(false, OnKeepProportionsChanged));

    public bool KeepProportions
    {
        get => (bool)GetValue(KeepProportionsProperty);
        set => SetValue(KeepProportionsProperty, value);
    }

    private static void OnKeepProportionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is ShapeCanvas canvas)
            canvas.InvalidateVisual();
    }
    public void SetTime(TimeSpan time)
    {
        if (Shapes == null)
            return;

        IEnumerable<IHand> hands = Shapes.OfType<IHand>();

        foreach (IHand hand in hands)
            hand.Time = time;

        InvalidateVisual();
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
#if PERFORMANCE_INFO
        PerformanceInfo.Start();
#endif
        try
        {
            base.OnRender(drawingContext);

            if (Shapes == null || Shapes.Count == 0)
                return;

            double diameter = Math.Min(ActualWidth, ActualHeight);

            drawingContext.CreateDrawingPlan()
                .WithTransform(() =>
                {
                    double offsetX = ActualWidth / 2;
                    double offsetY = ActualHeight / 2;

                    return new TranslateTransform(offsetX, offsetY);
                })
                .WithTransform(() =>
                {
                    return KeepProportions
                        ? null
                        : CreateScaleTransform(diameter);
                })
                .Draw(dc => RenderShapes(dc, diameter));
        }
        finally
        {
#if PERFORMANCE_INFO
            PerformanceInfo.Stop();
#endif
        }
    }

    private ScaleTransform CreateScaleTransform(double diameter)
    {
        double scaleX = ActualWidth / diameter;
        double scaleY = ActualHeight / diameter;
        double centerX = diameter / 2;
        double centerY = diameter / 2;

        ScaleTransform scaleTransform = new(scaleX, scaleY, centerX, centerY);
        return scaleTransform;
    }

    private void RenderShapes(DrawingContext drawingContext, double diameter)
    {
        IEnumerable<Shape> visibleShapes = Shapes
            .Where(x => x != null && x.IsVisible);

        foreach (Shape shape in visibleShapes)
            shape.Render(drawingContext, diameter);
    }
}

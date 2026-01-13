using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public class ShapeCanvas : Canvas
{
    private NotifyCollectionChangedEventHandler collectionChangedHandler;

    public static readonly DependencyProperty ShapesProperty = DependencyProperty.Register(
        nameof(Shapes),
        typeof(ObservableCollection<Shape>),
        typeof(ShapeCanvas),
        new PropertyMetadata(null, OnShapesChanged));

    public static readonly DependencyProperty KeepProportionsProperty = DependencyProperty.Register(
        nameof(KeepProportions),
        typeof(bool),
        typeof(ShapeCanvas),
        new PropertyMetadata(false, OnKeepProportionsChanged));

    public ObservableCollection<Shape> Shapes
    {
        get => (ObservableCollection<Shape>)GetValue(ShapesProperty);
        set => SetValue(ShapesProperty, value);
    }

    public bool KeepProportions
    {
        get => (bool)GetValue(KeepProportionsProperty);
        set => SetValue(KeepProportionsProperty, value);
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

    private static void OnKeepProportionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is ShapeCanvas canvas)
            canvas.InvalidateVisual();
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
        base.OnRender(drawingContext);

        if (Shapes == null)
            return;

        if (KeepProportions)
        {
            double squareSize = Math.Min(ActualWidth, ActualHeight);
            double offsetX = (ActualWidth - squareSize) / 2;
            double offsetY = (ActualHeight - squareSize) / 2;

            Rect squareBounds = new(0, 0, squareSize, squareSize);

            drawingContext.PushTransform(new TranslateTransform(offsetX, offsetY));
            DisplayShapes(drawingContext, squareBounds);
            drawingContext.Pop();
        }
        else
        {
            Rect bounds = new(0, 0, ActualWidth, ActualHeight);
            DisplayShapes(drawingContext, bounds);
        }
    }

    private void DisplayShapes(DrawingContext drawingContext, Rect bounds)
    {
        IEnumerable<Shape> visibleShapes = Shapes.Where(x => x.IsVisible);

        foreach (Shape shape in visibleShapes)
            shape.Render(drawingContext, bounds);
    }
}

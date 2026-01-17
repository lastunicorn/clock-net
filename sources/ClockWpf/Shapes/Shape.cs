using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

public abstract class Shape : DependencyObject
{
    #region IsVisilbe DependencyProperty

    public static readonly DependencyProperty IsVisibleProperty = DependencyProperty.Register(
        nameof(IsVisible),
        typeof(bool),
        typeof(Shape),
        new PropertyMetadata(true));

    public bool IsVisible
    {
        get => (bool)GetValue(IsVisibleProperty);
        set => SetValue(IsVisibleProperty, value);
    }

    #endregion

    #region FillBrush DependencyProperty

    public static readonly DependencyProperty FillBrushProperty = DependencyProperty.Register(
        nameof(FillBrush),
        typeof(Brush),
        typeof(Shape),
        new FrameworkPropertyMetadata(Brushes.CornflowerBlue));

    public Brush FillBrush
    {
        get => (Brush)GetValue(FillBrushProperty);
        set => SetValue(FillBrushProperty, value);
    }

    #endregion

    #region StrokeBrush DependencyProperty

    public static readonly DependencyProperty StrokeBrushProperty = DependencyProperty.Register(
        nameof(StrokeBrush),
        typeof(Brush),
        typeof(Shape),
        new FrameworkPropertyMetadata(Brushes.Black, HandleStrokeChanged));

    private static void HandleStrokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is Shape shape)
        {
            shape.strokePen = null;
            shape.isStrokePenCreated = false;
        }
    }

    public Brush StrokeBrush
    {
        get => (Brush)GetValue(StrokeBrushProperty);
        set => SetValue(StrokeBrushProperty, value);
    }

    #endregion

    #region StrokeThickness DependencyProperty

    public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
        nameof(StrokeThickness),
        typeof(double),
        typeof(Shape),
        new FrameworkPropertyMetadata(1.0, HandleStrokeThicknessChanged));

    private static void HandleStrokeThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is Shape shape)
        {
            shape.strokePen = null;
            shape.isStrokePenCreated = false;
        }
    }

    public double StrokeThickness
    {
        get => (double)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }

    #endregion

    #region StrokePen Property

    private Pen strokePen;
    private bool isStrokePenCreated;

    protected Pen StrokePen
    {
        get
        {
            if (!isStrokePenCreated)
            {
                strokePen = CreateStrokePen();
                isStrokePenCreated = true;
            }

            return strokePen;
        }
    }

    protected virtual Pen CreateStrokePen()
    {
        return StrokeThickness > 0 && StrokeBrush != null
            ? new(StrokeBrush, StrokeThickness)
            : null;
    }

    #endregion

    public void Render(ClockDrawingContext context)
    {
        bool allowToRender = OnRendering(context);

        if (!allowToRender)
            return;

        DoRender(context);

        OnRendered(context);
    }

    protected virtual bool OnRendering(ClockDrawingContext context)
    {
        return true;
    }

    public abstract void DoRender(ClockDrawingContext context);

    protected virtual void OnRendered(ClockDrawingContext context)
    {
    }
}

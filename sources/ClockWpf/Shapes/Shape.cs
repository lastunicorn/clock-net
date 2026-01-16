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

    #region Fill DependencyProperty

    public static readonly DependencyProperty FillProperty = DependencyProperty.Register(
        nameof(Fill),
        typeof(Brush),
        typeof(HandBase),
        new FrameworkPropertyMetadata(Brushes.CornflowerBlue));

    public Brush Fill
    {
        get => (Brush)GetValue(FillProperty);
        set => SetValue(FillProperty, value);
    }

    #endregion

    #region Stroke DependencyProperty

    public static readonly DependencyProperty StrokeProperty = DependencyProperty.Register(
        nameof(Stroke),
        typeof(Brush),
        typeof(HandBase),
        new FrameworkPropertyMetadata(Brushes.Black, HandleStrokeChanged));

    private static void HandleStrokeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is Shape shape)
            shape.strokePen = null;
    }

    public Brush Stroke
    {
        get => (Brush)GetValue(StrokeProperty);
        set => SetValue(StrokeProperty, value);
    }

    #endregion

    #region StrokeThickness DependencyProperty

    public static readonly DependencyProperty StrokeThicknessProperty = DependencyProperty.Register(
        nameof(StrokeThickness),
        typeof(double),
        typeof(HandBase),
        new FrameworkPropertyMetadata(1.0, HandleStrokeThicknessChanged));

    private static void HandleStrokeThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is Shape shape)
            shape.strokePen = null;
    }

    public double StrokeThickness
    {
        get => (double)GetValue(StrokeThicknessProperty);
        set => SetValue(StrokeThicknessProperty, value);
    }

    #endregion

    #region StrokePen Property

    private Pen strokePen;

    protected Pen StrokePen
    {
        get
        {
            strokePen ??= CreateStrokePen();
            return strokePen;
        }
    }

    private Pen CreateStrokePen()
    {
        return StrokeThickness > 0 && Stroke != null
            ? new(Stroke, StrokeThickness)
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

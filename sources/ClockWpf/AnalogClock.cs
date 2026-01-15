using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using DustInTheWind.ClockWpf.Shapes;
using DustInTheWind.ClockWpf.TimeProviders;

namespace DustInTheWind.ClockWpf;

public class AnalogClock : Control
{
    private ShapeCanvas shapeCanvas;

#if PERFORMANCE_INFO

    #region PerformanceInfo DependencyProperty

    public static readonly DependencyProperty PerformanceInfoProperty = DependencyProperty.Register(
        nameof(PerformanceInfo),
        typeof(PerformanceInfo),
        typeof(AnalogClock),
        new PropertyMetadata(null));

    public PerformanceInfo PerformanceInfo
    {
        get => (PerformanceInfo)GetValue(PerformanceInfoProperty);
        private set => SetValue(PerformanceInfoProperty, value);
    }

    #endregion

#endif

    #region Shapes DependencyProperty

    public static readonly DependencyProperty ShapesProperty = DependencyProperty.Register(
        nameof(Shapes),
        typeof(ObservableCollection<Shape>),
        typeof(AnalogClock),
        new PropertyMetadata(null));

    public ObservableCollection<Shape> Shapes
    {
        get => (ObservableCollection<Shape>)GetValue(ShapesProperty);
        set => SetValue(ShapesProperty, value);
    }

    #endregion

    #region KeepProportions DependencyProperty

    public static readonly DependencyProperty KeepProportionsProperty = DependencyProperty.Register(
        nameof(KeepProportions),
        typeof(bool),
        typeof(AnalogClock),
        new PropertyMetadata(true, OnKeepProportionsChanged));

    private static void OnKeepProportionsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not AnalogClock analogClock)
            return;

        analogClock.shapeCanvas?.InvalidateVisual();
    }

    public bool KeepProportions
    {
        get => (bool)GetValue(KeepProportionsProperty);
        set => SetValue(KeepProportionsProperty, value);
    }

    #endregion

    #region TimeProvider DependencyProperty

    public static readonly DependencyProperty TimeProviderProperty = DependencyProperty.Register(
        nameof(TimeProvider),
        typeof(ITimeProvider),
        typeof(AnalogClock),
        new PropertyMetadata(null, OnTimeProviderChanged));

    private static void OnTimeProviderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is not AnalogClock analogClock)
            return;

        if (e.OldValue is ITimeProvider oldTimeProvider)
            oldTimeProvider.TimeChanged -= analogClock.HandleTimeChanged;

        if (e.NewValue is ITimeProvider newTimeProvider)
            newTimeProvider.TimeChanged += analogClock.HandleTimeChanged;
    }

    private void HandleTimeChanged(object sender, TimeChangedEventArgs e)
    {
        if (Dispatcher.HasShutdownStarted || Dispatcher.HasShutdownFinished)
            return;

        Dispatcher.Invoke(() =>
        {
            UpdateHandsTime(e.Time);
        });
    }

    private void UpdateHandsTime(TimeSpan time)
    {
        if (Shapes == null)
            return;

        IEnumerable<IHand> hands = Shapes.OfType<IHand>();

        foreach (IHand hand in hands)
            hand.Time = time;

        shapeCanvas?.InvalidateVisual();
    }

    public ITimeProvider TimeProvider
    {
        get => (ITimeProvider)GetValue(TimeProviderProperty);
        set => SetValue(TimeProviderProperty, value);
    }

    #endregion

    static AnalogClock()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(AnalogClock), new FrameworkPropertyMetadata(typeof(AnalogClock)));
    }

    public AnalogClock()
    {
        Shapes = [];
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        shapeCanvas = GetTemplateChild("PART_ShapeCanvas") as ShapeCanvas;

#if PERFORMANCE_INFO
        if (shapeCanvas != null)
            PerformanceInfo = shapeCanvas.PerformanceInfo;
#endif
    }
}

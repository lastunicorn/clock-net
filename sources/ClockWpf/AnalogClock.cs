using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using DustInTheWind.ClockWpf.Shapes;
using DustInTheWind.ClockWpf.TimeProviders;

namespace DustInTheWind.ClockWpf;

public class AnalogClock : Control
{
    private ShapeCanvas shapeCanvas;

    public static readonly DependencyProperty ShapesProperty = DependencyProperty.Register(
        nameof(Shapes),
        typeof(ObservableCollection<Shape>),
        typeof(AnalogClock),
        new PropertyMetadata(new ObservableCollection<Shape>()));

    public ObservableCollection<Shape> Shapes
    {
        get => (ObservableCollection<Shape>)GetValue(ShapesProperty);
        set => SetValue(ShapesProperty, value);
    }

    public static readonly DependencyProperty KeepProportionsProperty = DependencyProperty.Register(
        nameof(KeepProportions),
        typeof(bool),
        typeof(AnalogClock),
        new PropertyMetadata(true));

    public bool KeepProportions
    {
        get => (bool)GetValue(KeepProportionsProperty);
        set => SetValue(KeepProportionsProperty, value);
    }

    public static readonly DependencyProperty TimeProviderProperty = DependencyProperty.Register(
        nameof(TimeProvider),
        typeof(ITimeProvider),
        typeof(AnalogClock),
        new PropertyMetadata(null, OnTimeProviderChanged));

    public ITimeProvider TimeProvider
    {
        get => (ITimeProvider)GetValue(TimeProviderProperty);
        set => SetValue(TimeProviderProperty, value);
    }

    static AnalogClock()
    {
        DefaultStyleKeyProperty.OverrideMetadata(typeof(AnalogClock), new FrameworkPropertyMetadata(typeof(AnalogClock)));
    }

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

        foreach (Shape shape in Shapes)
        {
            if (shape is IHand hand)
                hand.Time = time;
        }

        shapeCanvas?.InvalidateVisual();
    }

    public override void OnApplyTemplate()
    {
        base.OnApplyTemplate();

        shapeCanvas = GetTemplateChild("PART_ShapeCanvas") as ShapeCanvas;
    }
}

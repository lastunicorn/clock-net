using System.Windows;

namespace DustInTheWind.ClockWpf.Shapes;

public abstract class HandBase : Shape, IHand
{
    public static readonly DependencyProperty LengthProperty = DependencyProperty.Register(
        nameof(Length),
        typeof(double),
        typeof(HandBase),
        new FrameworkPropertyMetadata(95.0));

    public double Length
    {
        get => (double)GetValue(LengthProperty);
        set => SetValue(LengthProperty, value);
    }

    public static readonly DependencyProperty TimeProperty = DependencyProperty.Register(
        nameof(Time),
        typeof(TimeSpan),
        typeof(HandBase),
        new FrameworkPropertyMetadata(TimeSpan.Zero));

    public TimeSpan Time
    {
        get => (TimeSpan)GetValue(TimeProperty);
        set => SetValue(TimeProperty, value);
    }

    public static readonly DependencyProperty ComponentToDisplayProperty = DependencyProperty.Register(
        nameof(ComponentToDisplay),
        typeof(TimeComponent),
        typeof(HandBase),
        new FrameworkPropertyMetadata(TimeComponent.Second));

    public TimeComponent ComponentToDisplay
    {
        get => (TimeComponent)GetValue(ComponentToDisplayProperty);
        set => SetValue(ComponentToDisplayProperty, value);
    }

    protected double CalculateAngle()
    {
        double value = ComponentToDisplay switch
        {
            TimeComponent.Hour => Time.TotalHours % 12,
            TimeComponent.Minute => Time.TotalMinutes % 60,
            TimeComponent.Second => Time.TotalSeconds % 60,
            _ => Time.TotalSeconds % 60
        };

        double divisor = ComponentToDisplay switch
        {
            TimeComponent.Hour => 12.0,
            TimeComponent.Minute => 60.0,
            TimeComponent.Second => 60.0,
            _ => 60.0
        };

        return (value / divisor) * 360.0;
    }
}

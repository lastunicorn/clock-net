using System.Windows;

namespace DustInTheWind.ClockWpf.Shapes;

/// <summary>
/// Provides an abstract base class for clock hands.
/// The hand displays a specific time component, such as hours, minutes, or
/// seconds, within a graphical user interface.
/// </summary>
/// <remarks>
/// Inherit from this class to implement custom clock hand visuals that represent a particular component
/// of time. The class exposes properties to control the hand's length, the time value it displays, and which time
/// component is visualized.</remarks>
public abstract class HandBase : Shape, IHand
{
    #region Length DependencyProperty

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

    #endregion

    #region Time DependencyProperty

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

    #endregion

    #region ComponentToDisplay DependencyProperty

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

    #endregion

    protected double CalculateHandAngle()
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

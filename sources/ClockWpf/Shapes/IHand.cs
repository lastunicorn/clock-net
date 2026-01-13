namespace DustInTheWind.ClockWpf.Shapes;

public interface IHand
{
    TimeSpan Time { get; set; }

    TimeComponent ComponentToDisplay { get; set; }
}

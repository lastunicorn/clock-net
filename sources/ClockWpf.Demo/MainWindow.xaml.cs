using System.Windows;
using DustInTheWind.ClockWpf.Shapes;

namespace ClockWpf.Demo;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        analogClock1.Shapes.Add(new SimpleBackground());
        analogClock1.Shapes.Add(new SimpleHand());
    }
}
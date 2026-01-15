using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;
using DustInTheWind.ClockWpf;
using DustInTheWind.ClockWpf.Shapes;
using DustInTheWind.ClockWpf.Templates;
using DustInTheWind.ClockWpf.TimeProviders;

namespace ClockWpf.Demo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ObservableCollection<TemplateInfo> availableTemplates = [];

    public MainWindow()
    {
        InitializeComponent();

        CreateShapesFor(analogClock1);

        LoadAvailableTemplates();
        PopulateTemplateComboBox();

        LocalTimeProvider localTimeProvider = new();
        localTimeProvider.Start();

        analogClock1.TimeProvider = localTimeProvider;
        analogClock2.TimeProvider = localTimeProvider;
        analogClock3.TimeProvider = localTimeProvider;
    }

    private void CreateShapesFor(AnalogClock analogClock)
    {
        analogClock.Shapes.Add(new FlatBackground());

        analogClock.Shapes.Add(new Hours
        {
            Orientation = RimItemOrientation.Normal
        });
        analogClock.Shapes.Add(new Ticks
        {
            Orientation = RimItemOrientation.FaceCenter
        });

        analogClock.Shapes.Add(new DiamondHand
        {
            ComponentToDisplay = TimeComponent.Hour,
            Length = 48,
            Width = 10,
            TailLength = 12,
            StrokeThickness = 0,
            Fill = Brushes.RoyalBlue
        });

        analogClock.Shapes.Add(new DiamondHand
        {
            ComponentToDisplay = TimeComponent.Minute,
            Length = 74,
            Width = 8,
            TailLength = 8,
            StrokeThickness = 0,
            Fill = Brushes.LimeGreen
        });

        analogClock.Shapes.Add(new SimpleHand
        {
            ComponentToDisplay = TimeComponent.Second,
            Length = 85,
            TailLength = 14,
            Stroke = Brushes.Red,
            StrokeThickness = 1
        });
    }

    private void LoadAvailableTemplates()
    {
        IEnumerable<TemplateInfo> clockTemplates = EnumerateClockTemplates()
            .OrderBy(x => x.Name)
            .ToList();

        foreach (TemplateInfo template in clockTemplates)
            availableTemplates.Add(template);
    }

    private static IEnumerable<TemplateInfo> EnumerateClockTemplates()
    {
        Assembly clockWpfAssembly = typeof(ClockTemplate).Assembly;

        Type[] types = clockWpfAssembly.GetTypes();

        foreach (Type type in types)
        {
            if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(ClockTemplate)))
            {
                yield return new TemplateInfo
                {
                    Name = type.Name
                        .Replace("ClockTemplate", "")
                        .Replace("Template", ""),
                    Type = type
                };
            }
        }
    }

    private void PopulateTemplateComboBox()
    {
        templateComboBox.ItemsSource = availableTemplates;

        if (availableTemplates.Count > 0)
        {
            TemplateInfo initialTemplateInfo = availableTemplates
                .FirstOrDefault(x => x.Type == typeof(CapsuleClockTemplate));

            int capsuleIndex = availableTemplates.IndexOf(initialTemplateInfo);

            templateComboBox.SelectedIndex = capsuleIndex >= 0
                ? capsuleIndex
                : 0;
        }
    }

    private void TemplateComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        if (templateComboBox.SelectedItem is TemplateInfo selectedTemplate)
        {
            ClockTemplate template = (ClockTemplate)Activator.CreateInstance(selectedTemplate.Type);
            analogClock3.ApplyClockTemplate(template);
        }
    }
}
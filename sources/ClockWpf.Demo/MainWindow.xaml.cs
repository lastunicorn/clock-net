using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
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

        PopulateTemplateComboBox();

        LocalTimeProvider localTimeProvider = new();
        localTimeProvider.Start();

        analogClock1.TimeProvider = localTimeProvider;
    }

    private void PopulateTemplateComboBox()
    {
        IEnumerable<TemplateInfo> clockTemplates = EnumerateClockTemplates()
            .OrderBy(x => x.Name)
            .ToList();

        foreach (TemplateInfo template in clockTemplates)
            availableTemplates.Add(template);

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

    private void TemplateComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (templateComboBox.SelectedItem is TemplateInfo selectedTemplate)
        {
            ClockTemplate template = (ClockTemplate)Activator.CreateInstance(selectedTemplate.Type);
            analogClock1.ApplyClockTemplate(template);
        }
    }
}
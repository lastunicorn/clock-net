using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace DustInTheWind.ClockWpf.Shapes;

/// <summary>
/// A rim shape that displays texts around the clock face.
/// </summary>
public class TextRim : RimBase
{
    #region Texts DependencyProperty

    public static readonly DependencyProperty TextsProperty = DependencyProperty.Register(
        nameof(Texts),
        typeof(string[]),
        typeof(TextRim),
        new FrameworkPropertyMetadata(null));

    public string[] Texts
    {
        get => (string[])GetValue(TextsProperty);
        set => SetValue(TextsProperty, value);
    }

    #endregion

    #region FontFamily DependencyProperty

    public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register(
        nameof(FontFamily),
        typeof(FontFamily),
        typeof(TextRim),
        new FrameworkPropertyMetadata(new FontFamily("Arial")));

    public FontFamily FontFamily
    {
        get => (FontFamily)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }

    #endregion

    #region FontSize DependencyProperty

    public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(
        nameof(FontSize),
        typeof(double),
        typeof(TextRim),
        new FrameworkPropertyMetadata(12.0));

    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    #endregion

    #region FontWeight DependencyProperty

    public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(
        nameof(FontWeight),
        typeof(FontWeight),
        typeof(TextRim),
        new FrameworkPropertyMetadata(FontWeights.Normal));

    public FontWeight FontWeight
    {
        get => (FontWeight)GetValue(FontWeightProperty);
        set => SetValue(FontWeightProperty, value);
    }

    #endregion

    private Typeface typeface;

    protected override bool OnRendering(double diameter)
    {
        string[] texts = Texts;

        if (texts == null || texts.Length == 0)
            return false;

        typeface = new(FontFamily, FontStyles.Normal, FontWeight, FontStretches.Normal);

        return base.OnRendering(diameter);
    }

    protected override void RenderItem(DrawingContext drawingContext, int index)
    {
        string[] texts = Texts;

        if (texts == null)
            return;

        if (index >= texts.Length)
            return;

        string text = texts[index];

        if (string.IsNullOrEmpty(text))
            return;

        FormattedText formattedText = new(
            text,
            CultureInfo.CurrentCulture,
            FlowDirection.LeftToRight,
            typeface,
            FontSize,
            Fill,
            1.0);

        double textX = -formattedText.Width / 2;
        double textY = -formattedText.Height / 2;

        Point textPosition = new(textX, textY);
        drawingContext.DrawText(formattedText, textPosition);
    }
}

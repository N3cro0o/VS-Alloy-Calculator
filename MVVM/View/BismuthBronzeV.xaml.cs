using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Alloy_Calc.MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy BismuthBronzeV.xaml
    /// </summary>
    public partial class BismuthBronzeV : UserControl
    {
        [GeneratedRegex(@"[^0-9]+")]
        private static partial Regex _regex();
        int _zinc = 20;
        int _bismuth = 10;
        int _ingots = 5;

        public BismuthBronzeV()
        {
            InitializeComponent();
            updateAnswer();
        }

        private void updateAnswer()
        {
            int units = _ingots * 100;
            int zinc = (units * _zinc / 100);
            int bismuth = (units * _bismuth / 100);
            int copper = units - zinc - bismuth;

            CopperBlock.Text = $"Copper units: {copper}";
            CopperBlock.ToolTip = $"Minimum nuggets: {double.Ceiling((double)copper / 5)}";
            ZincBlock.Text = $"Zinc units: {zinc}";
            ZincBlock.ToolTip = $"Minimum nuggets: {double.Ceiling((double)zinc / 5)}";
            BismuthBlock.Text = $"Bismuth units: {bismuth}";
            BismuthBlock.ToolTip = $"Minimum nuggets: {double.Ceiling((double)bismuth / 5)}";
        }

        private void ZincProportionChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _zinc = (int)e.NewValue;
            ZincPercentBlock.Text = $"Zinc ({_zinc}%)";
            if (IsInitialized)
                updateAnswer();
        }
        
        private void BismuthProportionChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _bismuth = (int)e.NewValue;
            BismuthPercentBlock.Text = $"Bismuth ({_bismuth}%)";
            if (IsInitialized)
                updateAnswer();
        }

        private void IngotNumberPreview(object sender, TextCompositionEventArgs e)
        {
            Debug.Print(e.Text);
            e.Handled = _regex().IsMatch(e.Text);
            if (e.Handled)
            {
                if (sender is TextBox box && !string.IsNullOrEmpty(box.Text))
                    _ingots = int.Parse(box.Text);
                else
                    _ingots = 5;
            }
            if (IsInitialized)
                updateAnswer();
        }

    }
}

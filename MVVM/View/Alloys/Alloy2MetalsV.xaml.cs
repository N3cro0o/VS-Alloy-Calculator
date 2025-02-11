using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Alloy_Calc.MVVM.ViewModel;
using Alloy_Calc.Services;


namespace Alloy_Calc.MVVM.View.Alloys
{
    /// <summary>
    /// Logika interakcji dla klasy Alloy2MetalsV.xaml
    /// </summary>
    public partial class Alloy2MetalsV : UserControl
    {
        [GeneratedRegex(@"[^0-9]+")]
        private static partial Regex _regex();

        string _m1Name;
        string _m2Name;

        int _m1 = 8;
        int _ingots = 5;

        public Alloy2MetalsV()
        {
            InitializeComponent();
            NavParams p = ((MainWindowVM)App.Current.MainWindow.DataContext).Navigation.Params;

            // Add checks later
            TitleBlock.Text = p.Name;
            _m1Name = p.Metals[0];
            _m2Name = p.Metals[1];
            LowerMetalPercentBlock.Text = $"{_m1Name} ({_m1}%)";
            LowerMetalSlider.Minimum = p.Mins[0];
            LowerMetalSlider.Value = p.Mins[0];
            _m1 = p.Mins[0];
            LowerMetalSlider.Maximum = p.Maxs[0] + 0.5;

            updateAnswer();
        }

        private void updateAnswer()
        {
            int units = _ingots * 100;
            int metal1 = (units * _m1 / 100);
            int metal2 = units - metal1;

            Metal1Block.Text = $"{_m2Name} units: {metal2}";
            Metal1Block.ToolTip = $"Minimum nuggets: {double.Ceiling((double)metal2 / 5)}";
            Metal2Block.Text = $"{_m1Name} units: {metal1}";
            Metal2Block.ToolTip = $"Minimum nuggets: {double.Ceiling((double)metal1 / 5)}";
        }

        private void ProportionChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _m1 = (int)e.NewValue;
            LowerMetalPercentBlock.Text = $"{_m1Name} ({_m1}%)";
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

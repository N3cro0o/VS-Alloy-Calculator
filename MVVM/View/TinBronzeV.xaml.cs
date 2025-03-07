﻿using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Alloy_Calc.MVVM.View
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1.xaml
    /// </summary>
    public partial class TinBronzeV : UserControl
    {
        [GeneratedRegex(@"[^0-9]+")]
        private static partial Regex _regex();
        int _tin = 8;
        int _ingots = 5;

        public TinBronzeV()
        {
            InitializeComponent();
            updateAnswer();
        }

        private void updateAnswer()
        {
            int units = _ingots * 100;
            int tin = (units * _tin / 100);
            int copper = units - tin;

            CopperBlock.Text = $"Copper units: {copper}";
            CopperBlock.ToolTip = $"Minimum nuggets: {double.Ceiling((double)copper / 5)}";
            TinBlock.Text = $"Tin units: {tin}";
            TinBlock.ToolTip = $"Minimum nuggets: {double.Ceiling((double)tin / 5)}";
        }

        private void ProportionChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _tin = (int)e.NewValue;
            TinPercentBlock.Text = $"Tin ({_tin}%)";
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

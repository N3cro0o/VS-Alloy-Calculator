using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Alloy_Calc.Core;
using Alloy_Calc.MVVM.ViewModel;
using Alloy_Calc.MVVM.ViewModel.Alloys;

namespace Alloy_Calc.MVVM.View.Alloys
{
    public partial class AllAlloysV : UserControl
    {
        readonly AllAlloysVM? _vm;
        public AllAlloysV()
        {
            InitializeComponent();
            MainWindow window = (MainWindow)App.Current.MainWindow;
            _vm = (AllAlloysVM)((MainWindowVM)window.DataContext).Navigation.CurrView;
            if (_vm != null) 
            {
                int num = 1;
                foreach (RelayCommand com in _vm.AllNavigateCommands)
                {
                    StackPanel stack = new StackPanel
                    {
                        Orientation = Orientation.Horizontal,
                        Margin = new Thickness(10),
                    };
                    stack.Children.Add(new TextBlock
                    {
                        Text = $"{num}.",
                        Margin = new Thickness(0, 0, 5, 0),
                        Foreground = new SolidColorBrush(Color.FromRgb(243, 243, 243)),
                        FontSize = 16
                    });
                    stack.Children.Add(new Button
                    {
                        Content = com.Name,
                        Command = com,
                        Height = 25,
                        Width = 110
                    });
                    ButtonPanel.Children.Add(stack);
                    num++;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alloy_Calc.Core;
using Alloy_Calc.Services;

namespace Alloy_Calc.MVVM.ViewModel
{
    internal class MainWindowVM : Core.ViewModelBase
    {
        private INavService _navigation;

        public INavService Navigation { get => _navigation; set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateHomeCom { get; set; }
        public RelayCommand NavigateTinBronzeCom { get; set; }
        public RelayCommand NavigateBismuthBronzeCom { get; set; }
        public RelayCommand NavigateBlackBronzeCom { get; set; }

        public MainWindowVM(INavService navService)
        {
            Navigation = navService;
            NavigateHomeCom = new RelayCommand(o => { Navigation.NavigateTo<HomeVM>(); }, o => true);
            NavigateTinBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<TinBronzeVM>(); }, o => true);
            NavigateBismuthBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<BismuthBronzeVM>(); }, o => true);
            NavigateBlackBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<BlackBronzeVM>(); }, o => true);

            NavigateHomeCom.Execute(null);
        }
    }
}

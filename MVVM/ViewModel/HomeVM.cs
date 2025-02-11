using Alloy_Calc.Core;
using Alloy_Calc.MVVM.ViewModel.Alloys;
using Alloy_Calc.Services;

namespace Alloy_Calc.MVVM.ViewModel
{
    internal class HomeVM : Core.ViewModelBase
    {
        private INavService _navigation;

        public INavService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateAlloyScreenCom {  get; set; }
        public RelayCommand NavigateTinBronzeCom { get; set; }
        public RelayCommand NavigateBismuthBronzeCom { get; set; }
        public RelayCommand NavigateBlackBronzeCom { get; set; }

        public HomeVM(INavService navigation)
        {
            Navigation = navigation;
            NavigateTinBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<TinBronzeVM>(); }, o => true);
            NavigateBismuthBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<BismuthBronzeVM>(); }, o => true);
            NavigateBlackBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<BlackBronzeVM>(); }, o => true);
            NavigateAlloyScreenCom = new RelayCommand(o => { Navigation.NavigateTo<AllAlloysVM>(); }, o => true);
        }
    }
}

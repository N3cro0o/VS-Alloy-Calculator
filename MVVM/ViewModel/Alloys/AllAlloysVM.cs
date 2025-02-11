using Alloy_Calc.Core;
using Alloy_Calc.Services;

namespace Alloy_Calc.MVVM.ViewModel.Alloys
{
    internal class AllAlloysVM : Core.ViewModelBase
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

        public RelayCommand NavigateTinBronzeCom { get; set; }
        public RelayCommand NavigateBismuthBronzeCom { get; set; }
        public RelayCommand NavigateBlackBronzeCom { get; set; }

        public RelayCommand[] AllNavigateCommands { get; set; }

        public AllAlloysVM(INavService navigation)
        {
            Navigation = navigation;
            NavigateTinBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<TinBronzeVM>(); }, o => true, "Tin bronze");
            NavigateBismuthBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<BismuthBronzeVM>(); }, o => true, "Bismuth bronze");
            NavigateBlackBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<BlackBronzeVM>(); }, o => true, "Black bronze");

            AllNavigateCommands = [ NavigateTinBronzeCom, NavigateBismuthBronzeCom, NavigateBlackBronzeCom ];
        }
    }
}

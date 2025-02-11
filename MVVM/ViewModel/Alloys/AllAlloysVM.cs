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
        public RelayCommand NavigateBrassCom { get; set; }
        public RelayCommand NavigateLeadSoldierCom { get; set; }
        public RelayCommand NavigateMolyDBCom { get; set; }
        public RelayCommand NavigateSilverSoldierCom { get; set; }
        public RelayCommand NavigateElectrumCom { get; set; }
        public RelayCommand NavigateCupronickelCom { get; set; }

        public RelayCommand[] AllNavigateCommands { get; set; }

        public AllAlloysVM(INavService navigation)
        {
            Navigation = navigation;
            NavigateTinBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<TinBronzeVM>(); }, o => true, "Tin bronze");
            NavigateBismuthBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<BismuthBronzeVM>(); }, o => true, "Bismuth bronze");
            NavigateBlackBronzeCom = new RelayCommand(o => { Navigation.NavigateTo<BlackBronzeVM>(); }, o => true, "Black bronze");
            NavigateBrassCom = new RelayCommand(o =>
            {
                Navigation.NavigateTo<Alloy2MetalsVM>(new NavParams
                {
                    Name = "Brass",
                    Metals = ["Zinc", "Copper"],
                    Mins = [30, 60],
                    Maxs = [40, 70]
                });
            }, o => true, "Brass");
            NavigateLeadSoldierCom = new RelayCommand(o =>
            {
                Navigation.NavigateTo<Alloy2MetalsVM>(new NavParams
                {
                    Name = "Lead Soldier",
                    Metals = ["Lead", "Tin"],
                    Mins = [45, 45],
                    Maxs = [55, 55]
                });
            }, o => true, "Lead Soldier");
            NavigateMolyDBCom = new RelayCommand(o =>
            {
                Navigation.NavigateTo<Alloy2MetalsVM>(new NavParams
                {
                    Name = "Molybdochalkos",
                    Metals = ["Copper", "Lead"],
                    Mins = [8, 88],
                    Maxs = [12, 92]
                });
            }, o => true, "Molybdochalkos");
            NavigateSilverSoldierCom = new RelayCommand(o =>
            {
                Navigation.NavigateTo<Alloy2MetalsVM>(new NavParams
                {
                    Name = "Silver Solder",
                    Metals = ["Silver", "Tin"],
                    Mins = [40, 50],
                    Maxs = [50, 60]
                });
            }, o => true, "Silver Solder");
            NavigateElectrumCom = new RelayCommand(o =>
            {
                Navigation.NavigateTo<Alloy2MetalsVM>(new NavParams
                {
                    Name = "Electrum",
                    Metals = ["Gold", "Silver"],
                    Mins = [40, 40],
                    Maxs = [60, 40]
                });
            }, o => true, "Electrum");
            NavigateCupronickelCom = new RelayCommand(o =>
            {
                Navigation.NavigateTo<Alloy2MetalsVM>(new NavParams
                {
                    Name = "Cupronickel",
                    Metals = ["Nickel", "Copper"],
                    Mins = [25, 65],
                    Maxs = [35, 75]
                });
            }, o => true, "Cupronickel");

            AllNavigateCommands = [ NavigateTinBronzeCom, NavigateBismuthBronzeCom, NavigateBlackBronzeCom, NavigateBrassCom,
                NavigateLeadSoldierCom, NavigateMolyDBCom,NavigateSilverSoldierCom,NavigateElectrumCom,NavigateCupronickelCom];
        }
    }
}

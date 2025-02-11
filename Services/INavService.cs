using Alloy_Calc.Core;
using Alloy_Calc.MVVM.ViewModel.Alloys;

namespace Alloy_Calc.Services
{
    public interface INavService
    {
        ViewModelBase CurrView { get; }
        NavParams Params { get; }
        void NavigateTo<T>() where T : ViewModelBase;
        void NavigateTo<T>(NavParams param) where T : ViewModelBase;
    }
}

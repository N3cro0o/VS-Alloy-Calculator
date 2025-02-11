using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alloy_Calc.Core;
using Alloy_Calc.MVVM.ViewModel.Alloys;

namespace Alloy_Calc.Services
{
    internal class NavService : ObservableObject, INavService
    {
        private ViewModelBase _currView;
        private NavParams _params;
        public NavParams Params
        {
            get => _params;
            private set
            {
                _params = value;
            }
        }
        private readonly Func<Type, ViewModelBase> _viewModelFactory;
        public ViewModelBase CurrView
        {
            get => _currView;
            private set
            {
                _currView = value;
                OnPropertyChanged();
            }
        }

        public NavService(Func<Type, ViewModelBase> viewModelFactory)
        {
            _viewModelFactory = viewModelFactory;
        }

        public void NavigateTo<T>() where T : ViewModelBase
        {
            ViewModelBase VM = _viewModelFactory.Invoke(typeof(T));
            CurrView = VM;
            Params = new NavParams();
        }

        public void NavigateTo<T>(NavParams param) where T : ViewModelBase
        {
            ViewModelBase VM = _viewModelFactory.Invoke(typeof(T));
            CurrView = VM;
            Params = param;
        }
    }
}

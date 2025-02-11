using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alloy_Calc.Core;

namespace Alloy_Calc.Services
{
    internal class NavService : ObservableObject, INavService
    {
        private ViewModelBase _currView;
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
        }
    }
}

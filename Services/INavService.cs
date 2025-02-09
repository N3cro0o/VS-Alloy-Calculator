using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alloy_Calc.Core;

namespace Alloy_Calc.Services
{
    public interface INavService
    {
        ViewModelBase CurrView { get; }
        void NavigateTo<T>() where T : ViewModelBase;
    }
}

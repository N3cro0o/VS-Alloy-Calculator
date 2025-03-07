﻿using System.Windows;
using Alloy_Calc.Core;
using Alloy_Calc.MVVM.View;
using Alloy_Calc.MVVM.ViewModel;
using Alloy_Calc.MVVM.ViewModel.Alloys;
using Alloy_Calc.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Alloy_Calc
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// https://github.com/N3cro0o/VS-Alloy-Calculator
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;
        public static string Version = "v 0.2";

        public App()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<MainWindowVM>();
            services.AddSingleton<HomeVM>();
            services.AddSingleton<TinBronzeVM>();
            services.AddSingleton<BismuthBronzeVM>();
            services.AddSingleton<BlackBronzeVM>();
            services.AddSingleton<AllAlloysVM>();
            services.AddSingleton<Alloy2MetalsVM>();
            services.AddSingleton<MainWindow>(ServiceProvider => new MainWindow
            {
                DataContext = ServiceProvider.GetRequiredService<MainWindowVM>()
            });
            services.AddSingleton<INavService, NavService>();
            services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType => (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = _serviceProvider.GetRequiredService<MainWindow>();
            window.Show();
            base.OnStartup(e);
        }
    }

}

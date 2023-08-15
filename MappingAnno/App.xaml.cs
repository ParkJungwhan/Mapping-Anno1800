using System;
using System.Windows;
using MappingAnno.ViewModels;
using MappingAnno.Views;
using MappingAnno.Views.MapViews;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MVVMHelper;
using NLog.Extensions.Logging;

namespace MappingAnno
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        public IServiceProvider Services { get; }

        public App()
        {
            Services = ConfigureServices();
            this.InitializeComponent();

            DIService.Services = Services;
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            //GlobalData.Init(e);

            //ChangeSkin(GlobalData.Config.Skin);

            MainWindow main = DIService.GetDIService<MainWindow>();
            main.DataContext = DIService.GetDIService<MainWindowViewModel>();
            main.Show();
        }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Logger
            services.AddLogging(logginbuilder =>
            {
                logginbuilder.ClearProviders();
                logginbuilder.AddNLog();
            });

            // 싱글톤으로 등록하여 헬퍼 클래스처럼 동작할 수 있게하는건 여기서 등록
            //services.AddSingleton<IWindowManagerService, WindowManagerService>();
            //services.AddSingleton<MonitorViewModel>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<MainLoadViewModel>();

            //// common ui
            //services.AddTransient<IMenu, ToolMenu>();
            //services.AddTransient<MainWindowContent>();
            services.AddTransient<MainLoadView>();

            services.AddTransient<WorldView>();

            services.AddTransient<WorldMap>();
            services.AddTransient<CrownFallsMap>();
            services.AddTransient<EnbesaMap>();
            services.AddTransient<NewContinentMap>();
            services.AddTransient<OldContinentMap>();
            services.AddTransient<NorthContinentMap>();

            services.AddSingleton<MainWindow>();

            //// 객체를 등록하고 di를 통해 계속 호출될때마다 객체가 생성되는 방식으로 등록하는 부분
            //services.AddTransient<PTMSplashProcess>();

            //services.AddTransient<ISplashProcess, PTMSplashProcess>();

            return services.BuildServiceProvider();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            //GlobalData.Save();

            // 저장할지 물어보고 y/n

            base.OnExit(e);
        }
    }
}
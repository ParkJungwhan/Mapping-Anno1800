using System;
using System.Windows;
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

            //var winmgr = Services.GetService<IWindowManagerService>();
            //winmgr?.StartProcess();

            MainWindow main = new MainWindow();
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

            //// common ui
            //services.AddTransient<IMenu, ToolMenu>();
            //services.AddTransient<MainWindowContent>();

            //// 객체를 등록하고 di를 통해 계속 호출될때마다 객체가 생성되는 방식으로 등록하는 부분
            //services.AddTransient<PTMSplashProcess>();

            //services.AddTransient<ISplashProcess, PTMSplashProcess>();

            return services.BuildServiceProvider();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            //GlobalData.Save();

            base.OnExit(e);
        }
    }
}
using System.Windows;
using CommunityToolkit.Mvvm.Messaging;
using MappingAnno.Models;
using MappingAnno.Views;
using MVVMHelper;

namespace MappingAnno
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var mainload = DIService.GetDIService<MainLoadView>();
            // mainload.DataContext = ((MainWindowViewModel)this.DataContext).LoadList;

            ChangeContent(mainload);

            WeakReferenceMessenger.Default.Register<UIChangeMessage>(this, ChangeMainContent);
        }

        private void ChangeMainContent(object recipient, UIChangeMessage message)
        {
            ChangeContent(message.Value);
        }

        private void ChangeContent(UIElement uiConent)
        {
            // animation story
            mainContent.Children.Clear();
            mainContent.Children.Add(uiConent);
        }
    }
}
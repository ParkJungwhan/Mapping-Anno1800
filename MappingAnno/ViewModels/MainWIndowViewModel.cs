using CommunityToolkit.Mvvm.ComponentModel;

namespace MappingAnno.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public string Title { get; set; }

        public MainWindowViewModel()
        {
            Title = "Mapping - Anno Union";
        }
    }
}
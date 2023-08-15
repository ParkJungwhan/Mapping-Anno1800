using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MappingAnno.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        public string Title { get; set; }

        public MainLoadViewModel LoadList { get; set; }

        public MainWindowViewModel()
        {
            Title = "Mapping - Anno Union (Anno 1800)";

            LoadList = new MainLoadViewModel();
        }
    }
}
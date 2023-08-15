using System;
using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using HandyControl.Controls;
using MappingAnno.Models;
using MappingAnno.Views;
using MVVMHelper;

namespace MappingAnno.ViewModels
{
    public class MainLoadViewModel : ObservableObject
    {
        public List<LoadInfoModel> SaveList { get; set; }

        public MainLoadViewModel()
        {
            SaveList = new List<LoadInfoModel>(10);
            for (int i = 0; i < 10; i++)
            {
                SaveList.Add(new LoadInfoModel()
                {
                    Index = i + 1,
                    LastSaveTime = DateTime.Now,
                    Name = $"Name {i + 1}",
                    ClickCommand = new RelayCommand<LoadInfoModel>(LoadProject)
                });
            }
        }

        private void LoadProject(LoadInfoModel model)
        {
            // 여기서 worldview먼저 호출
            //var newprojectview = DIService.GetDIService<UIChangeMessage>();

            var worldview = DIService.GetDIService<WorldView>();

            var newproject = new UIChangeMessage(worldview);
            newproject.ProejctPath = model.ProjectPath;

            WeakReferenceMessenger.Default.Send(newproject);
        }
    }

    public class LoadInfoModel
    {
        public int Index { get; set; }
        public string Name { get; set; }
        public DateTime LastSaveTime { get; set; }
        public string ProjectPath { get; set; }

        //public RelayCommand<int> ClickCommand { get; set; }
        public RelayCommand<LoadInfoModel> ClickCommand { get; set; }
    }
}
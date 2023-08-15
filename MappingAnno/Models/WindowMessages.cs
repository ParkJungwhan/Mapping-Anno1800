using System.Windows;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace MappingAnno.Models
{
    public class UIChangeMessage : ValueChangedMessage<UIElement>
    {
        public UIElement content { get; set; }
        public string ProejctPath { get; set; }

        public UIChangeMessage(UIElement value) : base(value)
        {
            content = value;
        }
    }
}
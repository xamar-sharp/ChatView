using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
namespace ChatView.Models
{
    public class Message : INotifyPropertyChanged
    {
        private readonly MessageDTO _message;
        public string TextMessage { get => _message.TextMessage; set { _message.TextMessage = value; OnPropertyChanged(); } }
        public DateTime CreatedAt { get => _message.CreatedAt; set { _message.CreatedAt = value; OnPropertyChanged(); } }
        public ImageSource SenderIcon { get => ImageSource.FromUri(new Uri(_message.IconURI)); set { } }
        public string SenderLogin { get => _message.Login; set { _message.Login = value; OnPropertyChanged(); } }
        public Message(MessageDTO dto)
        {
            _message = dto;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}

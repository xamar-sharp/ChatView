using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using ChatView.Models;
using System.Windows.Input;
namespace ChatView
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Message> _messages;
        public ObservableCollection<Message> Messages { get { return _messages; } set { _messages = value; OnPropertyChanged(); } }
        public ICommand RefreshCommand { get; set; }
        public ICommand ContextCommand { get; set; }
        public Color BackColor { get; set; }
        public ImageSource ContextIcon { get; set; }
        public MainPage()
        {
            InitializeComponent();
            chat.Messages = new ObservableCollection<Message>(new List<Message>(4) { new Message(new MessageDTO() { CreatedAt = DateTime.Now, Login = App.MainName, IconURI = App.MainIconURI, TextMessage = "Hello are you?" }),
            new Message(new MessageDTO() { CreatedAt = DateTime.Now, Login = "friend", IconURI = "https://b1.pngbarn.com/png/1017/383/valve-world-icon-addon-1-badge-of-blood-white-and-blue-logo-screenshot-png-clip-art-thumbnail.png", TextMessage = "Hello!" })}) ;
            BackColor = Color.Blue;
            chat.Pair = new KeyValuePair<Color, Color>(Color.DarkOrchid, Color.MediumOrchid);
            chat.IconTappedCommand = new Command(async (obj)=>
            {
                await DisplayAlert((obj as Message).SenderLogin, (obj as Message).TextMessage, "Cancel");
            });
            RefreshCommand = new Command((obj) =>
            {
                (obj as RefreshView).IsRefreshing = true;
            });
            ContextCommand = new Command(obj =>
            {
                chat.Messages.Remove((obj as ListView).SelectedItem as Message);
            });
            chat.ContextCommand = ContextCommand;
            chat.RefreshCommand = RefreshCommand;
            this.BindingContext = this;
        }
    }
}

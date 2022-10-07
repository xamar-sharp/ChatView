using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ChatView.Models;
using Xamarin.Forms;
using System.Windows.Input;
using Xamarin.Forms.Xaml;

namespace ChatView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatView : ContentView
    {
        public static readonly BindableProperty MessagesProperty = BindableProperty.Create("Messages", typeof(ObservableCollection<Message>), typeof(ChatView), null);
        public static readonly BindableProperty PairProperty = BindableProperty.Create("Pair", typeof(KeyValuePair<Color, Color>), typeof(ChatView), new KeyValuePair<Color, Color>(Color.CornflowerBlue, Color.White));
        public static readonly BindableProperty BackgroundImageProperty = BindableProperty.Create("BackgroundImage", typeof(ImageSource), typeof(ChatView), new FileImageSource { File = "back.jpg" });
        public static readonly BindableProperty ContextIconProperty = BindableProperty.Create("ContextIcon", typeof(ImageSource), typeof(ChatView), new FileImageSource { File = "remove.png" });
        public static readonly BindableProperty ContextCommandProperty = BindableProperty.Create("ContextCommand", typeof(ICommand), typeof(ChatView), null);
        public static readonly BindableProperty RefreshCommandProperty = BindableProperty.Create("RefreshCommand", typeof(ICommand), typeof(ChatView), null);
        public static readonly BindableProperty SendImageProperty = BindableProperty.Create("SendImage", typeof(ImageSource), typeof(ChatView), new FileImageSource { File = "send.png" });
        public static readonly BindableProperty BackColorProperty = BindableProperty.Create("BackColor", typeof(Color), typeof(ChatView), Color.White);
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create("TextColor", typeof(Color), typeof(ChatView), Color.Black);
        public static readonly BindableProperty RefreshColorProperty = BindableProperty.Create("RefreshColor", typeof(Color), typeof(ChatView), Color.Green);
        public static readonly BindableProperty TextMessageProperty = BindableProperty.Create("TextMessage", typeof(string), typeof(ChatView), "");
        public static readonly BindableProperty ContentTextColorProperty = BindableProperty.Create("ContentTextColor", typeof(Color), typeof(ChatView), Color.Black);
        public static readonly BindableProperty ContentTitleColorProperty = BindableProperty.Create("ContentTitleColor", typeof(Color), typeof(ChatView), Color.Gray);
        public static readonly BindableProperty ContentDateColorProperty = BindableProperty.Create("ContentDateColor", typeof(Color), typeof(ChatView), Color.Green);

        public ImageSource SendImage { get => GetValue(ChatView.SendImageProperty) as ImageSource; set => SetValue(ChatView.SendImageProperty, value); }
        public Color ContentTitleColor { get => (Color)GetValue(ChatView.ContentTitleColorProperty); set => SetValue(ChatView.ContentTitleColorProperty, value); }
        public Color ContentTextColor { get => (Color)GetValue(ChatView.ContentTextColorProperty); set => SetValue(ChatView.ContentTextColorProperty, value); }
        public Color ContentDateColor { get => (Color)GetValue(ChatView.ContentDateColorProperty); set => SetValue(ChatView.ContentDateColorProperty, value); }
        public Color BackColor { get => (Color)GetValue(ChatView.BackColorProperty); set => SetValue(ChatView.BackColorProperty, value); }
        public Color TextColor { get => (Color)GetValue(ChatView.TextColorProperty); set => SetValue(ChatView.TextColorProperty, value); }
        public Color RefreshColor { get => (Color)GetValue(ChatView.RefreshColorProperty); set => SetValue(ChatView.RefreshColorProperty, value); }
        public string TextMessage { get => GetValue(ChatView.TextMessageProperty) as string; set => SetValue(ChatView.TextMessageProperty, value); }
        public ImageSource BackgroundImage { get => GetValue(ChatView.BackgroundImageProperty) as ImageSource; set => SetValue(ChatView.BackgroundImageProperty, value); }
        public ObservableCollection<Message> Messages { get => GetValue(ChatView.MessagesProperty) as ObservableCollection<Message>; set { SetValue(ChatView.MessagesProperty, value); OnPropertyChanged(); } }
        public ICommand RefreshCommand { get => GetValue(ChatView.RefreshCommandProperty) as ICommand; set => SetValue(ChatView.RefreshCommandProperty, value); }
        public ICommand ContextCommand { get => GetValue(ChatView.ContextCommandProperty) as ICommand; set => SetValue(ChatView.ContextCommandProperty, value); }
        public ImageSource ContextIcon { get => GetValue(ChatView.ContextIconProperty) as ImageSource; set => SetValue(ChatView.ContextIconProperty, value); }
        public KeyValuePair<Color, Color> Pair { get => (KeyValuePair<Color, Color>)GetValue(ChatView.PairProperty); set => SetValue(ChatView.PairProperty, value); }
        public ICommand SendMessageCommand { get; set; }
        public ICommand IconTappedCommand { get; set; }
        public string UserName { get; set; }
        public ChatView()
        {
            InitializeComponent();
            SendMessageCommand = new Command(() =>
            {
                Messages.Add(new Message(new MessageDTO() { CreatedAt = DateTime.Now,IconURI = App.MainIconURI,Login=App.MainName,TextMessage=TextMessage}));
            });
            this.BindingContext = this;
        }
        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if (width > height)
            {
                stack.WidthRequest = 600;
            }
            else if (height> width)
            {
                stack.WidthRequest = 285;
            }
        }
    }
}
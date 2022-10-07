using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;
using ChatView.Models;
namespace ChatView.Converters
{
    public sealed class ChatSenderConverter : IValueConverter
    {
        public object Convert(object value, Type target, object param, CultureInfo info)
        {
            return (value as string) == (param as ChatView).UserName ? LayoutOptions.EndAndExpand : LayoutOptions.StartAndExpand;
        }
        public object ConvertBack(object value, Type target, object param, CultureInfo info)
        {
            throw new NotImplementedException();
        }
    }
}

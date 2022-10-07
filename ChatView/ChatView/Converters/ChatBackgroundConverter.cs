using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Globalization;
using ChatView.Models;
namespace ChatView.Converters
{
    public sealed class ChatBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type target, object param, CultureInfo info)
        {
            KeyValuePair<Color, Color> pair = (param as ChatView).Pair;
            return (value as string) == (param as ChatView).UserName ? pair.Key : pair.Value;
        }
        public object ConvertBack(object value, Type target, object param, CultureInfo info)
        {
            throw new NotImplementedException();
        }
    }
}

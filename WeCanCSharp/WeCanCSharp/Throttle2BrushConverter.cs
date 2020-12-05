using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace WeCanCSharp
{
    class Throttle2BrushConverter : IValueConverter
    {
        readonly private static byte[] brushes = { 0xf5, 0xf6, 0xf7, 0xf8, 0xf9, 0xfa, 0xfb, 0xfc, 0xfd, 0xfe, 0xff };
        SolidColorBrush brush; 
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            brush = new SolidColorBrush(Color.FromArgb(brushes[(int)value], 0xff, 0x00, 0x00));
            return brush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

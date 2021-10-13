using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace WeCanCSharp
{
    class Throttle2BrushConverter : IValueConverter
    {
        readonly private static byte[] brushes = { 55, 65, 75, 85, 95, 105, 115, 125, 135, 145, 155, 165, 175, 185, 195, 205, 215, 225, 235, 245, 255 };
        SolidColorBrush brush;
        int value2;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            value2 = System.Convert.ToInt32(value) + 10;
            brush = new SolidColorBrush(Color.FromArgb(brushes[value2], 0, 255, 0));
            return brush;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

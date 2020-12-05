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
        readonly private static SolidColorBrush blue = new SolidColorBrush(Colors.Blue);
        readonly private static SolidColorBrush dblue = new SolidColorBrush(Colors.DodgerBlue);
        readonly private static SolidColorBrush dsblue = new SolidColorBrush(Colors.DeepSkyBlue);
        readonly private static SolidColorBrush lsblue = new SolidColorBrush(Colors.LightSkyBlue);
        readonly private static SolidColorBrush pblue = new SolidColorBrush(Colors.PowderBlue);
        readonly private static SolidColorBrush black = new SolidColorBrush(Colors.Black);
        readonly private static SolidColorBrush maroon = new SolidColorBrush(Colors.Maroon);
        readonly private static SolidColorBrush dred = new SolidColorBrush(Colors.DarkRed);
        readonly private static SolidColorBrush fb = new SolidColorBrush(Colors.Firebrick);
        readonly private static SolidColorBrush red = new SolidColorBrush(Colors.Red);
        readonly private static SolidColorBrush crimson = new SolidColorBrush(Colors.Crimson);
        readonly private static SolidColorBrush[] brushes = new[] { blue, dblue, dsblue, lsblue, pblue, maroon, dred, fb, red, crimson };

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((int)value == 0)
            {
                return black;
            }
            if ((int)value == 10)
            {
                return brushes[9];
            }
            else
            {
                if (((int)value) % 2 == 0)
                {
                    return brushes[((int)value / 2) + 5];
                }
                else
                {
                    return brushes[(((int)value - 1) / 2) + 5];
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

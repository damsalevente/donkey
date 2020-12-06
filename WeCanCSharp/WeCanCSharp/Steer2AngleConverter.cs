
using System;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace WeCanCSharp
{
    class Steer2AngleConverter : IValueConverter
    {
        public int MaxSteerAngle = 6;
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            double dVal = (double)value;
            return dVal * MaxSteerAngle;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}


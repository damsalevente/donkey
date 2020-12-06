using System;
using Windows.UI.Xaml.Data;

namespace WeCanCSharp
{
    internal class Steer2AngleConverter : IValueConverter
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
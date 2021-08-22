using System;
using System.Globalization;
using Xamarin.Forms;

namespace LeiTool.IVauleConverters
{
    class TodoListIsFinishedToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
                return Color.Green;
            else
                return Color.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((Color)value == Color.Green)
                return true;
            else return false;
        }
    }
}

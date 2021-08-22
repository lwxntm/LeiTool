using System;
using System.Globalization;
using Xamarin.Forms;

namespace LeiTool.IVauleConverters
{
    class TodoListIsFinishedToStrConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
                return "已完成";
            if ((bool)value == false)
                return "未完成";
            else
                return "未知";

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "已完成")
                return true;
            if ((string)value == "未完成")
                return false;
            else return false;
        }
    }
}

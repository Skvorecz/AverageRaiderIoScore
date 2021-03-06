﻿using System;
using System.Globalization;
using System.Windows.Data;
using AverageRaiderIoScore.Domain;

namespace AverageRaiderIoScore
{
    class StringToRegionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null ? ((Region)value).ToString() : String.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (Region)Enum.Parse(typeof(Region), (string)value);
        }
    }
}
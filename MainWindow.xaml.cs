using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab6
{
    class WeatherControl : DependencyObject
    {

        public static readonly DependencyProperty TempProperty;
        private string windDir;
        private int windSp;
        private int rainFall;

        private enum rainfall
        {
            Sunny,
            Cloudly,
            Rainy,
            snowy
        }
        public string WindDir
        {
            get => windDir;
            set => windDir = value;
        }
        public int WindSp
        {
            get => windSp;
            set => windSp = value;
        }
        public int Temp
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        public int RainFall
        {
            get => (int)GetValue(TempProperty);
            set => SetValue(TempProperty, value);
        }
        public WeatherControl(string windDir, int windSp, int rainFall)
        {
            this.WindDir = windDir;
            this.WindSp = windSp;
            this.RainFall = rainFall;
        }
        static WeatherControl()
        {

            TempProperty = DependencyProperty.Register(
            nameof(Temp),
            typeof(int),
            typeof(WeatherControl),

            new FrameworkPropertyMetadata(
            0,
            FrameworkPropertyMetadataOptions.AffectsMeasure |
            FrameworkPropertyMetadataOptions.AffectsRender,
            null,
            new CoerceValueCallback(CoerceTemp)),
            new ValidateValueCallback(ValidateTemp));
        }
        private static bool ValidateTemp(object value)
        {

            int v = (int)value;
            if (v > -50 && v < 50)
                return true;
            else
                return false;
        }
        private static object CoerceTemp(DependencyObject d, object baseValue)
        {
            int v = (int)baseValue;
            if (v > -50 && v < 50)
                return v;
            else
                return 0;

        }
        public string Print()
        {
            return $"{WindDir}{WindSp}{RainFall}";
        }
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace LotteryTools.Styles
{
    public class ListViewBgConverter : System.Windows.Data.IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ListViewItem item = (ListViewItem)value;
            ListView listView = ItemsControl.ItemsControlFromItemContainer(item) as ListView;

            int index = listView.ItemContainerGenerator.IndexFromContainer(item);
            if (index % 2 == 0)
            {
                return Brushes.Cornsilk;
            }
            else
            {
                return Brushes.White;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}

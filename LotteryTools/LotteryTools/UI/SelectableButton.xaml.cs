using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace LotteryTools.UI
{
    /// <summary>
    /// SelectableButton.xaml 的交互逻辑
    /// </summary>
    public partial class SelectableButton : UserControl
    {
        private bool _selected = false;
        private string _text = "";


        [DefaultValue(false)]
        [Browsable(true)]
        public bool Selected 
        {
            get { return _selected; }
            set { this._selected = value; }
        }

        [Browsable(true)]
        [DefaultValue("1")]
        public string Text 
        {
            get { return _text; }
            set 
            {
                this._text = value;
                this.ContentLabel.Content = value;
            }
        }

        public SelectableButton()
        {
            InitializeComponent();
        }

    }
}

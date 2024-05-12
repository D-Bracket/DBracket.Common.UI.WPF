using DBracket.Common.UI.WPF.Charts.Controls.Components;
using DBracket.Common.UI.WPF.Charts.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DBracket.Common.UI.WPF.Sample.Views.Examples
{
    /// <summary>
    /// Interaktionslogik für SideBar.xaml
    /// </summary>
    public partial class SideBar : UserControl
    {
        public SideBar()
        {
            InitializeComponent();
            DataContext = new SideBarControl();
            Menu.ItemsSource = Items;
        }

        public ObservableCollection<SideBarItem> Items
        {
            get => (ObservableCollection<SideBarItem>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }
        /// <summary>DataPoint DependencyProperty</summary>
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
            "Items", typeof(ObservableCollection<SideBarItem>), typeof(SideBar), new FrameworkPropertyMetadata(new ObservableCollection<SideBarItem>()));

    }
}

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

namespace Try
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> ObsString { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ObsString = new ObservableCollection<string>()
            {
                "LG Nexus 5X",
                "Huawei Nexus 6P",
                "iPhone 6S",
                "iPhone 6S Plus",
                "Аsus Zenphone 2",
                "Microsoft Lumia 950",
                "LG Nexus 5X",
                "Huawei Nexus 6P",
                "iPhone 6S",
                "iPhone 6S Plus",
                "Аsus Zenphone 2",
                "Microsoft Lumia 950",
                "LG Nexus 5X",
                "Huawei Nexus 6P",
                "iPhone 6S",
                "iPhone 6S Plus",
                "Аsus Zenphone 2",
                "Microsoft Lumia 950",

            };

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ResourceDictionary newDictionary = new ResourceDictionary();
            //newDictionary.Source = new Uri("Style2.xaml", UriKind.Relative);
            //this.Resources.MergedDictionaries[0] = newDictionary;

            //Application.Current.Resources.MergedDictionaries[0] = newDictionary;
        }
    }
}

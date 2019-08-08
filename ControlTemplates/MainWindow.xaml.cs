using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace ControlTemplates
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Type controlType = typeof(Control);
            List<Type> derivedTypes = new List<Type>();
            // Искать все типы в сборке, где определен класс Control. 
            Assembly assembly = Assembly.GetAssembly(typeof(Control));
            foreach (Type type in assembly.GetTypes())
            {
                // Добавлять тип в список, только если это унаследованный от Control, 
                // конкретный и общедоступный класс. 
            if (type.IsSubclassOf(controlType) && !type.IsAbstract && type.IsPublic)
                {
                    derivedTypes.Add(type);
                }
            }
            // Сортировать по типам. Специальный класс TypeComparer 
            // упорядочивает типы по именам в алфавитном порядке. 
            //derivedTypes.Sort(new TypeComparer());
            // Отобразить список типов. 
            IstTypes.ItemsSource = derivedTypes;

        }

        private void IstTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                // Получить выбранный тип. 
                Type type = (Type)IstTypes.SelectedItem;
                // Создать экземпляр типа. 
                ConstructorInfo info = type.GetConstructor(System.Type.EmptyTypes);
                Control control = (Control)info.Invoke(null);
                // Добавить его в Grid (оставив скрытым). 
                control.Visibility = Visibility.Collapsed;
                grid.Children.Add(control);
                // Получить шаблон. 
                ControlTemplate template = control.Template;
                // Получить XAML-разметку для шаблона. 
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                StringBuilder sb = new StringBuilder();
                XmlWriter writer = XmlWriter.Create(sb, settings);
                XamlWriter.Save(template, writer);
                // Отобразить шаблон. 
                txtTemplate.Text = sb.ToString();
                // Удалить элемент управления из Grid. 
                grid.Children.Remove(control);
            }
            catch (Exception err)
            {
                // При генерации шаблона возникла ошибка. 
                txtTemplate.Text = "<< Error generating template: " + err.Message + ">>";
            }

        }
    }
}

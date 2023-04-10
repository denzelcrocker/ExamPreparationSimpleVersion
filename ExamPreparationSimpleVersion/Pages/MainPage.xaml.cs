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

namespace ExamPreparationSimpleVersion.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }
        List<Modules.children> childrens = new List<Modules.children>();
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            AllChildrens.ItemsSource = null;
            string path = Modules.OpenDialog();
            childrens = Modules.ReadChildrens(path);
            AllChildrens.ItemsSource = childrens;
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            string path = Modules.OpenDialog();
            Modules.WriteChildrens(childrens, path);
        }
    }
}

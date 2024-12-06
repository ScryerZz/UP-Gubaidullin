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
using UP_Gubaidullin.ModelDB;

namespace UP_Gubaidullin.Pages
{
    /// <summary>
    /// Логика взаимодействия для DirectionPage.xaml
    /// </summary>
    public partial class DirectionPage : Page
    {
        public DirectionPage()
        {
            InitializeComponent();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTB.Text))
                return;
            if (string.IsNullOrWhiteSpace(CodeTB.Text))
                return;
            var dir = new Departments { Cipher = CodeTB.Text, DepartmentName = NameTB.Text, Faculties = App.db.Faculties.FirstOrDefault(i => i.Abbreviation == FacTB.Text) };
            if (dir.Faculties == null)
                return;

            App.db.Departments.Add(dir);
            try
            {
                App.db.SaveChanges();
            }
            finally
            {
                NavigationService.Navigate(new DirectionsPage());
            }
        }
    }
}

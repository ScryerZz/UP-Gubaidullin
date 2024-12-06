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

namespace UP_Gubaidullin.Pages
{
    /// <summary>
    /// Логика взаимодействия для RolePage.xaml
    /// </summary>
    public partial class RolePage : Page
    {
        public RolePage()
        {
            InitializeComponent();
        }

        private void Button_Exam(object sender, RoutedEventArgs e)
        {
            if (App.user.Educators != null)
            {
                NavigationService.Navigate(new ExamPage());
            }
            else
            {
                MessageBox.Show("Этот пользователь не учитель");
            }
        }

        private void Button_DepHead(object sender, RoutedEventArgs e)
        {
            if (App.user.DepartmentHeads != null)
            {
                NavigationService.Navigate(new DepHeadPage());
            }
            else
            {
                MessageBox.Show("Этот пользователь не заведующий кафедрой");
            }
        }

        private void Button_Engin(object sender, RoutedEventArgs e)
        {
            if (App.user.Engineers != null)
            {
                NavigationService.Navigate(new EnginPage());
            }
            else
            {
                MessageBox.Show("Этот пользователь не инженер");
            }
        }
    }
}

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
    public partial class HelloPage : Page
    {
        public HelloPage()
        {
            InitializeComponent();
        }

        private void OnEnter(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(PasswordTB.Text, out int password))
            {
                App.user = App.db.Employees.FirstOrDefault(i => i.ID_Employee == password);
                if (App.user == null)
                {
                    MessageBox.Show("Такого сотрудника не существует!");
                }
                else
                {
                    MessageBox.Show("Вы успешно авторизовались!");
                    NavigationService.Navigate(new RolePage());
                }
            }
        }
    }
}

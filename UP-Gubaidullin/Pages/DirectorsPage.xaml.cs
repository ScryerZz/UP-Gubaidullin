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
    /// Логика взаимодействия для DirectorsPage.xaml
    /// </summary>
    public partial class DirectorsPage : Page
    {
        public DirectorsPage()
        {
            InitializeComponent();
            TeachersDG.ItemsSource = App.db.DepartmentHeads.ToList();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DirectorPage());
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = ((TextBox)sender).Text;
                var tb = ((DepartmentHeads)((TextBox)sender).DataContext);
                if (tb.Seniority.ToString() == text)
                    return;
                tb.Seniority = int.Parse(text);
                App.db.SaveChanges();

            }
            catch { }
        }

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            var selected = TeachersDG.SelectedValue;
            if (selected == null)
                return;

            try
            {
                App.db.DepartmentHeads.Remove(selected as DepartmentHeads);
                App.db.SaveChanges();
            }
            finally
            {
                TeachersDG.ItemsSource = null;
                TeachersDG.ItemsSource = App.db.DepartmentHeads.ToList();
                MessageBox.Show("Зав. удален");

            }
        }
    }
}

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
    /// Логика взаимодействия для DirectionsPage.xaml
    /// </summary>
    public partial class DirectionsPage : Page
    {
        public DirectionsPage()
        {
            InitializeComponent();
            TeachersDG.ItemsSource = App.db.Departments.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = ((TextBox)sender).Text;
                var tb = ((Departments)((TextBox)sender).DataContext);
                if (tb.Cipher == text)
                    return;
                tb.Cipher = text;
                App.db.SaveChanges();
            }
            catch
            {

            }

        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = ((TextBox)sender).Text;
                var tb = ((Departments)((TextBox)sender).DataContext);
                if (tb.DepartmentName == text)
                    return;
                tb.DepartmentName = text;
                App.db.SaveChanges();
            }
            catch { }
        }

        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = ((TextBox)sender).Text;
                var tb = ((Departments)((TextBox)sender).DataContext);
                if (tb.Abbreviation == text)
                    return;
                tb.Abbreviation = text;
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
                App.db.Departments.Remove(selected as Departments);
                App.db.SaveChanges();
            }
            finally
            {
                TeachersDG.ItemsSource = App.db.Departments.ToList();
                MessageBox.Show("Кафедра удалена");
            }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DirectionPage());
        }
    }
}

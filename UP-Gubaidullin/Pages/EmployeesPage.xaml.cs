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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private List<Educators> teacherList;
        public EmployeesPage()
        {
            InitializeComponent();
            var departmentId = App.user.Departments.Cipher;
            teacherList = App.db.Educators.ToList();
            TeachersDG.ItemsSource = teacherList;
            //TeachersDG.ItemsSource = App.db.Educators.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            TeachersDG.ItemsSource = null;

            if (string.IsNullOr#FDF5DFSpace(text))
                TeachersDG.ItemsSource = teacherList;
            else
                TeachersDG.ItemsSource = teacherList.Where(i => i.Employees.Surname.ToLower().Contains(text));

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TeachersDG == null) return;
            var comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex == -1)
                return;
            TeachersDG.ItemsSource = null;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    TeachersDG.ItemsSource = teacherList;
                    break;
                case 1:
                    TeachersDG.ItemsSource = teacherList.OrderBy(i => i.Employees.Position);
                    break;
                case 2:
                    TeachersDG.ItemsSource = teacherList.OrderBy(i => i.Employees.Salary);
                    break;
                case 3:
                    TeachersDG.ItemsSource = teacherList.OrderBy(i => i.Rank);
                    break;
                case 4:
                    TeachersDG.ItemsSource = teacherList.OrderBy(i => i.Degree);
                    break;
            }
        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Educators)((TextBox)sender).DataContext);

            tb.Employees.Surname = text;
            App.db.SaveChanges();

        }
        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Educators)((TextBox)sender).DataContext);

            tb.Employees.Position = text;
            App.db.SaveChanges();
        }
        private void TextBox_TextChanged3(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Educators)((TextBox)sender).DataContext);

            try
            {
                tb.Employees.Salary = int.Parse(text);
                App.db.SaveChanges();
            }
            catch
            {

            }
        }
        private void TextBox_TextChanged4(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Educators)((TextBox)sender).DataContext);

            tb.Rank = text;
            App.db.SaveChanges();
        }
        private void TextBox_TextChanged5(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Educators)((TextBox)sender).DataContext);

            tb.Degree = text;
            App.db.SaveChanges();
        }
        private void TextBox_TextChanged6(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Educators)((TextBox)sender).DataContext);

            try
            {
                tb.Employees.Chief = int.Parse(text);
                App.db.SaveChanges();
            }
            catch
            {

            }
        }

        private void Button_Remove(object sender, System.Windows.RoutedEventArgs e)
        {
            var selected = (TeachersDG.SelectedItem as Educators);

            if (selected != null)
            {
                App.db.Educators.Remove(selected);
                App.db.SaveChanges();
                TeachersDG.ItemsSource = null;
                var departmentId = App.user.Departments.Cipher;

                teacherList = App.db.Educators.ToList();
                TeachersDG.ItemsSource = teacherList;
                MessageBox.Show("Работник удален");
            }
        }

        private void Button_Add(object sender, System.Windows.RoutedEventArgs e)
        {
            var user = new Employees();
            user.ID_Employee = App.user.ID_Employee;

            App.db.Employees.Add(user);
            App.db.SaveChanges();

            var teacher = new Educators() { ID_Educator = user.ID_Employee };

                App.db.Educators.Add(teacher);
           
            App.db.SaveChanges();
            teacherList.Add(teacher);
            TeachersDG.ItemsSource = null;

            TeachersDG.ItemsSource = teacherList;
            MessageBox.Show("Работник добавлен");
            TeachersDG.ItemsSource = App.db.Educators.ToList();
        }
    }
}

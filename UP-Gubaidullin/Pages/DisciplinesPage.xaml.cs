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
    /// Логика взаимодействия для DisciplinesPage.xaml
    /// </summary>
    public partial class DisciplinesPage : Page
    {
        public DisciplinesPage()
        {
            InitializeComponent();
            TeachersDG.ItemsSource = App.db.Disciplines.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Disciplines)((TextBox)sender).DataContext);
            if (tb.DisciplineName == text)
                return;
            tb.DisciplineName = text;
            App.db.SaveChanges();
        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Disciplines)((TextBox)sender).DataContext);
            if (tb.Volume.ToString() == text)
                return;
            try
            {
                tb.Volume = int.Parse(text);
                App.db.SaveChanges();
            }
            catch { }

        }

        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((Disciplines)((TextBox)sender).DataContext);
            if (tb.Departments != null && tb.Departments.Cipher == text)
                return;
            tb.Departments = App.db.Departments.FirstOrDefault(i => i.Cipher == text);
            if (tb.Departments != null)
                try
                {
                    App.db.SaveChanges();
                }
                catch { }
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var disc = new Disciplines();
            App.db.Disciplines.Add(disc);
            App.db.SaveChanges();
            TeachersDG.ItemsSource = null;

            TeachersDG.ItemsSource = App.db.Disciplines.ToList();
            MessageBox.Show("Дисциплина создана");
        }

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            if (TeachersDG.SelectedValue is null)
                return;

            App.db.Disciplines.Remove(TeachersDG.SelectedValue as Disciplines);
            App.db.SaveChanges();
            TeachersDG.ItemsSource = null;

            TeachersDG.ItemsSource = App.db.Disciplines.ToList();

            MessageBox.Show("Дисциплина удалена");
        }
    }
}

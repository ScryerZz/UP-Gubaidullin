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
    /// Логика взаимодействия для ExamsFullPage.xaml
    /// </summary>
    public partial class ExamsFullPage : Page
    {
        public ExamsFullPage()
        {
            InitializeComponent();
            var userCode = App.user.Cipher;
            ExamsDG.DataContext = App.db.Exams.ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tb = (TextBox)sender;
                var exam = tb.DataContext as Exams;
                if (exam == null)
                    return;
                exam.Appraisal = int.Parse(tb.Text);
                App.db.SaveChanges();
            }
            catch
            {

            }
        }

        private void TextBox_TextChanged1(object sender, TextChangedEventArgs e)
        {
            var text = ((TextBox)sender).Text;
            var tb = ((TextBox)sender).DataContext as Exams;
            if (tb == null)
                return;
            tb.Audience = text;
            App.db.SaveChanges();
        }

        private void TextBox_TextChanged2(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tb = (TextBox)sender;
                var exam = tb.DataContext as Exams;
                if (exam == null)
                    return;
                exam.ID_Discipline = int.Parse(tb.Text);
                App.db.SaveChanges();
            }
            catch
            {

            }
        }

        private void TextBox_TextChanged3(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tb = (TextBox)sender;
                var exam = tb.DataContext as Exams;
                if (exam == null)
                    return;
                exam.ID_Student = int.Parse(tb.Text);
                App.db.SaveChanges();
            }
            catch
            {

            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var tb = (DatePicker)sender;
            var exam = tb.DataContext as Exams;
            if (tb.SelectedDate == null || exam.Date == tb.SelectedDate)
                return;
            exam.Date = tb.SelectedDate;
            App.db.SaveChanges();
        }

        private void Button_Add(object sender, RoutedEventArgs e)
        {
            var examNew = new Exams() { Date = DateTime.Today };
            App.db.Exams.Add(examNew);
            App.db.SaveChanges();

            var userCode = App.user.Cipher;
            ExamsDG.DataContext = null;
            ExamsDG.DataContext = App.db.Exams.ToList();
            MessageBox.Show("Сдача добавлена");

        }

        private void Button_Remove(object sender, RoutedEventArgs e)
        {
            var current = ExamsDG.SelectedValue as Exams;
            if (current == null)
                return;

            App.db.Exams.Remove(current);
            App.db.SaveChanges();
            var userCode = App.user.Cipher;

            ExamsDG.DataContext = null;
            ExamsDG.DataContext = App.db.Exams.ToList();
            MessageBox.Show("Сдача удалена");
        }
    }
}

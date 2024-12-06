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
    /// Логика взаимодействия для ExamPage.xaml
    /// </summary>
    public partial class ExamPage : Page
    {
        public ExamPage()
        {
            InitializeComponent();
            DataContext = App.db.Exams.Where(i => i.ID_Educator == App.user.ID_Employee).ToList();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var tb = (TextBox)sender;
                var exam = tb.DataContext as Exams;
                exam.Appraisal = int.Parse(tb.Text);
                App.db.SaveChanges();
            }
            catch
            {

            }

        }
    }
}

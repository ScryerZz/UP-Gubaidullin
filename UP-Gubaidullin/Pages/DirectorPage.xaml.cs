﻿using System;
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
    /// Логика взаимодействия для DirectorPage.xaml
    /// </summary>
    public partial class DirectorPage : Page
    {
        public DirectorPage()
        {
            InitializeComponent();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                var user = int.Parse(CodeTB.Text);
                var exp = int.Parse(ExpTB.Text);
                App.db.DepartmentHeads.Add(new ModelDB.DepartmentHeads() { ID_DepartmentHead = user, Seniority = exp });
                App.db.SaveChanges();

                NavigationService.Navigate(new DirectorsPage());
            }
            catch
            {

            }
        }
    }
}

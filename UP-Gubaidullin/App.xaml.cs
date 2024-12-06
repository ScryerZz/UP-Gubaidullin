using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using UP_Gubaidullin.ModelDB;

namespace UP_Gubaidullin
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static UPEntities db = new UPEntities();
        public static Employees user;
    }
}

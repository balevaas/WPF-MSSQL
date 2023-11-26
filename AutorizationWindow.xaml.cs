using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AutorizationWindow.xaml
    /// </summary>
    public partial class AutorizationWindow : Window
    {
        readonly DataBase dataBase = new DataBase();
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        private void AutorizeBtn_Click(object sender, RoutedEventArgs e)
        {
            if(loginTB.Text != string.Empty && passwordTB.Text != string.Empty)
            {
                string login = loginTB.Text;
                string password = passwordTB.Text;
                string cmd = "select * from User where UserEmail = '" + login + "' and UserPassword = '" + password + "'";
                DataTable dt = dataBase.SqlSelect(cmd);
                if(dt.Rows.Count == 1)
                {

                } 
            }

        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly DataBase data = new DataBase();
        public MainWindow()
        {
            InitializeComponent();

            ProductsViewDataGrid();

            ProductsListView();
        }

        /// <summary>
        /// Метод для "простого" вывода данных в табличку
        /// </summary>
        private void ProductsViewDataGrid()
        {
            DataTable dt = data.SqlSelect("select * from Product"); // обращение к методу из класса
            DGProduct.ItemsSource = dt.DefaultView; // передаем их в дата грид
            data.CloseConnection(); // закрываем соединение
        }

        private void ProductsListView()
        {
            DataTable dt = data.SqlSelect("Select * from Product");
            LWProduct.ItemsSource = dt.DefaultView;
            data.CloseConnection();
        }

        private void AutorizeBtn_Click(object sender, RoutedEventArgs e)
        {
            AutorizationWindow autorize = new AutorizationWindow();
            autorize.Show();
        }
    }
}

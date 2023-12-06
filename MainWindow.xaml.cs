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
        // Объявили экземпляр класса DataBase, чтобы можно было обращаться к методам 
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
            DataTable dt = data.SqlSelect("select * from Product"); // обращение к методу из класса, можно написать как сразу необходимый запрос
            DGProduct.ItemsSource = dt.DefaultView; // передаем их в дата грид
            data.CloseConnection(); // закрываем соединение
        }

        private void ProductsListView()
        {
            string query = "select * from Product"; // так и сначала объявить переменную типа string 
            DataTable dt = data.SqlSelect(query); // и уже передать ее 
            LWProduct.ItemsSource = dt.DefaultView; // также передаем все в listview 
            data.CloseConnection();
        }

        private void AutorizeBtn_Click(object sender, RoutedEventArgs e)
        {
            // просто переход на другое окошко
            AutorizationWindow autorize = new AutorizationWindow();
            autorize.Show();
        }
    }
}

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
        // Также создаем экземпляр класса
        readonly DataBase dataBase = new DataBase();
        public AutorizationWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия на кнопку "Войти"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AutorizeBtn_Click(object sender, RoutedEventArgs e)
        {
            // передаем введенные в боксы значения в переменные
            string email = loginTB.Text;
            string password = passwordTB.Password;
            // проверка на заполненность боксов
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Вы не ввели почту или пароль", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            // иначе, начинаем сверять данные с таблицей user
            else
            {
                // здесь проверяем на совпадения с помощью запроса сравниваем введенные значения с теми, что храняться в бд и если нашлось хотя бы одно
                if (dataBase.SqlSelect("select * from [dbo].[User] where [UserLogin] = '" + email + "' and [UserPassword] = '" + password + "'").Rows.Count > 0)
                {
                    // то следом с помощью запроса получаем роль этого пользователя используя почту
                    DataTable dt = dataBase.SqlSelect("select [UserRole] from [dbo].[User] where [UserLogin] = '" + email + "'");
                    int role = Convert.ToInt32(dt.Rows[0][0]); // так как при работе такого запроса будет только ОДНО значение (ячейка),
                                                               // присваиваем ее в целочисленную переменную
                    // далее обычными условиями проверяем на роли
                    if (role == 1)
                    {
                        // тут messagebox можно будет заменить на переходы в другие окна или что нибудь другое
                        MessageBox.Show("Администратор", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (role == 2)
                    {
                        MessageBox.Show("Менеджер", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else if (role == 3)
                    {
                        MessageBox.Show("Клиент", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ошибка", "Successfully", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Данные введены неккоректно", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

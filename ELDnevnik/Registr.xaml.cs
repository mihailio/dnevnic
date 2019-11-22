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
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace ELDnevnik
{
    /// <summary>
    /// Логика взаимодействия для Registr.xaml
    /// </summary>
    public partial class Registr : Window
    {
        SqlConnection connect = new SqlConnection(@"Data Source=SERV-SQL-09\SQLEXPRESS;Initial Catalog=user6;Persist Security Info=True;User ID=user6;Password=wsruser6");
        public Registr()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand reg = new SqlCommand("insert into [Пользователь] values ('"+reg_login.Text  +"' ,'"+ reg_pass.Text +"' ,'"+ rol.Text +"' )", connect);

                if (reg_login.Text != " " && reg_login.Text != "" && reg_pass.Text != "" && reg_pass.Text != " ")
                {
                    reg.ExecuteNonQuery();
                }
                else
                {
                    MessageBox.Show("Введите корректные данные!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! \n " + ex.ToString());
                throw;
            }
            finally
            {
                connect.Close();
            }
        }
    }
}

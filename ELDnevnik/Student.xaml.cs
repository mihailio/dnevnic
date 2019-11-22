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
    /// Логика взаимодействия для Student.xaml
    /// </summary>
    public partial class Student : Window
    {
        SqlConnection connect = new SqlConnection(@"Data Source=SERV-SQL-09\SQLEXPRESS;Initial Catalog=user6;Persist Security Info=True;User ID=user6;Password=wsruser6");
        List<string[]> data = new List<string[]>();
        public Student()
        {
            InitializeComponent();
            lbllogin.Content = UserInfo.UserLogin.ToString();
            cb_mesiyc.Items.Add(new string[] { "Январь", "Февр", "Март", "Апрель", "Май", "Июнь", "Июль",
                                                "Август", "Сеньябрь", "Октябрь", "Ноябрь", "Декабрь", });
            try
            {
                connect.Open();
                SqlCommand comm_predmet = new SqlCommand("select [Предмет] from [Классы преподователей] where [ИД_Класс] = '" + UserInfo.UserClass.ToString() + "' ", connect);
                SqlDataReader read_predmet = comm_predmet.ExecuteReader();
                
                for (int i = 0; i < read_predmet.FieldCount; i++)
                {
                    read_predmet.Read();
                    cb_predmet.Items.Add(read_predmet[0]); //// добвыление предметов в комбобокс
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! \n" + ex.ToString());
                throw;
            }
            finally
            {
                connect.Close();
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Button_on_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select [Дата],[Оценка] from [Оценки] where [Ученик] = '"+ UserInfo.UserID.ToString() +"' and" +
                                                " [Препод_Предмет] = '"+UserInfo.UserClass +"'" , connect); //// ИСПРАВИТЬ ПРЕДМЕТЫ!!!
                connect.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    data.Add(new string[3]);
                    data[data.Count - 1][0] = read[0].ToString();
                    data[data.Count - 1][1] = read[1].ToString();
                    data[data.Count - 1][2] = read[2].ToString();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! \n" + ex.ToString());
                throw;
            }
            finally
            {
                connect.Close();
            }
        }
    }
}

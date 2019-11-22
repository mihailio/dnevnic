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
using System.Data.SqlClient;
namespace ELDnevnik
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection connect = new SqlConnection(@"Data Source=SERV-SQL-09\SQLEXPRESS;Initial Catalog=user6;Persist Security Info=True;User ID=user6;Password=wsruser6");
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string role= "no";
            try
            {
                connect.Open();
                SqlCommand auth = new SqlCommand("Select * from [Пользователь] where [Логин] = '"+ Login_tb.Text +"' and [Пароль] = '"+ pss.Password.ToString() +"'", connect);
                SqlDataReader read = auth.ExecuteReader();
            
                if (read.HasRows)
                {
                    read.Read();
                    role = read[2].ToString();

                    UserInfo.UserLogin = Login_tb.Text;
                    

                }
                else
                {
                    
                    MessageBox.Show("Неверный логин или пароль");
                   
                }

                switch (role)
                {
                    case "no":
                        break;
                    case "3":
                        SqlCommand iduser = new SqlCommand("select [ИД],[Класс] from [Ученик]  where [Логин] = '" + Login_tb.Text + "'", connect);
                        SqlDataReader stud = iduser.ExecuteReader();
                        UserInfo.UserID = stud[0].ToString();
                        UserInfo.UserClass = stud[1].ToString();
                        this.Hide();
                        Student student = new Student();
                        student.ShowDialog();
                        break;
                    case "2":
                        this.Hide();
                        Prepod prepod = new Prepod();
                        prepod.ShowDialog();
                        break;
                    case "1":
                        MessageBox.Show("АДМИН");
                        break;
                    default:
                        MessageBox.Show("Ошибка!");
                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка! \n " + ex.ToString());
            }
            finally
            {
                connect.Close();
            }
        }
    }
}

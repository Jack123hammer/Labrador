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

namespace Labrador
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        Entities db = new Entities();
        public int level_out;
        public Window1()
        {
            InitializeComponent();

        }

        private void btn_enter_Click(object sender, RoutedEventArgs e)
        {
            Employee emp = db.Employee.SingleOrDefault(t => t.Login == tb_login.Text && t.Password == pb_password.Password);
            if (emp ==null)
            {
                MessageBox.Show("Debil");
            }
            else
            {
                level_out = emp.Access_Level;
                MainWindow  m = new MainWindow(level_out);
                m.Show();
                Close();
            }
        }
    }
}

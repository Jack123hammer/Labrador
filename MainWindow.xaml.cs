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

namespace Labrador
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Entities db = new Entities();
        public int level;
        public MainWindow(int level_out)
        {
            InitializeComponent();
            level = level_out;
            Access();
            Update();
        }

        public void Access()
        {
            if (level==1)
            {
                btn_delete_author.Visibility = Visibility.Collapsed;

            }
        }
        public void Update()
        {
            
            dg_author.ItemsSource = db.Author.ToList();
            dg_books.ItemsSource = db.Book.ToList();
            cb_authors.ItemsSource= db.Author.ToList();
        }

        public void Search_Author()
        {
           
            dg_author.ItemsSource = db.Author.Where(t => t.Last_Name.Contains(tb_last_name_author.Text) && t.First_Name.Contains(tb_first_name_author.Text) && t.Second_Name.Contains(tb_second_name_author.Text)).ToList();
        }

        public void Search_Book()
        {
            dg_books.ItemsSource = db.Book.Where(t => t.Book_Name.Contains(tb_book_name.Text) && t.Author.Last_Name.Contains(tb_book_last_name.Text) && t.Author.First_Name.Contains(tb_book_first_name.Text)).ToList();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void tb_last_name_author_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search_Author();
        }

        private void tb_first_name_author_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search_Author();
        }

        private void tb_second_name_author_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search_Author();
        }

        private void dg_author_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Author f = dg_author.SelectedItem as Author;
            if (f==null)
                return;
            tb_last_name_edit_author.Text = f.Last_Name;
            tb_first_name_edit_author.Text = f.First_Name;
            tb_second_name_edit_author.Text = f.Second_Name;
        }

        private void btn_add_author_Click(object sender, RoutedEventArgs e)
        {
            Author f = new Author
            {
                Last_Name = tb_last_name_edit_author.Text,
                First_Name = tb_first_name_edit_author.Text,
                Second_Name = tb_second_name_edit_author.Text,
                Last_Changes_By = 1
            };
            db.Author.Add(f);
            db.SaveChanges();
            Update();

        }

        private void btn_edit_author_Click(object sender, RoutedEventArgs e)
        {
            Author f = dg_author.SelectedItem as Author;
            if (f == null)
                return;
            f.Last_Name = tb_last_name_edit_author.Text;
            f.First_Name = tb_first_name_edit_author.Text;
            f.Second_Name = tb_second_name_edit_author.Text;
            db.SaveChanges();
            Update();
        }

        private void btn_delete_author_Click(object sender, RoutedEventArgs e)
        {
            Author f = dg_author.SelectedItem as Author;
            if (f == null)
                return;
            db.Author.Remove(f);
            db.SaveChanges();
            Update();
        }

        private void Change_acc_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1();
            w.Show();
            Close();
        }

        private void tb_book_name1_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search_Book();  
        }

        private void tb_book_last_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search_Book();
        }

        private void tb_book_first_name_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search_Book();
        }

        private void dg_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book f = dg_author.SelectedItem as Book;
            if (f == null)
                return;
            tb_book_name_edit.Text = f.Book_Name;
            dp_date_book.DisplayDate = f.Release_Date;
            tb_book_price_edit.Text = Convert.ToString(f.Price) ;
            
        }
    }
}

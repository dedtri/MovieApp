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
using MovieApp.Codes;
using System.Data.SqlClient;

namespace MovieApp
{
    /// <summary>
    /// Interaction logic for EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        public EditWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {       
            using SqlConnection con = new SqlConnection(ADOHandler.ConnectionString);
            con.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = "UPDATE Movies SET Title = @p1, Director = @p2, ReleaseYear = @p3 Where ID = @id";
            command.Parameters.AddWithValue("@id", ID.Text);
            command.Parameters.AddWithValue("@p1", title.Text);
            command.Parameters.AddWithValue("@p2", director.Text);
            command.Parameters.AddWithValue("@p3", releaseyear.Text);
            command.Connection = con;
            if (director.Text.Length == 0 || releaseyear.Text.Length == 0 || title.Text.Length == 0)
            {
                MessageBox.Show("Theres an empty field.");
            }
            else if (director.Text.Length <= 10 && releaseyear.Text.Length <= 4 && releaseyear.Text.Length >= 4 && title.Text.Length <= 13)
            {
                try
                {
                    int a = command.ExecuteNonQuery();
                    if (a == 1)
                    {
                        MessageBox.Show("Success!");
                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Invalid input.");
                }
            }
            else
            {
                MessageBox.Show("Invalid input.");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            List<Movies> movies = ADOHandler.GetMovies();
            List<Movies> temp = new();


            try
            { 
            foreach (var c in movies)
            {
                if (c.ID == Convert.ToInt32(ID.Text))
                {
                    temp.Add(c);
                }
            }
            }
            catch
            {
            }


            if (temp.Count == 1)
            { 
                    movietitle.Visibility = Visibility.Visible;
                foreach (var c in temp)
                {
                    movietitle.Content = c.Title;
                }
                    formgrid.Visibility = Visibility.Visible;
                    submit.Visibility = Visibility.Hidden;
                    confirm.Visibility = Visibility.Visible;
                    movieid.Visibility = Visibility.Hidden;
                    ID.Visibility = Visibility.Hidden;
            }
            else
                {
                    MessageBox.Show("Movie ID was not found / Invalid ID");
                }
            
        }

        private void ID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            { 
            Button_Click(sender, e);
            }
        }

        private void ID_KeyDown2(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click_2(sender, e);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Movies> movies = ADOHandler.GetMovies();
            List<Movies> temp = new();


            try
            {
                foreach (var c in movies)
                {
                    if (c.ID == Convert.ToInt32(ID.Text))
                    {
                        temp.Add(c);
                    }
                }
            }
            catch
            {
            }


            if (temp.Count == 1)
            {
                movietitle.Visibility = Visibility.Visible;
                foreach (var c in temp)
                {
                    movietitle.Content = c.Title;
                }
                formgrid.Visibility = Visibility.Visible;
                submit.Visibility = Visibility.Hidden;
                confirm.Visibility = Visibility.Visible;
                movieid.Visibility = Visibility.Hidden;
                ID.Visibility = Visibility.Hidden;
            }
        }
    }
}

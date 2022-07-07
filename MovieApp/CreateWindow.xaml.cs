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
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        public CreateWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ADOHandler adoHandler = new ADOHandler();

            using SqlConnection con = new SqlConnection(ADOHandler.ConnectionString);
            con.Open();

            SqlCommand command = new SqlCommand();
            command.CommandText = $"Insert into [Movies](Title, Director, ReleaseYear)values('{title.Text}','{director.Text}','{releaseyear.Text}')";
            //command.CommandText = "Insert into [Movies](Title, Director, ReleaseYear)values(@p1,@p2,@p3)";
            //command.Parameters.AddWithValue("@p1", title.Text);
            //command.Parameters.AddWithValue("@p2", director.Text);
            //command.Parameters.AddWithValue("@p3", releaseyear.Text);
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

        private void releaseyear_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Button_Click_1(sender, e);
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}

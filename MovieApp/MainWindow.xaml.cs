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
using MovieApp.Codes;
using System.Data.SqlClient;
using System.Data;

namespace MovieApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            GetMovies();
        }


private void window_Activated(object sender, EventArgs e)
        {
            GetMovies();
        }
    

    public void GetMovies()
        {
            SqlConnection con = new SqlConnection(ADOHandler.ConnectionString);
            con.Open();

            SqlCommand command = new SqlCommand
                          (
                          "SELECT " +
                          "* " +
                          "FROM Movies"
                          );

            command.Connection = con;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable("Movies");
            da.Fill(dt);

            dataGrid1.ItemsSource = dt.DefaultView;
            con.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow win2 = new CreateWindow();
            win2.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DeleteWindow win = new DeleteWindow();
            win.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationWindow window = new NavigationWindow();

            Uri source = new Uri("http://www.google.com", UriKind.Absolute);

            window.Source = source; window.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EditWindow win = new EditWindow();
            win.Show();
        }
    }
}

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
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
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
            try
            {
                int test = Convert.ToInt32(ID.Text);
                SqlCommand command = new SqlCommand("DELETE FROM Movies WHERE ID = " + test, con);
                int a = command.ExecuteNonQuery();
                if (a == 1)
                {
                    //MessageBox.Show("Success!");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Wrong ID or Input");
            }
               
        }

        private void ID_KeyDown(object sender, KeyEventArgs e)
        {  
            if (e.Key == Key.Return)
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

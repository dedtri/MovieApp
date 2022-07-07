using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MovieApp.Codes
{
    internal class ADOHandler
    {
        public static string? ConnectionString
        {
            get => "Data Source=192.168.192.130;Initial Catalog=MovieDatabase;User ID=admin;Password=Admin1;Connect Timeout=30;Encrypt=False;" +
                "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public static List<Movies> GetMovies()
        {

            List<Movies> movies = new List<Movies>();

            using SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            SqlCommand command = new SqlCommand
                          (
                          "SELECT " +
                          "* " +
                          "FROM Movies", con
                          );

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Movies movie = new Movies() { ID = reader.GetInt32(0), Title = reader.GetString(1), Director = reader.GetString(2), ReleaseYear = reader.GetInt32(3) };
                movies.Add(movie);
            }

            return movies;

            //con.Close(); - Kun hvis man ikke har using       
        }

    }
}

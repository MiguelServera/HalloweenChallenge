using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsProject
{
    public partial class Details : Form
    {
        private string connectionString = "Server=localhost;Database=sakila;Uid=client;Pwd='$3cr3t3t';";
        public Details(Films selectedFilm)
        {
            InitializeComponent();
            List<Films> film = new List<Films>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            string sql = $"SELECT DESCRIPTION FROM FILM" +
                $" WHERE TITLE LIKE '%{selectedFilm.title}%'";
            film = connection.Query<Films>(sql).ToList();
            Films films = film.FirstOrDefault();
            listBoxDescription.DataSource = film;
            listBoxDescription.Text = films.FullDesc;
        }
    }
}

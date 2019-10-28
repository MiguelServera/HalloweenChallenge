using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using MySql.Data.MySqlClient;

namespace WindowsFormsProject
{
    public partial class Sakila : Form
    {
        private string connectionString = "Server=localhost;Database=sakila;Uid=client;Pwd='$3cr3t3t';";
        public Sakila()
        {
            InitializeComponent();
        }
        private void button_FindFilms_Click(object sender, EventArgs e)
        {
            string sql;
            List<Films> film = new List<Films>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            if (checkBoxMatch.Checked)
            {
                sql = $"SELECT TITLE FROM FILM" +
                 $" WHERE TITLE LIKE '{textBoxSearch.Text}'";
                film = connection.Query<Films>(sql).ToList();
                listBoxFilms.DataSource = film;
                listBoxFilms.DisplayMember = "FullInfo";
            }
            else
            {
                sql = $"SELECT TITLE FROM FILM" +
                    $" WHERE TITLE LIKE '%{textBoxSearch.Text}%'";
                film = connection.Query<Films>(sql).ToList();
                listBoxFilms.DataSource = film;
                listBoxFilms.DisplayMember = "FullInfo";
            }

            connection.Close();
        }

        private void listBoxFilms_DoubleClick(object sender, MouseEventArgs e)
        {
            Films selectedFilm = listBoxFilms.SelectedItem as Films;
            Details filmDetailsForm = new Details(selectedFilm);
            filmDetailsForm.ShowDialog(this);
        }
    }
}

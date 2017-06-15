using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Specialized;
using MySql.Data;
using System.Configuration;


namespace FaceIT
{
    public partial class Add : Form
    {
        public Add()
        {
            InitializeComponent();
        }

        private void Add_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();


            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Application.Exit();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Initialize connection / command
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;

            conn = new MySql.Data.MySqlClient.MySqlConnection();
            cmd = new MySql.Data.MySqlClient.MySqlCommand();

            // Set connection / query
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=project_innovate;";
            string myquerystring = "INSERT INTO klas (KlasNaam, Periode, AantalLeerlingen, AantalLessen) VALUES(@KlasNaam, @Periode, @AantalLeerlingen, @AantalLessen)";

            // Check the connection and the query
            try
            {
                // Open the connection and execute command (query)
                conn.Open();
                cmd.Connection = conn;

                cmd.Parameters.AddWithValue("@KlasNaam", ClassName.Text);
                cmd.Parameters.AddWithValue("@Periode", numericUpDown3.Text);
                cmd.Parameters.AddWithValue("@AantalLeerlingen", numericUpDown1.Text);
                cmd.Parameters.AddWithValue("@AantalLessen", numericUpDown2.Text);


                cmd.CommandText = myquerystring;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Class successfully added!",
                "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                // Close connection
                conn.Close();
                //Refreshing the page
                new Add().Show();
                this.Hide();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                // Show error
                MessageBox.Show(ex.Message);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Home().Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Close();
            new Home().Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            new Home().Show();
        }

        private void ClassName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

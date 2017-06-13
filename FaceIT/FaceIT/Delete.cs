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
using MySql.Data.MySqlClient;
using System.Configuration;


namespace FaceIT
{
    public partial class Delete : Form
    {
        public Delete()
        {
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);

            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=project_innovate;"))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM klas", con))
            {
                DataTable klasTable = new DataTable();
                adapter.Fill(klasTable);
                listBox1.DisplayMember = "KlasNaam";
                listBox1.DataSource = klasTable;
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Home().Show();
        }

        private void Delete_Button_Click(object sender, EventArgs e)
        {
            string text = listBox1.SelectedItem.ToString();
            //MessageBox.Show(text); 
            DataRowView drv = (DataRowView)listBox1.SelectedItem;
            String valueOfItem = drv["KlasNaam"].ToString();
            //MessageBox.Show(valueOfItem);

            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;

            conn = new MySql.Data.MySqlClient.MySqlConnection();
            cmd = new MySql.Data.MySqlClient.MySqlCommand();

            // Set connection / query
            conn.ConnectionString = "server=localhost;uid=root;pwd=;database=project_innovate;";
            string myquerystring = "DELETE FROM klas WHERE KlasNaam=@KlasNaam";

            // Check the connection and the query
            try
            {
                // Open the connection and execute command (query)
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = myquerystring;
                cmd.Parameters.AddWithValue("@KlasNaam", valueOfItem);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Class is deleted successfully!",
                "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                // Close connection                
                conn.Close();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                // Show error
                MessageBox.Show(ex.Message);
            }
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
    }
}

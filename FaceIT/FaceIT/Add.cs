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
			if (string.IsNullOrWhiteSpace (ClassName.Text) || string.IsNullOrWhiteSpace (numericUpDown3.Text) || string.IsNullOrWhiteSpace (numericUpDown1.Text)) {
				MessageBox.Show ("Fields can't be empty.");
			} else if (Convert.ToInt32 (numericUpDown3.Text) > 4 || Convert.ToInt32 (numericUpDown3.Text) < 1) {
				MessageBox.Show ("Period must be between 1 and 4.");
			} else if (Convert.ToInt32 (numericUpDown1.Text) < 1) {
				MessageBox.Show ("There must be atleast 1 student.");
			} else {
				// Initialize connection / command
				MySql.Data.MySqlClient.MySqlConnection conn;
				MySql.Data.MySqlClient.MySqlCommand cmd;

				conn = new MySql.Data.MySqlClient.MySqlConnection();
				cmd = new MySql.Data.MySqlClient.MySqlCommand();

				// Set connection / query
				conn.ConnectionString = "server=localhost;uid=root;pwd=12345;database=FaceIT;";
				//conn.ConnectionString = "server=localhost;uid=root;pwd=;database=FaceIT;";
				string myquerystring = "INSERT INTO klas (KlasNaam, Periode, AantalLeerlingen, AantalLessen) VALUES(@KlasNaam, @Periode, @AantalLeerlingen, 0)";

				// Check the connection and the query
				try
				{
					// Open the connection and execute command (query)
					conn.Open();
					cmd.Connection = conn;

                    string Class = ClassName.Text.Replace(" ", "_");
					cmd.Parameters.AddWithValue("@KlasNaam", Class);
					cmd.Parameters.AddWithValue("@Periode", numericUpDown3.Text);
					cmd.Parameters.AddWithValue("@AantalLeerlingen", numericUpDown1.Text);


					cmd.CommandText = myquerystring;
					cmd.ExecuteNonQuery();
					String path = System.Reflection.Assembly.GetEntryAssembly().Location;
					Console.WriteLine(path);
					if (path.Contains("/"))
					{
						if (path.EndsWith("Debug/FaceIT.exe"))
						{
							path = path.Replace("FaceIT/FaceIT/bin/Debug/FaceIT.exe", "FaceRec/Processed/");
						}
						else if (path.EndsWith("Release/FaceIT.exe"))
						{
							path = path.Replace("FaceIT/FaceIT/bin/Release/FaceIT.exe", "FaceRec/Processed/");
						}
						System.IO.Directory.CreateDirectory(path + "/" + Class + "-" + numericUpDown3.Text);
					}
					else
					{
						if (path.EndsWith("Debug\\FaceIT.exe"))
						{
							path = path.Replace("FaceIT\\FaceIT\\bin\\Debug\\FaceIT.exe", "FaceRec\\Processed\\");
						}
						else if (path.EndsWith("Release\\FaceIT.exe"))
						{
							path = path.Replace("FaceIT\\FaceIT\\bin\\Release\\FaceIT.exe", "FaceRec\\Processed'\\");
						}
						System.IO.Directory.CreateDirectory(path + "\\" + Class + "-" + numericUpDown3.Text);
					}

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
					if (ex.Number == 1062) {
						MessageBox.Show ("Class already exist.");
					} else 
					{
						MessageBox.Show(ex.Message);
					}
				}
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {

        }
    }
}

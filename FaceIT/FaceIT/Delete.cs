using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace FaceIT
{
    public partial class Delete : Form
    {
        private object KlasNaam;
        private object Periode;

        public Delete()
        {
            InitializeComponent();
        }

        //Setting the escape key to exit the application when needed
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                Application.Exit();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void Delete_Load(object sender, EventArgs e)
        {

            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=project_innovate;"))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT KlasNaam,Periode FROM klas", con))
            {
                

                DataTable klasTable = new DataTable();
                adapter.Fill(klasTable);

                // Putting the KlasNaam and periode in a string to display in the listBox
                foreach (DataRow row in klasTable.Rows)
                    listBox1.Items.Add(string.Format("{0}  -  Periode {1}", row[0], row[1]));
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Home().Show();
        }

        private void Delete_Button_Click_1(object sender, EventArgs e)
        {
            // Splitting the string to get the KlasNaam
            Text = listBox1.SelectedItem.ToString();
            string[] lines = Text.Split(new[] { "  -  Periode " }, StringSplitOptions.None);
            int count = 0;
            foreach (string line in lines)
            {
                if(count == 0)
                {
                    KlasNaam = line;
                }
                if (count == 1)
                {                   
                    int x = Int32.Parse(line);
                    Periode = x;
                }
                count++;
            }

             MySqlConnection conn;
             MySqlCommand cmd;

             conn = new MySqlConnection();
             cmd = new MySqlCommand();

             // Setting connectionstring and delete query
             conn.ConnectionString = "server=127.0.0.1;uid=root;pwd=;database=project_innovate;";
             string myquerystring = "DELETE FROM klas WHERE KlasNaam=@KlasNaam AND Periode=@Periode;";

             // Check the connection and the query
             try
             {
                 // Open the connection and execute command (query)
                 conn.Open();
                 cmd.Connection = conn;
                 cmd.CommandText = myquerystring;
                 cmd.Parameters.AddWithValue("@KlasNaam", KlasNaam);
                 cmd.Parameters.AddWithValue("@Periode", Periode);
                 cmd.ExecuteNonQuery();
                 MessageBox.Show("Class is successfully deleted!",
                 "Succes!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                 // Close connection                
                 conn.Close();

                 //Refreshing the page 
                 new Delete().Show();
                 this.Hide();

             }
             catch (MySql.Data.MySqlClient.MySqlException ex)
             {
                 // Show error
                 MessageBox.Show(ex.Message);
             }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            new Home().Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            new Home().Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

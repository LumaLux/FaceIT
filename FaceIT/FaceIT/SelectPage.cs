using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace FaceIT
{
    public partial class SelectPage : Form
    {
        public static string SelectedItem;

        public SelectPage()
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

        private void button5_Click(object sender, EventArgs e)
        {
            new Home().Show();
            this.Close();
        }

        private void Select_Load(object sender, EventArgs e)
        {

            //Setting the connection info and setting the query to pull data from the database
            using (MySqlConnection con = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=FaceIT;"))
            //using (MySqlConnection con = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=FaceIT;"))
            using (MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT KlasNaam,Periode FROM klas", con))
            {
                
                DataTable klasTable = new DataTable();
                adapter.Fill(klasTable);

                //Putting the KlasNaam and Periode in one row
                foreach (DataRow row in klasTable.Rows)
                    listBox1.Items.Add(string.Format("{0}  -  Periode {1}", row[0], row[1]));
            }
        }

        private void Select_Button_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select a class");
            }
            else
            {
                SelectedItem = listBox1.SelectedItem.ToString();
                new Presence().Show();
                this.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Text = listBox1.SelectedItem.ToString();
			string[] lines = Text.Split(new[] { "  -  Periode " }, StringSplitOptions.None);
            int count = 0;
            string klas = "";
            int periode = 0;
			foreach (string line in lines)
			{
				if (count == 0)
				{
					klas = line;
				}
				if (count == 1)
				{
					periode = Int32.Parse(line);
				}
                count++;
			}
			Process proc = new System.Diagnostics.Process();
			String path = System.Reflection.Assembly.GetEntryAssembly().Location;
			if(path.EndsWith("Debug/FaceIT.exe")){
				path = path.Replace("FaceIT/FaceIT/bin/Debug/FaceIT.exe", "FaceRec/");
			}else if(path.EndsWith("Release/FaceIT.exe")){
				path = path.Replace("FaceIT/FaceIT/bin/Release/FaceIT.exe", "FaceRec/");
			}
			Console.WriteLine(path);
			proc.StartInfo.FileName = "/bin/bash";
			proc.StartInfo.Arguments = "-c \" " + "gnome-terminal -x bash -ic 'cd " + path + "; python3 main.py " + klas + " " + periode + "' \"";
			proc.StartInfo.UseShellExecute = false;
			proc.StartInfo.RedirectStandardOutput = true;
			proc.Start();

			while (!proc.StandardOutput.EndOfStream)
			{
				Console.WriteLine(proc.StandardOutput.ReadLine());
			}
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new Home().Show();
        }

    }
}

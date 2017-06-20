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
using System.IO;

namespace FaceIT
{
    public partial class Presence : Form
    {
        private int Periode;
        private string KlasNaam;
        private int CountLessons;
        private int count2;
        private string path2;


        public Presence()
        {
            InitializeComponent();
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

        private void Presence_Load(object sender, EventArgs e)
        {

            
            Text = SelectPage.SelectedItem;
            

            string[] lines = Text.Split(new[] { "  -  Periode " }, StringSplitOptions.None);
            int count = 0;
            foreach (string line in lines)
            {
                if (count == 0)
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
            //MessageBox.Show(KlasNaam);

            String path = System.Reflection.Assembly.GetEntryAssembly().Location;
            if (path.Contains("/"))
            {
                count2++;
                if (path.EndsWith("Debug/FaceIT.exe"))
                {
                    path = path.Replace("FaceIT/FaceIT/bin/Debug/FaceIT.exe", "FaceRec/Processed/" + KlasNaam);
                }
                else if (path.EndsWith("Release/FaceIT.exe"))
                {
                    path = path.Replace("FaceIT/FaceIT/bin/Release/FaceIT.exe", "FaceRec/Processed/" + KlasNaam);
                }
            }
            else
            {
                if (path.EndsWith("Debug\\FaceIT.exe"))
                {
                    path = path.Replace("FaceIT\\FaceIT\\bin\\Debug\\FaceIT.exe", "FaceRec\\Processed\\" + KlasNaam);
                }
                else if (path.EndsWith("Release\\FaceIT.exe"))
                {
                    path = path.Replace("FaceIT\\FaceIT\\bin\\Release\\FaceIT.exe", "FaceRec\\Processed'\\" + KlasNaam);
                }
            }
            int fCount = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly).Length;
                
                

            listView1.View = View.Details;
            MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=FaceIT;");
           // MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=FaceIT;");
            string cmd =String.Format("SELECT * FROM leerling WHERE Klas_KlasNaam = '{0}';", KlasNaam);
            string cmd2 = String.Format("SELECT * FROM klas WHERE KlasNaam = '{0}';", KlasNaam);
            //MessageBox.Show(cmd);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection);
            MySqlDataAdapter adapter2 = new MySqlDataAdapter(cmd2, connection);
            DataTable dt2 = new DataTable();
            adapter2.Fill(dt2);

            foreach (DataRow row in dt2.Rows)
            {
                label2.Text = String.Format("Total students: {0} of the {1}", fCount, row[2]);
                CountLessons = Convert.ToInt32(row[3]);
            }


            // Where class is sleceted class (Placeholder INF1E),AND ID MATCHES PHOTO ID to get the right class
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            int count3 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];

                if(count2 == 1)
                {
                    path2 = path + "/" + dr["ID"];
                }
                else
                {
                    path2 = path + "\\" + dr["ID"];
                }

                Array NameImage = Directory.GetFiles(path2);
                foreach (string img in NameImage)
                {
                    MessageBox.Show(img);
                }
                int AanwezigProc = (int)Math.Round((double)Convert.ToInt32(dr["Aanwezig"]) / (double)CountLessons * 100);
                ListViewItem listitem = new ListViewItem(dr["Klas_KlasNaam"].ToString());
                listitem.SubItems.Add(dr["Aanwezig"].ToString());
                listitem.SubItems.Add(AanwezigProc.ToString() + "%");
                listView1.Items.Add(listitem);


                count3++;
            }

            label1.Text = String.Format("Class: {0}  -  Periode: {1}", KlasNaam, Periode);

            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            new SelectPage().Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            new SelectPage().Show();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

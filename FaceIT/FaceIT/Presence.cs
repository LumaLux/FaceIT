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

namespace FaceIT
{
    public partial class Presence : Form
    {
        private int Periode;
        private string KlasNaam;

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

            label1.Text = String.Format("Class: {0}  -  Periode: {1}", KlasNaam, Periode);

            listView1.View = View.Details;
            //MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=project_innovate;");
            MySqlConnection connection = new MySqlConnection("server=localhost;uid=root;pwd=12345;database=FaceIT;");
            string cmd =String.Format("SELECT * FROM leerling WHERE Klas_KlasNaam = '{0}';", KlasNaam);
            //MessageBox.Show(cmd);
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd, connection);


            // Where class is sleceted class (Placeholder INF1E),AND ID MATCHES PHOTO ID to get the right class
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                ListViewItem listitem = new ListViewItem(dr["ID"].ToString());
                listitem.SubItems.Add(dr["Aanwezig"].ToString());
                listitem.SubItems.Add(dr["Klas_KlasNaam"].ToString());
                listView1.Items.Add(listitem);
            }
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
    }
}

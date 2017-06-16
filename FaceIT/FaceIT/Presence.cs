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
        public Presence()
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

        private void Presence_Load(object sender, EventArgs e)
        {
                listView1.View = View.Details;
                MySqlConnection connection = new MySqlConnection("server=127.0.0.1;uid=root;pwd=;database=project_innovate;");
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM leerling", connection); // Where class is sleceted class lol AND ID MATCHES PHOTO ID LOL
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
            new Select().Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

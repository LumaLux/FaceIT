using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceIT
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {

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
            this.Hide();
            new Add().Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {          
            new Delete().Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            new About().Show();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            new Exit().Show();
        }

        private void SelectButton_Click_1(object sender, EventArgs e)
        {
            new SelectPage().Show();
            this.Hide();
        }
    }
}

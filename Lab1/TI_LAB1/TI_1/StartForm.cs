using System;
using System.Windows.Forms;

namespace TI_1
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void btnColumnar_Click(object sender, EventArgs e)
        {
            MainForm form1 = new MainForm(CipherType.Columnar);
            form1.Show();
            this.Hide();
            form1.FormClosed += (s, args) => this.Show();
        }

        private void btnVigenere_Click(object sender, EventArgs e)
        {
            MainForm form1 = new MainForm(CipherType.Vigenere);
            form1.Show();
            this.Hide();
            form1.FormClosed += (s, args) => this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }

    public enum CipherType
    {
        Columnar,
        Vigenere
    }
}
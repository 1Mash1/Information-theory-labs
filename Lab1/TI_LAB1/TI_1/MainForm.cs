using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TI_1
{
    public partial class MainForm : Form
    {

        private CipherType currentCipherType;

        public MainForm()
        {
            InitializeComponent();
            currentCipherType = CipherType.Columnar;
            SetFormName();
            dataGridViewTable.Visible = false;
        }

        public MainForm(CipherType cipherType)
        {
            InitializeComponent();
            currentCipherType = cipherType;
            SetFormName();
            dataGridViewTable.Visible = false;
        }

        private void SetFormName()
        {
            if (currentCipherType == CipherType.Columnar)
                Text = "Столбцовый метод (улучшенный)";
            else
                Text = "Метод Виженера";
        }

        void CalculateButton_Click(object sender, EventArgs e)
        {
            string key, plainText, cipher, decipher;
            dataGridViewTable.Rows.Clear();
            dataGridViewTable.Columns.Clear();
            dataGridViewTable.Visible = false;
            if (currentCipherType == CipherType.Columnar)
            {
                key = KeyTextBox.Text;
                if (key == "")
                {
                    MessageBox.Show("Проверьте ваш ключ, чтобы он содержал английские буквы", "Неправильный ключ");
                    return;
                }
                plainText = ImprovedColumnarCipher.GetPlainText(PlainTextBox.Text);
                if (EncipherRadioButton.Checked)
                {
                    cipher = ImprovedColumnarCipher.Encipher(plainText, key, dataGridViewTable);
                    ResultTextBox.Text = cipher;
                }
                else if (DecypherRadioButton.Checked)
                {
                    decipher = ImprovedColumnarCipher.Decipher(plainText, key, dataGridViewTable);
                    ResultTextBox.Text = decipher;
                }
            }
            if (currentCipherType == CipherType.Vigenere)
            {
                key = Vigener.GetPlainTextOrKey(KeyTextBox.Text);
                if (key is "")
                {
                    MessageBox.Show("Проверьте ваш ключ, чтобы он содержал русские буквы", "Неправильный ключ");
                    return;
                }
                Func<string, string, string> processFunction =
                    EncipherRadioButton.Checked ? Vigener.Encipher : Vigener.Decipher;
                var result = processFunction(PlainTextBox.Text, key);
                if (result == "")
                {
                    MessageBox.Show("Проверьте ваш вводимый текст, чтобы он содержал русские буквы", "Неправильный ключ");
                    return;
                }
                ResultTextBox.Text = result;
                Vigener.ShowVigenereTable(dataGridViewTable);

            }
        }

        void PlainTextBox_TextChanged(object sender, EventArgs e)
        {
            ResultTextBox.Clear();
            dataGridViewTable.Rows.Clear();
            dataGridViewTable.Columns.Clear();
            dataGridViewTable.Visible = false;
        }

        void SaveFileMenu_Click(object sender, EventArgs e)
        {
            if (ResultTextBox.Text.Length is 0)
            {
                MessageBox.Show("Нет результатов для сохранения", "Внимание");
                return;
            }
            var dialogResult = SaveFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                using StreamWriter sw = new StreamWriter(SaveFileDialog.FileName);
                sw.WriteLine(ResultTextBox.Text);
            }
        }

        void OpenFileMenu_Click(object sender, EventArgs e)
        {
            var dialogResult = OpenFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                using StreamReader sw = new StreamReader(OpenFileDialog.FileName);
                StringBuilder sb = new StringBuilder();
                var str = sw.ReadToEnd().Where(x => x != '\n');
                foreach (var item in str)
                {
                    sb.Append(item);
                }
                PlainTextBox.Text = sb.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PlainTextBox.Clear();
            KeyTextBox.Clear();
            ResultTextBox.Clear();
            dataGridViewTable.Rows.Clear();
            dataGridViewTable.Columns.Clear();
            dataGridViewTable.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            HelpForm helpForm = new HelpForm(currentCipherType);
            helpForm.ShowDialog();
        }

        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {
            ResultTextBox.Clear();
            dataGridViewTable.Rows.Clear();
            dataGridViewTable.Columns.Clear();
            dataGridViewTable.Visible = false;
        }
    }
}

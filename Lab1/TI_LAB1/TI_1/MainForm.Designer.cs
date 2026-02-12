namespace TI_1
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.PlainTextLabel = new System.Windows.Forms.Label();
            this.PlainTextBox = new System.Windows.Forms.TextBox();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.KeyLabel = new System.Windows.Forms.Label();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DecypherRadioButton = new System.Windows.Forms.RadioButton();
            this.EncipherRadioButton = new System.Windows.Forms.RadioButton();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.dataGridViewTable = new System.Windows.Forms.DataGridView();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.MainMenu.Size = new System.Drawing.Size(982, 30);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveFileMenu,
            this.OpenFileMenu});
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            this.ToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.ToolStripMenuItem.Text = "Файл";
            // 
            // SaveFileMenu
            // 
            this.SaveFileMenu.Name = "SaveFileMenu";
            this.SaveFileMenu.Size = new System.Drawing.Size(217, 26);
            this.SaveFileMenu.Text = "Сохранить в файл";
            this.SaveFileMenu.Click += new System.EventHandler(this.SaveFileMenu_Click);
            // 
            // OpenFileMenu
            // 
            this.OpenFileMenu.Name = "OpenFileMenu";
            this.OpenFileMenu.Size = new System.Drawing.Size(217, 26);
            this.OpenFileMenu.Text = "Открыть файл";
            this.OpenFileMenu.Click += new System.EventHandler(this.OpenFileMenu_Click);
            // 
            // PlainTextLabel
            // 
            this.PlainTextLabel.Location = new System.Drawing.Point(461, 49);
            this.PlainTextLabel.Name = "PlainTextLabel";
            this.PlainTextLabel.Size = new System.Drawing.Size(236, 26);
            this.PlainTextLabel.TabIndex = 7;
            this.PlainTextLabel.Text = "Исходный текст:";
            // 
            // PlainTextBox
            // 
            this.PlainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlainTextBox.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PlainTextBox.Location = new System.Drawing.Point(461, 78);
            this.PlainTextBox.Multiline = true;
            this.PlainTextBox.Name = "PlainTextBox";
            this.PlainTextBox.Size = new System.Drawing.Size(499, 94);
            this.PlainTextBox.TabIndex = 1;
            this.PlainTextBox.TextChanged += new System.EventHandler(this.PlainTextBox_TextChanged);
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.KeyTextBox.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.KeyTextBox.Location = new System.Drawing.Point(461, 233);
            this.KeyTextBox.Multiline = true;
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(499, 94);
            this.KeyTextBox.TabIndex = 2;
            this.KeyTextBox.TextChanged += new System.EventHandler(this.KeyTextBox_TextChanged);
            // 
            // KeyLabel
            // 
            this.KeyLabel.Location = new System.Drawing.Point(461, 204);
            this.KeyLabel.Name = "KeyLabel";
            this.KeyLabel.Size = new System.Drawing.Size(236, 26);
            this.KeyLabel.TabIndex = 9;
            this.KeyLabel.Text = "Ключ:";
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultTextBox.Location = new System.Drawing.Point(12, 400);
            this.ResultTextBox.Multiline = true;
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(443, 268);
            this.ResultTextBox.TabIndex = 12;
            this.ResultTextBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "Результат:";
            // 
            // DecypherRadioButton
            // 
            this.DecypherRadioButton.Location = new System.Drawing.Point(528, 417);
            this.DecypherRadioButton.Name = "DecypherRadioButton";
            this.DecypherRadioButton.Size = new System.Drawing.Size(259, 62);
            this.DecypherRadioButton.TabIndex = 4;
            this.DecypherRadioButton.TabStop = true;
            this.DecypherRadioButton.Text = "Дешифрование";
            this.DecypherRadioButton.UseVisualStyleBackColor = true;
            // 
            // EncipherRadioButton
            // 
            this.EncipherRadioButton.Checked = true;
            this.EncipherRadioButton.Location = new System.Drawing.Point(528, 353);
            this.EncipherRadioButton.Name = "EncipherRadioButton";
            this.EncipherRadioButton.Size = new System.Drawing.Size(259, 58);
            this.EncipherRadioButton.TabIndex = 3;
            this.EncipherRadioButton.TabStop = true;
            this.EncipherRadioButton.Text = "Шифрование";
            this.EncipherRadioButton.UseVisualStyleBackColor = true;
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(528, 485);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(150, 60);
            this.CalculateButton.TabIndex = 7;
            this.CalculateButton.Text = "Рассчитать";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "openFileDialog1";
            this.OpenFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(528, 560);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(150, 60);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Очистить все";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(638, 665);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(130, 40);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "На главную";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Location = new System.Drawing.Point(798, 665);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(130, 40);
            this.btnHelp.TabIndex = 16;
            this.btnHelp.Text = "Помощь";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // dataGridViewTable
            // 
            this.dataGridViewTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTable.Location = new System.Drawing.Point(12, 33);
            this.dataGridViewTable.Name = "dataGridViewTable";
            this.dataGridViewTable.ReadOnly = true;
            this.dataGridViewTable.RowHeadersVisible = false;
            this.dataGridViewTable.RowHeadersWidth = 51;
            this.dataGridViewTable.RowTemplate.Height = 24;
            this.dataGridViewTable.Size = new System.Drawing.Size(415, 315);
            this.dataGridViewTable.TabIndex = 17;
            this.dataGridViewTable.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.ClientSize = new System.Drawing.Size(982, 753);
            this.Controls.Add(this.dataGridViewTable);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.DecypherRadioButton);
            this.Controls.Add(this.EncipherRadioButton);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.KeyTextBox);
            this.Controls.Add(this.KeyLabel);
            this.Controls.Add(this.PlainTextBox);
            this.Controls.Add(this.PlainTextLabel);
            this.Controls.Add(this.MainMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;

        private System.Windows.Forms.RadioButton DecypherRadioButton;
        private System.Windows.Forms.RadioButton EncipherRadioButton;
        private System.Windows.Forms.Button CalculateButton;

        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox KeyTextBox;
        private System.Windows.Forms.Label KeyLabel;

        private System.Windows.Forms.Label PlainTextLabel;

        private System.Windows.Forms.TextBox PlainTextBox;

        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenFileMenu;

        private System.Windows.Forms.MenuStrip MainMenu;

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.DataGridView dataGridViewTable;
    }
}
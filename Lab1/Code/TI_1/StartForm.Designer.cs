namespace TI_1
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.label1 = new System.Windows.Forms.Label();
            this.btnColumnar = new System.Windows.Forms.Button();
            this.btnVigenere = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(226, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(391, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Выберите метод шифрования";
            // 
            // btnColumnar
            // 
            this.btnColumnar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnColumnar.Location = new System.Drawing.Point(125, 154);
            this.btnColumnar.Name = "btnColumnar";
            this.btnColumnar.Size = new System.Drawing.Size(200, 90);
            this.btnColumnar.TabIndex = 1;
            this.btnColumnar.Text = "Столбцовый метод (улучшенный)";
            this.btnColumnar.UseVisualStyleBackColor = true;
            this.btnColumnar.Click += new System.EventHandler(this.btnColumnar_Click);
            // 
            // btnVigenere
            // 
            this.btnVigenere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVigenere.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVigenere.Location = new System.Drawing.Point(517, 154);
            this.btnVigenere.Name = "btnVigenere";
            this.btnVigenere.Size = new System.Drawing.Size(200, 90);
            this.btnVigenere.TabIndex = 2;
            this.btnVigenere.Text = "Метод Виженера";
            this.btnVigenere.UseVisualStyleBackColor = true;
            this.btnVigenere.Click += new System.EventHandler(this.btnVigenere_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(349, 428);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(144, 51);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Выход";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 491);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnVigenere);
            this.Controls.Add(this.btnColumnar);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Главное меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnColumnar;
        private System.Windows.Forms.Button btnVigenere;
        private System.Windows.Forms.Button btnExit;
    }
}
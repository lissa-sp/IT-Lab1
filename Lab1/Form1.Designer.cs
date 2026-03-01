namespace Lab1
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbKey = new System.Windows.Forms.TextBox();
            this.tbInitText = new System.Windows.Forms.RichTextBox();
            this.rbVigener = new System.Windows.Forms.RadioButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbEnglish = new System.Windows.Forms.RadioButton();
            this.rbRussian = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbCipherPlayFair = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblKey = new System.Windows.Forms.Label();
            this.btnDecode = new System.Windows.Forms.Button();
            this.btnEncode = new System.Windows.Forms.Button();
            this.lblNameOfCypher = new System.Windows.Forms.Label();
            this.btnReadFromFile = new System.Windows.Forms.Button();
            this.lblInitText = new System.Windows.Forms.Label();
            this.tbModifiedText = new System.Windows.Forms.RichTextBox();
            this.lblModifiedText = new System.Windows.Forms.Label();
            this.btnSaveToFile = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbKey
            // 
            this.tbKey.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.tbKey.Location = new System.Drawing.Point(133, 250);
            this.tbKey.Name = "tbKey";
            this.tbKey.Size = new System.Drawing.Size(173, 32);
            this.tbKey.TabIndex = 0;
            // 
            // tbInitText
            // 
            this.tbInitText.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.tbInitText.Location = new System.Drawing.Point(61, 150);
            this.tbInitText.Name = "tbInitText";
            this.tbInitText.Size = new System.Drawing.Size(598, 152);
            this.tbInitText.TabIndex = 3;
            this.tbInitText.Text = "";
            // 
            // rbVigener
            // 
            this.rbVigener.AutoSize = true;
            this.rbVigener.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.rbVigener.Location = new System.Drawing.Point(21, 55);
            this.rbVigener.Name = "rbVigener";
            this.rbVigener.Size = new System.Drawing.Size(195, 28);
            this.rbVigener.TabIndex = 5;
            this.rbVigener.TabStop = true;
            this.rbVigener.Text = "Шифр Виженера";
            this.rbVigener.UseVisualStyleBackColor = true;
            this.rbVigener.CheckedChanged += new System.EventHandler(this.rbVigener_CheckedChanged);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Chocolate;
            this.pnlMain.Controls.Add(this.groupBox2);
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Controls.Add(this.btnClear);
            this.pnlMain.Controls.Add(this.lblKey);
            this.pnlMain.Controls.Add(this.btnDecode);
            this.pnlMain.Controls.Add(this.btnEncode);
            this.pnlMain.Controls.Add(this.tbKey);
            this.pnlMain.Location = new System.Drawing.Point(718, -1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(363, 554);
            this.pnlMain.TabIndex = 6;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbEnglish);
            this.groupBox2.Controls.Add(this.rbRussian);
            this.groupBox2.Location = new System.Drawing.Point(63, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(243, 100);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Язык";
            // 
            // rbEnglish
            // 
            this.rbEnglish.AutoSize = true;
            this.rbEnglish.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.rbEnglish.Location = new System.Drawing.Point(21, 22);
            this.rbEnglish.Name = "rbEnglish";
            this.rbEnglish.Size = new System.Drawing.Size(202, 28);
            this.rbEnglish.TabIndex = 13;
            this.rbEnglish.TabStop = true;
            this.rbEnglish.Text = "Английский язык";
            this.rbEnglish.UseVisualStyleBackColor = true;
            this.rbEnglish.CheckedChanged += new System.EventHandler(this.rbEnglish_CheckedChanged);
            // 
            // rbRussian
            // 
            this.rbRussian.AutoSize = true;
            this.rbRussian.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.rbRussian.Location = new System.Drawing.Point(21, 55);
            this.rbRussian.Name = "rbRussian";
            this.rbRussian.Size = new System.Drawing.Size(159, 28);
            this.rbRussian.TabIndex = 14;
            this.rbRussian.TabStop = true;
            this.rbRussian.Text = "Русский язык";
            this.rbRussian.UseVisualStyleBackColor = true;
            this.rbRussian.CheckedChanged += new System.EventHandler(this.rbRussian_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbCipherPlayFair);
            this.groupBox1.Controls.Add(this.rbVigener);
            this.groupBox1.Location = new System.Drawing.Point(63, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(243, 100);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Алгоритм";
            // 
            // rbCipherPlayFair
            // 
            this.rbCipherPlayFair.AutoSize = true;
            this.rbCipherPlayFair.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.rbCipherPlayFair.Location = new System.Drawing.Point(21, 21);
            this.rbCipherPlayFair.Name = "rbCipherPlayFair";
            this.rbCipherPlayFair.Size = new System.Drawing.Size(199, 28);
            this.rbCipherPlayFair.TabIndex = 7;
            this.rbCipherPlayFair.Text = "Шифр Плейфера";
            this.rbCipherPlayFair.UseVisualStyleBackColor = true;
            this.rbCipherPlayFair.CheckedChanged += new System.EventHandler(this.rbCipherPlayFair_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnClear.Location = new System.Drawing.Point(63, 506);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(243, 36);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Очистить";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.lblKey.Location = new System.Drawing.Point(59, 253);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(68, 24);
            this.lblKey.TabIndex = 11;
            this.lblKey.Text = "Ключ:";
            // 
            // btnDecode
            // 
            this.btnDecode.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnDecode.Location = new System.Drawing.Point(63, 419);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(243, 36);
            this.btnDecode.TabIndex = 10;
            this.btnDecode.Text = "Расшифровать";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // btnEncode
            // 
            this.btnEncode.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnEncode.Location = new System.Drawing.Point(63, 366);
            this.btnEncode.Name = "btnEncode";
            this.btnEncode.Size = new System.Drawing.Size(243, 36);
            this.btnEncode.TabIndex = 9;
            this.btnEncode.Text = "Шифровать";
            this.btnEncode.UseVisualStyleBackColor = true;
            this.btnEncode.Click += new System.EventHandler(this.btnEncode_Click);
            // 
            // lblNameOfCypher
            // 
            this.lblNameOfCypher.AutoSize = true;
            this.lblNameOfCypher.Font = new System.Drawing.Font("Broadway", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameOfCypher.ForeColor = System.Drawing.Color.Chocolate;
            this.lblNameOfCypher.Location = new System.Drawing.Point(167, 33);
            this.lblNameOfCypher.Name = "lblNameOfCypher";
            this.lblNameOfCypher.Size = new System.Drawing.Size(392, 42);
            this.lblNameOfCypher.TabIndex = 7;
            this.lblNameOfCypher.Text = "Простейшие шифры";
            // 
            // btnReadFromFile
            // 
            this.btnReadFromFile.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnReadFromFile.Location = new System.Drawing.Point(440, 107);
            this.btnReadFromFile.Name = "btnReadFromFile";
            this.btnReadFromFile.Size = new System.Drawing.Size(219, 37);
            this.btnReadFromFile.TabIndex = 8;
            this.btnReadFromFile.Text = "Читать из файла";
            this.btnReadFromFile.UseVisualStyleBackColor = true;
            this.btnReadFromFile.Click += new System.EventHandler(this.btnReadFromFile_Click);
            // 
            // lblInitText
            // 
            this.lblInitText.AutoSize = true;
            this.lblInitText.BackColor = System.Drawing.SystemColors.Control;
            this.lblInitText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblInitText.Font = new System.Drawing.Font("Book Antiqua", 14F);
            this.lblInitText.ForeColor = System.Drawing.Color.Chocolate;
            this.lblInitText.Location = new System.Drawing.Point(56, 116);
            this.lblInitText.Name = "lblInitText";
            this.lblInitText.Size = new System.Drawing.Size(196, 28);
            this.lblInitText.TabIndex = 10;
            this.lblInitText.Text = "Исходный текст";
            // 
            // tbModifiedText
            // 
            this.tbModifiedText.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.tbModifiedText.Location = new System.Drawing.Point(61, 378);
            this.tbModifiedText.Name = "tbModifiedText";
            this.tbModifiedText.Size = new System.Drawing.Size(598, 152);
            this.tbModifiedText.TabIndex = 11;
            this.tbModifiedText.Text = "";
            // 
            // lblModifiedText
            // 
            this.lblModifiedText.AutoSize = true;
            this.lblModifiedText.BackColor = System.Drawing.SystemColors.Control;
            this.lblModifiedText.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblModifiedText.Font = new System.Drawing.Font("Book Antiqua", 14F);
            this.lblModifiedText.ForeColor = System.Drawing.Color.Chocolate;
            this.lblModifiedText.Location = new System.Drawing.Point(56, 347);
            this.lblModifiedText.Name = "lblModifiedText";
            this.lblModifiedText.Size = new System.Drawing.Size(287, 28);
            this.lblModifiedText.TabIndex = 12;
            this.lblModifiedText.Text = "Преобразованный текст";
            // 
            // btnSaveToFile
            // 
            this.btnSaveToFile.Font = new System.Drawing.Font("Book Antiqua", 12F);
            this.btnSaveToFile.Location = new System.Drawing.Point(440, 335);
            this.btnSaveToFile.Name = "btnSaveToFile";
            this.btnSaveToFile.Size = new System.Drawing.Size(219, 37);
            this.btnSaveToFile.TabIndex = 13;
            this.btnSaveToFile.Text = "Сохранить в файл";
            this.btnSaveToFile.UseVisualStyleBackColor = true;
            this.btnSaveToFile.Click += new System.EventHandler(this.btnSaveToFile_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.btnSaveToFile);
            this.Controls.Add(this.lblModifiedText);
            this.Controls.Add(this.tbModifiedText);
            this.Controls.Add(this.lblInitText);
            this.Controls.Add(this.btnReadFromFile);
            this.Controls.Add(this.lblNameOfCypher);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tbInitText);
            this.Name = "frmMain";
            this.Text = "Encoder/Decoder";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbKey;
        private System.Windows.Forms.RichTextBox tbInitText;
        private System.Windows.Forms.RadioButton rbVigener;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.RadioButton rbCipherPlayFair;
        private System.Windows.Forms.Label lblNameOfCypher;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Button btnEncode;
        private System.Windows.Forms.Button btnReadFromFile;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblInitText;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rbRussian;
        private System.Windows.Forms.RadioButton rbEnglish;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox tbModifiedText;
        private System.Windows.Forms.Label lblModifiedText;
        private System.Windows.Forms.Button btnSaveToFile;
    }
}


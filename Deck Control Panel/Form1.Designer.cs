namespace Deck_Control_Panel
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            notifyIcon = new NotifyIcon(components);
            timer1 = new System.Windows.Forms.Timer(components);
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            groupBox2 = new GroupBox();
            ramAvailDisplayLabel = new Label();
            ramUsageDisplayLabel = new Label();
            cpuUsageDisplayLabel = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox3 = new GroupBox();
            progressBar2 = new ProgressBar();
            label12 = new Label();
            label11 = new Label();
            progressBar1 = new ProgressBar();
            labelMinutos = new Label();
            label9 = new Label();
            labelHoras = new Label();
            label7 = new Label();
            connButton = new Button();
            portComboBox = new ComboBox();
            pictureBox1 = new PictureBox();
            checkBox1 = new CheckBox();
            timerPortas = new System.Windows.Forms.Timer(components);
            button_refresh = new Button();
            statusStrip1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Deck Control Panel";
            notifyIcon.Visible = true;
            notifyIcon.MouseDoubleClick += notifyIcon1_MouseDoubleClick;
            // 
            // timer1
            // 
            timer1.Interval = 200;
            timer1.Tick += timer1_Tick;
            // 
            // statusStrip1
            // 
            statusStrip1.Enabled = false;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 281);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(229, 22);
            statusStrip1.SizingGrip = false;
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Enabled = false;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(151, 17);
            toolStripStatusLabel1.Text = "Deck Control Panel V.2023a";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(99, 95);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tamanho RAM";
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Enabled = false;
            radioButton3.Location = new Point(22, 69);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(55, 19);
            radioButton3.TabIndex = 2;
            radioButton3.Text = "16 GB";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Enabled = false;
            radioButton2.Location = new Point(22, 44);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(55, 19);
            radioButton2.TabIndex = 1;
            radioButton2.Text = "32 GB";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Enabled = false;
            radioButton1.Location = new Point(22, 19);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(55, 19);
            radioButton1.TabIndex = 0;
            radioButton1.TabStop = true;
            radioButton1.Text = "64 GB";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ramAvailDisplayLabel);
            groupBox2.Controls.Add(ramUsageDisplayLabel);
            groupBox2.Controls.Add(cpuUsageDisplayLabel);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label1);
            groupBox2.Location = new Point(12, 113);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(205, 93);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Info";
            // 
            // ramAvailDisplayLabel
            // 
            ramAvailDisplayLabel.AutoSize = true;
            ramAvailDisplayLabel.Location = new Point(156, 67);
            ramAvailDisplayLabel.Name = "ramAvailDisplayLabel";
            ramAvailDisplayLabel.Size = new Size(31, 15);
            ramAvailDisplayLabel.TabIndex = 5;
            ramAvailDisplayLabel.Text = "0 GB";
            // 
            // ramUsageDisplayLabel
            // 
            ramUsageDisplayLabel.AutoSize = true;
            ramUsageDisplayLabel.Location = new Point(156, 43);
            ramUsageDisplayLabel.Name = "ramUsageDisplayLabel";
            ramUsageDisplayLabel.Size = new Size(31, 15);
            ramUsageDisplayLabel.TabIndex = 4;
            ramUsageDisplayLabel.Text = "0 GB";
            // 
            // cpuUsageDisplayLabel
            // 
            cpuUsageDisplayLabel.AutoSize = true;
            cpuUsageDisplayLabel.Location = new Point(156, 20);
            cpuUsageDisplayLabel.Name = "cpuUsageDisplayLabel";
            cpuUsageDisplayLabel.Size = new Size(26, 15);
            cpuUsageDisplayLabel.TabIndex = 3;
            cpuUsageDisplayLabel.Text = "0 %";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 67);
            label3.Name = "label3";
            label3.Size = new Size(144, 15);
            label3.TabIndex = 2;
            label3.Text = "Memoria RAM disponível:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 43);
            label2.Name = "label2";
            label2.Size = new Size(129, 15);
            label2.TabIndex = 1;
            label2.Text = "Memoria RAM em uso:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 20);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 0;
            label1.Text = "Percentagem uso CPU:";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(progressBar2);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(progressBar1);
            groupBox3.Controls.Add(labelMinutos);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(labelHoras);
            groupBox3.Controls.Add(label7);
            groupBox3.Location = new Point(95, 212);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(122, 58);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Synchronization";
            // 
            // progressBar2
            // 
            progressBar2.Location = new Point(87, 36);
            progressBar2.Maximum = 2;
            progressBar2.Minimum = 1;
            progressBar2.Name = "progressBar2";
            progressBar2.Size = new Size(17, 15);
            progressBar2.TabIndex = 7;
            progressBar2.Value = 1;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(67, 36);
            label12.Name = "label12";
            label12.Size = new Size(20, 15);
            label12.TabIndex = 6;
            label12.Text = "Rx";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 36);
            label11.Name = "label11";
            label11.Size = new Size(18, 15);
            label11.TabIndex = 5;
            label11.Text = "Tx";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(34, 36);
            progressBar1.Maximum = 2;
            progressBar1.Minimum = 1;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(17, 15);
            progressBar1.TabIndex = 4;
            progressBar1.Value = 1;
            // 
            // labelMinutos
            // 
            labelMinutos.AutoSize = true;
            labelMinutos.Location = new Point(94, 19);
            labelMinutos.Name = "labelMinutos";
            labelMinutos.Size = new Size(17, 15);
            labelMinutos.TabIndex = 3;
            labelMinutos.Text = "--";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(88, 19);
            label9.Name = "label9";
            label9.Size = new Size(10, 15);
            label9.TabIndex = 2;
            label9.Text = ":";
            // 
            // labelHoras
            // 
            labelHoras.AutoSize = true;
            labelHoras.Location = new Point(73, 19);
            labelHoras.Name = "labelHoras";
            labelHoras.Size = new Size(17, 15);
            labelHoras.TabIndex = 1;
            labelHoras.Text = "--";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 19);
            label7.Name = "label7";
            label7.Size = new Size(64, 15);
            label7.TabIndex = 0;
            label7.Text = "Hora local:";
            // 
            // connButton
            // 
            connButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            connButton.Location = new Point(117, 66);
            connButton.Name = "connButton";
            connButton.Size = new Size(100, 41);
            connButton.TabIndex = 5;
            connButton.Text = "Connect";
            connButton.UseVisualStyleBackColor = true;
            connButton.Click += button1_Click;
            // 
            // portComboBox
            // 
            portComboBox.Enabled = false;
            portComboBox.FormattingEnabled = true;
            portComboBox.Location = new Point(146, 37);
            portComboBox.Name = "portComboBox";
            portComboBox.Size = new Size(71, 23);
            portComboBox.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.img1;
            pictureBox1.Location = new Point(12, 212);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(77, 58);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(117, 12);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(100, 19);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Always COM9";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // timerPortas
            // 
            timerPortas.Interval = 50;
            timerPortas.Tick += timer2_Tick;
            // 
            // button_refresh
            // 
            button_refresh.BackgroundImage = Properties.Resources.img3;
            button_refresh.BackgroundImageLayout = ImageLayout.Stretch;
            button_refresh.Location = new Point(117, 37);
            button_refresh.Name = "button_refresh";
            button_refresh.Size = new Size(23, 23);
            button_refresh.TabIndex = 8;
            button_refresh.UseVisualStyleBackColor = true;
            button_refresh.Click += button_refresh_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(229, 303);
            Controls.Add(button_refresh);
            Controls.Add(checkBox1);
            Controls.Add(portComboBox);
            Controls.Add(connButton);
            Controls.Add(pictureBox1);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(statusStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Deck Control";
            WindowState = FormWindowState.Minimized;
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            Resize += Form1_Resize;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private NotifyIcon notifyIcon;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private GroupBox groupBox1;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Label ramUsageDisplayLabel;
        private Label cpuUsageDisplayLabel;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label ramAvailDisplayLabel;
        private Button connButton;
        private ComboBox portComboBox;
        private ProgressBar progressBar1;
        private Label labelMinutos;
        private Label label9;
        private Label labelHoras;
        private Label label7;
        private ProgressBar progressBar2;
        private Label label12;
        private Label label11;
        private PictureBox pictureBox1;
        private CheckBox checkBox1;
        private System.Windows.Forms.Timer timerPortas;
        private Button button_refresh;
    }
}
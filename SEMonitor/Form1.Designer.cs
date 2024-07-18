namespace SEMonitor
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            groupBox4 = new GroupBox();
            lblstore = new Label();
            button9 = new Button();
            label4 = new Label();
            txtDb = new TextBox();
            label2 = new Label();
            progressBar1 = new ProgressBar();
            button5 = new Button();
            txtlog = new TextBox();
            button4 = new Button();
            groupBox3 = new GroupBox();
            button7 = new Button();
            lstmapped = new ListBox();
            button3 = new Button();
            groupBox2 = new GroupBox();
            listBoxName = new ListBox();
            button6 = new Button();
            button2 = new Button();
            lstip = new ListBox();
            groupBox1 = new GroupBox();
            txtmachinename = new TextBox();
            label3 = new Label();
            button1 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            triggerEventOls = new System.Windows.Forms.Timer(components);
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            panel2 = new Panel();
            txtlog2 = new TextBox();
            button8 = new Button();
            ClbtriggerEventOls = new System.Windows.Forms.Timer(components);
            folderBrowserDialog1 = new FolderBrowserDialog();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(groupBox4);
            panel1.Controls.Add(progressBar1);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(txtlog);
            panel1.Controls.Add(button4);
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(groupBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1122, 590);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(6, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(294, 143);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(lblstore);
            groupBox4.Controls.Add(button9);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(txtDb);
            groupBox4.Controls.Add(label2);
            groupBox4.Location = new Point(306, 191);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(339, 87);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "Thông tin Cơ bản";
            // 
            // lblstore
            // 
            lblstore.AutoSize = true;
            lblstore.Location = new Point(177, 58);
            lblstore.Name = "lblstore";
            lblstore.Size = new Size(0, 15);
            lblstore.TabIndex = 6;
            // 
            // button9
            // 
            button9.Location = new Point(76, 54);
            button9.Name = "button9";
            button9.Size = new Size(79, 23);
            button9.TabIndex = 5;
            button9.Text = "Chọn";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 57);
            label4.Name = "label4";
            label4.Size = new Size(64, 15);
            label4.TabIndex = 2;
            label4.Text = "Nơi lưu trữ";
            // 
            // txtDb
            // 
            txtDb.Location = new Point(74, 21);
            txtDb.Name = "txtDb";
            txtDb.Size = new Size(254, 23);
            txtDb.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 24);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 0;
            label2.Text = "DATABASE";
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(859, 83);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 32);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 6;
            progressBar1.Visible = false;
            // 
            // button5
            // 
            button5.BackColor = Color.Brown;
            button5.Font = new Font("Segoe UI", 15F);
            button5.ForeColor = Color.White;
            button5.Location = new Point(662, 300);
            button5.Name = "button5";
            button5.Size = new Size(252, 44);
            button5.TabIndex = 5;
            button5.Text = "STOP";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // txtlog
            // 
            txtlog.BackColor = SystemColors.Info;
            txtlog.Location = new Point(16, 350);
            txtlog.Multiline = true;
            txtlog.Name = "txtlog";
            txtlog.ScrollBars = ScrollBars.Both;
            txtlog.Size = new Size(1103, 217);
            txtlog.TabIndex = 4;
            txtlog.TextChanged += txtlog_TextChanged;
            // 
            // button4
            // 
            button4.BackColor = Color.GreenYellow;
            button4.Font = new Font("Tahoma", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Tomato;
            button4.Location = new Point(369, 300);
            button4.Name = "button4";
            button4.Size = new Size(287, 44);
            button4.TabIndex = 3;
            button4.Text = "Bắt đầu theo dõi";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button7);
            groupBox3.Controls.Add(lstmapped);
            groupBox3.Location = new Point(968, 25);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(149, 253);
            groupBox3.TabIndex = 2;
            groupBox3.TabStop = false;
            groupBox3.Text = "Thông tin Kết nối";
            // 
            // button7
            // 
            button7.Location = new Point(23, 220);
            button7.Name = "button7";
            button7.Size = new Size(98, 23);
            button7.TabIndex = 3;
            button7.Text = "Xoá Hết ";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // lstmapped
            // 
            lstmapped.FormattingEnabled = true;
            lstmapped.ItemHeight = 15;
            lstmapped.Location = new Point(6, 19);
            lstmapped.Name = "lstmapped";
            lstmapped.Size = new Size(126, 184);
            lstmapped.TabIndex = 0;
            // 
            // button3
            // 
            button3.BackColor = Color.YellowGreen;
            button3.Font = new Font("Tahoma", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.Coral;
            button3.Location = new Point(860, 121);
            button3.Name = "button3";
            button3.Size = new Size(99, 64);
            button3.TabIndex = 2;
            button3.Text = "Kiểm tra kết nối";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(listBoxName);
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(lstip);
            groupBox2.Location = new Point(663, 25);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(191, 253);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Danh Sách máy soi";
            // 
            // listBoxName
            // 
            listBoxName.FormattingEnabled = true;
            listBoxName.ItemHeight = 15;
            listBoxName.Location = new Point(24, 19);
            listBoxName.Name = "listBoxName";
            listBoxName.Size = new Size(61, 184);
            listBoxName.TabIndex = 3;
            // 
            // button6
            // 
            button6.Location = new Point(110, 220);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 2;
            button6.Text = "Xoá Hết";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button2
            // 
            button2.Location = new Point(6, 220);
            button2.Name = "button2";
            button2.Size = new Size(98, 23);
            button2.TabIndex = 1;
            button2.Text = "Xoá Máy này";
            button2.UseVisualStyleBackColor = true;
            // 
            // lstip
            // 
            lstip.FormattingEnabled = true;
            lstip.ItemHeight = 15;
            lstip.Location = new Point(91, 21);
            lstip.Name = "lstip";
            lstip.Size = new Size(94, 184);
            lstip.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtmachinename);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(button1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(306, 25);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(339, 160);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Thông tin máy soi cần theo dõi";
            // 
            // txtmachinename
            // 
            txtmachinename.Location = new Point(79, 38);
            txtmachinename.Name = "txtmachinename";
            txtmachinename.Size = new Size(76, 23);
            txtmachinename.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 41);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 3;
            label3.Text = "Máy soi số";
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(79, 96);
            button1.Name = "button1";
            button1.Size = new Size(92, 23);
            button1.TabIndex = 2;
            button1.Text = "Thêm vào";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(79, 67);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(229, 23);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 70);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "IP";
            // 
            // triggerEventOls
            // 
            triggerEventOls.Interval = 1000;
            triggerEventOls.Tick += triggerEventOls_Tick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1133, 621);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(panel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1125, 593);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "OnlineRecording     ";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1125, 593);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Clipboard";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ActiveCaption;
            panel2.Controls.Add(txtlog2);
            panel2.Controls.Add(button8);
            panel2.Location = new Point(3, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(1126, 591);
            panel2.TabIndex = 0;
            // 
            // txtlog2
            // 
            txtlog2.BackColor = SystemColors.Info;
            txtlog2.Location = new Point(16, 54);
            txtlog2.Multiline = true;
            txtlog2.Name = "txtlog2";
            txtlog2.ScrollBars = ScrollBars.Both;
            txtlog2.Size = new Size(1100, 527);
            txtlog2.TabIndex = 1;
            // 
            // button8
            // 
            button8.BackColor = Color.GreenYellow;
            button8.Font = new Font("Tahoma", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button8.ForeColor = Color.Coral;
            button8.Location = new Point(16, 12);
            button8.Name = "button8";
            button8.Size = new Size(279, 36);
            button8.TabIndex = 0;
            button8.Text = "Watch Reject Image";
            button8.UseVisualStyleBackColor = false;
            button8.Click += button8_Click;
            // 
            // ClbtriggerEventOls
            // 
            ClbtriggerEventOls.Interval = 1000;
            ClbtriggerEventOls.Tick += ClbtriggerEventOls_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1147, 637);
            Controls.Add(tabControl1);
            MaximizeBox = false;
            Name = "Form1";
            Text = "Giám sát Theo dõi hành lý- DA NANG INTERNATIONAL AIRPORT";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private ListBox lstip;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Button button2;
        private Button button3;
        private GroupBox groupBox3;
        private ListBox lstmapped;
        private Button button4;
        private TextBox txtlog;
        private System.Windows.Forms.Timer triggerEventOls;
        private Button button5;
        private Button button6;
        private Button button7;
        private ProgressBar progressBar1;
        private GroupBox groupBox4;
        private TextBox txtDb;
        private Label label2;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Panel panel2;
        private Button button8;
        private TextBox txtlog2;
        private System.Windows.Forms.Timer ClbtriggerEventOls;
        private Label label3;
        private TextBox txtmachinename;
        private ListBox listBoxName;
        private PictureBox pictureBox1;
        private Label label4;
        private Label lblstore;
        private Button button9;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}

namespace winform_1
{
    partial class Game
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Game));
            this.snposition = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.gscore = new System.Windows.Forms.Label();
            this.paihang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.user = new System.Windows.Forms.Timer(this.components);
            this.run = new System.Windows.Forms.Timer(this.components);
            this.btn_start = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // snposition
            // 
            this.snposition.Interval = 10;
            this.snposition.Tick += new System.EventHandler(this.snposition_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(149, 198);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "重新开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gscore
            // 
            this.gscore.BackColor = System.Drawing.Color.MistyRose;
            this.gscore.Location = new System.Drawing.Point(3, 318);
            this.gscore.Name = "gscore";
            this.gscore.Size = new System.Drawing.Size(137, 23);
            this.gscore.TabIndex = 3;
            // 
            // paihang
            // 
            this.paihang.BackColor = System.Drawing.Color.Yellow;
            this.paihang.Location = new System.Drawing.Point(-2, 0);
            this.paihang.Name = "paihang";
            this.paihang.Size = new System.Drawing.Size(126, 180);
            this.paihang.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.MistyRose;
            this.label1.Location = new System.Drawing.Point(2, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 5;
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(294, 198);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 6;
            this.exit.Text = "退出登录";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.button2_Click);
            // 
            // user
            // 
            this.user.Tick += new System.EventHandler(this.user_Tick);
            // 
            // run
            // 
            this.run.Interval = 200;
            this.run.Tick += new System.EventHandler(this.zw_Tick);
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.Transparent;
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.ForeColor = System.Drawing.Color.Transparent;
            this.btn_start.Image = ((System.Drawing.Image)(resources.GetObject("btn_start.Image")));
            this.btn_start.Location = new System.Drawing.Point(214, 120);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(102, 49);
            this.btn_start.TabIndex = 7;
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.zw_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.paihang);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.gscore);
            this.panel1.Location = new System.Drawing.Point(475, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 371);
            this.panel1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.MistyRose;
            this.label3.Location = new System.Drawing.Point(2, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "当前用户：";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.MistyRose;
            this.label2.Location = new System.Drawing.Point(2, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "当前分数：";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(600, 375);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_start);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.button1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rssm_main_KeyDown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer snposition;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label gscore;
        private System.Windows.Forms.Label paihang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Timer user;
        private System.Windows.Forms.Timer run;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
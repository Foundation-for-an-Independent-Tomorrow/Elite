
namespace Elite
{
    partial class Elite_Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Elite_Dashboard));
            this.BTN_Exit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BTN_New_Client = new System.Windows.Forms.Button();
            this.BTN_Admin = new System.Windows.Forms.Button();
            this.BTN_Home = new System.Windows.Forms.Button();
            this.BTN_Close = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LblCurrentRunningTime = new System.Windows.Forms.Label();
            this.LblLongDate = new System.Windows.Forms.Label();
            this.LblUserName = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BTN_Minimize = new System.Windows.Forms.Button();
            this.LblHomeScreen = new System.Windows.Forms.Label();
            this.PnlFormLoader = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BTN_Exit
            // 
            this.BTN_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BTN_Exit.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BTN_Exit.FlatAppearance.BorderSize = 0;
            this.BTN_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Exit.ForeColor = System.Drawing.Color.White;
            this.BTN_Exit.Location = new System.Drawing.Point(995, 5);
            this.BTN_Exit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BTN_Exit.Name = "BTN_Exit";
            this.BTN_Exit.Size = new System.Drawing.Size(33, 32);
            this.BTN_Exit.TabIndex = 4;
            this.BTN_Exit.Text = "X";
            this.BTN_Exit.UseVisualStyleBackColor = false;
            this.BTN_Exit.Click += new System.EventHandler(this.BTN_Exit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.BTN_New_Client);
            this.panel1.Controls.Add(this.BTN_Admin);
            this.panel1.Controls.Add(this.BTN_Home);
            this.panel1.Controls.Add(this.BTN_Close);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.ForeColor = System.Drawing.Color.GhostWhite;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(193, 762);
            this.panel1.TabIndex = 5;
            // 
            // BTN_New_Client
            // 
            this.BTN_New_Client.BackColor = System.Drawing.Color.SlateBlue;
            this.BTN_New_Client.Dock = System.Windows.Forms.DockStyle.Top;
            this.BTN_New_Client.FlatAppearance.BorderSize = 0;
            this.BTN_New_Client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_New_Client.Location = new System.Drawing.Point(0, 145);
            this.BTN_New_Client.Name = "BTN_New_Client";
            this.BTN_New_Client.Size = new System.Drawing.Size(193, 34);
            this.BTN_New_Client.TabIndex = 10;
            this.BTN_New_Client.Text = "New Client";
            this.BTN_New_Client.UseVisualStyleBackColor = false;
            this.BTN_New_Client.Click += new System.EventHandler(this.BTN_New_Client_Click);
            // 
            // BTN_Admin
            // 
            this.BTN_Admin.BackColor = System.Drawing.Color.SlateBlue;
            this.BTN_Admin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BTN_Admin.FlatAppearance.BorderSize = 0;
            this.BTN_Admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Admin.Location = new System.Drawing.Point(0, 694);
            this.BTN_Admin.Name = "BTN_Admin";
            this.BTN_Admin.Size = new System.Drawing.Size(193, 34);
            this.BTN_Admin.TabIndex = 9;
            this.BTN_Admin.Text = "Admin";
            this.BTN_Admin.UseVisualStyleBackColor = false;
            this.BTN_Admin.Visible = false;
            this.BTN_Admin.Click += new System.EventHandler(this.BTN_Admin_Click);
            // 
            // BTN_Home
            // 
            this.BTN_Home.BackColor = System.Drawing.Color.SlateBlue;
            this.BTN_Home.Dock = System.Windows.Forms.DockStyle.Top;
            this.BTN_Home.FlatAppearance.BorderSize = 0;
            this.BTN_Home.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Home.Location = new System.Drawing.Point(0, 111);
            this.BTN_Home.Name = "BTN_Home";
            this.BTN_Home.Size = new System.Drawing.Size(193, 34);
            this.BTN_Home.TabIndex = 8;
            this.BTN_Home.Text = "Home";
            this.BTN_Home.UseVisualStyleBackColor = false;
            this.BTN_Home.Visible = false;
            this.BTN_Home.Click += new System.EventHandler(this.BTN_Home_Click);
            // 
            // BTN_Close
            // 
            this.BTN_Close.BackColor = System.Drawing.Color.SlateBlue;
            this.BTN_Close.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BTN_Close.FlatAppearance.BorderSize = 0;
            this.BTN_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Close.Location = new System.Drawing.Point(0, 728);
            this.BTN_Close.Name = "BTN_Close";
            this.BTN_Close.Size = new System.Drawing.Size(193, 34);
            this.BTN_Close.TabIndex = 7;
            this.BTN_Close.Text = "Exit";
            this.BTN_Close.UseVisualStyleBackColor = false;
            this.BTN_Close.Click += new System.EventHandler(this.BTN_Close_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LblCurrentRunningTime);
            this.panel2.Controls.Add(this.LblLongDate);
            this.panel2.Controls.Add(this.LblUserName);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 111);
            this.panel2.TabIndex = 6;
            // 
            // LblCurrentRunningTime
            // 
            this.LblCurrentRunningTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblCurrentRunningTime.AutoSize = true;
            this.LblCurrentRunningTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblCurrentRunningTime.ForeColor = System.Drawing.Color.GhostWhite;
            this.LblCurrentRunningTime.Location = new System.Drawing.Point(12, 71);
            this.LblCurrentRunningTime.Name = "LblCurrentRunningTime";
            this.LblCurrentRunningTime.Size = new System.Drawing.Size(46, 17);
            this.LblCurrentRunningTime.TabIndex = 2;
            this.LblCurrentRunningTime.Text = "label2";
            // 
            // LblLongDate
            // 
            this.LblLongDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblLongDate.AutoEllipsis = true;
            this.LblLongDate.AutoSize = true;
            this.LblLongDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLongDate.ForeColor = System.Drawing.Color.GhostWhite;
            this.LblLongDate.Location = new System.Drawing.Point(12, 45);
            this.LblLongDate.Name = "LblLongDate";
            this.LblLongDate.Size = new System.Drawing.Size(44, 16);
            this.LblLongDate.TabIndex = 1;
            this.LblLongDate.Text = "label1";
            // 
            // LblUserName
            // 
            this.LblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LblUserName.AutoSize = true;
            this.LblUserName.ForeColor = System.Drawing.Color.GhostWhite;
            this.LblUserName.Location = new System.Drawing.Point(12, 17);
            this.LblUserName.Name = "LblUserName";
            this.LblUserName.Size = new System.Drawing.Size(51, 20);
            this.LblUserName.TabIndex = 0;
            this.LblUserName.Text = "label1";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel3.Controls.Add(this.BTN_Minimize);
            this.panel3.Controls.Add(this.LblHomeScreen);
            this.panel3.Controls.Add(this.BTN_Exit);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(193, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1033, 111);
            this.panel3.TabIndex = 6;
            this.panel3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dashboard_MouseDown);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Dashboard_MouseMove);
            this.panel3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Dashboard_MouseUp);
            // 
            // BTN_Minimize
            // 
            this.BTN_Minimize.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.BTN_Minimize.FlatAppearance.BorderSize = 0;
            this.BTN_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Minimize.ForeColor = System.Drawing.Color.GhostWhite;
            this.BTN_Minimize.Location = new System.Drawing.Point(955, 4);
            this.BTN_Minimize.Name = "BTN_Minimize";
            this.BTN_Minimize.Size = new System.Drawing.Size(33, 33);
            this.BTN_Minimize.TabIndex = 6;
            this.BTN_Minimize.Text = "_";
            this.BTN_Minimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BTN_Minimize.UseVisualStyleBackColor = false;
            this.BTN_Minimize.Click += new System.EventHandler(this.BTN_Minimize_Click);
            // 
            // LblHomeScreen
            // 
            this.LblHomeScreen.AutoSize = true;
            this.LblHomeScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblHomeScreen.ForeColor = System.Drawing.Color.GhostWhite;
            this.LblHomeScreen.Location = new System.Drawing.Point(28, 38);
            this.LblHomeScreen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblHomeScreen.Name = "LblHomeScreen";
            this.LblHomeScreen.Size = new System.Drawing.Size(70, 25);
            this.LblHomeScreen.TabIndex = 5;
            this.LblHomeScreen.Text = "label1";
            // 
            // PnlFormLoader
            // 
            this.PnlFormLoader.Location = new System.Drawing.Point(200, 119);
            this.PnlFormLoader.Name = "PnlFormLoader";
            this.PnlFormLoader.Size = new System.Drawing.Size(1014, 631);
            this.PnlFormLoader.TabIndex = 7;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Elite_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1226, 762);
            this.Controls.Add(this.PnlFormLoader);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Elite_Dashboard";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elite_Dashboard";
            this.Load += new System.EventHandler(this.Elite_Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BTN_Exit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label LblHomeScreen;
        private System.Windows.Forms.Panel PnlFormLoader;
        private System.Windows.Forms.Label LblCurrentRunningTime;
        private System.Windows.Forms.Label LblLongDate;
        private System.Windows.Forms.Label LblUserName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button BTN_Close;
        private System.Windows.Forms.Button BTN_Home;
        private System.Windows.Forms.Button BTN_Admin;
        private System.Windows.Forms.Button BTN_New_Client;
        private System.Windows.Forms.Button BTN_Minimize;
    }
}
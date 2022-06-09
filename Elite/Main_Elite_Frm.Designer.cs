
namespace Elite
{
    partial class Main_Elite_Frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main_Elite_Frm));
            this.DGV_Client_Search = new System.Windows.Forms.DataGridView();
            this.CBox_CMs = new System.Windows.Forms.ComboBox();
            this.TXT_Client_Search_By_LastName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lbl_Search_By_CM = new System.Windows.Forms.Label();
            this.BTN_Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Client_Search)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // DGV_Client_Search
            // 
            this.DGV_Client_Search.AllowUserToAddRows = false;
            this.DGV_Client_Search.AllowUserToDeleteRows = false;
            this.DGV_Client_Search.AllowUserToResizeColumns = false;
            this.DGV_Client_Search.AllowUserToResizeRows = false;
            this.DGV_Client_Search.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV_Client_Search.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.DGV_Client_Search.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Client_Search.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DGV_Client_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_Client_Search.Location = new System.Drawing.Point(0, 0);
            this.DGV_Client_Search.Name = "DGV_Client_Search";
            this.DGV_Client_Search.ReadOnly = true;
            this.DGV_Client_Search.RowHeadersVisible = false;
            this.DGV_Client_Search.RowTemplate.Height = 30;
            this.DGV_Client_Search.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Client_Search.Size = new System.Drawing.Size(990, 543);
            this.DGV_Client_Search.TabIndex = 1;
            this.DGV_Client_Search.TabStop = false;
            this.DGV_Client_Search.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Client_Search_CellContentDoubleClick);
            // 
            // CBox_CMs
            // 
            this.CBox_CMs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CBox_CMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CBox_CMs.FormattingEnabled = true;
            this.CBox_CMs.Location = new System.Drawing.Point(555, 41);
            this.CBox_CMs.Name = "CBox_CMs";
            this.CBox_CMs.Size = new System.Drawing.Size(215, 28);
            this.CBox_CMs.TabIndex = 2;
            // 
            // TXT_Client_Search_By_LastName
            // 
            this.TXT_Client_Search_By_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_Client_Search_By_LastName.Location = new System.Drawing.Point(225, 41);
            this.TXT_Client_Search_By_LastName.Name = "TXT_Client_Search_By_LastName";
            this.TXT_Client_Search_By_LastName.Size = new System.Drawing.Size(233, 27);
            this.TXT_Client_Search_By_LastName.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.DGV_Client_Search);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(12, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(990, 543);
            this.panel2.TabIndex = 6;
            // 
            // Lbl_Search_By_CM
            // 
            this.Lbl_Search_By_CM.AutoSize = true;
            this.Lbl_Search_By_CM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Search_By_CM.ForeColor = System.Drawing.Color.Black;
            this.Lbl_Search_By_CM.Location = new System.Drawing.Point(551, 14);
            this.Lbl_Search_By_CM.Name = "Lbl_Search_By_CM";
            this.Lbl_Search_By_CM.Size = new System.Drawing.Size(223, 24);
            this.Lbl_Search_By_CM.TabIndex = 6;
            this.Lbl_Search_By_CM.Text = "Search by Case Manager";
            // 
            // BTN_Search
            // 
            this.BTN_Search.BackgroundImage = global::Elite.Properties.Resources.searchbtn;
            this.BTN_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BTN_Search.FlatAppearance.BorderSize = 0;
            this.BTN_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Search.ForeColor = System.Drawing.Color.Black;
            this.BTN_Search.Location = new System.Drawing.Point(794, 41);
            this.BTN_Search.Name = "BTN_Search";
            this.BTN_Search.Size = new System.Drawing.Size(28, 27);
            this.BTN_Search.TabIndex = 5;
            this.BTN_Search.UseVisualStyleBackColor = true;
            this.BTN_Search.Click += new System.EventHandler(this.BTN_Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(221, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Search by Client Last Name";
            // 
            // Main_Elite_Frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1014, 631);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXT_Client_Search_By_LastName);
            this.Controls.Add(this.Lbl_Search_By_CM);
            this.Controls.Add(this.BTN_Search);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.CBox_CMs);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(225)))), ((int)(((byte)(152)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main_Elite_Frm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elite";
            this.Load += new System.EventHandler(this.Main_Elite_Frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Client_Search)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DGV_Client_Search;
        private System.Windows.Forms.ComboBox CBox_CMs;
        private System.Windows.Forms.Button BTN_Search;
        private System.Windows.Forms.TextBox TXT_Client_Search_By_LastName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Lbl_Search_By_CM;
        private System.Windows.Forms.Label label1;
    }
}


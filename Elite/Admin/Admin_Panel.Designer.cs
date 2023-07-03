
namespace Elite
{
    partial class Admin_Panel
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BTN_Add_New_Admin = new RJCodeAdvance.RJControls.RJButton();
            this.BTN_Add_Update_CMs = new RJCodeAdvance.RJControls.RJButton();
            this.DGV_Admin = new System.Windows.Forms.DataGridView();
            this.DGV_CaseManagers = new System.Windows.Forms.DataGridView();
            this.BTN_Cancel = new RJCodeAdvance.RJControls.RJButton();
            this.LBL_CMs = new System.Windows.Forms.Label();
            this.LBL_Admins = new System.Windows.Forms.Label();
            this.LBL_Admin_Pnl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Admin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CaseManagers)).BeginInit();
            this.SuspendLayout();
            // 
            // BTN_Add_New_Admin
            // 
            this.BTN_Add_New_Admin.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BTN_Add_New_Admin.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BTN_Add_New_Admin.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BTN_Add_New_Admin.BorderRadius = 0;
            this.BTN_Add_New_Admin.BorderSize = 0;
            this.BTN_Add_New_Admin.FlatAppearance.BorderSize = 0;
            this.BTN_Add_New_Admin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Add_New_Admin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Add_New_Admin.ForeColor = System.Drawing.Color.White;
            this.BTN_Add_New_Admin.Location = new System.Drawing.Point(375, 285);
            this.BTN_Add_New_Admin.Name = "BTN_Add_New_Admin";
            this.BTN_Add_New_Admin.Size = new System.Drawing.Size(161, 39);
            this.BTN_Add_New_Admin.TabIndex = 0;
            this.BTN_Add_New_Admin.Text = "Add new Admin";
            this.BTN_Add_New_Admin.TextColor = System.Drawing.Color.White;
            this.BTN_Add_New_Admin.UseVisualStyleBackColor = false;
            // 
            // BTN_Add_Update_CMs
            // 
            this.BTN_Add_Update_CMs.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BTN_Add_Update_CMs.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BTN_Add_Update_CMs.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BTN_Add_Update_CMs.BorderRadius = 0;
            this.BTN_Add_Update_CMs.BorderSize = 0;
            this.BTN_Add_Update_CMs.FlatAppearance.BorderSize = 0;
            this.BTN_Add_Update_CMs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Add_Update_CMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Add_Update_CMs.ForeColor = System.Drawing.Color.White;
            this.BTN_Add_Update_CMs.Location = new System.Drawing.Point(375, 340);
            this.BTN_Add_Update_CMs.Name = "BTN_Add_Update_CMs";
            this.BTN_Add_Update_CMs.Size = new System.Drawing.Size(161, 39);
            this.BTN_Add_Update_CMs.TabIndex = 2;
            this.BTN_Add_Update_CMs.Text = "Add New CM";
            this.BTN_Add_Update_CMs.TextColor = System.Drawing.Color.White;
            this.BTN_Add_Update_CMs.UseVisualStyleBackColor = false;
            // 
            // DGV_Admin
            // 
            this.DGV_Admin.AllowUserToAddRows = false;
            this.DGV_Admin.AllowUserToDeleteRows = false;
            this.DGV_Admin.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.DGV_Admin.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.DGV_Admin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV_Admin.DefaultCellStyle = dataGridViewCellStyle5;
            this.DGV_Admin.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.DGV_Admin.Location = new System.Drawing.Point(12, 99);
            this.DGV_Admin.Name = "DGV_Admin";
            this.DGV_Admin.ReadOnly = true;
            this.DGV_Admin.RowHeadersVisible = false;
            this.DGV_Admin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_Admin.Size = new System.Drawing.Size(566, 150);
            this.DGV_Admin.TabIndex = 4;
            // 
            // DGV_CaseManagers
            // 
            this.DGV_CaseManagers.AllowUserToAddRows = false;
            this.DGV_CaseManagers.AllowUserToDeleteRows = false;
            this.DGV_CaseManagers.AllowUserToResizeColumns = false;
            this.DGV_CaseManagers.AllowUserToResizeRows = false;
            this.DGV_CaseManagers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV_CaseManagers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV_CaseManagers.BackgroundColor = System.Drawing.Color.LightSteelBlue;
            this.DGV_CaseManagers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_CaseManagers.Location = new System.Drawing.Point(12, 285);
            this.DGV_CaseManagers.Name = "DGV_CaseManagers";
            this.DGV_CaseManagers.ReadOnly = true;
            this.DGV_CaseManagers.RowHeadersVisible = false;
            this.DGV_CaseManagers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV_CaseManagers.ShowEditingIcon = false;
            this.DGV_CaseManagers.Size = new System.Drawing.Size(299, 150);
            this.DGV_CaseManagers.TabIndex = 5;
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.BTN_Cancel.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.BTN_Cancel.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.BTN_Cancel.BorderRadius = 0;
            this.BTN_Cancel.BorderSize = 0;
            this.BTN_Cancel.FlatAppearance.BorderSize = 0;
            this.BTN_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BTN_Cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BTN_Cancel.ForeColor = System.Drawing.Color.White;
            this.BTN_Cancel.Location = new System.Drawing.Point(375, 396);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(161, 39);
            this.BTN_Cancel.TabIndex = 6;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.TextColor = System.Drawing.Color.White;
            this.BTN_Cancel.UseVisualStyleBackColor = false;
            // 
            // LBL_CMs
            // 
            this.LBL_CMs.AutoSize = true;
            this.LBL_CMs.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_CMs.ForeColor = System.Drawing.Color.GhostWhite;
            this.LBL_CMs.Location = new System.Drawing.Point(12, 252);
            this.LBL_CMs.Name = "LBL_CMs";
            this.LBL_CMs.Size = new System.Drawing.Size(149, 22);
            this.LBL_CMs.TabIndex = 7;
            this.LBL_CMs.Text = "Case Managers";
            // 
            // LBL_Admins
            // 
            this.LBL_Admins.AutoSize = true;
            this.LBL_Admins.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Admins.ForeColor = System.Drawing.Color.GhostWhite;
            this.LBL_Admins.Location = new System.Drawing.Point(12, 66);
            this.LBL_Admins.Name = "LBL_Admins";
            this.LBL_Admins.Size = new System.Drawing.Size(75, 22);
            this.LBL_Admins.TabIndex = 8;
            this.LBL_Admins.Text = "Admins";
            // 
            // LBL_Admin_Pnl
            // 
            this.LBL_Admin_Pnl.AutoSize = true;
            this.LBL_Admin_Pnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Admin_Pnl.ForeColor = System.Drawing.Color.GhostWhite;
            this.LBL_Admin_Pnl.Location = new System.Drawing.Point(12, 9);
            this.LBL_Admin_Pnl.Name = "LBL_Admin_Pnl";
            this.LBL_Admin_Pnl.Size = new System.Drawing.Size(160, 29);
            this.LBL_Admin_Pnl.TabIndex = 9;
            this.LBL_Admin_Pnl.Text = "Admin Panel";
            // 
            // Admin_Panel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(596, 464);
            this.Controls.Add(this.LBL_Admin_Pnl);
            this.Controls.Add(this.LBL_Admins);
            this.Controls.Add(this.LBL_CMs);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.DGV_CaseManagers);
            this.Controls.Add(this.DGV_Admin);
            this.Controls.Add(this.BTN_Add_Update_CMs);
            this.Controls.Add(this.BTN_Add_New_Admin);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin_Panel";
            this.Opacity = 0.9D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Admin_Panel_FormClosing);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Dashboard_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Dashboard_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Dashboard_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Admin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_CaseManagers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RJCodeAdvance.RJControls.RJButton BTN_Add_New_Admin;
        private RJCodeAdvance.RJControls.RJButton BTN_Add_Update_CMs;
        private System.Windows.Forms.DataGridView DGV_Admin;
        private System.Windows.Forms.DataGridView DGV_CaseManagers;
        private RJCodeAdvance.RJControls.RJButton BTN_Cancel;
        private System.Windows.Forms.Label LBL_CMs;
        private System.Windows.Forms.Label LBL_Admins;
        private System.Windows.Forms.Label LBL_Admin_Pnl;
    }
}
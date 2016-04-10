namespace VetExample.Base
{
    partial class frmBaseListDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseListDetail));
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbFilter = new System.Windows.Forms.GroupBox();
            this.ckiJustValid = new System.Windows.Forms.CheckBox();
            this.gbNavigate = new System.Windows.Forms.GroupBox();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.gbEditing = new System.Windows.Forms.GroupBox();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tssbResults = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslFound = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.gbNavigate.SuspendLayout();
            this.gbEditing.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel1.Controls.Add(this.gbFilter);
            this.panel1.Controls.Add(this.gbNavigate);
            this.panel1.Controls.Add(this.gbEditing);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 91);
            this.panel1.TabIndex = 0;
            // 
            // gbFilter
            // 
            this.gbFilter.Controls.Add(this.ckiJustValid);
            this.gbFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFilter.ForeColor = System.Drawing.Color.Teal;
            this.gbFilter.Location = new System.Drawing.Point(394, 0);
            this.gbFilter.Name = "gbFilter";
            this.gbFilter.Size = new System.Drawing.Size(173, 91);
            this.gbFilter.TabIndex = 3;
            this.gbFilter.TabStop = false;
            this.gbFilter.Text = "Filter";
            // 
            // ckiJustValid
            // 
            this.ckiJustValid.AutoSize = true;
            this.ckiJustValid.Checked = true;
            this.ckiJustValid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckiJustValid.ForeColor = System.Drawing.Color.Black;
            this.ckiJustValid.Location = new System.Drawing.Point(47, 39);
            this.ckiJustValid.Name = "ckiJustValid";
            this.ckiJustValid.Size = new System.Drawing.Size(75, 17);
            this.ckiJustValid.TabIndex = 0;
            this.ckiJustValid.Text = "Valid Data";
            this.ckiJustValid.UseVisualStyleBackColor = true;
            this.ckiJustValid.CheckedChanged += new System.EventHandler(this.ckiJustValid_CheckedChanged);
            // 
            // gbNavigate
            // 
            this.gbNavigate.Controls.Add(this.btnNext);
            this.gbNavigate.Controls.Add(this.btnLast);
            this.gbNavigate.Controls.Add(this.btnFirst);
            this.gbNavigate.Controls.Add(this.btnPrevious);
            this.gbNavigate.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbNavigate.ForeColor = System.Drawing.Color.Teal;
            this.gbNavigate.Location = new System.Drawing.Point(281, 0);
            this.gbNavigate.Name = "gbNavigate";
            this.gbNavigate.Size = new System.Drawing.Size(113, 91);
            this.gbNavigate.TabIndex = 2;
            this.gbNavigate.TabStop = false;
            this.gbNavigate.Text = "Navigation";
            // 
            // btnNext
            // 
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.Location = new System.Drawing.Point(64, 39);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(25, 23);
            this.btnNext.TabIndex = 3;
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.Image = ((System.Drawing.Image)(resources.GetObject("btnLast.Image")));
            this.btnLast.Location = new System.Drawing.Point(40, 61);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(25, 23);
            this.btnLast.TabIndex = 2;
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // btnFirst
            // 
            this.btnFirst.Image = ((System.Drawing.Image)(resources.GetObject("btnFirst.Image")));
            this.btnFirst.Location = new System.Drawing.Point(40, 18);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(25, 23);
            this.btnFirst.TabIndex = 1;
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.Image")));
            this.btnPrevious.Location = new System.Drawing.Point(16, 39);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(25, 23);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // gbEditing
            // 
            this.gbEditing.Controls.Add(this.btnReload);
            this.gbEditing.Controls.Add(this.btnSave);
            this.gbEditing.Controls.Add(this.btnCancel);
            this.gbEditing.Controls.Add(this.btnRestore);
            this.gbEditing.Controls.Add(this.btnDelete);
            this.gbEditing.Controls.Add(this.btnNew);
            this.gbEditing.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbEditing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gbEditing.ForeColor = System.Drawing.Color.Teal;
            this.gbEditing.Location = new System.Drawing.Point(0, 0);
            this.gbEditing.Name = "gbEditing";
            this.gbEditing.Size = new System.Drawing.Size(281, 91);
            this.gbEditing.TabIndex = 1;
            this.gbEditing.TabStop = false;
            this.gbEditing.Text = "Editing";
            // 
            // btnReload
            // 
            this.btnReload.ForeColor = System.Drawing.Color.Black;
            this.btnReload.Image = global::VetExample.Properties.Resources.Command_Refresh_1_;
            this.btnReload.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReload.Location = new System.Drawing.Point(226, 24);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(49, 52);
            this.btnReload.TabIndex = 5;
            this.btnReload.Text = "Reload";
            this.btnReload.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Image = global::VetExample.Properties.Resources.Save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSave.Location = new System.Drawing.Point(173, 24);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(49, 52);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Image = global::VetExample.Properties.Resources.Command_Undo_1_;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(88, 53);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(70, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.ForeColor = System.Drawing.Color.Black;
            this.btnRestore.Image = global::VetExample.Properties.Resources.Recover_Deleted_Items;
            this.btnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestore.Location = new System.Drawing.Point(88, 24);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(70, 23);
            this.btnRestore.TabIndex = 2;
            this.btnRestore.Text = "Restore";
            this.btnRestore.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Image = global::VetExample.Properties.Resources.Report_Delete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(6, 53);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(70, 23);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.ForeColor = System.Drawing.Color.Black;
            this.btnNew.Image = global::VetExample.Properties.Resources.Item_New;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(6, 24);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(70, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssbResults,
            this.tsslFound});
            this.statusStrip1.Location = new System.Drawing.Point(0, 402);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(567, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tssbResults
            // 
            this.tssbResults.ForeColor = System.Drawing.Color.Lime;
            this.tssbResults.Name = "tssbResults";
            this.tssbResults.Size = new System.Drawing.Size(36, 17);
            this.tssbResults.Text = "Find: ";
            // 
            // tsslFound
            // 
            this.tsslFound.AutoSize = false;
            this.tsslFound.ForeColor = System.Drawing.Color.Maroon;
            this.tsslFound.Name = "tsslFound";
            this.tsslFound.Size = new System.Drawing.Size(60, 17);
            this.tsslFound.Text = "0";
            this.tsslFound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmBaseListDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 424);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "frmBaseListDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBaseListDetail";
            this.panel1.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.gbNavigate.ResumeLayout(false);
            this.gbEditing.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.GroupBox gbEditing;
        public System.Windows.Forms.Button btnNew;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnRestore;
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnReload;
        public System.Windows.Forms.GroupBox gbNavigate;
        public System.Windows.Forms.GroupBox gbFilter;
        public System.Windows.Forms.Button btnNext;
        public System.Windows.Forms.Button btnLast;
        public System.Windows.Forms.Button btnFirst;
        public System.Windows.Forms.Button btnPrevious;
        public System.Windows.Forms.ToolStripStatusLabel tssbResults;
        public System.Windows.Forms.CheckBox ckiJustValid;
        public System.Windows.Forms.ToolStripStatusLabel tsslFound;
    }
}
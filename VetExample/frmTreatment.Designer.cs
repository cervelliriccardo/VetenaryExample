namespace VetExample
{
    partial class frmTreatment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTreatment));
            this.treatmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbTreatmentType = new System.Windows.Forms.ComboBox();
            this.treatmentTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbTreatmentDate = new System.Windows.Forms.MaskedTextBox();
            this.lNote = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.tbValidityStartDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbValidityEndDate = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // treatmentBindingSource
            // 
            this.treatmentBindingSource.DataSource = typeof(VetExample.Entities.Treatment);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Treatment type:";
            // 
            // cbTreatmentType
            // 
            this.cbTreatmentType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.treatmentBindingSource, "treatmentType", true));
            this.cbTreatmentType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentBindingSource, "treatmentType", true));
            this.cbTreatmentType.DataSource = this.treatmentTypeBindingSource;
            this.cbTreatmentType.DisplayMember = "TRET_DESCRIPTION";
            this.cbTreatmentType.FormattingEnabled = true;
            this.cbTreatmentType.Location = new System.Drawing.Point(12, 35);
            this.cbTreatmentType.Name = "cbTreatmentType";
            this.cbTreatmentType.Size = new System.Drawing.Size(210, 21);
            this.cbTreatmentType.TabIndex = 5;
            // 
            // treatmentTypeBindingSource
            // 
            this.treatmentTypeBindingSource.DataSource = typeof(VetExample.Entities.TreatmentType);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Treatment date:";
            // 
            // tbTreatmentDate
            // 
            this.tbTreatmentDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentBindingSource, "TREA_TREATDATE_PK", true));
            this.tbTreatmentDate.Location = new System.Drawing.Point(243, 36);
            this.tbTreatmentDate.Mask = "00/00/0000";
            this.tbTreatmentDate.Name = "tbTreatmentDate";
            this.tbTreatmentDate.Size = new System.Drawing.Size(207, 20);
            this.tbTreatmentDate.TabIndex = 7;
            this.tbTreatmentDate.ValidatingType = typeof(System.DateTime);
            // 
            // lNote
            // 
            this.lNote.AutoSize = true;
            this.lNote.Location = new System.Drawing.Point(12, 133);
            this.lNote.Name = "lNote";
            this.lNote.Size = new System.Drawing.Size(33, 13);
            this.lNote.TabIndex = 8;
            this.lNote.Text = "Note:";
            // 
            // tbNote
            // 
            this.tbNote.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentBindingSource, "TREA_NOTE", true));
            this.tbNote.Location = new System.Drawing.Point(12, 149);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(438, 130);
            this.tbNote.TabIndex = 9;
            // 
            // tbValidityStartDate
            // 
            this.tbValidityStartDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentBindingSource, "validityStartDate", true));
            this.tbValidityStartDate.Location = new System.Drawing.Point(12, 92);
            this.tbValidityStartDate.Mask = "00/00/0000";
            this.tbValidityStartDate.Name = "tbValidityStartDate";
            this.tbValidityStartDate.Size = new System.Drawing.Size(207, 20);
            this.tbValidityStartDate.TabIndex = 11;
            this.tbValidityStartDate.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Validity start date:";
            // 
            // tbValidityEndDate
            // 
            this.tbValidityEndDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentBindingSource, "validityEndDate", true));
            this.tbValidityEndDate.Location = new System.Drawing.Point(243, 92);
            this.tbValidityEndDate.Mask = "00/00/0000";
            this.tbValidityEndDate.Name = "tbValidityEndDate";
            this.tbValidityEndDate.Size = new System.Drawing.Size(207, 20);
            this.tbValidityEndDate.TabIndex = 13;
            this.tbValidityEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Validity end date:";
            // 
            // frmTreatment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(462, 349);
            this.Controls.Add(this.tbValidityEndDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbValidityStartDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbNote);
            this.Controls.Add(this.lNote);
            this.Controls.Add(this.tbTreatmentDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTreatmentType);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTreatment";
            this.Text = "Treatment";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cbTreatmentType, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbTreatmentDate, 0);
            this.Controls.SetChildIndex(this.lNote, 0);
            this.Controls.SetChildIndex(this.tbNote, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.tbValidityStartDate, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbValidityEndDate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.treatmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentTypeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource treatmentBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTreatmentType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbTreatmentDate;
        private System.Windows.Forms.Label lNote;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.MaskedTextBox tbValidityStartDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbValidityEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource treatmentTypeBindingSource;
    }
}

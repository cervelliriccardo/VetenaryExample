namespace VetExample
{
    partial class frmTreatmentType
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
            System.Windows.Forms.Label Label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTreatmentType));
            this.tcListDetail = new System.Windows.Forms.TabControl();
            this.tpList = new System.Windows.Forms.TabPage();
            this.dgvTreatmentTypes = new System.Windows.Forms.DataGridView();
            this.TRET_ID_PK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRET_DESCRIPTION = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validityStartDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validityEndDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedByUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablePrefixDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inTxnDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.currentStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatmentTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tpDetails = new System.Windows.Forms.TabPage();
            this.lDataEliminazione = new System.Windows.Forms.Label();
            this.lDataUltimaModifica = new System.Windows.Forms.Label();
            this.lUtenteConfiguratore = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbValidityEndDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbValidityStartDate = new System.Windows.Forms.MaskedTextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            Label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbEditing.SuspendLayout();
            this.gbNavigate.SuspendLayout();
            this.gbFilter.SuspendLayout();
            this.tcListDetail.SuspendLayout();
            this.tpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatmentTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentTypeBindingSource)).BeginInit();
            this.tpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(684, 91);
            // 
            // gbFilter
            // 
            this.gbFilter.Size = new System.Drawing.Size(290, 91);
            // 
            // Label6
            // 
            Label6.Location = new System.Drawing.Point(5, 172);
            Label6.Name = "Label6";
            Label6.Size = new System.Drawing.Size(86, 15);
            Label6.TabIndex = 46;
            Label6.Text = "Last modified:";
            Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcListDetail
            // 
            this.tcListDetail.Controls.Add(this.tpList);
            this.tcListDetail.Controls.Add(this.tpDetails);
            this.tcListDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcListDetail.Location = new System.Drawing.Point(0, 91);
            this.tcListDetail.Name = "tcListDetail";
            this.tcListDetail.SelectedIndex = 0;
            this.tcListDetail.Size = new System.Drawing.Size(684, 315);
            this.tcListDetail.TabIndex = 2;
            // 
            // tpList
            // 
            this.tpList.Controls.Add(this.dgvTreatmentTypes);
            this.tpList.Location = new System.Drawing.Point(4, 22);
            this.tpList.Name = "tpList";
            this.tpList.Padding = new System.Windows.Forms.Padding(3);
            this.tpList.Size = new System.Drawing.Size(676, 289);
            this.tpList.TabIndex = 0;
            this.tpList.Text = "Treatment types";
            this.tpList.UseVisualStyleBackColor = true;
            // 
            // dgvTreatmentTypes
            // 
            this.dgvTreatmentTypes.AllowUserToAddRows = false;
            this.dgvTreatmentTypes.AllowUserToDeleteRows = false;
            this.dgvTreatmentTypes.AutoGenerateColumns = false;
            this.dgvTreatmentTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTreatmentTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreatmentTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TRET_ID_PK,
            this.TRET_DESCRIPTION,
            this.validityStartDateDataGridViewTextBoxColumn,
            this.validityEndDateDataGridViewTextBoxColumn,
            this.lastModifiedByDataGridViewTextBoxColumn,
            this.lastModifiedDateDataGridViewTextBoxColumn,
            this.deletedDateDataGridViewTextBoxColumn,
            this.lastModifiedByUserDataGridViewTextBoxColumn,
            this.tablePrefixDataGridViewTextBoxColumn,
            this.inTxnDataGridViewCheckBoxColumn,
            this.currentStateDataGridViewTextBoxColumn});
            this.dgvTreatmentTypes.DataSource = this.treatmentTypeBindingSource;
            this.dgvTreatmentTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTreatmentTypes.Location = new System.Drawing.Point(3, 3);
            this.dgvTreatmentTypes.MultiSelect = false;
            this.dgvTreatmentTypes.Name = "dgvTreatmentTypes";
            this.dgvTreatmentTypes.ReadOnly = true;
            this.dgvTreatmentTypes.Size = new System.Drawing.Size(670, 283);
            this.dgvTreatmentTypes.TabIndex = 0;
            this.dgvTreatmentTypes.Click += new System.EventHandler(this.dgvTreatmentTypes_Click);
            this.dgvTreatmentTypes.DoubleClick += new System.EventHandler(this.dgvTreatmentTypes_DoubleClick);
            // 
            // TRET_ID_PK
            // 
            this.TRET_ID_PK.DataPropertyName = "TRET_ID_PK";
            this.TRET_ID_PK.HeaderText = "Id";
            this.TRET_ID_PK.Name = "TRET_ID_PK";
            this.TRET_ID_PK.ReadOnly = true;
            this.TRET_ID_PK.Visible = false;
            // 
            // TRET_DESCRIPTION
            // 
            this.TRET_DESCRIPTION.DataPropertyName = "TRET_DESCRIPTION";
            this.TRET_DESCRIPTION.HeaderText = "Description";
            this.TRET_DESCRIPTION.Name = "TRET_DESCRIPTION";
            this.TRET_DESCRIPTION.ReadOnly = true;
            // 
            // validityStartDateDataGridViewTextBoxColumn
            // 
            this.validityStartDateDataGridViewTextBoxColumn.DataPropertyName = "validityStartDate";
            this.validityStartDateDataGridViewTextBoxColumn.HeaderText = "Validity start date";
            this.validityStartDateDataGridViewTextBoxColumn.Name = "validityStartDateDataGridViewTextBoxColumn";
            this.validityStartDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // validityEndDateDataGridViewTextBoxColumn
            // 
            this.validityEndDateDataGridViewTextBoxColumn.DataPropertyName = "validityEndDate";
            this.validityEndDateDataGridViewTextBoxColumn.HeaderText = "Validity end date";
            this.validityEndDateDataGridViewTextBoxColumn.Name = "validityEndDateDataGridViewTextBoxColumn";
            this.validityEndDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastModifiedByDataGridViewTextBoxColumn
            // 
            this.lastModifiedByDataGridViewTextBoxColumn.DataPropertyName = "lastModifiedBy";
            this.lastModifiedByDataGridViewTextBoxColumn.HeaderText = "lastModifiedBy";
            this.lastModifiedByDataGridViewTextBoxColumn.Name = "lastModifiedByDataGridViewTextBoxColumn";
            this.lastModifiedByDataGridViewTextBoxColumn.ReadOnly = true;
            this.lastModifiedByDataGridViewTextBoxColumn.Visible = false;
            // 
            // lastModifiedDateDataGridViewTextBoxColumn
            // 
            this.lastModifiedDateDataGridViewTextBoxColumn.DataPropertyName = "lastModifiedDate";
            this.lastModifiedDateDataGridViewTextBoxColumn.HeaderText = "Last modified date";
            this.lastModifiedDateDataGridViewTextBoxColumn.Name = "lastModifiedDateDataGridViewTextBoxColumn";
            this.lastModifiedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deletedDateDataGridViewTextBoxColumn
            // 
            this.deletedDateDataGridViewTextBoxColumn.DataPropertyName = "deletedDate";
            this.deletedDateDataGridViewTextBoxColumn.HeaderText = "Deleted date";
            this.deletedDateDataGridViewTextBoxColumn.Name = "deletedDateDataGridViewTextBoxColumn";
            this.deletedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // lastModifiedByUserDataGridViewTextBoxColumn
            // 
            this.lastModifiedByUserDataGridViewTextBoxColumn.DataPropertyName = "lastModifiedByUser";
            this.lastModifiedByUserDataGridViewTextBoxColumn.HeaderText = "Last modified by";
            this.lastModifiedByUserDataGridViewTextBoxColumn.Name = "lastModifiedByUserDataGridViewTextBoxColumn";
            this.lastModifiedByUserDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tablePrefixDataGridViewTextBoxColumn
            // 
            this.tablePrefixDataGridViewTextBoxColumn.DataPropertyName = "TablePrefix";
            this.tablePrefixDataGridViewTextBoxColumn.HeaderText = "TablePrefix";
            this.tablePrefixDataGridViewTextBoxColumn.Name = "tablePrefixDataGridViewTextBoxColumn";
            this.tablePrefixDataGridViewTextBoxColumn.ReadOnly = true;
            this.tablePrefixDataGridViewTextBoxColumn.Visible = false;
            // 
            // inTxnDataGridViewCheckBoxColumn
            // 
            this.inTxnDataGridViewCheckBoxColumn.DataPropertyName = "inTxn";
            this.inTxnDataGridViewCheckBoxColumn.HeaderText = "inTxn";
            this.inTxnDataGridViewCheckBoxColumn.Name = "inTxnDataGridViewCheckBoxColumn";
            this.inTxnDataGridViewCheckBoxColumn.ReadOnly = true;
            this.inTxnDataGridViewCheckBoxColumn.Visible = false;
            // 
            // currentStateDataGridViewTextBoxColumn
            // 
            this.currentStateDataGridViewTextBoxColumn.DataPropertyName = "CurrentState";
            this.currentStateDataGridViewTextBoxColumn.HeaderText = "CurrentState";
            this.currentStateDataGridViewTextBoxColumn.Name = "currentStateDataGridViewTextBoxColumn";
            this.currentStateDataGridViewTextBoxColumn.ReadOnly = true;
            this.currentStateDataGridViewTextBoxColumn.Visible = false;
            // 
            // treatmentTypeBindingSource
            // 
            this.treatmentTypeBindingSource.DataSource = typeof(VetExample.Entities.TreatmentType);
            this.treatmentTypeBindingSource.PositionChanged += new System.EventHandler(this.treatmentTypeBindingSource_PositionChanged);
            // 
            // tpDetails
            // 
            this.tpDetails.Controls.Add(this.lDataEliminazione);
            this.tpDetails.Controls.Add(this.lDataUltimaModifica);
            this.tpDetails.Controls.Add(this.lUtenteConfiguratore);
            this.tpDetails.Controls.Add(Label6);
            this.tpDetails.Controls.Add(this.label4);
            this.tpDetails.Controls.Add(this.label3);
            this.tpDetails.Controls.Add(this.tbValidityEndDate);
            this.tpDetails.Controls.Add(this.label2);
            this.tpDetails.Controls.Add(this.tbValidityStartDate);
            this.tpDetails.Controls.Add(this.tbDescription);
            this.tpDetails.Controls.Add(this.label1);
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetails.Size = new System.Drawing.Size(676, 289);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "Details";
            this.tpDetails.UseVisualStyleBackColor = true;
            // 
            // lDataEliminazione
            // 
            this.lDataEliminazione.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lDataEliminazione.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentTypeBindingSource, "deletedDate", true));
            this.lDataEliminazione.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lDataEliminazione.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lDataEliminazione.ForeColor = System.Drawing.Color.Silver;
            this.lDataEliminazione.Location = new System.Drawing.Point(274, 127);
            this.lDataEliminazione.Name = "lDataEliminazione";
            this.lDataEliminazione.Size = new System.Drawing.Size(100, 20);
            this.lDataEliminazione.TabIndex = 49;
            this.lDataEliminazione.Text = "...";
            this.lDataEliminazione.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lDataUltimaModifica
            // 
            this.lDataUltimaModifica.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lDataUltimaModifica.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentTypeBindingSource, "lastModifiedDate", true));
            this.lDataUltimaModifica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lDataUltimaModifica.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lDataUltimaModifica.ForeColor = System.Drawing.Color.Silver;
            this.lDataUltimaModifica.Location = new System.Drawing.Point(8, 187);
            this.lDataUltimaModifica.Name = "lDataUltimaModifica";
            this.lDataUltimaModifica.Size = new System.Drawing.Size(97, 20);
            this.lDataUltimaModifica.TabIndex = 48;
            this.lDataUltimaModifica.Text = "...";
            this.lDataUltimaModifica.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lUtenteConfiguratore
            // 
            this.lUtenteConfiguratore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lUtenteConfiguratore.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentTypeBindingSource, "lastModifiedByUser", true));
            this.lUtenteConfiguratore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lUtenteConfiguratore.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lUtenteConfiguratore.ForeColor = System.Drawing.Color.Silver;
            this.lUtenteConfiguratore.Location = new System.Drawing.Point(111, 187);
            this.lUtenteConfiguratore.Name = "lUtenteConfiguratore";
            this.lUtenteConfiguratore.Size = new System.Drawing.Size(263, 20);
            this.lUtenteConfiguratore.TabIndex = 47;
            this.lUtenteConfiguratore.Text = "...";
            this.lUtenteConfiguratore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 45;
            this.label4.Text = "Deleted date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 44;
            this.label3.Text = "Validity end date:";
            // 
            // tbValidityEndDate
            // 
            this.tbValidityEndDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentTypeBindingSource, "validityEndDate", true));
            this.tbValidityEndDate.Location = new System.Drawing.Point(141, 127);
            this.tbValidityEndDate.Mask = "00/00/0000";
            this.tbValidityEndDate.Name = "tbValidityEndDate";
            this.tbValidityEndDate.Size = new System.Drawing.Size(100, 20);
            this.tbValidityEndDate.TabIndex = 43;
            this.tbValidityEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Validity start date:";
            // 
            // tbValidityStartDate
            // 
            this.tbValidityStartDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentTypeBindingSource, "validityStartDate", true));
            this.tbValidityStartDate.Location = new System.Drawing.Point(8, 127);
            this.tbValidityStartDate.Mask = "00/00/0000";
            this.tbValidityStartDate.Name = "tbValidityStartDate";
            this.tbValidityStartDate.Size = new System.Drawing.Size(100, 20);
            this.tbValidityStartDate.TabIndex = 41;
            this.tbValidityStartDate.ValidatingType = typeof(System.DateTime);
            // 
            // tbDescription
            // 
            this.tbDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.treatmentTypeBindingSource, "TRET_DESCRIPTION", true));
            this.tbDescription.Location = new System.Drawing.Point(8, 53);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(366, 20);
            this.tbDescription.TabIndex = 40;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Description:";
            // 
            // frmTreatmentType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(684, 428);
            this.Controls.Add(this.tcListDetail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTreatmentType";
            this.Text = "Treatment Type";
            this.Shown += new System.EventHandler(this.frmTreatmentType_Shown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tcListDetail, 0);
            this.panel1.ResumeLayout(false);
            this.gbEditing.ResumeLayout(false);
            this.gbNavigate.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            this.tcListDetail.ResumeLayout(false);
            this.tpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatmentTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentTypeBindingSource)).EndInit();
            this.tpDetails.ResumeLayout(false);
            this.tpDetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcListDetail;
        private System.Windows.Forms.TabPage tpList;
        private System.Windows.Forms.TabPage tpDetails;
        private System.Windows.Forms.DataGridView dgvTreatmentTypes;
        private System.Windows.Forms.BindingSource treatmentTypeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRET_ID_PK;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRET_DESCRIPTION;
        private System.Windows.Forms.DataGridViewTextBoxColumn validityStartDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn validityEndDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deletedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedByUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tablePrefixDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn inTxnDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentStateDataGridViewTextBoxColumn;
        internal System.Windows.Forms.Label lDataEliminazione;
        internal System.Windows.Forms.Label lDataUltimaModifica;
        internal System.Windows.Forms.Label lUtenteConfiguratore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbValidityEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox tbValidityStartDate;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Label label1;
    }
}

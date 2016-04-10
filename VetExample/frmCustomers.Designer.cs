namespace VetExample
{
    partial class frmCustomers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomers));
            this.customerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbCustomer = new System.Windows.Forms.GroupBox();
            this.tbValidityStartDate = new System.Windows.Forms.MaskedTextBox();
            this.tbValidityEndDate = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lLastModifiedDate = new System.Windows.Forms.Label();
            this.lLastModifiedBy = new System.Windows.Forms.Label();
            this.lDeletedDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.lPhone = new System.Windows.Forms.Label();
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvAnimals = new System.Windows.Forms.DataGridView();
            this.aNIMIDPKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aNIMCUSTIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aNIMNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aNIMANMTIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.animalTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aNIMBIRTHDATEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validityStartDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validityEndDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedByDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedByUserDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablePrefixDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inTxnDataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.currentStateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.animalsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRestoreAnimal = new System.Windows.Forms.Button();
            this.btnDeleteAnimal = new System.Windows.Forms.Button();
            this.btnEditAnimal = new System.Windows.Forms.Button();
            this.btnNewAnimal = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvTreatments = new System.Windows.Forms.DataGridView();
            this.tREAANIMIDPKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.animalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tREATRETIDPKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatmentTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tREATREATDATEPKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tREAPERFORMEDBYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatmentPerformedByUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tREANOTEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validityStartDateDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validityEndDateDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedByDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedDateDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedDateDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedByUserDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablePrefixDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inTxnDataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.currentStateDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treatmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnRestoreTreatment = new System.Windows.Forms.Button();
            this.btnDeleteTreatment = new System.Windows.Forms.Button();
            this.btnEditTreatment = new System.Windows.Forms.Button();
            this.btnNewTreatment = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tcListDetail = new System.Windows.Forms.TabControl();
            this.tpList = new System.Windows.Forms.TabPage();
            this.dgvCustomers = new System.Windows.Forms.DataGridView();
            this.cUSTIDPKDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTNAMEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTSURMANEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cUSTTELNUMDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validityStartDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validityEndDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deletedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastModifiedByUserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tablePrefixDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inTxnDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.currentStateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpDetails = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTreatmentType = new System.Windows.Forms.Button();
            this.btnAnimalType = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbEditing.SuspendLayout();
            this.gbNavigate.SuspendLayout();
            this.gbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbCustomer.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalsBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentsBindingSource)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tcListDetail.SuspendLayout();
            this.tpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).BeginInit();
            this.tpDetails.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Size = new System.Drawing.Size(988, 91);
            this.panel1.Controls.SetChildIndex(this.gbEditing, 0);
            this.panel1.Controls.SetChildIndex(this.gbNavigate, 0);
            this.panel1.Controls.SetChildIndex(this.gbFilter, 0);
            this.panel1.Controls.SetChildIndex(this.groupBox1, 0);
            // 
            // gbFilter
            // 
            this.gbFilter.Dock = System.Windows.Forms.DockStyle.Left;
            // 
            // customerBindingSource
            // 
            this.customerBindingSource.DataSource = typeof(VetExample.Entities.Customer);
            this.customerBindingSource.PositionChanged += new System.EventHandler(this.customerBindingSource_PositionChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Panel2.Controls.Add(this.panel5);
            this.splitContainer1.Size = new System.Drawing.Size(974, 466);
            this.splitContainer1.SplitterDistance = 267;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbCustomer);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel3);
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Size = new System.Drawing.Size(974, 267);
            this.splitContainer2.SplitterDistance = 373;
            this.splitContainer2.TabIndex = 0;
            // 
            // gbCustomer
            // 
            this.gbCustomer.Controls.Add(this.tbValidityStartDate);
            this.gbCustomer.Controls.Add(this.tbValidityEndDate);
            this.gbCustomer.Controls.Add(this.label8);
            this.gbCustomer.Controls.Add(this.lLastModifiedDate);
            this.gbCustomer.Controls.Add(this.lLastModifiedBy);
            this.gbCustomer.Controls.Add(this.lDeletedDate);
            this.gbCustomer.Controls.Add(this.label6);
            this.gbCustomer.Controls.Add(this.label5);
            this.gbCustomer.Controls.Add(this.label4);
            this.gbCustomer.Controls.Add(this.tbPhone);
            this.gbCustomer.Controls.Add(this.lPhone);
            this.gbCustomer.Controls.Add(this.tbSurname);
            this.gbCustomer.Controls.Add(this.label2);
            this.gbCustomer.Controls.Add(this.tbName);
            this.gbCustomer.Controls.Add(this.label1);
            this.gbCustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbCustomer.Location = new System.Drawing.Point(0, 0);
            this.gbCustomer.Name = "gbCustomer";
            this.gbCustomer.Size = new System.Drawing.Size(373, 267);
            this.gbCustomer.TabIndex = 0;
            this.gbCustomer.TabStop = false;
            this.gbCustomer.Text = "Customer";
            // 
            // tbValidityStartDate
            // 
            this.tbValidityStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValidityStartDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "validityStartDate", true));
            this.tbValidityStartDate.Location = new System.Drawing.Point(105, 112);
            this.tbValidityStartDate.Mask = "00/00/0000";
            this.tbValidityStartDate.Name = "tbValidityStartDate";
            this.tbValidityStartDate.Size = new System.Drawing.Size(263, 20);
            this.tbValidityStartDate.TabIndex = 7;
            this.tbValidityStartDate.ValidatingType = typeof(System.DateTime);
            // 
            // tbValidityEndDate
            // 
            this.tbValidityEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbValidityEndDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "validityEndDate", true));
            this.tbValidityEndDate.Location = new System.Drawing.Point(105, 144);
            this.tbValidityEndDate.Mask = "00/00/0000";
            this.tbValidityEndDate.Name = "tbValidityEndDate";
            this.tbValidityEndDate.Size = new System.Drawing.Size(263, 20);
            this.tbValidityEndDate.TabIndex = 9;
            this.tbValidityEndDate.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label8.Location = new System.Drawing.Point(5, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Last modify:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lLastModifiedDate
            // 
            this.lLastModifiedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lLastModifiedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lLastModifiedDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "lastModifiedDate", true));
            this.lLastModifiedDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lLastModifiedDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lLastModifiedDate.ForeColor = System.Drawing.Color.Silver;
            this.lLastModifiedDate.Location = new System.Drawing.Point(105, 213);
            this.lLastModifiedDate.Name = "lLastModifiedDate";
            this.lLastModifiedDate.Size = new System.Drawing.Size(87, 20);
            this.lLastModifiedDate.TabIndex = 14;
            this.lLastModifiedDate.Text = "...";
            this.lLastModifiedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lLastModifiedBy
            // 
            this.lLastModifiedBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lLastModifiedBy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lLastModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lLastModifiedBy.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "lastModifiedByUser", true));
            this.lLastModifiedBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lLastModifiedBy.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lLastModifiedBy.ForeColor = System.Drawing.Color.Silver;
            this.lLastModifiedBy.Location = new System.Drawing.Point(197, 213);
            this.lLastModifiedBy.Name = "lLastModifiedBy";
            this.lLastModifiedBy.Size = new System.Drawing.Size(171, 20);
            this.lLastModifiedBy.TabIndex = 13;
            this.lLastModifiedBy.Text = "...";
            this.lLastModifiedBy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lDeletedDate
            // 
            this.lDeletedDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lDeletedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lDeletedDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lDeletedDate.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "deletedDate", true));
            this.lDeletedDate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lDeletedDate.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lDeletedDate.ForeColor = System.Drawing.Color.Silver;
            this.lDeletedDate.Location = new System.Drawing.Point(105, 178);
            this.lDeletedDate.Name = "lDeletedDate";
            this.lDeletedDate.Size = new System.Drawing.Size(263, 20);
            this.lDeletedDate.TabIndex = 12;
            this.lDeletedDate.Text = "...";
            this.lDeletedDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.Location = new System.Drawing.Point(5, 182);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Deleted date:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.Location = new System.Drawing.Point(5, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Validity end date:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label4.Location = new System.Drawing.Point(5, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Validity start date:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPhone
            // 
            this.tbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "CUST_TEL_NUM", true));
            this.tbPhone.Location = new System.Drawing.Point(105, 83);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(263, 20);
            this.tbPhone.TabIndex = 5;
            // 
            // lPhone
            // 
            this.lPhone.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lPhone.Location = new System.Drawing.Point(5, 86);
            this.lPhone.Name = "lPhone";
            this.lPhone.Size = new System.Drawing.Size(94, 13);
            this.lPhone.TabIndex = 4;
            this.lPhone.Text = "Phone:";
            this.lPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSurname
            // 
            this.tbSurname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSurname.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "CUST_SURMANE", true));
            this.tbSurname.Location = new System.Drawing.Point(105, 51);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(263, 20);
            this.tbSurname.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.Location = new System.Drawing.Point(5, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Surname:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.customerBindingSource, "CUST_NAME", true));
            this.tbName.Location = new System.Drawing.Point(105, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(263, 20);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel3.Controls.Add(this.dgvAnimals);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(597, 237);
            this.panel3.TabIndex = 1;
            // 
            // dgvAnimals
            // 
            this.dgvAnimals.AllowUserToAddRows = false;
            this.dgvAnimals.AllowUserToDeleteRows = false;
            this.dgvAnimals.AutoGenerateColumns = false;
            this.dgvAnimals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAnimals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.aNIMIDPKDataGridViewTextBoxColumn,
            this.aNIMCUSTIDDataGridViewTextBoxColumn,
            this.customerDataGridViewTextBoxColumn,
            this.aNIMNAMEDataGridViewTextBoxColumn,
            this.aNIMANMTIDDataGridViewTextBoxColumn,
            this.animalTypeDataGridViewTextBoxColumn,
            this.aNIMBIRTHDATEDataGridViewTextBoxColumn,
            this.validityStartDateDataGridViewTextBoxColumn1,
            this.validityEndDateDataGridViewTextBoxColumn1,
            this.lastModifiedByDataGridViewTextBoxColumn1,
            this.lastModifiedDateDataGridViewTextBoxColumn1,
            this.deletedDateDataGridViewTextBoxColumn1,
            this.lastModifiedByUserDataGridViewTextBoxColumn1,
            this.tablePrefixDataGridViewTextBoxColumn1,
            this.inTxnDataGridViewCheckBoxColumn1,
            this.currentStateDataGridViewTextBoxColumn1});
            this.dgvAnimals.DataSource = this.animalsBindingSource;
            this.dgvAnimals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnimals.Location = new System.Drawing.Point(0, 0);
            this.dgvAnimals.MultiSelect = false;
            this.dgvAnimals.Name = "dgvAnimals";
            this.dgvAnimals.ReadOnly = true;
            this.dgvAnimals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnimals.Size = new System.Drawing.Size(597, 237);
            this.dgvAnimals.TabIndex = 0;
            this.dgvAnimals.DoubleClick += new System.EventHandler(this.dgvAnimals_DoubleClick);
            // 
            // aNIMIDPKDataGridViewTextBoxColumn
            // 
            this.aNIMIDPKDataGridViewTextBoxColumn.DataPropertyName = "ANIM_ID_PK";
            this.aNIMIDPKDataGridViewTextBoxColumn.HeaderText = "Id";
            this.aNIMIDPKDataGridViewTextBoxColumn.Name = "aNIMIDPKDataGridViewTextBoxColumn";
            this.aNIMIDPKDataGridViewTextBoxColumn.ReadOnly = true;
            this.aNIMIDPKDataGridViewTextBoxColumn.Visible = false;
            // 
            // aNIMCUSTIDDataGridViewTextBoxColumn
            // 
            this.aNIMCUSTIDDataGridViewTextBoxColumn.DataPropertyName = "ANIM_CUST_ID";
            this.aNIMCUSTIDDataGridViewTextBoxColumn.HeaderText = "ANIM_CUST_ID";
            this.aNIMCUSTIDDataGridViewTextBoxColumn.Name = "aNIMCUSTIDDataGridViewTextBoxColumn";
            this.aNIMCUSTIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.aNIMCUSTIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // customerDataGridViewTextBoxColumn
            // 
            this.customerDataGridViewTextBoxColumn.DataPropertyName = "customer";
            this.customerDataGridViewTextBoxColumn.HeaderText = "customer";
            this.customerDataGridViewTextBoxColumn.Name = "customerDataGridViewTextBoxColumn";
            this.customerDataGridViewTextBoxColumn.ReadOnly = true;
            this.customerDataGridViewTextBoxColumn.Visible = false;
            // 
            // aNIMNAMEDataGridViewTextBoxColumn
            // 
            this.aNIMNAMEDataGridViewTextBoxColumn.DataPropertyName = "ANIM_NAME";
            this.aNIMNAMEDataGridViewTextBoxColumn.HeaderText = "Name";
            this.aNIMNAMEDataGridViewTextBoxColumn.Name = "aNIMNAMEDataGridViewTextBoxColumn";
            this.aNIMNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aNIMANMTIDDataGridViewTextBoxColumn
            // 
            this.aNIMANMTIDDataGridViewTextBoxColumn.DataPropertyName = "ANIM_ANMT_ID";
            this.aNIMANMTIDDataGridViewTextBoxColumn.HeaderText = "ANIM_ANMT_ID";
            this.aNIMANMTIDDataGridViewTextBoxColumn.Name = "aNIMANMTIDDataGridViewTextBoxColumn";
            this.aNIMANMTIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.aNIMANMTIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // animalTypeDataGridViewTextBoxColumn
            // 
            this.animalTypeDataGridViewTextBoxColumn.DataPropertyName = "animalType";
            this.animalTypeDataGridViewTextBoxColumn.HeaderText = "Animal type";
            this.animalTypeDataGridViewTextBoxColumn.Name = "animalTypeDataGridViewTextBoxColumn";
            this.animalTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // aNIMBIRTHDATEDataGridViewTextBoxColumn
            // 
            this.aNIMBIRTHDATEDataGridViewTextBoxColumn.DataPropertyName = "ANIM_BIRTHDATE";
            this.aNIMBIRTHDATEDataGridViewTextBoxColumn.HeaderText = "Animal birthdate";
            this.aNIMBIRTHDATEDataGridViewTextBoxColumn.Name = "aNIMBIRTHDATEDataGridViewTextBoxColumn";
            this.aNIMBIRTHDATEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // validityStartDateDataGridViewTextBoxColumn1
            // 
            this.validityStartDateDataGridViewTextBoxColumn1.DataPropertyName = "validityStartDate";
            this.validityStartDateDataGridViewTextBoxColumn1.HeaderText = "Validity start date";
            this.validityStartDateDataGridViewTextBoxColumn1.Name = "validityStartDateDataGridViewTextBoxColumn1";
            this.validityStartDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // validityEndDateDataGridViewTextBoxColumn1
            // 
            this.validityEndDateDataGridViewTextBoxColumn1.DataPropertyName = "validityEndDate";
            this.validityEndDateDataGridViewTextBoxColumn1.HeaderText = "Validity end date";
            this.validityEndDateDataGridViewTextBoxColumn1.Name = "validityEndDateDataGridViewTextBoxColumn1";
            this.validityEndDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // lastModifiedByDataGridViewTextBoxColumn1
            // 
            this.lastModifiedByDataGridViewTextBoxColumn1.DataPropertyName = "lastModifiedBy";
            this.lastModifiedByDataGridViewTextBoxColumn1.HeaderText = "Last ModifiedBy";
            this.lastModifiedByDataGridViewTextBoxColumn1.Name = "lastModifiedByDataGridViewTextBoxColumn1";
            this.lastModifiedByDataGridViewTextBoxColumn1.ReadOnly = true;
            this.lastModifiedByDataGridViewTextBoxColumn1.Visible = false;
            // 
            // lastModifiedDateDataGridViewTextBoxColumn1
            // 
            this.lastModifiedDateDataGridViewTextBoxColumn1.DataPropertyName = "lastModifiedDate";
            this.lastModifiedDateDataGridViewTextBoxColumn1.HeaderText = "Last modified date";
            this.lastModifiedDateDataGridViewTextBoxColumn1.Name = "lastModifiedDateDataGridViewTextBoxColumn1";
            this.lastModifiedDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // deletedDateDataGridViewTextBoxColumn1
            // 
            this.deletedDateDataGridViewTextBoxColumn1.DataPropertyName = "deletedDate";
            this.deletedDateDataGridViewTextBoxColumn1.HeaderText = "Deleted date";
            this.deletedDateDataGridViewTextBoxColumn1.Name = "deletedDateDataGridViewTextBoxColumn1";
            this.deletedDateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // lastModifiedByUserDataGridViewTextBoxColumn1
            // 
            this.lastModifiedByUserDataGridViewTextBoxColumn1.DataPropertyName = "lastModifiedByUser";
            this.lastModifiedByUserDataGridViewTextBoxColumn1.HeaderText = "Last modified by";
            this.lastModifiedByUserDataGridViewTextBoxColumn1.Name = "lastModifiedByUserDataGridViewTextBoxColumn1";
            this.lastModifiedByUserDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // tablePrefixDataGridViewTextBoxColumn1
            // 
            this.tablePrefixDataGridViewTextBoxColumn1.DataPropertyName = "TablePrefix";
            this.tablePrefixDataGridViewTextBoxColumn1.HeaderText = "TablePrefix";
            this.tablePrefixDataGridViewTextBoxColumn1.Name = "tablePrefixDataGridViewTextBoxColumn1";
            this.tablePrefixDataGridViewTextBoxColumn1.ReadOnly = true;
            this.tablePrefixDataGridViewTextBoxColumn1.Visible = false;
            // 
            // inTxnDataGridViewCheckBoxColumn1
            // 
            this.inTxnDataGridViewCheckBoxColumn1.DataPropertyName = "inTxn";
            this.inTxnDataGridViewCheckBoxColumn1.HeaderText = "inTxn";
            this.inTxnDataGridViewCheckBoxColumn1.Name = "inTxnDataGridViewCheckBoxColumn1";
            this.inTxnDataGridViewCheckBoxColumn1.ReadOnly = true;
            this.inTxnDataGridViewCheckBoxColumn1.Visible = false;
            // 
            // currentStateDataGridViewTextBoxColumn1
            // 
            this.currentStateDataGridViewTextBoxColumn1.DataPropertyName = "CurrentState";
            this.currentStateDataGridViewTextBoxColumn1.HeaderText = "CurrentState";
            this.currentStateDataGridViewTextBoxColumn1.Name = "currentStateDataGridViewTextBoxColumn1";
            this.currentStateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.currentStateDataGridViewTextBoxColumn1.Visible = false;
            // 
            // animalsBindingSource
            // 
            this.animalsBindingSource.AllowNew = true;
            this.animalsBindingSource.DataMember = "animals";
            this.animalsBindingSource.DataSource = this.customerBindingSource;
            this.animalsBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.animalsBindingSource_AddingNew);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel2.Controls.Add(this.btnRestoreAnimal);
            this.panel2.Controls.Add(this.btnDeleteAnimal);
            this.panel2.Controls.Add(this.btnEditAnimal);
            this.panel2.Controls.Add(this.btnNewAnimal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(597, 30);
            this.panel2.TabIndex = 0;
            // 
            // btnRestoreAnimal
            // 
            this.btnRestoreAnimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestoreAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestoreAnimal.Image = global::VetExample.Properties.Resources.Recover_Deleted_Items;
            this.btnRestoreAnimal.Location = new System.Drawing.Point(568, 4);
            this.btnRestoreAnimal.Name = "btnRestoreAnimal";
            this.btnRestoreAnimal.Size = new System.Drawing.Size(22, 22);
            this.btnRestoreAnimal.TabIndex = 3;
            this.btnRestoreAnimal.UseVisualStyleBackColor = true;
            this.btnRestoreAnimal.Click += new System.EventHandler(this.btnRestoreAnimal_Click);
            // 
            // btnDeleteAnimal
            // 
            this.btnDeleteAnimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteAnimal.Image = global::VetExample.Properties.Resources.Report_Delete;
            this.btnDeleteAnimal.Location = new System.Drawing.Point(540, 4);
            this.btnDeleteAnimal.Name = "btnDeleteAnimal";
            this.btnDeleteAnimal.Size = new System.Drawing.Size(22, 22);
            this.btnDeleteAnimal.TabIndex = 2;
            this.btnDeleteAnimal.UseVisualStyleBackColor = true;
            this.btnDeleteAnimal.Click += new System.EventHandler(this.btnDeleteAnimal_Click);
            // 
            // btnEditAnimal
            // 
            this.btnEditAnimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditAnimal.Image = global::VetExample.Properties.Resources.Edit;
            this.btnEditAnimal.Location = new System.Drawing.Point(512, 4);
            this.btnEditAnimal.Name = "btnEditAnimal";
            this.btnEditAnimal.Size = new System.Drawing.Size(22, 22);
            this.btnEditAnimal.TabIndex = 1;
            this.btnEditAnimal.UseVisualStyleBackColor = true;
            this.btnEditAnimal.Click += new System.EventHandler(this.btnEditAnimal_Click);
            // 
            // btnNewAnimal
            // 
            this.btnNewAnimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewAnimal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewAnimal.Image = global::VetExample.Properties.Resources.Item_New;
            this.btnNewAnimal.Location = new System.Drawing.Point(484, 4);
            this.btnNewAnimal.Name = "btnNewAnimal";
            this.btnNewAnimal.Size = new System.Drawing.Size(22, 22);
            this.btnNewAnimal.TabIndex = 0;
            this.btnNewAnimal.UseVisualStyleBackColor = true;
            this.btnNewAnimal.Click += new System.EventHandler(this.btnNewAnimal_Click);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvTreatments);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 30);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(974, 165);
            this.panel6.TabIndex = 5;
            // 
            // dgvTreatments
            // 
            this.dgvTreatments.AllowUserToAddRows = false;
            this.dgvTreatments.AllowUserToDeleteRows = false;
            this.dgvTreatments.AutoGenerateColumns = false;
            this.dgvTreatments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTreatments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTreatments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tREAANIMIDPKDataGridViewTextBoxColumn,
            this.animalDataGridViewTextBoxColumn,
            this.tREATRETIDPKDataGridViewTextBoxColumn,
            this.treatmentTypeDataGridViewTextBoxColumn,
            this.tREATREATDATEPKDataGridViewTextBoxColumn,
            this.tREAPERFORMEDBYDataGridViewTextBoxColumn,
            this.treatmentPerformedByUserDataGridViewTextBoxColumn,
            this.tREANOTEDataGridViewTextBoxColumn,
            this.validityStartDateDataGridViewTextBoxColumn2,
            this.validityEndDateDataGridViewTextBoxColumn2,
            this.lastModifiedByDataGridViewTextBoxColumn2,
            this.lastModifiedDateDataGridViewTextBoxColumn2,
            this.deletedDateDataGridViewTextBoxColumn2,
            this.lastModifiedByUserDataGridViewTextBoxColumn2,
            this.tablePrefixDataGridViewTextBoxColumn2,
            this.inTxnDataGridViewCheckBoxColumn2,
            this.currentStateDataGridViewTextBoxColumn2});
            this.dgvTreatments.DataSource = this.treatmentsBindingSource;
            this.dgvTreatments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTreatments.Location = new System.Drawing.Point(0, 0);
            this.dgvTreatments.MultiSelect = false;
            this.dgvTreatments.Name = "dgvTreatments";
            this.dgvTreatments.ReadOnly = true;
            this.dgvTreatments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTreatments.Size = new System.Drawing.Size(974, 165);
            this.dgvTreatments.TabIndex = 1;
            this.dgvTreatments.DoubleClick += new System.EventHandler(this.dgvTreatments_DoubleClick);
            // 
            // tREAANIMIDPKDataGridViewTextBoxColumn
            // 
            this.tREAANIMIDPKDataGridViewTextBoxColumn.DataPropertyName = "TREA_ANIM_ID_PK";
            this.tREAANIMIDPKDataGridViewTextBoxColumn.HeaderText = "Id";
            this.tREAANIMIDPKDataGridViewTextBoxColumn.Name = "tREAANIMIDPKDataGridViewTextBoxColumn";
            this.tREAANIMIDPKDataGridViewTextBoxColumn.ReadOnly = true;
            this.tREAANIMIDPKDataGridViewTextBoxColumn.Visible = false;
            // 
            // animalDataGridViewTextBoxColumn
            // 
            this.animalDataGridViewTextBoxColumn.DataPropertyName = "animal";
            this.animalDataGridViewTextBoxColumn.HeaderText = "animal";
            this.animalDataGridViewTextBoxColumn.Name = "animalDataGridViewTextBoxColumn";
            this.animalDataGridViewTextBoxColumn.ReadOnly = true;
            this.animalDataGridViewTextBoxColumn.Visible = false;
            // 
            // tREATRETIDPKDataGridViewTextBoxColumn
            // 
            this.tREATRETIDPKDataGridViewTextBoxColumn.DataPropertyName = "TREA_TRET_ID_PK";
            this.tREATRETIDPKDataGridViewTextBoxColumn.HeaderText = "TREA_TRET_ID_PK";
            this.tREATRETIDPKDataGridViewTextBoxColumn.Name = "tREATRETIDPKDataGridViewTextBoxColumn";
            this.tREATRETIDPKDataGridViewTextBoxColumn.ReadOnly = true;
            this.tREATRETIDPKDataGridViewTextBoxColumn.Visible = false;
            // 
            // treatmentTypeDataGridViewTextBoxColumn
            // 
            this.treatmentTypeDataGridViewTextBoxColumn.DataPropertyName = "treatmentType";
            this.treatmentTypeDataGridViewTextBoxColumn.HeaderText = "Treatment type";
            this.treatmentTypeDataGridViewTextBoxColumn.Name = "treatmentTypeDataGridViewTextBoxColumn";
            this.treatmentTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tREATREATDATEPKDataGridViewTextBoxColumn
            // 
            this.tREATREATDATEPKDataGridViewTextBoxColumn.DataPropertyName = "TREA_TREATDATE_PK";
            this.tREATREATDATEPKDataGridViewTextBoxColumn.HeaderText = "Treatment date";
            this.tREATREATDATEPKDataGridViewTextBoxColumn.Name = "tREATREATDATEPKDataGridViewTextBoxColumn";
            this.tREATREATDATEPKDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tREAPERFORMEDBYDataGridViewTextBoxColumn
            // 
            this.tREAPERFORMEDBYDataGridViewTextBoxColumn.DataPropertyName = "TREA_PERFORMEDBY";
            this.tREAPERFORMEDBYDataGridViewTextBoxColumn.HeaderText = "Treatmentperformedby";
            this.tREAPERFORMEDBYDataGridViewTextBoxColumn.Name = "tREAPERFORMEDBYDataGridViewTextBoxColumn";
            this.tREAPERFORMEDBYDataGridViewTextBoxColumn.ReadOnly = true;
            this.tREAPERFORMEDBYDataGridViewTextBoxColumn.Visible = false;
            // 
            // treatmentPerformedByUserDataGridViewTextBoxColumn
            // 
            this.treatmentPerformedByUserDataGridViewTextBoxColumn.DataPropertyName = "treatmentPerformedByUser";
            this.treatmentPerformedByUserDataGridViewTextBoxColumn.HeaderText = "Treatment performed by";
            this.treatmentPerformedByUserDataGridViewTextBoxColumn.Name = "treatmentPerformedByUserDataGridViewTextBoxColumn";
            this.treatmentPerformedByUserDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tREANOTEDataGridViewTextBoxColumn
            // 
            this.tREANOTEDataGridViewTextBoxColumn.DataPropertyName = "TREA_NOTE";
            this.tREANOTEDataGridViewTextBoxColumn.HeaderText = "Note";
            this.tREANOTEDataGridViewTextBoxColumn.Name = "tREANOTEDataGridViewTextBoxColumn";
            this.tREANOTEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // validityStartDateDataGridViewTextBoxColumn2
            // 
            this.validityStartDateDataGridViewTextBoxColumn2.DataPropertyName = "validityStartDate";
            this.validityStartDateDataGridViewTextBoxColumn2.HeaderText = "Validity start date";
            this.validityStartDateDataGridViewTextBoxColumn2.Name = "validityStartDateDataGridViewTextBoxColumn2";
            this.validityStartDateDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // validityEndDateDataGridViewTextBoxColumn2
            // 
            this.validityEndDateDataGridViewTextBoxColumn2.DataPropertyName = "validityEndDate";
            this.validityEndDateDataGridViewTextBoxColumn2.HeaderText = "Validity end date";
            this.validityEndDateDataGridViewTextBoxColumn2.Name = "validityEndDateDataGridViewTextBoxColumn2";
            this.validityEndDateDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // lastModifiedByDataGridViewTextBoxColumn2
            // 
            this.lastModifiedByDataGridViewTextBoxColumn2.DataPropertyName = "lastModifiedBy";
            this.lastModifiedByDataGridViewTextBoxColumn2.HeaderText = "lastModifiedBy";
            this.lastModifiedByDataGridViewTextBoxColumn2.Name = "lastModifiedByDataGridViewTextBoxColumn2";
            this.lastModifiedByDataGridViewTextBoxColumn2.ReadOnly = true;
            this.lastModifiedByDataGridViewTextBoxColumn2.Visible = false;
            // 
            // lastModifiedDateDataGridViewTextBoxColumn2
            // 
            this.lastModifiedDateDataGridViewTextBoxColumn2.DataPropertyName = "lastModifiedDate";
            this.lastModifiedDateDataGridViewTextBoxColumn2.HeaderText = "Last modified date";
            this.lastModifiedDateDataGridViewTextBoxColumn2.Name = "lastModifiedDateDataGridViewTextBoxColumn2";
            this.lastModifiedDateDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // deletedDateDataGridViewTextBoxColumn2
            // 
            this.deletedDateDataGridViewTextBoxColumn2.DataPropertyName = "deletedDate";
            this.deletedDateDataGridViewTextBoxColumn2.HeaderText = "Deleted date";
            this.deletedDateDataGridViewTextBoxColumn2.Name = "deletedDateDataGridViewTextBoxColumn2";
            this.deletedDateDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // lastModifiedByUserDataGridViewTextBoxColumn2
            // 
            this.lastModifiedByUserDataGridViewTextBoxColumn2.DataPropertyName = "lastModifiedByUser";
            this.lastModifiedByUserDataGridViewTextBoxColumn2.HeaderText = "Last modified by";
            this.lastModifiedByUserDataGridViewTextBoxColumn2.Name = "lastModifiedByUserDataGridViewTextBoxColumn2";
            this.lastModifiedByUserDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // tablePrefixDataGridViewTextBoxColumn2
            // 
            this.tablePrefixDataGridViewTextBoxColumn2.DataPropertyName = "TablePrefix";
            this.tablePrefixDataGridViewTextBoxColumn2.HeaderText = "TablePrefix";
            this.tablePrefixDataGridViewTextBoxColumn2.Name = "tablePrefixDataGridViewTextBoxColumn2";
            this.tablePrefixDataGridViewTextBoxColumn2.ReadOnly = true;
            this.tablePrefixDataGridViewTextBoxColumn2.Visible = false;
            // 
            // inTxnDataGridViewCheckBoxColumn2
            // 
            this.inTxnDataGridViewCheckBoxColumn2.DataPropertyName = "inTxn";
            this.inTxnDataGridViewCheckBoxColumn2.HeaderText = "inTxn";
            this.inTxnDataGridViewCheckBoxColumn2.Name = "inTxnDataGridViewCheckBoxColumn2";
            this.inTxnDataGridViewCheckBoxColumn2.ReadOnly = true;
            this.inTxnDataGridViewCheckBoxColumn2.Visible = false;
            // 
            // currentStateDataGridViewTextBoxColumn2
            // 
            this.currentStateDataGridViewTextBoxColumn2.DataPropertyName = "CurrentState";
            this.currentStateDataGridViewTextBoxColumn2.HeaderText = "CurrentState";
            this.currentStateDataGridViewTextBoxColumn2.Name = "currentStateDataGridViewTextBoxColumn2";
            this.currentStateDataGridViewTextBoxColumn2.ReadOnly = true;
            this.currentStateDataGridViewTextBoxColumn2.Visible = false;
            // 
            // treatmentsBindingSource
            // 
            this.treatmentsBindingSource.AllowNew = true;
            this.treatmentsBindingSource.DataMember = "treatments";
            this.treatmentsBindingSource.DataSource = this.animalsBindingSource;
            this.treatmentsBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.treatmentsBindingSource_AddingNew);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.panel5.Controls.Add(this.btnRestoreTreatment);
            this.panel5.Controls.Add(this.btnDeleteTreatment);
            this.panel5.Controls.Add(this.btnEditTreatment);
            this.panel5.Controls.Add(this.btnNewTreatment);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(974, 30);
            this.panel5.TabIndex = 4;
            // 
            // btnRestoreTreatment
            // 
            this.btnRestoreTreatment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestoreTreatment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRestoreTreatment.Image = global::VetExample.Properties.Resources.Recover_Deleted_Items;
            this.btnRestoreTreatment.Location = new System.Drawing.Point(945, 4);
            this.btnRestoreTreatment.Name = "btnRestoreTreatment";
            this.btnRestoreTreatment.Size = new System.Drawing.Size(22, 22);
            this.btnRestoreTreatment.TabIndex = 3;
            this.btnRestoreTreatment.UseVisualStyleBackColor = true;
            this.btnRestoreTreatment.Click += new System.EventHandler(this.btnRestoreTreatment_Click);
            // 
            // btnDeleteTreatment
            // 
            this.btnDeleteTreatment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTreatment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDeleteTreatment.Image = global::VetExample.Properties.Resources.Report_Delete;
            this.btnDeleteTreatment.Location = new System.Drawing.Point(917, 4);
            this.btnDeleteTreatment.Name = "btnDeleteTreatment";
            this.btnDeleteTreatment.Size = new System.Drawing.Size(22, 22);
            this.btnDeleteTreatment.TabIndex = 2;
            this.btnDeleteTreatment.UseVisualStyleBackColor = true;
            this.btnDeleteTreatment.Click += new System.EventHandler(this.btnDeleteTreatment_Click);
            // 
            // btnEditTreatment
            // 
            this.btnEditTreatment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTreatment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditTreatment.Image = global::VetExample.Properties.Resources.Edit;
            this.btnEditTreatment.Location = new System.Drawing.Point(889, 4);
            this.btnEditTreatment.Name = "btnEditTreatment";
            this.btnEditTreatment.Size = new System.Drawing.Size(22, 22);
            this.btnEditTreatment.TabIndex = 1;
            this.btnEditTreatment.UseVisualStyleBackColor = true;
            this.btnEditTreatment.Click += new System.EventHandler(this.btnEditTreatment_Click);
            // 
            // btnNewTreatment
            // 
            this.btnNewTreatment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewTreatment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewTreatment.Image = global::VetExample.Properties.Resources.Item_New;
            this.btnNewTreatment.Location = new System.Drawing.Point(861, 4);
            this.btnNewTreatment.Name = "btnNewTreatment";
            this.btnNewTreatment.Size = new System.Drawing.Size(22, 22);
            this.btnNewTreatment.TabIndex = 0;
            this.btnNewTreatment.UseVisualStyleBackColor = true;
            this.btnNewTreatment.Click += new System.EventHandler(this.btnNewTreatment_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.tcListDetail);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 91);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(988, 498);
            this.panel4.TabIndex = 3;
            // 
            // tcListDetail
            // 
            this.tcListDetail.Controls.Add(this.tpList);
            this.tcListDetail.Controls.Add(this.tpDetails);
            this.tcListDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcListDetail.Location = new System.Drawing.Point(0, 0);
            this.tcListDetail.Name = "tcListDetail";
            this.tcListDetail.SelectedIndex = 0;
            this.tcListDetail.Size = new System.Drawing.Size(988, 498);
            this.tcListDetail.TabIndex = 0;
            // 
            // tpList
            // 
            this.tpList.Controls.Add(this.dgvCustomers);
            this.tpList.Location = new System.Drawing.Point(4, 22);
            this.tpList.Name = "tpList";
            this.tpList.Padding = new System.Windows.Forms.Padding(3);
            this.tpList.Size = new System.Drawing.Size(980, 472);
            this.tpList.TabIndex = 0;
            this.tpList.Text = "Customers";
            this.tpList.UseVisualStyleBackColor = true;
            // 
            // dgvCustomers
            // 
            this.dgvCustomers.AllowUserToAddRows = false;
            this.dgvCustomers.AllowUserToDeleteRows = false;
            this.dgvCustomers.AutoGenerateColumns = false;
            this.dgvCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cUSTIDPKDataGridViewTextBoxColumn,
            this.cUSTNAMEDataGridViewTextBoxColumn,
            this.cUSTSURMANEDataGridViewTextBoxColumn,
            this.cUSTTELNUMDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.validityStartDateDataGridViewTextBoxColumn,
            this.validityEndDateDataGridViewTextBoxColumn,
            this.lastModifiedByDataGridViewTextBoxColumn,
            this.lastModifiedDateDataGridViewTextBoxColumn,
            this.deletedDateDataGridViewTextBoxColumn,
            this.lastModifiedByUserDataGridViewTextBoxColumn,
            this.tablePrefixDataGridViewTextBoxColumn,
            this.inTxnDataGridViewCheckBoxColumn,
            this.currentStateDataGridViewTextBoxColumn});
            this.dgvCustomers.DataSource = this.customerBindingSource;
            this.dgvCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomers.Location = new System.Drawing.Point(3, 3);
            this.dgvCustomers.MultiSelect = false;
            this.dgvCustomers.Name = "dgvCustomers";
            this.dgvCustomers.ReadOnly = true;
            this.dgvCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomers.Size = new System.Drawing.Size(974, 466);
            this.dgvCustomers.TabIndex = 0;
            this.dgvCustomers.Click += new System.EventHandler(this.dgvCustomers_Click);
            this.dgvCustomers.DoubleClick += new System.EventHandler(this.dgvCustomers_DoubleClick);
            // 
            // cUSTIDPKDataGridViewTextBoxColumn
            // 
            this.cUSTIDPKDataGridViewTextBoxColumn.DataPropertyName = "CUST_ID_PK";
            this.cUSTIDPKDataGridViewTextBoxColumn.HeaderText = "CUST_ID_PK";
            this.cUSTIDPKDataGridViewTextBoxColumn.Name = "cUSTIDPKDataGridViewTextBoxColumn";
            this.cUSTIDPKDataGridViewTextBoxColumn.ReadOnly = true;
            this.cUSTIDPKDataGridViewTextBoxColumn.Visible = false;
            // 
            // cUSTNAMEDataGridViewTextBoxColumn
            // 
            this.cUSTNAMEDataGridViewTextBoxColumn.DataPropertyName = "CUST_NAME";
            this.cUSTNAMEDataGridViewTextBoxColumn.HeaderText = "Name";
            this.cUSTNAMEDataGridViewTextBoxColumn.Name = "cUSTNAMEDataGridViewTextBoxColumn";
            this.cUSTNAMEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cUSTSURMANEDataGridViewTextBoxColumn
            // 
            this.cUSTSURMANEDataGridViewTextBoxColumn.DataPropertyName = "CUST_SURMANE";
            this.cUSTSURMANEDataGridViewTextBoxColumn.HeaderText = "Surname";
            this.cUSTSURMANEDataGridViewTextBoxColumn.Name = "cUSTSURMANEDataGridViewTextBoxColumn";
            this.cUSTSURMANEDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cUSTTELNUMDataGridViewTextBoxColumn
            // 
            this.cUSTTELNUMDataGridViewTextBoxColumn.DataPropertyName = "CUST_TEL_NUM";
            this.cUSTTELNUMDataGridViewTextBoxColumn.HeaderText = "Phone";
            this.cUSTTELNUMDataGridViewTextBoxColumn.Name = "cUSTTELNUMDataGridViewTextBoxColumn";
            this.cUSTTELNUMDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            this.descriptionDataGridViewTextBoxColumn.Visible = false;
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
            // tpDetails
            // 
            this.tpDetails.Controls.Add(this.splitContainer1);
            this.tpDetails.Location = new System.Drawing.Point(4, 22);
            this.tpDetails.Name = "tpDetails";
            this.tpDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tpDetails.Size = new System.Drawing.Size(980, 472);
            this.tpDetails.TabIndex = 1;
            this.tpDetails.Text = "Details";
            this.tpDetails.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTreatmentType);
            this.groupBox1.Controls.Add(this.btnAnimalType);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.ForeColor = System.Drawing.Color.Teal;
            this.groupBox1.Location = new System.Drawing.Point(567, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 91);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Manage Tipologic";
            // 
            // btnTreatmentType
            // 
            this.btnTreatmentType.ForeColor = System.Drawing.Color.Black;
            this.btnTreatmentType.Image = global::VetExample.Properties.Resources.Caduceus;
            this.btnTreatmentType.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnTreatmentType.Location = new System.Drawing.Point(94, 19);
            this.btnTreatmentType.Name = "btnTreatmentType";
            this.btnTreatmentType.Size = new System.Drawing.Size(65, 65);
            this.btnTreatmentType.TabIndex = 7;
            this.btnTreatmentType.Text = "Treatment Type";
            this.btnTreatmentType.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTreatmentType.UseVisualStyleBackColor = true;
            this.btnTreatmentType.Click += new System.EventHandler(this.btnTreatmentType_Click);
            // 
            // btnAnimalType
            // 
            this.btnAnimalType.ForeColor = System.Drawing.Color.Black;
            this.btnAnimalType.Image = global::VetExample.Properties.Resources.Dog;
            this.btnAnimalType.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAnimalType.Location = new System.Drawing.Point(19, 19);
            this.btnAnimalType.Name = "btnAnimalType";
            this.btnAnimalType.Size = new System.Drawing.Size(65, 65);
            this.btnAnimalType.TabIndex = 6;
            this.btnAnimalType.Text = "Animal Type";
            this.btnAnimalType.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAnimalType.UseVisualStyleBackColor = true;
            this.btnAnimalType.Click += new System.EventHandler(this.btnAnimalType_Click);
            // 
            // frmCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(988, 611);
            this.Controls.Add(this.panel4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCustomers";
            this.Text = "Customers";
            this.Shown += new System.EventHandler(this.frmCustomers_Shown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel4, 0);
            this.panel1.ResumeLayout(false);
            this.gbEditing.ResumeLayout(false);
            this.gbNavigate.ResumeLayout(false);
            this.gbFilter.ResumeLayout(false);
            this.gbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbCustomer.ResumeLayout(false);
            this.gbCustomer.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalsBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTreatments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treatmentsBindingSource)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tcListDetail.ResumeLayout(false);
            this.tpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomers)).EndInit();
            this.tpDetails.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource customerBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn descrizioneDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label lPhone;
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lDeletedDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lLastModifiedDate;
        private System.Windows.Forms.Label lLastModifiedBy;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvAnimals;
        private System.Windows.Forms.BindingSource animalsBindingSource;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRestoreAnimal;
        private System.Windows.Forms.Button btnDeleteAnimal;
        private System.Windows.Forms.Button btnEditAnimal;
        private System.Windows.Forms.Button btnNewAnimal;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabControl tcListDetail;
        private System.Windows.Forms.TabPage tpList;
        private System.Windows.Forms.TabPage tpDetails;
        private System.Windows.Forms.DataGridView dgvCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTIDPKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTSURMANEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cUSTTELNUMDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn validityStartDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn validityEndDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedByDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deletedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedByUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tablePrefixDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn inTxnDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentStateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnRestoreTreatment;
        private System.Windows.Forms.Button btnDeleteTreatment;
        private System.Windows.Forms.Button btnEditTreatment;
        private System.Windows.Forms.Button btnNewTreatment;
        private System.Windows.Forms.DataGridView dgvTreatments;
        private System.Windows.Forms.BindingSource treatmentsBindingSource;
        private System.Windows.Forms.MaskedTextBox tbValidityEndDate;
        private System.Windows.Forms.MaskedTextBox tbValidityStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNIMIDPKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNIMCUSTIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNIMNAMEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNIMANMTIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn animalTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn aNIMBIRTHDATEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn validityStartDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn validityEndDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedByDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn deletedDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedByUserDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tablePrefixDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn inTxnDataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentStateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn tREAANIMIDPKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn animalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tREATRETIDPKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn treatmentTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tREATREATDATEPKDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tREAPERFORMEDBYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn treatmentPerformedByUserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tREANOTEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn validityStartDateDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn validityEndDateDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedByDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedDateDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn deletedDateDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastModifiedByUserDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn tablePrefixDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn inTxnDataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn currentStateDataGridViewTextBoxColumn2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Button btnTreatmentType;
        public System.Windows.Forms.Button btnAnimalType;
    }
}
